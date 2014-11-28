using System.Globalization;

namespace ClooN.Functions
{
    internal class RidgedMultifractalImpl : Module {

        private RidgedMultifractalImpl(int octaves, float frequency, float lacunarity, float gain, float offset) {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = "";
            nfi.NumberDecimalSeparator = ".";


            genCode(octaves.ToString(nfi), frequency.ToString(Noise.NI, nfi), lacunarity.ToString(Noise.NI, nfi), gain.ToString(Noise.NI, nfi), offset.ToString(Noise.NI, nfi));

        }

        public static Module ValueOf(int octaves, float frequency, float lacunarity, float gain, float offset) {
            return new RidgedMultifractalImpl(octaves, frequency, lacunarity, gain, offset);
        }

        private void genCode(string octaves, string frequency, string lacunarity, string gain, string offset) {
            code = "ridgedMultifractal(in_pos," + octaves + "," + frequency + "," + lacunarity + "," + gain + "," + offset + ", perm)";

        }
        
    }
}
