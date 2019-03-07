using System;
using MathLib.Api.Base;

namespace MathLib.Api.Functions.Elementary
{
    public class Sqrt : Function
    {
        private readonly Function _innerF;

        public Sqrt(Function f)
        {
            _innerF = f;
        }

        #region Interface implementation

        // Calculate function
        public override double Calc(double val)
        {
            return Math.Sqrt(val);
        }

        // Derivative rule
        public override Function Derivative()
        {
            return new Constant(1) / (new Constant(2) * Funcs.Sq(_innerF)) * _innerF.Derivative();
        }

        //Integration rule
        public override Function Integrate()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Print formula

        // Вывод в виде строки
        public override string ToString()
        {
            return $"sqrt({_innerF})";
        }

        // Latex view
        public override string Print()
        {
            return @"\sqrt {" + _innerF.Print() + "}";
        }

        #endregion
    }
}