using ClooN.Functions;

namespace ClooN
{
    /// <summary>
    /// Basic NoiseModule class
    /// </summary>
    public abstract class NoiseModule
    {
        protected string code;

        /// <summary>
        /// Contains the stub code for the OpenCL program
        /// </summary>
        public string Code { get { return code; } }

        public static NoiseModule operator +(NoiseModule ls, NoiseModule rs) {
            return AddImpl.ValueOf(ls, rs);
        }

        public static NoiseModule operator -(NoiseModule ls, NoiseModule rs) {
            return SubtractImpl.ValueOf(ls, rs);
        }

        public static NoiseModule operator *(NoiseModule ls, NoiseModule rs) {
            return MultiplyImpl.ValueOf(ls, rs);
        }

        public static NoiseModule operator /(NoiseModule ls, NoiseModule rs) {
            return DivideImpl.ValueOf(ls, rs);
        }

        public static implicit operator NoiseModule(float value) {
            return ConstantImpl.ValueOf(value);
        }

        public static implicit operator NoiseModule(double value)
        {
            return ConstantImpl.ValueOf((float)value);
        }
    }
}
