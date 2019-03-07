using System;
using MathLib.Api.Base;

namespace MathLib.Api.Functions.Trigonometric
{
    public class Sinus : Function
    {
        public Sinus()
        {
        }

        public Sinus(Function f)
        {
            InnerF = f;
        }

        private Function InnerF { get; }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return Math.Sin(val);
        }

        // Deirvative rule
        public override Function Derivative()
        {
            return Funcs.Cos(InnerF) * InnerF.Derivative();
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
            return $"sin({InnerF})";
        }

        // Latex view
        public override string Print()
        {
            return $@"\sin ({InnerF.Print()})";
        }

        #endregion
    }
}