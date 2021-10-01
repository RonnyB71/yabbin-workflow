using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yabbin.Workflow.Core.Common;

namespace Yabbin.Workflow.Core.Events
{
    public class Event : FlowNode
    {
        public event EventHandler<FlowElementEventArgs> OnEventStart;
        public event EventHandler<FlowElementEventArgs> OnEventEnd;

        protected virtual void EventStart(FlowElementEventArgs e)
        {
            EventHandler<FlowElementEventArgs> handler = OnEventStart;
            handler?.Invoke(this, e);
        }

        protected virtual void EventEnd(FlowElementEventArgs e)
        {
            EventHandler<FlowElementEventArgs> handler = OnEventEnd;
            handler?.Invoke(this, e);
        }

        public override void InvokeFlow()
        {
            Console.WriteLine("Event flow invoked.");
        }
    }
}
