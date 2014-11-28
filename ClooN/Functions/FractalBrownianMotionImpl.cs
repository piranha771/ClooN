using System.Globalization;

namespace ClooN.Functions
{
    internal class FractalBrownianMotionImpl : Module {
        
        private FractalBrownianMotionImpl(int octaves, float frequency, float lacunarity, float persistence) {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = "";
            nfi.NumberDecimalSeparator = ".";

            genCode(octaves.ToString(nfi), frequency.ToString(Noise.NI, nfi), lacunarity.ToString(Noise.NI, nfi), persistence.ToString(Noise.NI, nfi));
        }

        public static Module ValueOf(int octaves, float frequency, float lacunarity, float persistence) {
            return new FractalBrownianMotionImpl(octaves, frequency, lacunarity, persistence);
        }

        private void genCode(string octaves, string frequency, string lacunarity, string persistence) {
            code = "fractalBrownianMotion(in_pos," + octaves + "," + frequency + "," + lacunarity + "," + persistence + ", perm)";
        }
    }
}
