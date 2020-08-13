using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
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

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "runtimeState")]
        public TriggerRuntimeState? RuntimeState { get; set; }

        [JsonProperty(PropertyName = "annotations")]
        public IList<object> Annotations { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public virtual Trigger ToSdkObject()
        {
            var trigger = new Trigger();
            SetProperties(trigger);
            return trigger;
        }

        protected void SetProperties(Trigger trigger)
        {
            trigger.Description = this.Description;
            this.Annotations?.ForEach(item => trigger.Annotations.Add(item));
            if (this.AdditionalProperties != null)
            {
                foreach (var item in this.AdditionalProperties)
                {
                    if (item.Key != "typeProperties")
                    {
                        trigger.Add(item.Key, item.Value);
                    }
                }
            }
        }
    }
}
