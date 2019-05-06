using System;
using MathLib.Api.Base;

namespace MathLib.Api.Functions.Elementary
{
    // Exponential function
    public class Exponenta : Function
    {
        private readonly double _a;
        private readonly Function _innerF;

        // e^x or a^x

        // e^(f(x)) or a^(f(x))
        public Exponenta(Function f, double a = Math.E)
        {
            _a = a;
            _innerF = f;
        }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val) => Math.Pow(_a, val);

        // Derivative rule
        public override Function Derivative()
        {
            return Math.Abs(_a - Math.E) <= 10e-6
                ? Funcs.Exp(_innerF) * _innerF.Derivative()
                : this * Funcs.Ln(new Constant(_a));
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
            return Math.Abs(_a - Math.E) <= 10e-6
                ? $"exp({_innerF})"
                : $"{_a}^({_innerF})";
        }

        // Latex view
        public override string Print()
        {
            return Math.Abs(_a - Math.E) <= 10e-6
                ? @"\exp \left(" + _innerF.Print() + @"\right)"
                : new Constant(_a).Print() + @"^\left(" + _innerF.Print() + @"\right)";
        }

        #endregion
    }
}