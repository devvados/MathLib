using System;
using MathLib.Api.Base;

namespace MathLib.Api.Functions.Elementary
{
    // Log (x) with base a
    public class Logarithm : Function
    {
        private readonly double _a;
        private readonly Function _innerF;

        // Ln(x) or Log[a](x)
        public Logarithm(double a = Math.E)
        {
            _a = a;
        }

        // Ln(f(x)) or Log[a](f(x))
        public Logarithm(Function f, double a = Math.E)
        {
            _a = a;
            _innerF = f;
        }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return Math.Log(val, _a);
        }

        // Derivative rule
        public override Function Derivative()
        {
            if (_innerF != null)
            {
                if (Math.Abs(_a - Math.E) <= 10e-6)
                    return new Constant(1) / _innerF * _innerF.Derivative();
                return new Constant(1) / (Funcs.Id * new Constant(Math.Log(_a, Math.E))) * _innerF.Derivative();
            }

            return new Constant(1) / (Funcs.Id * new Constant(Math.Log(_a, Math.E)));
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
                return $"ln({_innerF})";
            return $"log[{_a}]({_innerF})";
        }

        // Latex view
        public override string Print()
        {
            if (Math.Abs(_a - Math.E) <= 10e-6)
                return $@"\ln ({_innerF.Print()})";
            return $@"\log_{_a} ({_innerF.Print()})";
        }

        #endregion
    }
}