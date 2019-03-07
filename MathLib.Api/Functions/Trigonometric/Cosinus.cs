using System;
using MathLib.Api.Base;

namespace MathLib.Api.Functions.Trigonometric
{
    public class Cosinus : Function
    {
        public Cosinus(Function f)
        {
            InnerF = f;
        }

        private Function InnerF { get; }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return Math.Cos(val);
        }

        // Deirvative rule
        public override Function Derivative()
        {
            return new Constant(-1) * Funcs.Sin(InnerF) * InnerF.Derivative();
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
            return $"cos({InnerF})";
        }

        // Latex view
        public override string Print()
        {
            return $@"\cos ({InnerF.Print()})";
        }

        #endregion
    }
}