
namespace ClooN.Functions
{
    internal class RoundImpl : Module {
        private RoundImpl(Module module) {
            genCode(module.Code);
        }

        public static Module ValueOf(Module module) {
            return new RoundImpl(module);
        }

        private void genCode(string moduleCode) {
            code = "round("+moduleCode+")";
        }
    }
}
