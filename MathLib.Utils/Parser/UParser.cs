using Antlr4.Runtime;
using MathLib.Api.Model.Base;
using MathLib.Utils.Parser.Grammar;
using MathLib.Utils.Parser.Visitor;

namespace MathLib.Utils.Parser
{
    public class UParser
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