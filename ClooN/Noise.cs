using ClooN.Functions;

namespace ClooN
{
    /// <summary>
    /// Utility Class for Noise compositions
    /// </summary>
    public static class Noise {

        internal static string NI = "0.0###############";

        /// <summary>
        /// Generates cloud style noise on multiple octaves. Single octaves create white noise looks.
        /// </summary>
        /// <param name="octaves">Number of layers</param>
        /// <param name="frequency">The scale of the noise</param>
        /// <param name="lacunarity">Multiplier for frequency for each octave</param>
        /// <param name="persistence">Multiplier for amplitude (value-range) for each octave</param>
        /// <returns>NoiseModule</returns>
        public static NoiseModule FractalBrownianMotion(int octaves, NoiseModule frequency, NoiseModule lacunarity, NoiseModule persistence)
        {
            return FractalBrownianMotionImpl.ValueOf(octaves, frequency, lacunarity, persistence);
        }

        /// <summary>
        /// Generates a dune style fractal. Multiple layers become like hard edge mountains.
        /// </summary>
        /// <param name="octaves">>Number of layers</param>
        /// <param name="frequency">The scale of the noise</param>
        /// <param name="lacunarity">Multiplier for frequency for each octave</param>
        /// <param name="persistence">Multiplier for amplitude (value-range) for each octave</param>
        /// <param name="offset">Desired offset as float or another module</param>
        /// <returns>NoiseModule</returns>
        public static NoiseModule RidgedMultifractal(int octaves, NoiseModule frequency, NoiseModule lacunarity, NoiseModule persistence, NoiseModule offset)
        {
            return RidgedMultifractalImpl.ValueOf(octaves, frequency, lacunarity, persistence, offset);
        }

        /// <summary>
        /// Generates tapeworm looking noise. Multiple layers shift, scale and blend additional tapeworms.
        /// </summary>
        /// <param name="octaves">>Number of layers</param>
        /// <param name="frequency">The scale of the noise</param>
        /// <param name="lacunarity">Desired lacunarity as float or another module</param>
        /// <param name="persistence">Desired gain as float or another module</param>
        /// <returns>NoiseModule</returns>
        public static NoiseModule Turbulence(int octaves, NoiseModule frequency, NoiseModule lacunarity, NoiseModule persistence)
        {
            return TurbulenceImpl.ValueOf(octaves, frequency, lacunarity, persistence);
        }

        /// <summary>
        /// Generates a mosaic pattern
        /// </summary>
        /// <param name="frequency">The scale of the noise</param>
        /// <param name="type">Type of Voronoi</param>
        /// <returns>NoiseModule</returns>
        public static NoiseModule Voronoi(NoiseModule frequency, VoronoiType type)
        {
            return VoronoiImpl.ValueOf(frequency, type);
        }

        // -- OPS

        /// <summary>
        /// Absolute value
        /// </summary>
        /// <param name="module">noisemodule</param>
        /// <returns>Absolute value</returns>
        public static NoiseModule Abs(NoiseModule module)
        {
            return AbsImpl.ValueOf(module);
        }

        /// <summary>
        /// Linear blend
        /// </summary>
        /// <param name="min">Minimum value as float or another module</param>
        /// <param name="max">Maximum value as float or another module</param>
        /// <param name="interpoliant"></param>
        /// <returns>Linear blend</returns>
        public static NoiseModule Lerp(NoiseModule min, NoiseModule max, NoiseModule interpoliant)
        {
            return LerpImpl.ValueOf(min, max, interpoliant);
        }

        /// <summary>
        /// Minimum of two
        /// </summary>
        /// <param name="module1">First Module</param>
        /// <param name="module2">Second Module</param>
        /// <returns>Minimum Module</returns>
        public static NoiseModule Min(NoiseModule module1, NoiseModule module2)
        {
            return MinImpl.ValueOf(module1, module2);
        }

        /// <summary>
        /// Maximum of two
        /// </summary>
        /// <param name="module1">First Module</param>
        /// <param name="module2">Second Module</param>
        /// <returns>Maximum Module</returns>
        public static NoiseModule Max(NoiseModule module1, NoiseModule module2)
        {
            return MaxImpl.ValueOf(module1, module2);
        }

        /// <summary>
        /// Compute basis to the power of exponent
        /// </summary>
        /// <param name="basis">Basis Module</param>
        /// <param name="exponent">Exponent Module</param>
        /// <returns>Exponential Module</returns>
        public static NoiseModule Power(NoiseModule basis, NoiseModule exponent)
        {
            return PowerImpl.ValueOf(basis, exponent);
        }

        /// <summary>
        /// Integral value nearest to module rounding
        /// </summary>
        /// <param name="module">Module to round up</param>
        /// <returns>Rounded module</returns>
        public static NoiseModule Round(NoiseModule module)
        {
            return RoundImpl.ValueOf(module);
        }

        /// <summary>
        /// If value is smaller than edge returns 0 else value
        /// </summary>
        /// <param name="edge">The edge all values equal or below it will result in 0</param>
        /// <param name="value">Value to get stepped</param>
        /// <returns>If value is smaller than edge returns 0 else value</returns>
        public static NoiseModule Step(NoiseModule edge, NoiseModule value)
        {
            return StepImpl.ValueOf(edge, value);
        }
    }
}
