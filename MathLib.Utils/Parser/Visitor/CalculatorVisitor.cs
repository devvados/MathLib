using System;
using System.Collections.Generic;
using System.Globalization;
using MathLib.Api.Base;
using MathLib.Api.Functions;
using MathLib.Api.Functions.Elementary;
using MathLib.Api.Functions.Hyperbolic;
using MathLib.Api.Functions.InverseTrig;
using MathLib.Api.Functions.Trigonometric;
using MathLib.Utils.Parser.Grammar;

namespace MathLib.Utils.Parser.Visitor
{
    public class MathVisitor : MathBaseVisitor<Function>
    {
        private static readonly Dictionary<int, Function> FunctionMap = new Dictionary<int, Function>
        {
            {MathParser.SIN, Funcs.Sin()},
            {MathParser.COS, Funcs.Cos()},
            {MathParser.TAN, Funcs.Tan()},
            {MathParser.COT, Funcs.Cot()},
            {MathParser.ARCSIN, Funcs.Asin()},
            {MathParser.ARCCOS, Funcs.Acos()},
            {MathParser.ARCTAN, Funcs.Atan()},
            {MathParser.ARCCOT, Funcs.Acot()},
            {MathParser.SQRT, Funcs.Sq()},
            {MathParser.LN, Funcs.Ln()},
            {MathParser.EXP, Funcs.Exp()},
            {MathParser.SH, Funcs.Sh()},
            {MathParser.CH, Funcs.Ch()},
            {MathParser.TH, Funcs.Tgh()},
            {MathParser.CTH, Funcs.Cth()}
        };

        // Power operator
        public override Function VisitPow(MathParser.PowContext context)
        {
            Function res = null;
            
            res = Visit(context.expr(0)) ^ Visit(context.expr(1));

            return res;
        }

        // Multiply or Divide operator
        public override Function VisitMulDiv(MathParser.MulDivContext context)
        {
            Function res = null;

            if (context.op.Text == "*")
                res = Visit(context.expr(0)) * Visit(context.expr(1));
            if (context.op.Text == "/")
                res = Visit(context.expr(0)) / Visit(context.expr(1));

            return res;
        }

        // Addition or Substraction operator
        public override Function VisitAddSub(MathParser.AddSubContext context)
        {
            Function res = null;

            if (context.op.Text == "+")
                res = Visit(context.expr(0)) + Visit(context.expr(1));
            if (context.op.Text == "-")
                res = Visit(context.expr(0)) - Visit(context.expr(1));

            return res;
        }

        // Value expression
        public override Function VisitVal(MathParser.ValContext context)
        {
            return new Constant(Convert.ToDouble(context.VAL().GetText(), CultureInfo.InvariantCulture.NumberFormat));
        }

        // Function expression
        public override Function VisitFunction(MathParser.FunctionContext context)
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

        // Parens
        public override Function VisitParens(MathParser.ParensContext context)
        {
            return Visit(context.expr());
        }

        // Identity (variable)
        public override Function VisitIdentity(MathParser.IdentityContext context)
        {
            return new Identity();
        }

        // Unary Minus operator
        public override Function VisitMinus(MathParser.MinusContext context)
        {
            return new Constant(-1) * Visit(context.expr());
        }
    }
}