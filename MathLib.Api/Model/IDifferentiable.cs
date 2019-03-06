using MathLib.Api.Model.Base;

namespace MathLib.Api.Model
{
    public interface IDifferentiable
    {
        Function Derivative();
    }
}