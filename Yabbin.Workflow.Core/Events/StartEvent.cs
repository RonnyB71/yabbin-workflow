using System;
using Yabbin.Workflow.Core.Common;

namespace Yabbin.Workflow.Core.Events
{
    public class StartEvent : Event
    {
        public override void InvokeFlow()
        {
            base.InvokeFlow();

            Console.WriteLine($"Starting event (Id: {Id}, Name: {Name}).");
            EventStart(new FlowElementEventArgs(Id, FlowEventType.Start));
            Console.WriteLine($"Ending event (Id: {Id}, Name: {Name}).");
            EventEnd(new FlowElementEventArgs(Id, FlowEventType.End));
        }
    }
}
