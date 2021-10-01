using System;
using Xunit;
using Yabbin.Workflow.Core.Activities;
using Yabbin.Workflow.Core.Common;
using Yabbin.Workflow.Core.Events;
using Yabbin.Workflow.Core.Processes;

namespace Yabbin.Workflow.Core.Tests
{
    public class ProcessTests
    {
        [Fact]
        public void AddFlow_StartEvent_ShouldOnlyHaveOne()
        {
            var process = new Process() { Id = "BasicFlow", Name = "Basic flow" };
            var startEvent = new StartEvent() { Id = "StartEvent", Name = "Start event" };
            process.AddFlow(startEvent);

            Assert.Throws<ArgumentException>(() => process.AddFlow(startEvent));
        }

        [Fact]
        public void AddFlow_StartEvent_ShouldHaveAtLeastOne()
        {
            var process = new Process() { Id = "BasicFlow", Name = "Basic flow" };

            Assert.Throws<InvalidOperationException>(() => process.Start());
        }

        [Fact]
        public void AddFlow_EndEvent_ShouldHaveAtLeastOne()
        {
            var process = new Process() { Id = "BasicFlow", Name = "Basic flow" };
            var startEvent = new StartEvent() { Id = "StartEvent", Name = "Start event" };
            process.AddFlow(startEvent);

            Assert.Throws<InvalidOperationException>(() => process.Start());
        }

        [Fact]
        public void Process_SimpleFlow_ShouldRunAutomatically()
        {
            var process = new Process() { Id = "BasicFlow", Name = "Basic flow" };

            var startEvent = new StartEvent() { Id = "StartEvent", Name = "Start event" };
            var task = new Task() { Id = "Task", Name = "Task" };
            var endEvent = new EndEvent() { Id = "EndEvent", Name = "End event" };
            var sequenceFlow1 = new SequenceFlow() { Id = "SequenceFlow_1", Name = "Sequence flow 1", Incoming = startEvent, Outgoing = task };
            var sequenceFlow2 = new SequenceFlow() { Id = "SequenceFlow_2", Name = "Sequence flow 2", Incoming = task, Outgoing = endEvent };

            process.AddFlow(startEvent);
            process.AddFlow(sequenceFlow1);
            process.AddFlow(task);
            process.AddFlow(sequenceFlow2);
            process.AddFlow(endEvent);

            process.Start();
        }
    }
}
