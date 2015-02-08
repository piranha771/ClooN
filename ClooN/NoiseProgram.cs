using System;
using System.Collections.Generic;
using Cloo;
using RndXorshift;
using ClooN.Functions;
using ClooN.Properties;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClooN
{
    /// <summary>
    /// Noise programm to generate noise on gpu
    /// </summary>
    public sealed class NoiseProgram : IDisposable
    {

        private bool disposed = false;

        private const int PermSize = 256;

        private ComputeContext context;
        private ComputeKernel kernelExplicit;
        private ComputeKernel kernelImplicit;

        private ComputeBuffer<int> permutationBuffer;
        private ComputeBuffer<float> outputBuffer;
        private ComputeCommandQueue queue;

        private NoiseModule module;
        private int[] permutationTable = new int[PermSize];

        private int lastLength;

        private string completeSource;

        private int seed;

        /// <summary>
        /// Sets the initial state for the random generator.
        /// Same seeds will result in the same noise.
        /// This behavior is not guaranteed over different versions!
        /// </summary>
        public int Seed
        {
            get
            {
                return seed;
            }
            set
            {
                seed = value;
                setupPermutationBuffer();
            }
        }
        

        /// <summary>
        /// Contains the complete sourcecode that is compiled and processed by the ClDevice
        /// </summary>
        public string CompleteSource
        {
            get { return completeSource; }
        }

        /// <summary>
        /// Creates a new noise program that uses a noisemodule
        /// </summary>
        /// <param name="module"></param>
        public NoiseProgram(NoiseModule module)
        {
            this.module = (NoiseModule)module;
        }

        /// <summary>
        /// Compiles the OpenCL program on the first availble platform
        /// </summary>
        public void Compile()
        {
            Compile(ComputePlatform.Platforms[0]);
        }

        /// <summary>
        /// Compiles the OpenCL program on the first availble platform
        /// </summary>
        /// <param name="platform">The platform to run this program on</param>
        public void Compile(ComputePlatform platform) {
            
            if (context != null) return;

            // Creating context on platform
            context = new ComputeContext(ComputeDeviceTypes.All, new ComputeContextPropertyList(platform), null, IntPtr.Zero); // CPU Fallback?

            // Reading the static source file
            string include = Resources.noise;

            // Stub
            string stub =
            @"
            __kernel void cl_main(__global Single3 *input, __global int *perm, __global float *output) { 
                int index = get_global_id(0);
                Single3 in_pos = input[index];      
                output[index] = "+ module.Code + @";
            }

            __kernel void cl_main_range(ImplicitCube cube, __global int *perm, __global float *output) {
                int index = get_global_id(0) + cube.lengthX * (get_global_id(1) + cube.lengthZ * get_global_id(2)) ;
                Single3 in_pos = { cube.startX + get_global_id(0) * cube.offsetX, cube.startY + get_global_id(1) * cube.offsetY, cube.startZ + get_global_id(2) * cube.offsetZ };
                output[index] = " + module.Code + @";
            }";
            completeSource = include + stub;

            ComputeProgram program = new ComputeProgram(context, completeSource);
            try
            {
                program.Build(context.Platform.Devices, null, null, IntPtr.Zero);
            }
            catch 
            {
                // TODO: Replace this nasty exception re-throwing
                throw new Exception(program.GetBuildLog(program.Devices[0]));
            }

            kernelExplicit = program.CreateKernel("cl_main");
            kernelImplicit = program.CreateKernel("cl_main_range");

            setupPermutationBuffer();
            queue = new ComputeCommandQueue(context, context.Devices[0], ComputeCommandQueueFlags.None);
        }

        /// <summary>
        /// Gets the values for an explicit input
        /// </summary>
        /// <param name="input">The explicit input</param>
        /// <param name="output">The output values</param>
        public void GetValues(Single3[] input, ref float[] output)
        {
            if (context == null || kernelExplicit == null) throw new Exception("Compile first!");

            int inputLength = input.Length;

            // IO length changed
            if (lastLength != inputLength)
            {
                lastLength = inputLength;
                outputBuffer = new Cloo.ComputeBuffer<float>(context, ComputeMemoryFlags.WriteOnly | ComputeMemoryFlags.AllocateHostPointer, inputLength);
                kernelExplicit.SetMemoryArgument(2, outputBuffer);
            }

            // Setup IO Buffers
            ComputeBuffer<Single3> bufIn = new Cloo.ComputeBuffer<Single3>(context, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.CopyHostPointer, input);

            // Arrange params
            kernelExplicit.SetMemoryArgument(0, bufIn);

            // Exec and read
            queue.Execute(kernelExplicit, null, new long[] { input.Length }, null, null);
            GCHandle outHandle = GCHandle.Alloc(output, GCHandleType.Pinned);
            queue.Read<float>(outputBuffer, true, 0, inputLength, outHandle.AddrOfPinnedObject(), null); // Read saves about 500 - 1000 ticks. Sweet for small queues
            outHandle.Free();

            queue.Finish();
        }

        /// <summary>
        /// Gets the values for an implicit input
        /// </summary>
        /// <param name="input">The implicit input</param>
        /// <param name="output">The implicit values</param>
        public void GetValues(ref ImplicitCube input, ref float[] output)
        {
            if (context == null || kernelImplicit == null) throw new Exception("Compile first!");

            int inputLength = input.ValueCount;

            // IO length changed
            if (lastLength != inputLength)
            {
                lastLength = inputLength;
                outputBuffer = new Cloo.ComputeBuffer<float>(context, ComputeMemoryFlags.WriteOnly | ComputeMemoryFlags.AllocateHostPointer, inputLength);
                kernelImplicit.SetMemoryArgument(2, outputBuffer);
            }

            // Arrange input param
            kernelImplicit.SetValueArgument<ImplicitCube>(0, input);           
            
            // Exec and read
            queue.Execute(kernelImplicit, null, new long[] { input.LengthX, input.LengthY, input.LengthZ }, null, null);
            GCHandle outHandle = GCHandle.Alloc(output, GCHandleType.Pinned); 
            queue.Read<float>(outputBuffer, true, 0, inputLength, outHandle.AddrOfPinnedObject(), null); // Read saves about 500 - 1000 ticks. Sweet for small queues
            outHandle.Free();

            queue.Finish();
        }

        private void setupPermutationBuffer() 
        {        
            if (context != null) {
                generatePermutation(seed);
                permutationBuffer = new Cloo.ComputeBuffer<int>(context, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.CopyHostPointer, permutationTable);
                kernelExplicit.SetMemoryArgument(1, permutationBuffer); 
                kernelImplicit.SetMemoryArgument(1, permutationBuffer);  
            }             
        }

        /// <summary>
        /// Creates random permutationTable array, random values have no duplicates and are not higher than array length
        /// </summary>
        /// <param name="seed">initial state for the random generator</param>
        private void generatePermutation(int seed) {
            Rnd random = new Rnd(seed);

            List<int> permList = new List<int>(PermSize);
            for (int i = 0; i < PermSize; i++) permList.Add(i);

            for (int i = 0; i < PermSize; i++)
            {
                int index = random.Next(0, permList.Count);
                permutationTable[i] = permList[index];
                permList.RemoveAt(index);
            }
        }

        /// <summary>
        /// Disposes the OpenCL context
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                context.Dispose();
            }

            disposed = true;
        }
    }
}
