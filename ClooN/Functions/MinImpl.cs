
namespace ClooN.Functions
{
    internal class MinImpl : Module {
        private MinImpl(Module module1, Module module2) {
            genCode(module1.Code, module2.Code);
        }

        public static Module ValueOf(Module module1, Module module2) {
            return new MinImpl(module1, module2);
        }

        private void genCode(string module1, string module2) {
            code = "min("+module1+","+module2+")";
        }


    }
}
