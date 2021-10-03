using System;
using Yabbin.Workflow.Core.Common;
using Yabbin.Workflow.Core.Events;

namespace Yabbin.Workflow.Core.Gateways
{
    public class ExclusiveGateway : Gateway
    {
        public override void InvokeFlow()
        {
            Console.WriteLine($"{this} invoked");

            Console.WriteLine($"Starting gateway (Id: {Id}, Name: {Name}).");
            GatewayStart(new FlowElementEventArgs(Id, FlowEventType.Start));
            Console.WriteLine($"Ending gatway (Id: {Id}, Name: {Name}).");
            GatewayEnd(new FlowElementEventArgs(Id, FlowEventType.End));
        }
    }
}
