using System;
using MathLib.Api.Base;

namespace MathLib.Api.Functions.Hyperbolic
{
    public class HypTangens : Function
    {
        public HypTangens(Function f)
        {
            InnerF = f;
        }

        private Function InnerF { get; }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return Math.Tanh(val);
        }

        // Deirvative rule
        public override Function Derivative()
        {
            return (new Constant(1) - Funcs.Tgh(InnerF)) ^ (new Constant(2) * InnerF.Derivative());
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
            return
                $"(exp({InnerF.Print()}) - exp({(new Constant(-1) * InnerF).Print()}))/(exp({InnerF.Print()}) + exp({(new Constant(-1) * InnerF).Print()}))";
        }

        // Latex view
        public override string Print()
        {
            return
                $@"(\exp ({InnerF.Print()}) - \exp ({(new Constant(-1) * InnerF).Print()}))/(\exp ({InnerF.Print()}) - \exp ({(new Constant(-1) * InnerF).Print()}))";
        }

        #endregion
    }
}