using MathLib.Api.Base;

namespace MathLib.Engine
{
    public interface IEngine
    {
        OperationResult Evaluate(string function);
    }
}