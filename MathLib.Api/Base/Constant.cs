using System;
using System.Globalization;
using MathLib.Api.Functions;

namespace MathLib.Api.Base
{
    public class Constant : Function
    {
        private readonly double _value;

        public Constant(double val)
        {
            _value = val;
        }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return _value;
        }

        // Derivative rule
        public override Function Derivative()
        {
            return Funcs.Zero;
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
            return _value.ToString("0.####", CultureInfo.InvariantCulture.NumberFormat);
        }

        // Latex view
        public override string Print()
        {
            return $"{_value}";
        }

        #endregion
    }
}