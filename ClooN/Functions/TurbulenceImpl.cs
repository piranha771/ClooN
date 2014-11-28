using System.Globalization;

namespace ClooN.Functions
{
    internal class TurbulenceImpl : Module {

        private TurbulenceImpl(int octaves, float frequency, float lacunarity, float gain) {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = "";
            nfi.NumberDecimalSeparator = ".";

            genCode(octaves.ToString(nfi), frequency.ToString(Noise.NI, nfi), lacunarity.ToString(Noise.NI, nfi), gain.ToString(Noise.NI, nfi));
        }

        public static Module ValueOf(int octaves, float frequency, float lacunarity, float gain) {
            return new TurbulenceImpl(octaves, frequency, lacunarity, gain);
        }

        private void genCode(string octaves, string frequency, string lacunarity, string gain) {
            code = "turbulence(in_pos," + octaves + "," + frequency + "," + lacunarity + "," + gain + ", perm)";
        }
    }
}
