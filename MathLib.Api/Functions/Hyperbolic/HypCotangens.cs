using System;
using MathLib.Api.Model.Base;
using MathNet.Numerics;

namespace MathLib.Api.Model.Functions.Hyperbolic
{
    public class HypCotangens : Function
    {
        public HypCotangens()
        {
        }

        public HypCotangens(Function f)
        {
            InnerF = f;
        }

        public Function InnerF { get; }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return Trig.Coth(val);
        }

        // Deirvative rule
        public override Function Derivative()
        {
            return (new Constant(1) - Funcs.Cth(InnerF)) ^ (new Constant(2) * InnerF.Derivative());
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
                $"(exp({InnerF}) + exp({new Constant(-1) * InnerF}))/(exp({InnerF}) - exp({new Constant(-1) * InnerF}))";
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