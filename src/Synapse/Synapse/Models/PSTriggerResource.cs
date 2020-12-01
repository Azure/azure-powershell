using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSTriggerResource : PSSubResource
    {
        public PSTriggerResource(TriggerResource triggerResource, string workspaceName)
            :base(triggerResource?.Id,
                 triggerResource?.Name,
                 triggerResource?.Type,
                 triggerResource?.Etag)
        {
            this.WorkspaceName = workspaceName;
            this.Properties = triggerResource?.Properties;
        }

        public string WorkspaceName { get; set; }

        public Trigger Properties { get; set; }

        [Hidden]
        [JsonProperty(PropertyName = "properties")]
        public PSTrigger PropertiesForCreate { get; set; }

        public TriggerResource ToSdkObject()
        {
            return new TriggerResource(this.PropertiesForCreate?.ToSdkObject());
        }
    }
}
