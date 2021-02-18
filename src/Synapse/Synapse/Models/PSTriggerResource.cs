using Azure.Analytics.Synapse.Artifacts.Models;

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
    }
}
