
namespace ClooN.Functions
{
    internal class MinImpl : NoiseModule {
        private MinImpl(NoiseModule module1, NoiseModule module2) {
            genCode(module1.Code, module2.Code);
        }

        public static NoiseModule ValueOf(NoiseModule module1, NoiseModule module2) {
            return new MinImpl(module1, module2);
        }

        private void genCode(string module1, string module2) {
            code = "min("+module1+","+module2+")";
        }


    }
}
