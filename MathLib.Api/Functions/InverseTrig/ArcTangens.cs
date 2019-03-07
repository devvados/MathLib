using System;
using MathLib.Api.Base;
using MathNet.Numerics;

namespace MathLib.Api.Functions.InverseTrig
{
    public class ArcTangens : Function
    {
        public ArcTangens(Function f)
        {
            InnerF = f;
        }

        private Function InnerF { get; }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return Trig.Atan(val);
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
            return $"arctan({InnerF})";
        }

        // Latex view
        public override string Print()
        {
            return $@"\arctan ({InnerF.Print()})";
        }

        #endregion
    }
}