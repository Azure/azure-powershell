using Azure.Analytics.Synapse.Artifacts.Models;

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
    }
}
