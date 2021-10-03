using System;
using Yabbin.Workflow.Core.Common;
using Yabbin.Workflow.Core.Events;

namespace Yabbin.Workflow.Core.Gateways
{
    public abstract class Gateway : FlowNode
    {
        public event EventHandler<FlowElementEventArgs> OnGatewayStart;
        public event EventHandler<FlowElementEventArgs> OnGatewayEnd;

        protected virtual void GatewayStart(FlowElementEventArgs e)
        {
            EventHandler<FlowElementEventArgs> handler = OnGatewayStart;
            handler?.Invoke(this, e);
        }

        protected virtual void GatewayEnd(FlowElementEventArgs e)
        {
            EventHandler<FlowElementEventArgs> handler = OnGatewayEnd;
            handler?.Invoke(this, e);
        }
        public abstract override void InvokeFlow();
    }
}
