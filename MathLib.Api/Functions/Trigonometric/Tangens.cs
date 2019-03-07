using System;
using MathLib.Api.Base;
using MathNet.Numerics;

namespace MathLib.Api.Functions.Trigonometric
{
    public class Tangens : Function
    {
        public Tangens(Function f)
        {
            InnerF = f;
        }

        private Function InnerF { get; }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return Trig.Tan(val);
        }

        // Deirvative rule
        public override Function Derivative()
        {
            return new Constant(1) / (new Constant(1) + (InnerF ^ new Constant(2))) * InnerF.Derivative();
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
            return $"tan({InnerF})";
        }

        // Latex view
        public override string Print()
        {
            return $@"\tan ({InnerF.Print()})";
        }

        #endregion
    }
}