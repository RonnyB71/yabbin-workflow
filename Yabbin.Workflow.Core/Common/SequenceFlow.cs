namespace Yabbin.Workflow.Core.Common
{
    /// <summary>
    /// A sequence flow basically represents an arrow connecting
    /// one flow node to another. An arrow can only have one source (incoming)
    /// and one target (outgoing), but you can have multiple arrows
    /// from/to the same flow node.
    /// </summary>
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
