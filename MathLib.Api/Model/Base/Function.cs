namespace MathLib.Api.Model.Base
{
    public abstract class Function : IDifferentiable, IIntegrable, ICalc, IPrint
    {
        // Interface implementation
        public abstract Function Derivative();
        public abstract Function Integrate();
        public abstract double Calc(double val);
        public abstract string Print();
    }
}