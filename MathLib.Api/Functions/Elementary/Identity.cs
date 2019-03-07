using System;
using MathLib.Api.Model.Base;

namespace MathLib.Api.Model.Functions.Elementary
{
    // Linear function
    public class Identity : Function
    {
        //public Identity(string s)
        //{
        //    Symbol = s;
        //}

        public string Symbol { get; set; }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return val;
        }

        // Deirvative rule
        public override Function Derivative()
        {
            return Funcs.Zero + new Constant(1);
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
            return "x";
        }

        // Latex view
        public override string Print()
        {
            return "x";
        }

        #endregion
    }
}