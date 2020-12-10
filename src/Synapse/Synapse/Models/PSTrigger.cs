using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
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
            var propertiesEnum = trigger?.GetEnumerator();
            if (propertiesEnum != null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
                while (propertiesEnum.MoveNext())
                {
                    this.AdditionalProperties.Add(propertiesEnum.Current);
                }
            }
        }

        public PSTrigger() { }

        public string Description { get; set; }

        public TriggerRuntimeState? RuntimeState { get; set; }

        public IList<object> Annotations { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
