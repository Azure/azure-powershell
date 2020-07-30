using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSTrigger
    {
        public PSTrigger(Trigger trigger)
        {
            this.Description = trigger?.Description;
            this.RuntimeState = trigger?.RuntimeState;
            this.Annotations = trigger?.Annotations;
            this.Keys = trigger?.Keys;
            this.Values = trigger?.Values;
        }

        public PSTrigger() { }

        public string Description { get; set; }

        public TriggerRuntimeState? RuntimeState { get; set; }

        public IList<object> Annotations { get; set; }

        public ICollection<string> Keys { get; }

        public ICollection<object> Values { get; }

        public virtual Trigger ToSdkObject()
        {
            var trigger = new Trigger()
            {
                Description = this.Description,
            };
            foreach (var item in this.Annotations)
            {
                trigger.Annotations.Add(item);
            }
            return trigger;
        }
    }
}
