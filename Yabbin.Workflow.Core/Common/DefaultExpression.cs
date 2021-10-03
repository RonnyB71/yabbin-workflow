using Yabbin.Workflow.Core.Foundation;

namespace Yabbin.Workflow.Core.Common
{
    public class DefaultExpression : BaseElement, IExpression
    {
        public bool Evaluate()
        {
            return true;
        }

    }
}