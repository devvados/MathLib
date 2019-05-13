using MathLib.Engine.Model;
using MathLib.Utils.Parser;

namespace MathLib.Engine.Modules
{
    public class DerivativeEngine : IEngine
    {
        private readonly IParser _mathParser;
        public DerivativeEngine(IParser mathParser)
        {
            this._mathParser = mathParser;
        }

        public OperationResult Evaluate(string function)
        {
            var parsedFunction = _mathParser.Parse(function);
            var derivativeFunction = parsedFunction.Derivative();

            return new OperationResult
            {
                SimpleExpression = derivativeFunction.ToString(),
                LatexExpression = derivativeFunction.Print()
            };
        }
    }
}