using Antlr4.Runtime;
using MathLib.Api.Base;
using MathLib.Utils.obj.Debug.netstandard2._0;
using MathLib.Utils.Parser.Visitor;

namespace MathLib.Utils.Parser
{
    public static class UParser
    {
        public static Function Parse(string formula)
        {
            var formulaObj = new CalculatorVisitor().Visit(
                new CalculatorParser(new CommonTokenStream(
                    new CalculatorLexer(new AntlrInputStream(formula)))).prog());

            return formulaObj;
        }
    }
}