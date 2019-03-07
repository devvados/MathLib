using System;
using MathLib.Api.Model.Base;
using MathLib.Api.Model.Functions;

namespace MathLib.Api.Model.Operations
{
    public class Power : Operator
    {
        public Power(Function a, Function b) : base(a, b)
        {
        }

        public static Function New(Function a, Function b)
        {
            if (b is Constant && Math.Abs(b.Calc(0)) < 0.0001)
                return new Constant(1);
            return new Power(a, b);
        }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return Math.Pow(LeftFunc.Calc(val), RightFunc.Calc(val));
        }

        // Derivative rule
        public override Function Derivative()
        {
            if (RightFunc is Constant)
                return RightFunc * (LeftFunc ^ (RightFunc - new Constant(1))) * LeftFunc.Derivative();
            return (RightFunc.Derivative() * Funcs.Ln(LeftFunc) + LeftFunc.Derivative() * RightFunc / LeftFunc) * this;
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
            return "(" + LeftFunc + ")" + "^(" + RightFunc + ")";
        }

        // Latex view
        public override string Print()
        {
            return LeftFunc.Print() + "^{" + RightFunc.Print() + "}";
        }

        #endregion
    }
}