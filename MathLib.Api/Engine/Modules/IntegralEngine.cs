using MathLib.Api.Model.Base;

namespace MathLib.Api.Engine.Modules
{
    public class IntegralEngine
    {
        private readonly Function function;
        private double _a, _b;

        public IntegralEngine(Function f)
        {
            function = f;
        }

        public IntegralEngine(Function f, double a, double b) : this(f)
        {
            function = f;
            _a = a;
            _b = b;
        }

        public Function Evaluate()
        {
            return function.Integrate();
        }
    }
}