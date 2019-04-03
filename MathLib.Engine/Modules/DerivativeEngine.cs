using System;
using MathLib.Utils.Parser;

namespace MathLib.Engine.Modules
{
    public class DerivativeEngine
    {
        public DerivativeEngine() { }

        public ExpressionResponse Evaluate(string function)
        {
            var parsedFunction = UParser.Parse(function);
            var derivativeFunction = parsedFunction.Derivative();
            
            return new ExpressionResponse(derivativeFunction.ToString(), derivativeFunction.Print());
        }
    }
}