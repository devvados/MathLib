using System;
using MathLib.Api.Base;

namespace MathLib.Api.Functions.Hyperbolic
{
    public class HypSinus : Function
    {
        public HypSinus(Function f)
        {
            InnerF = f;
        }

        private Function InnerF { get; }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return Math.Sinh(val);
        }

        // Deirvative rule
        public override Function Derivative()
        {
            return Funcs.Ch(InnerF) * InnerF.Derivative();
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
            return $"0.5 * (exp({InnerF}) + exp({new Constant(-1) * InnerF}))";
        }

        // Latex view
        public override string Print()
        {
            return
                $@"0.5 \cdot (\exp ({InnerF.Print()}) + \exp ({(new Constant(-1) * InnerF).Print()}))";
        }

        #endregion
    }
}