using ClooN.Functions;

namespace ClooN
{
    /// <summary>
    /// Utility Class for Noise compositions
    /// </summary>
    public static class Noise {

        internal static string NI = "0.0###############";

        public static IModule FractalBrownianMotion(int octaves, float frequency, float lacunarity, float persistence) {
            return FractalBrownianMotionImpl.ValueOf(octaves, frequency, lacunarity, persistence);
        }

        public static IModule RidgedMultifractal(int octaves, float frequency, float lacunarity, float gain, float offset) {
            return RidgedMultifractalImpl.ValueOf(octaves, frequency, lacunarity, gain, offset);
        }

        public static IModule Turbulence(int octaves, float frequency, float lacunarity, float gain) {
            return TurbulenceImpl.ValueOf(octaves, frequency, lacunarity, gain);
        }

        public static IModule Voronoi(float frequency, VoronoiType type) {
            return VoronoiImpl.ValueOf(frequency, type);
        }

        /// -- OPS

        public static IModule Abs(IModule module)
        {
            return AbsImpl.ValueOf((Module)module);
        }

        public static IModule Lerp(IModule min, IModule max, IModule interpoliant)
        {
            return LerpImpl.ValueOf((Module)min, (Module)max, (Module)interpoliant);
        }

        public static IModule Min(IModule module1, IModule module2)
        {
            return MinImpl.ValueOf((Module)module1, (Module)module2);
        }

        public static IModule Max(IModule module1, IModule module2)
        {
            return MaxImpl.ValueOf((Module)module1, (Module)module2);
        }

        public static IModule Power(IModule basis, IModule exponent)
        {
            return PowerImpl.ValueOf((Module)basis, (Module)exponent);
        }
    }
}
