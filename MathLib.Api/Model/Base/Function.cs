using MathLib.Api.Model.Operations;

namespace MathLib.Api.Model.Base
{
    public abstract class Function : IDifferentiable, IIntegrable, ICalc, IPrint
    {
        // Interface implementation
        public abstract Function Derivative();
        public abstract Function Integrate();
        public abstract double Calc(double val);
        public abstract string Print();
        
        #region f(x) <OPERATOR> g(x)

        // f(x) ^ g(x)
        public static Function operator ^(Function a, Function b)
        {
            return Power.New(a, b);
        }

        // f(x) + g(x)
        public static Function operator +(Function a, Function b)
        {
            return Addition.New(a, b);
        }

        // f(x) - g(x)
        public static Function operator -(Function a, Function b)
        {
            return Difference.New(a, b);
        }

        // f(x) * g(x)
        public static Function operator *(Function a, Function b)
        {
            return Multiplication.New(a, b);
        }

        // f(x) / g(x)
        public static Function operator /(Function a, Function b)
        {
            return Division.New(a, b);
        }

        #endregion
    }
}