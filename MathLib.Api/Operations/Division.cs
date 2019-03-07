using System;
using MathLib.Api.Base;
using MathLib.Api.Functions;

namespace MathLib.Api.Operations
{
    internal class Division : Operator
    {
        private Division(Function a, Function b) : base(a, b)
        {
        }

        public static Function New(Function a, Function b)
        {
            if (b is Constant && Math.Abs(b.Calc(0) - 1) <= 10e-6)
                return a;
            if (a is Constant && Math.Abs(a.Calc(0)) <= 10e-6)
                return Funcs.Zero;
            if (b is Constant && Math.Abs(b.Calc(0)) <= 10e-6)
                throw new DivideByZeroException("Function b cannot be zero constant");

            return b is Constant ? null : new Division(a, b);
        }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return LeftFunc.Calc(val) / RightFunc.Calc(val);
        }

        // Derivative rule
        public override Function Derivative()
        {
            return (LeftFunc.Derivative() * RightFunc - RightFunc.Derivative() * LeftFunc) / (RightFunc * RightFunc);
        }

        // Integration rule
        public override Function Integrate()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Print formula

        // String view
        public override string ToString()
        {
            return "(" + LeftFunc + ") / (" + RightFunc + ")";
        }

        // Latex view
        public override string Print()
        {
            return @"\frac{" + LeftFunc.Print() + "}{" + RightFunc.Print() + "}";
        }

        #endregion
    }
}