using MathLib.Api.Model.Base;
using MathLib.Utils.Parser;

namespace MathLib.Engine.Modules
{
    public class IntegralEngine
    {
        public IntegralEngine() { }

        public string Evaluate(string function)
        {
            var parsedFunction = UParser.Parse(function);
            return parsedFunction.Integrate().Print();
        }
    }
}