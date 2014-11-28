namespace ClooN.Functions
{
    internal class AddImpl : Module {
        private AddImpl(Module ls, Module rs) {
            genCode(ls.Code, rs.Code);
        }

        public static Module ValueOf(Module ls, Module rs) {
            return new AddImpl(ls, rs);
        }

        private void genCode(string ls, string rs) {
            code = "("+ls + " + " + rs+")";
        }
    }
}
