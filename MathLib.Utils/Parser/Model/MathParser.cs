using System.Runtime.InteropServices;
using Antlr4.Runtime;
using MathLib.Api.Base;
using MathLib.Utils.Parser.Grammar;
using MathLib.Utils.Parser.Visitor;

namespace MathLib.Utils.Parser.Model
{
    public class MathParser : IParser
    {
        public Function Parse(string formula)
        {
            var formulaObj = new MathVisitor().Visit(
                new Grammar.MathParser(new CommonTokenStream(
                    new MathLexer(new AntlrInputStream(formula)))).prog());

            return formulaObj;
        }
    }
}