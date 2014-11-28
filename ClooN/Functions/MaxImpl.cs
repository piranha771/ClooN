
namespace ClooN.Functions
{
    internal class MaxImpl : Module {
        private MaxImpl(Module module1, Module module2) {
            genCode(module1.Code, module2.Code);
        }

        public static Module ValueOf(Module module1, Module module2) {
            return new MaxImpl(module1, module2);
        }

        private void genCode(string module1Code, string module2Code) {
            code = "max(" + module1Code + "," + module2Code + ")";
        }
    }
}
