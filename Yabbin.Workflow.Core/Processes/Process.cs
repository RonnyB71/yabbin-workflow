using System;
using System.Collections.Generic;
using System.Linq;
using Yabbin.Workflow.Core.Activities;
using Yabbin.Workflow.Core.Common;
using Yabbin.Workflow.Core.Events;
using Yabbin.Workflow.Core.Foundation;
using Yabbin.Workflow.Core.Gateways;

namespace Yabbin.Workflow.Core.Processes
{
    /// <summary>
    /// Class that represents a BMPN process according to https://www.omg.org/spec/BPMN/2.0/PDF
    /// Tried to use the same class names and hierarchy as described in the PDF with a few simplifications.
    /// Should be able to creat a new process based on the BPMN reader class in Altinn
    /// https://github.com/Altinn/altinn-studio/blob/master/src/Altinn.Apps/AppTemplates/AspNet/Altinn.App.Common/Process/BpmnReader.cs
    /// </summary>
    public class Process : BaseElement
    {
        public Process()
        {
        }

        public string Name { get; set; }

        public Dictionary<string, FlowElement> FlowElements { get; set; } = new Dictionary<string, FlowElement>();
        public List<SequenceFlow> SequenceFlowElements { get; set; } = new List<SequenceFlow>();

        public void Start()
        {
            Console.WriteLine($"Process (Id: {Id}, Name: {Name}) starting.");

            var startEvent = FindStartEvent();
            if (startEvent == null)
            {
                throw new InvalidOperationException("No StartEvent added to process! You must define a StartEvent in order to start the process.");
            }

            var endEvent = FindEndEvent();
            if (endEvent == null)
            {
                throw new InvalidOperationException("No EndEvent added to process! You must define a EndEvent in order to start the process.");
            }

            startEvent.InvokeFlow();
        }

        public void AddFlow(FlowElement flowElement)
        {
            switch (flowElement)
            {
                case SequenceFlow sequenceFlow:
                    SequenceFlowElements.Add(sequenceFlow);
                    break;

                case Event @event:
                    if (@event is StartEvent && HasStartEvent())
                    {
                        throw new ArgumentException("Only one StartEvent allowed!");
                    }

                    @event.OnEventEnd += DispatchEvent;
                    FlowElements.Add(@event.Id, @event);
                    break;

                case Activity activity:
                    activity.OnActivityEnd += DispatchEvent;
                    FlowElements.Add(activity.Id, activity);
                    break;

                case Gateway gateway:
                    gateway.OnGatewayEnd += DispatchEvent;
                    FlowElements.Add(gateway.Id, gateway);
                    break;

                default:
                    FlowElements.Add(flowElement.Id, flowElement);
                    break;
            }
        }

        private bool HasStartEvent()
        {
            return FindStartEvent() != null;
        }

        private StartEvent FindStartEvent()
        {
            var startEventEntry = FlowElements.FirstOrDefault(e => e.Value.GetType() == typeof(StartEvent));
            
             return startEventEntry.Value as StartEvent;
        }

        private EndEvent FindEndEvent()
        {
            var endEventEntry = FlowElements.FirstOrDefault(e => e.Value.GetType() == typeof(EndEvent));

            return endEventEntry.Value as EndEvent;
        }

        private void DispatchEvent(object sender, FlowElementEventArgs e)
        {
            Console.WriteLine($"Dispatching event {sender}");

            List<SequenceFlow> sequenceFlows = SequenceFlowElements.Where(sf => sf.Incoming.Id == e.SourceId && e.FlowEventType == FlowEventType.End).ToList();

            foreach (var sequenceFlow in sequenceFlows)
            {
                sequenceFlow.InvokeFlow();
            }

            if (IsEndEvent(e, sequenceFlows))
            {
                Console.WriteLine($"Process (Id: {Id}, Name: {Name}) ended.");
            }
        }

        private bool IsEndEvent(FlowElementEventArgs e, List<SequenceFlow> sequenceFlows)
        {
            return sequenceFlows.Count == 0 && FlowElements.First(fe => fe.Value.Id == e.SourceId).Value is EndEvent && e.FlowEventType == FlowEventType.End;
        }
    }
}
