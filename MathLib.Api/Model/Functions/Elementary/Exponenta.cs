using System;
using MathLib.Api.Model.Base;

namespace MathLib.Api.Model.Functions.Elementary
{
    // Exponential function
    public class Exponenta : Function
    {
        private readonly double _a;
        private readonly Function _innerF;

        // e^x or a^x
        public Exponenta(double a = Math.E)
        {
            _a = a;
        }

        // e^(f(x)) or a^(f(x))
        public Exponenta(Function f, double a = Math.E)
        {
            _a = a;
            _innerF = f;
        }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return Math.Pow(_a, val);
        }

        // Deirvative rule
        public override Function Derivative()
        {
            if (Math.Abs(_a - Math.E) <= 10e-6)
                return Funcs.Exp(_innerF) * _innerF.Derivative();
            return this * Funcs.Ln(new Constant(_a));
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
            if (Math.Abs(_a - Math.E) <= 10e-6)
                return $"exp({_innerF})";
            return $"{_a}^({_innerF})";
        }

        // Latex view
        public override string Print()
        {
            if (Math.Abs(_a - Math.E) <= 10e-6)
                return @"\exp \left(" + _innerF.Print() + @"\right)";
            return new Constant(_a).Print() + @"^\left(" + _innerF.Print() + @"\right)";
        }

        #endregion
    }
}