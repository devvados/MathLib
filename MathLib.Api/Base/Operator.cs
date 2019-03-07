namespace MathLib.Api.Base
{
    public abstract class Operator : Function
    {
        protected readonly Function LeftFunc;
        protected readonly Function RightFunc;

        protected Operator(Function a, Function b)
        {
            LeftFunc = a;
            RightFunc = b;
        }

        // Interface implementation
        public abstract override double Calc(double value);
        public abstract override Function Derivative();
        public abstract override Function Integrate();
    }
}