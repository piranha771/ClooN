namespace ClooN.Functions
{
    internal class SubtractImpl : NoiseModule {
        private SubtractImpl(NoiseModule ls, NoiseModule rs) {
            genCode(ls, rs);
        }

        public static NoiseModule ValueOf(NoiseModule ls, NoiseModule rs) {
            return new SubtractImpl(ls, rs);
        }

        private void genCode(NoiseModule ls, NoiseModule rs) {
            code = "("+ls.Code + " - " + rs.Code+")";
        }
    }
}
