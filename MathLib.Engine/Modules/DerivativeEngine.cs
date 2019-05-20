using System.Diagnostics;
using System.Xml.Schema;
using MathLib.Engine.Model;
using MathLib.Utils.Parser;
using MathNet.Symbolics;

namespace MathLib.Engine.Modules
{
    public class DerivativeEngine : IEngine
    {
        private readonly IParser _mathParser;

        public DerivativeEngine() { }

        public DerivativeEngine(IParser mathParser)
        {
            this._mathParser = mathParser;
        }

        public OperationResult Evaluate(string function)
        {
            var parsedFunction = _mathParser.Parse(function);
            var derivativeFunction = parsedFunction.Derivative();

            var source = Trigonometric.Simplify(Infix.ParseOrThrow(parsedFunction.ToString()));
            var derivative = Trigonometric.Simplify(Infix.ParseOrThrow(derivativeFunction.ToString()));
            var latex = LaTeX.Format(source);
            
            return new OperationResult
            {
                SimpleExpression = derivative.ToString(),
                LatexExpression = latex
            };
        }
    }
}