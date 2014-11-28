namespace ClooN.Functions
{
    internal class DivideImpl : Module {
        private DivideImpl(Module ls, Module rs) {
            genCode(ls.Code, rs.Code);
        }

        public static Module ValueOf(Module ls, Module rs) {
            return new DivideImpl(ls, rs);
        }

        private void genCode(string ls, string rs) {
            code = "("+ls + @" / " + rs+")";
        }
    }
}