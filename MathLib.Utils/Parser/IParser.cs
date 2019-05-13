using MathLib.Api.Base;

namespace MathLib.Utils.Parser
{
    public interface IParser
    {
        Function Parse(string expression);
    }
}