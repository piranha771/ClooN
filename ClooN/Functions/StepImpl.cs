using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClooN.Functions
{
    class StepImpl : NoiseModule
    {
        private StepImpl(NoiseModule edge, NoiseModule value)
        {
            genCode(edge.Code, value.Code);
        }

        public static NoiseModule ValueOf(NoiseModule edge, NoiseModule value)
        {
            return new StepImpl(edge, value);
        }

        private void genCode(string edgeCode, string valueCode) {
            code = "step(" + edgeCode + ", " + valueCode + ")";
        }
    }
}
