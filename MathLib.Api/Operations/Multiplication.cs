using System;
using MathLib.Api.Base;

namespace MathLib.Api.Operations
{
    internal class Multiplication : Operator
    {
        private Multiplication(Function a, Function b) : base(a, b)
        {
        }

        public static Function New(Function a, Function b)
        {
            if (b is Constant && Math.Abs(b.Calc(0) - 1) <= 10e-6)
                return a;
            if (a is Constant && Math.Abs(a.Calc(0) - 1) <= 10e-6)
                return b;
            if (a is Constant && Math.Abs(a.Calc(0)) <= 10e-6)
                return new Constant(0);
            if (b is Constant && Math.Abs(b.Calc(0)) <= 10e-6)
                return new Constant(0);

            return new Multiplication(a, b);
        }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            var a = LeftFunc.Calc(val);
            if (Math.Abs(a) <= 10e-6)
                return a;
            var b = RightFunc.Calc(val);
            if (Math.Abs(b) <= 10e-6)
                return b;
            return a * b;
        }

        // Derivative rule
        public override Function Derivative()
        {
            return LeftFunc.Derivative() * RightFunc + LeftFunc * RightFunc.Derivative();
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
            return "(" + LeftFunc + ")*(" + RightFunc + ")";
        }

        // Latex view
        public override string Print()
        {
            return LeftFunc.Print() + @"\cdot " + RightFunc.Print();
        }

        #endregion
    }
}