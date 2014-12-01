using System;
using System.Collections.Generic;
using Cloo;
using RndXorshift;
using ClooN.Functions;
using ClooN.Properties;

namespace ClooN
{
    /// <summary>
    /// Noise programm to generate noise on gpu
    /// </summary>
    public sealed class NoiseProgram : IDisposable
    {

        private bool disposed = false;
        private object sync = new object();

        private const int PermSize = 256;

        private ComputeContext context;
        private ComputeKernel kernel;

        private Module module;
        private int[] permutation;
        private int lastSeed;

        private string completeSource;

        public string CompleteSource
        {
            get { return completeSource; }
        }

        public NoiseProgram(IModule module)
        {
            this.module = (Module)module;
        }

        /// <summary>
        /// Compiles the computer shader
        /// </summary>
        public void Compile()
        {
            Compile(ComputePlatform.Platforms[0]);
        }

        /// <summary>
        /// Compiles the computer shader
        /// </summary>
        public void Compile(ComputePlatform platform) {
            
            if (context != null) return;

            // Creating context on platform
            context = new ComputeContext(ComputeDeviceTypes.Gpu, new ComputeContextPropertyList(platform), null, IntPtr.Zero); // CPU Fallback?

            // Reading the static source file
            string include = Resources.noise;

            // Stub
            string stub =
            @"
            __kernel void cl_main(__global Single3 *input, __global int *perm, __global float *output) { 
                int index = get_global_id(0);
                Single3 in_pos = input[index];      
                output[index] = "+ module.Code +@";
            }";

            completeSource = include + stub;

            ComputeProgram program = new ComputeProgram(context, completeSource);
            program.Build(context.Platform.Devices, null, null, IntPtr.Zero);
            kernel = program.CreateKernel("cl_main");
        }

        /// <summary>
        /// Computes noise values for given vectors
        /// </summary>
        /// <param name="input">3d input vector/param>
        /// <returns>Noise results</returns>
        public float[] GetValues(Single3[] input, int seed) {

            lock (sync)
            {
                if (context == null || kernel == null) throw new Exception("Compile first!");


                int inputLength = input.Length;
                float[] output = new float[inputLength];

                // Setup perm buffer
                // .. if not exists for this seed
                if (permutation == null || lastSeed != seed)
                {
                    generatePermutation(PermSize, seed);
                    lastSeed = seed;
                }

                // Setup IO Buffers
                Cloo.ComputeBuffer<Single3> bufIn = new Cloo.ComputeBuffer<Single3>(context, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.CopyHostPointer, input);
                Cloo.ComputeBuffer<int> bufPerm = new Cloo.ComputeBuffer<int>(context, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.CopyHostPointer, permutation);
                Cloo.ComputeBuffer<float> bufOut = new Cloo.ComputeBuffer<float>(context, ComputeMemoryFlags.WriteOnly, output.Length);
                // Arrange params
                kernel.SetMemoryArgument(0, bufIn);
                kernel.SetMemoryArgument(1, bufPerm);
                kernel.SetMemoryArgument(2, bufOut);
                // Setup command
                ComputeEventList event_list = new ComputeEventList();
                ComputeCommandQueue commands = new ComputeCommandQueue(context, context.Devices[0], ComputeCommandQueueFlags.None);
                // Exec and read
                commands.Execute(kernel, null, new long[] { input.Length }, null, event_list);
                commands.ReadFromBuffer(bufOut, ref output, false, event_list);
                commands.Finish();

                return output;
            }
        }


        /// <summary>
        /// Creates random permutation array, random values have no duplicates and are not higher than array length
        /// </summary>
        /// <param name="size">size of permutation array</param>
        private void generatePermutation(int size, int seed) {
            permutation = new int[size];
            Rnd random = new Rnd(seed);

            List<int> permList = new List<int>(size);
            for (int i = 0; i < size; i++) permList.Add(i);

            for (int i = 0; i < size; i++)
            {
                int index = random.Next(0, permList.Count);
                permutation[i] = permList[index];
                permList.RemoveAt(index);
            }
        }

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
