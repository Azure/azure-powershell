using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
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
            this.Properties = new PSTrigger(triggerResource?.Properties);
        }

        public string WorkspaceName { get; set; }

        public PSTrigger Properties { get; set; }

        public TriggerResource ToSdkObject()
        {
            return new TriggerResource(this.Properties?.ToSdkObject());
        }
    }
}
