using MathLib.Api.Base;
using MathLib.Engine.Model;

namespace MathLib.Engine
{
    public interface IEngine
    {
        OperationResult Evaluate(string function);
    }
}