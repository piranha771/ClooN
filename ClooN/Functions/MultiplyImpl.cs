namespace ClooN.Functions
{
    internal class MultiplyImpl : Module {
        private MultiplyImpl(Module ls, Module rs) {
            genCode(ls, rs);
        }

        public static Module ValueOf(Module ls, Module rs) {
            return new MultiplyImpl(ls, rs);
        }

        private void genCode(Module ls, Module rs) {
            code = "("+ls.Code + " * " + rs.Code+")";
        }
    }
}
