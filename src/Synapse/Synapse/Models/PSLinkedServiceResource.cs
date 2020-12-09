using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;

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

        [JsonProperty(PropertyName = "properties")]
        internal PSLinkedService PropertiesForCreate { get; set; }

        public LinkedServiceResource ToSdkObject()
        {
            LinkedService linkedService = this.PropertiesForCreate?.ToSdkObject();
            LinkedServiceResource linkedServiceResource = new LinkedServiceResource(linkedService);
            return linkedServiceResource;
        }
    }
}
