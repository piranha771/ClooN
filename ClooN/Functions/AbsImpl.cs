
namespace ClooN.Functions
{
    internal class AbsImpl : Module {
        private AbsImpl(Module module) {
            genCode(module.Code);
        }

        public static Module ValueOf(Module module)
        {
            return new AbsImpl(module);
        }

        private void genCode(string moduleCode) {
            code = "abs("+moduleCode+")";
        }
    }
}
