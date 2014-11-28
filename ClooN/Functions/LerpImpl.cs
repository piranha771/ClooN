
namespace ClooN.Functions
{
    internal class LerpImpl : Module {
        private LerpImpl(Module min, Module max, Module interpolant) {
            genCode(min.Code, max.Code, interpolant.Code);
        }

        public static Module ValueOf(Module min, Module max, Module interpolant) {
            return new LerpImpl(min, max, interpolant);
        }

        private void genCode(string moduleMinCode, string moduleMaxCode, string moduleInterpolantCode) {
            code = "mix("+moduleMinCode+","+moduleMaxCode+","+moduleInterpolantCode+")";
        }
    }
}
