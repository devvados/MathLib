using System;
using MathLib.Api.Model.Base;

namespace MathLib.Api.Model.Functions.Hyperbolic
{
    public class HypCosinus : Function
    {
        public HypCosinus()
        {
        }

        public HypCosinus(Function f)
        {
            InnerF = f;
        }

        public Function InnerF { get; }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return Math.Cosh(val);
        }

        // Deirvative rule
        public override Function Derivative()
        {
            return Funcs.Sh(InnerF) * InnerF.Derivative();
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
            return $"0.5 * (exp({InnerF}) - exp({new Constant(-1) * InnerF}))";
        }

        // Latex view
        public override string Print()
        {
            return
                $@"0.5 \cdot (\exp ({InnerF.Print()}) - \exp ({(new Constant(-1) * InnerF).Print()}))";
        }

        #endregion
    }
}