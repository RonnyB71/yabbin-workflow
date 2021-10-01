namespace Yabbin.Workflow.Console
{
    using System;
    using Yabbin.Workflow.Core.Activities;
    using Yabbin.Workflow.Core.Common;
    using Yabbin.Workflow.Core.Events;
    using Yabbin.Workflow.Core.Processes;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var process = new Process() { Id = "BasicFlow", Name = "Basic flow" };

            var startEvent = new StartEvent() { Id = "StartEvent", Name = "Start event" };
            startEvent.OnEventStart += WhenStartEventStarts;
            startEvent.OnEventEnd += WhenStartEventEnds;
            
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

        public static void WhenStartEventStarts(object sender, EventArgs e)
        {
            Console.WriteLine("My custom code on start event starting.");
        }

        public static void WhenStartEventEnds(object sender, EventArgs e)
        {
            Console.WriteLine("My custom code on start event ending.");
        }
    }
}