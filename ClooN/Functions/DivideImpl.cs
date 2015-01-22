namespace ClooN.Functions
{
    internal class DivideImpl : NoiseModule {
        private DivideImpl(NoiseModule ls, NoiseModule rs) {
            genCode(ls.Code, rs.Code);
        }

        public static NoiseModule ValueOf(NoiseModule ls, NoiseModule rs) {
            return new DivideImpl(ls, rs);
        }

        private void genCode(string ls, string rs) {
            code = "("+ls + @" / " + rs+")";
        }
    }
}