using System;
using MathLib.Api.Base;
using MathLib.Api.Functions.Elementary;
using MathLib.Api.Functions.Hyperbolic;
using MathLib.Api.Functions.InverseTrig;
using MathLib.Api.Functions.Trigonometric;

namespace MathLib.Api.Functions
{
    public static class Funcs
    {
        // Sin(x) or Sin(g(x)) 

        public static Function Sin(Function f = null)
        {
            return new Sinus(f);
        }

        // Cos(x) or Cos(g(x))
        public static readonly Function Zero = new Constant(0);

        public static readonly Function Id = new Identity();

        #region Elementrty Functions

        // f(x) = x ^ n
        public static Function PowerFunction(int n)
        {
            return PowerFunction(Id, n);
        }

        // f(x) = g(x) ^ n
        public static Function PowerFunction(Function g, int n)
        {
            if (n == 0)
                return Zero + new Constant(1);
            var f = g;
            for (var i = 1; i < n; ++i)
                f *= g;
            return f;
        }

        // e^(x) or e^(g(x))
        public static Function Exp(Function f = null)
        {
            return new Exponenta(f);
        }

        // Ln(x) or Ln(g(x)) if a = exp;
        // Log[a](x) or Log[a](g(x)) if a != exp
        public static Function Ln(Function f = null, double a = Math.E)
        {
            return new Logarithm(f, a);
        }

        // Sqrt(x) or Sqrt(g(x))
        public static Function Sq(Function f = null)
        {
            return new Sqrt(f);
        }

        #endregion

        #region Trigonometric Functions

        public static Function Cos(Function f = null)
        {
            return new Cosinus(f);
        }

        // Tan(x) or Tan(g(x))
        public static Function Tan(Function f = null)
        {
            return new Tangens(f);
        }

        // Cth(x) or Ctg(g(x))
        public static Function Cot(Function f = null)
        {
            return new Cotangens(f);
        }

        #endregion

        #region Inverse Trigonometric Functions

        // Arcsin(x) or Arcsin(g(x)) 
        public static Function Asin(Function f = null)
        {
            return new ArcSinus(f);
        }

        // Arccos(x) or Arccos(g(x))
        public static Function Acos(Function f = null)
        {
            return new ArcCosinus(f);
        }

        // Arctan(x) or Arctan(g(x))
        public static Function Atan(Function f = null)
        {
            return new ArcTangens(f);
        }

        // Arccot(x) or Arccot(g(x))
        public static Function Acot(Function f = null)
        {
            return new ArcCotangens(f);
        }

        #endregion

        #region Hyperbolic Functions

        // Sh(x) or Sh(g(x))
        public static Function Sh(Function f = null)
        {
            return new HypSinus(f);
        }

        // Ch(x) or Ch(g(x))
        public static Function Ch(Function f = null)
        {
            return new HypCosinus(f);
        }

        // Tgh(x) or Tgh(g(x))
        public static Function Tgh(Function f = null)
        {
            return new HypTangens(f);
        }

        // Cth(x) or Cth(g(x))
        public static Function Cth(Function f = null)
        {
            return new HypCotangens(f);
        }

        #endregion

        #region Numeric Integration

        // Definite Integral
        public static double Integrate(this Function f, double a, double b)
        {
            return Integrate(f, a, b, (b - a) * 0.00001);
        }

        public static double Integrate(this Function f, double a, double b, double delta)
        {
            if (Math.Sign(delta) != Math.Sign(b - a))
                delta *= -1;

            double sum = 0;

            for (var x = a; x < b; x += delta)
            {
                if (x + delta > b)
                {
                    sum += (b - x) * f.Calc(x);
                    break;
                }

                sum += delta * f.Calc(x);
            }

            return sum;
        }

        // Simpson Method
        public static double SimpsonIntegrate(this Function f, double a, double b)
        {
            return SimpsonIntegrate(f, a, b, (b - a) * 0.00001);
        }

        public static double SimpsonIntegrate(this Function f, double a, double b, double delta)
        {
            if (Math.Sign(delta) != Math.Sign(b - a))
                delta *= -1;
            var n = (int) ((b - a) / delta);
            var h = (b - a) / n;
            double sum = 0;
            sum = f.Calc(a);

            for (var i = 1; i <= n; i += 2)
            {
                var x = a + h * i;
                sum += 4 * f.Calc(x);
            }

            for (var i = 2; i <= n - 1; i += 2)
            {
                var x = a + h * i;
                sum += 2 * f.Calc(x);
            }

            sum += f.Calc(b);

            return h * sum / 3;
        }

        #endregion
    }
}