using System;
using MathLib.Utils.Parser;

namespace MathLib.Engine.Modules
{
    public class DerivativeEngine : IEngine
    {
        public DerivativeEngine() { }

        public OperationResult Evaluate(string function)
        {
            var parsedFunction = UParser.Parse(function);
            var derivativeFunction = parsedFunction.Derivative();

            return new OperationResult
            {
                SimpleExpression = derivativeFunction.ToString(),
                LatexExpression = derivativeFunction.Print()
            };
        }
    }
}