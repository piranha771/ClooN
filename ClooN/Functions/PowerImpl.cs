
namespace ClooN.Functions
{
    internal class PowerImpl : Module {
        private PowerImpl(Module basis, Module exponent) {
            genCode(basis.Code, exponent.Code);
        }

        public static Module ValueOf(Module basis, Module exponent) {
            return new PowerImpl(basis, exponent);
        }

        private void genCode(string basisCode, string exponentCode) {
            code = "pow(abs(" + basisCode + ")," + exponentCode + ")";
        }
    }
}
