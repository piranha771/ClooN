using ClooN;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ClooNEditor
{
    class ModuleCompiler
    {
        private NoiseModule lastSuccessful;
        private string lastValidCode;
        private string errorMessage;

        public NoiseModule LastSuccessful
        {
            get { return lastSuccessful; }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
        }

        public string LastValidCode
        {
            get { return lastValidCode; }
        }

        public bool Compile(string code)
        {
            if (string.IsNullOrEmpty(code.Trim()))
            {
                errorMessage = "Empty Module";
                return false;
            }

            return CreateModule(RemoveShorts(code));
        }

        private string RemoveShorts(string code)
        {
            string result = code;

            result = Regex.Replace(result, "fbm\\(", "Noise.FractalBrownianMotion(", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "rmf\\(", "Noise.RidgedMultifractal(", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "turbu\\(", "Noise.Turbulence(", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "voro\\(", "Noise.Voronoi(", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "abs\\(", "Noise.Abs(", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "lerp\\(", "Noise.Lerp(", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "min\\(", "Noise.Min(", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "max\\(", "Noise.Max(", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "pow\\(", "Noise.Power(", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "rnd\\(", "Noise.Round(", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "step\\(", "Noise.Step(", RegexOptions.IgnoreCase);

            result = Regex.Replace(result, "(,|\\s)Cell", "VoronoiType.Cell", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "(,|\\s)F1", "VoronoiType.F1", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "(,|\\s)F2(\\s|\\))", "VoronoiType.F2", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "(,|\\s)F3", "VoronoiType.F3", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, "(,|\\s)F2F1", "VoronoiType.F2F1", RegexOptions.IgnoreCase);

            return result;
        }

        private bool CreateModule(string moduleCode)
        {
            string code =
@"using System; 
using ClooN; 
namespace Stub 
{ 
    public class StubClass 
    { 
        public static NoiseModule ModuleMaker() 
        { 
            return
" + moduleCode + @";
        }
    }
}";

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();
            parameters.ReferencedAssemblies.Add("ClooN.dll");
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;

            CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);

            if (results.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();

                foreach (CompilerError error in results.Errors)
                {
                    sb.AppendLine(String.Format("Error : {2}", error.Line-9, error.Column, error.ErrorText));
                }

                errorMessage = sb.ToString();

                return false;
            }
            else
            {
                MethodInfo info = results.CompiledAssembly.GetType("Stub.StubClass").GetMethod("ModuleMaker");

                lastSuccessful = ((Func<NoiseModule>)Delegate.CreateDelegate(typeof(Func<NoiseModule>), info))();
                lastValidCode = moduleCode;

                return true;
            }
        }


    }
}
