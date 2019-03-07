using MathLib.Api.Model.Base;

namespace MathLib.Api.Engine.Modules
{
    public class DerivativeEngine
    {
        private readonly Function function;

        public DerivativeEngine(Function f)
        {
            function = f;
        }

        public Function Evaluate()
        {
            return function.Derivative();
        }
    }
}