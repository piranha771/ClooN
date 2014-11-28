namespace ClooN.Functions
{
    internal class SubtractImpl : Module {
        private SubtractImpl(Module ls, Module rs) {
            genCode(ls, rs);
        }

        public static Module ValueOf(Module ls, Module rs) {
            return new SubtractImpl(ls, rs);
        }

        private void genCode(Module ls, Module rs) {
            code = "("+ls.Code + " - " + rs.Code+")";
        }
    }
}
