
namespace ClooN.Functions
{
    internal class LerpImpl : NoiseModule {
        private LerpImpl(NoiseModule min, NoiseModule max, NoiseModule interpolant) {
            genCode(min.Code, max.Code, interpolant.Code);
        }

        public static NoiseModule ValueOf(NoiseModule min, NoiseModule max, NoiseModule interpolant) {
            return new LerpImpl(min, max, interpolant);
        }

        private void genCode(string moduleMinCode, string moduleMaxCode, string moduleInterpolantCode) {
            code = "mix("+moduleMinCode+","+moduleMaxCode+","+moduleInterpolantCode+")";
        }
    }
}
