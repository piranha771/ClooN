
namespace ClooN.Functions
{
    internal class AbsImpl : NoiseModule {
        private AbsImpl(NoiseModule module) {
            genCode(module.Code);
        }

        public static NoiseModule ValueOf(NoiseModule module)
        {
            return new AbsImpl(module);
        }

        private void genCode(string moduleCode) {
            code = "fabs("+moduleCode+")";
        }
    }
}
