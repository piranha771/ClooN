using System.Globalization;

namespace ClooN.Functions
{
    internal class FractalBrownianMotionImpl : NoiseModule {

        private FractalBrownianMotionImpl(int octaves, NoiseModule frequency, NoiseModule lacunarity, NoiseModule persistence)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = "";
            nfi.NumberDecimalSeparator = ".";

            genCode(octaves.ToString(nfi), frequency.Code, lacunarity.Code, persistence.Code);
        }

        public static NoiseModule ValueOf(int octaves, NoiseModule frequency, NoiseModule lacunarity, NoiseModule persistence)
        {
            return new FractalBrownianMotionImpl(octaves, frequency, lacunarity, persistence);
        }

        private void genCode(string octaves, string frequency, string lacunarity, string persistence) {
            code = "fractalBrownianMotion(in_pos," + octaves + "," + frequency + "," + lacunarity + "," + persistence + ", perm)";
        }
    }
}
