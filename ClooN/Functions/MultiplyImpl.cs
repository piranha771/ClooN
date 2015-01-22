namespace ClooN.Functions
{
    internal class MultiplyImpl : NoiseModule {
        private MultiplyImpl(NoiseModule ls, NoiseModule rs) {
            genCode(ls, rs);
        }

        public static NoiseModule ValueOf(NoiseModule ls, NoiseModule rs) {
            return new MultiplyImpl(ls, rs);
        }

        private void genCode(NoiseModule ls, NoiseModule rs) {
            code = "("+ls.Code + " * " + rs.Code+")";
        }
    }
}
