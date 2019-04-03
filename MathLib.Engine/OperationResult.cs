namespace MathLib.Engine
{
    public struct OperationResult
    {
        private string simpleExpression;
        private string latexExpression;

        public OperationResult(string simpleExpression, string latexExpression)
        {
            this.simpleExpression = simpleExpression;
            this.latexExpression = latexExpression;
        }
    }
}