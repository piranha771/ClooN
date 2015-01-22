using System.Globalization;

namespace ClooN.Functions
{
    internal class RidgedMultifractalImpl : NoiseModule {

        private RidgedMultifractalImpl(int octaves, NoiseModule frequency, NoiseModule lacunarity, NoiseModule persistence, NoiseModule offset)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = "";
            nfi.NumberDecimalSeparator = ".";


            genCode(octaves.ToString(nfi), frequency.Code, lacunarity.Code, persistence.Code, offset.Code);

        }

        public static NoiseModule ValueOf(int octaves, NoiseModule frequency, NoiseModule lacunarity, NoiseModule persistence, NoiseModule offset)
        {
            return new RidgedMultifractalImpl(octaves, frequency, lacunarity, persistence, offset);
        }

        private void genCode(string octaves, string frequency, string lacunarity, string persistence, string offset)
        {
            code = "ridgedMultifractal(in_pos," + octaves + "," + frequency + "," + lacunarity + "," + persistence + "," + offset + ", perm)";

        }
        
    }
}
