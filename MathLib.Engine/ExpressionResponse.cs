namespace MathLib.Engine
{
    public struct ExpressionResponse
    {
        private string simpleExpression;
        private string latexExpression;

        public ExpressionResponse(string simpleExpression, string latexExpression)
        {
            this.simpleExpression = simpleExpression;
            this.latexExpression = latexExpression;
        }
    }
}