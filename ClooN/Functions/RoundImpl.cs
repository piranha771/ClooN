
namespace ClooN.Functions
{
    internal class RoundImpl : NoiseModule {
        private RoundImpl(NoiseModule module) {
            genCode(module.Code);
        }

        public static NoiseModule ValueOf(NoiseModule module) {
            return new RoundImpl(module);
        }

        private void genCode(string moduleCode) {
            code = "round("+moduleCode+")";
        }
    }
}
