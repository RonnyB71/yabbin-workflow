using Yabbin.Workflow.Core.Common;

namespace Yabbin.Workflow.Console
{
    public class DontNeedSignatureExpresseion : IExpression
    {
        public DontNeedSignatureExpresseion(int investmentInNOK)
        {
            InvestmentInNOK = investmentInNOK;
        }

        public int InvestmentInNOK { get; }

        public bool Evaluate()
        {
            if (InvestmentInNOK < 50000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
