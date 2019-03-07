using System;
using MathLib.Api.Base;
using MathNet.Numerics;

namespace MathLib.Api.Functions.InverseTrig
{
    public class ArcCotangens : Function
    {
        public ArcCotangens(Function f)
        {
            InnerF = f;
        }

        private Function InnerF { get; }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return Trig.Acot(val);
        }

        // Derivative rule
        public override Function Derivative()
        {
            return new Constant(-1) * (new Constant(1) / (new Constant(1) + (InnerF ^ new Constant(2)))) *
                   InnerF.Derivative();
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
            return $"arcctg({InnerF})";
        }

        // Latex view
        public override string Print()
        {
            return $@"\arcctg ({InnerF.Print()})";
        }

        #endregion
    }
}