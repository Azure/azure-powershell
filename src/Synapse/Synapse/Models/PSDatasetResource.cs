using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSDatasetResource : PSSubResource
    {
        public PSDatasetResource(DatasetResource dataset, string workspaceName)
            : base(dataset?.Id,
                  dataset?.Name,
                  dataset?.Type,
                  dataset?.Etag)
        {
            this.WorkspaceName = workspaceName;
            this.Properties = dataset?.Properties;
        }

        public string WorkspaceName { get; set; }

        public Dataset Properties { get; set; }

        [JsonProperty(PropertyName = "properties")]
        internal PSDataset PropertiesForCreate { get; set; }

        public DatasetResource ToSdkObject()
        {
            return new DatasetResource(this.PropertiesForCreate?.ToSdkObject());
        }
    }
}
