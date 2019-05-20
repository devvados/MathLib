using System.Diagnostics;
using System.Xml.Schema;
using MathLib.Engine.Model;
using MathLib.Utils.Parser;
using MathLib.Utils.Parser.Model;
using MathNet.Symbolics;

namespace MathLib.Engine.Modules
{
    public class DerivativeEngine : IEngine
    {
        private readonly IParser _mathParser;

        public DerivativeEngine()
        {
            _mathParser = new MathParser();
        }

        public OperationResult Evaluate(string function)
        {
            var parsedFunction = _mathParser.Parse(function);
            var derivativeFunction = parsedFunction.Derivative();

            var simplifiedSourceFunction = Trigonometric.Simplify(Infix.ParseOrThrow(parsedFunction.ToString()));
            var simplifiedDerivativeFunction = Trigonometric.Simplify(Infix.ParseOrThrow(derivativeFunction.ToString()));

            var simplifiedDerivative = _mathParser.Parse(Infix.Format(simplifiedDerivativeFunction));
            var latexDerivative = LaTeX.Format(simplifiedDerivativeFunction);
            
            return new OperationResult
            {
                SimpleExpression = simplifiedDerivative.ToString(),
                LatexExpression = latexDerivative
            };
        }
    }
}