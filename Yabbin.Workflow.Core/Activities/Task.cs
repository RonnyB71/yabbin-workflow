using System;
using Yabbin.Workflow.Core.Common;
using Yabbin.Workflow.Core.Events;

namespace Yabbin.Workflow.Core.Activities
{
    public class Task : Activity
    {
        public override void InvokeFlow()
        {
            base.InvokeFlow();

            Console.WriteLine($"Starting task (Id: {Id}, Name: {Name}).");
            TaskStart(new FlowElementEventArgs(Id, FlowEventType.Start));
            Console.WriteLine($"Ending task (Id: {Id}, Name: {Name}).");
            TaskEnd(new FlowElementEventArgs(Id, FlowEventType.End));
        }
    }
}
