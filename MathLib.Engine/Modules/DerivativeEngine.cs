using System;
using MathLib.Api.Model.Base;
using MathLib.Utils.Parser;

namespace MathLib.Engine.Modules
{
    public class DerivativeEngine
    {
        public DerivativeEngine() { }

        public string Evaluate(string function)
        {
            var parsedFunction = UParser.Parse(function);
            return parsedFunction.Derivative().Print();
        }
    }
}