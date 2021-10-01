using System;
using Yabbin.Workflow.Core.Common;
using Yabbin.Workflow.Core.Events;

namespace Yabbin.Workflow.Core.Activities
{
    public class Activity : FlowNode
    {

        public event EventHandler<FlowElementEventArgs> OnActivityStart;
        public event EventHandler<FlowElementEventArgs> OnActivityEnd;

        protected virtual void TaskStart(FlowElementEventArgs e)
        {
            EventHandler<FlowElementEventArgs> handler = OnActivityStart;
            handler?.Invoke(this, e);
        }

        protected virtual void TaskEnd(FlowElementEventArgs e)
        {
            EventHandler<FlowElementEventArgs> handler = OnActivityEnd;
            handler?.Invoke(this, e);
        }

        public override void InvokeFlow()
        {
            Console.WriteLine("Activity invoked.");
        }
    }
}
