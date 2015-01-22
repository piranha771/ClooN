
namespace ClooN.Functions
{
    internal class PowerImpl : NoiseModule {
        private PowerImpl(NoiseModule basis, NoiseModule exponent) {
            genCode(basis.Code, exponent.Code);
        }

        public static NoiseModule ValueOf(NoiseModule basis, NoiseModule exponent) {
            return new PowerImpl(basis, exponent);
        }

        private void genCode(string basisCode, string exponentCode) {
            code = "pow(fabs(" + basisCode + ")," + exponentCode + ")";
        }
    }
}
