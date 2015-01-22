using System;
using System.Globalization;

namespace ClooN.Functions
{
    internal class VoronoiImpl : NoiseModule {

        private VoronoiImpl(NoiseModule frequency, VoronoiType type) {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = "";
            nfi.NumberDecimalSeparator = ".";

            genCode(frequency.Code, getVoronoiFunction(type));
        }

        public static NoiseModule ValueOf(NoiseModule frequency, VoronoiType type)
        {
            return new VoronoiImpl(frequency, type);
        }

        private void genCode(string frequency, string type) {
            code = type + "(perm, (float4)(in_pos.x * " + frequency + ", in_pos.y * " + frequency + ", in_pos.z * " + frequency + ", 0))";
        }

        private string getVoronoiFunction(VoronoiType type) {
            switch (type) {
                case VoronoiType.Cell:
                    return "voronoiCell";
                case VoronoiType.F1:
                    return "voronoiF1";
                case VoronoiType.F2:
                    return "voronoiF2";
                case VoronoiType.F3:
                    return "voronoiF3";
                case VoronoiType.F2F1:
                    return "voronoiF2F1";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
