using System;
using MathLib.Api.Model.Base;
using MathLib.Api.Model.Functions;

namespace MathLib.Api.Model.Operations
{
    public class Difference : Operator
    {
        public Difference(Function a, Function b) : base(a, b)
        {
        }

        public static Function New(Function a, Function b)
        {
            if (b is Constant && Math.Abs(b.Calc(0)) <= 10e-6)
                return a;
            if (a is Constant && b is Constant && Math.Abs(a.Calc(0) - b.Calc(0)) <= 10e-6)
                return Funcs.Zero;
            if (a == b)
                return Funcs.Zero;
            if (a is Constant && b is Constant)
                return new Constant(a.Calc(0) - b.Calc(0));

            return new Difference(a, b);
        }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return LeftFunc.Calc(val) - RightFunc.Calc(val);
        }

        // Derivative rule
        public override Function Derivative()
        {
            return null; //LeftFunc.Derivative() - RightFunc.Derivative();
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
            return "(" + LeftFunc + ")-(" + RightFunc + ")";
        }

        // Latex view
        public override string Print()
        {
            return LeftFunc.Print() + "-" + RightFunc.Print();
        }

        #endregion
    }
}