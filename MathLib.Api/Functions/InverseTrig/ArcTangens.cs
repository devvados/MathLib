using System;
using MathLib.Api.Model.Base;
using MathNet.Numerics;

namespace MathLib.Api.Model.Functions.InverseTrig
{
    public class ArcTangens : Function
    {
        public ArcTangens()
        {
        }

        public ArcTangens(Function f)
        {
            InnerF = f;
        }

        public Function InnerF { get; }

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