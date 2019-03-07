using System;
using System.Collections.Generic;
using System.Globalization;
using MathLib.Api.Base;
using MathLib.Api.Functions;
using MathLib.Api.Functions.Elementary;
using MathLib.Api.Functions.Hyperbolic;
using MathLib.Api.Functions.InverseTrig;
using MathLib.Api.Functions.Trigonometric;
using MathLib.Api.Operations;
using MathLib.Utils.obj.Debug.netstandard2._0;

namespace MathLib.Utils.Parser.Visitor
{
    public class CalculatorVisitor : CalculatorBaseVisitor<Function>
    {
        private static readonly Dictionary<int, Function> FunctionMap = new Dictionary<int, Function>
        {
            {CalculatorParser.SIN, Funcs.Sin()},
            {CalculatorParser.COS, Funcs.Cos()},
            {CalculatorParser.TAN, Funcs.Tan()},
            {CalculatorParser.COT, Funcs.Cot()},
            {CalculatorParser.ARCSIN, Funcs.Asin()},
            {CalculatorParser.ARCCOS, Funcs.Acos()},
            {CalculatorParser.ARCTAN, Funcs.Atan()},
            {CalculatorParser.ARCCOT, Funcs.Acot()},
            {CalculatorParser.SQRT, Funcs.Sq()},
            {CalculatorParser.LN, Funcs.Ln()},
            {CalculatorParser.EXP, Funcs.Exp()},
            {CalculatorParser.SH, Funcs.Sh()},
            {CalculatorParser.CH, Funcs.Ch()},
            {CalculatorParser.TH, Funcs.Tgh()},
            {CalculatorParser.CTH, Funcs.Cth()}
        };

        /// <summary>
        ///     Power operator
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Function VisitPow(CalculatorParser.PowContext context)
        {
            Function res = null;
            
            res = Visit(context.expr(0)) ^ Visit(context.expr(1));

            return res;
        }

        /// <summary>
        ///     Multiply or Divide operator
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Function VisitMulDiv(CalculatorParser.MulDivContext context)
        {
            Function res = null;

            if (context.op.Text == "*")
                res = Visit(context.expr(0)) * Visit(context.expr(1));
            if (context.op.Text == "/")
                res = Visit(context.expr(0)) / Visit(context.expr(1));

            return res;
        }

        /// <summary>
        ///     Addition or Substraction operator
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Function VisitAddSub(CalculatorParser.AddSubContext context)
        {
            Function res = null;

            if (context.op.Text == "+")
                res = Visit(context.expr(0)) + Visit(context.expr(1));
            if (context.op.Text == "-")
                res = Visit(context.expr(0)) - Visit(context.expr(1));

            return res;
        }

        /// <summary>
        ///     Value expression
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Function VisitVal(CalculatorParser.ValContext context)
        {
            return new Constant(Convert.ToDouble(context.VAL().GetText(), CultureInfo.InvariantCulture.NumberFormat));
        }

        /// <summary>
        ///     Function expression
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Function VisitFunction(CalculatorParser.FunctionContext context)
        {
            Function res = null;

            //Trigonometric functions
            if (FunctionMap[context.fun.Type] is Sinus)
                res = new Sinus(Visit(context.expr()));
            if (FunctionMap[context.fun.Type] is Cosinus)
                res = new Cosinus(Visit(context.expr()));
            if (FunctionMap[context.fun.Type] is Tangens)
                res = new Tangens(Visit(context.expr()));
            if (FunctionMap[context.fun.Type] is Cotangens)
                res = new Cotangens(Visit(context.expr()));

            //Elementary functions
            if (FunctionMap[context.fun.Type] is Sqrt)
                res = new Sqrt(Visit(context.expr()));
            if (FunctionMap[context.fun.Type] is Logarithm)
                res = new Logarithm(Visit(context.expr()));
            if (FunctionMap[context.fun.Type] is Exponenta)
                res = new Exponenta(Visit(context.expr()));

            //Inverse Trigonometric functions
            if (FunctionMap[context.fun.Type] is ArcSinus)
                res = new ArcSinus(Visit(context.expr()));
            if (FunctionMap[context.fun.Type] is ArcCosinus)
                res = new ArcCosinus(Visit(context.expr()));
            if (FunctionMap[context.fun.Type] is ArcTangens)
                res = new ArcTangens(Visit(context.expr()));
            if (FunctionMap[context.fun.Type] is ArcCotangens)
                res = new ArcCotangens(Visit(context.expr()));

            //Hyperbolic functions
            if (FunctionMap[context.fun.Type] is HypSinus)
                res = new HypSinus(Visit(context.expr()));
            if (FunctionMap[context.fun.Type] is HypCosinus)
                res = new HypCosinus(Visit(context.expr()));
            if (FunctionMap[context.fun.Type] is HypTangens)
                res = new HypTangens(Visit(context.expr()));
            if (FunctionMap[context.fun.Type] is HypCotangens)
                res = new HypCotangens(Visit(context.expr()));

            return res;
        }

        /// <summary>
        ///     Parens
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Function VisitParens(CalculatorParser.ParensContext context)
        {
            return Visit(context.expr());
        }

        /// <summary>
        ///     Identity (variable)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Function VisitIdentity(CalculatorParser.IdentityContext context)
        {
            return new Identity();
        }

        /// <summary>
        ///     Unary Minus operator
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Function VisitMinus(CalculatorParser.MinusContext context)
        {
            return new Constant(-1) * Visit(context.expr());
        }
    }
}