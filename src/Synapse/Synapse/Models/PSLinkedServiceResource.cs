using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLinkedServiceResource : PSSubResource
    {
        public PSLinkedServiceResource(LinkedServiceResource linkedServiceResource, string workspaceName) 
            : base(linkedServiceResource?.Id,
                  linkedServiceResource?.Name,
                  linkedServiceResource?.Type,
                  linkedServiceResource?.Etag)
        {
            this.WorkspaceName = workspaceName;
            this.Properties = linkedServiceResource?.Properties;
        }

        public string WorkspaceName { get; set; }

        public LinkedService Properties { get; set; }
    }
}
