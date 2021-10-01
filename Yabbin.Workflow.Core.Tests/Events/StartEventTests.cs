using System;
using Xunit;
using Yabbin.Workflow.Core.Common;
using Yabbin.Workflow.Core.Events;

namespace Yabbin.Workflow.Core.Tests.Events
{
    public class StartEventTests
    {
        [Fact]
        public void StartEvent_EventStart_Raises()
        {
            var startEvent = new StartEvent() { Id = Guid.NewGuid().ToString(), Name = "Start event" };
          
            var receivedEvent = Assert.Raises<FlowElementEventArgs>(
                a => startEvent.OnEventStart += a,
                a => startEvent.OnEventStart -= a,
                () => startEvent.InvokeFlow());

            Assert.NotNull(receivedEvent);
            Assert.Equal(startEvent.Id, ((StartEvent)receivedEvent.Sender).Id);
            Assert.Equal(startEvent.Name, ((StartEvent)receivedEvent.Sender).Name);
            Assert.Equal(startEvent.Id, receivedEvent.Arguments.SourceId);
            Assert.Equal(FlowEventType.Start, receivedEvent.Arguments.FlowEventType);
        }

        [Fact]
        public void StartEvent_EventEnd_Raises()
        {
            var endEvent = new EndEvent() { Id = Guid.NewGuid().ToString(), Name = "End event" };

            var receivedEvent = Assert.Raises<FlowElementEventArgs>(
                a => endEvent.OnEventEnd += a,
                a => endEvent.OnEventEnd -= a,
                () => endEvent.InvokeFlow());

            Assert.NotNull(receivedEvent);
            Assert.Equal(endEvent.Id, ((EndEvent)receivedEvent.Sender).Id);
            Assert.Equal(endEvent.Name, ((EndEvent)receivedEvent.Sender).Name);
            Assert.Equal(endEvent.Id, receivedEvent.Arguments.SourceId);
            Assert.Equal(FlowEventType.End, receivedEvent.Arguments.FlowEventType);
        }
    }
}
