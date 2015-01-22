using System.Globalization;

namespace ClooN.Functions
{
    internal class ConstantImpl : NoiseModule {

        private ConstantImpl(float value) {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = "";
            nfi.NumberDecimalSeparator = ".";

            genCode(value.ToString(Noise.NI, nfi));
        }

        public static NoiseModule ValueOf(float value) {
            return new ConstantImpl(value);
        }

        private void genCode(string value) {
            code = value;
        }

    }

}
