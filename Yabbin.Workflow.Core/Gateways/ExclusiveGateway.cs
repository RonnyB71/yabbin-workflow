using System;

namespace Yabbin.Workflow.Core.Gateways
{
    public class ExclusiveGateway : Gateway
    {
        public override void InvokeFlow()
        {
            base.InvokeFlow();

            Console.WriteLine($"{this} invoked");
        }
    }
}
