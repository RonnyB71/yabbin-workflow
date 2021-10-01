namespace Yabbin.Workflow.Core.Common
{
    public class SequenceFlow : FlowElement
    {
        public FlowNode Incoming { get; set; }
        public FlowNode Outgoing { get; set; }

        public void InvokeFlow()
        {
            Outgoing.InvokeFlow();
        }
    }
}
