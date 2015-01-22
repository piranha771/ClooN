namespace ClooN.Functions
{
    internal class AddImpl : NoiseModule {
        private AddImpl(NoiseModule ls, NoiseModule rs) {
            genCode(ls.Code, rs.Code);
        }

        public static NoiseModule ValueOf(NoiseModule ls, NoiseModule rs) {
            return new AddImpl(ls, rs);
        }

        private void genCode(string ls, string rs) {
            code = "("+ ls + " + " + rs +")";
        }
    }
}
