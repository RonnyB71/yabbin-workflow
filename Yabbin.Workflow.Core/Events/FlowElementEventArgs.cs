using System;
using Yabbin.Workflow.Core.Common;

namespace Yabbin.Workflow.Core.Events
{
    public class FlowElementEventArgs : EventArgs
    {
        public FlowElementEventArgs(string sourceId, FlowEventType flowEventType)
        {
            SourceId = sourceId;
            FlowEventType = flowEventType;
        }

        public string SourceId { get; private set; }
        public FlowEventType FlowEventType { get; private set; }
    }
}
