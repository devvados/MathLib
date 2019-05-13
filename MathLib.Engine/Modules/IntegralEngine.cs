using MathLib.Utils.Parser;

namespace MathLib.Engine.Modules
{
    public class IntegralEngine
    {
        private readonly IParser _mathParser;
        public IntegralEngine(IParser mathParser)
        {
            this._mathParser = mathParser;
        }

        public string Evaluate(string function)
        {
            var parsedFunction = _mathParser.Parse(function);
            return parsedFunction.Integrate().Print();
        }
    }
}