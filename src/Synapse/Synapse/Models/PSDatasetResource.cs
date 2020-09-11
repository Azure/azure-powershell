using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            this.Properties = new PSDataset(dataset?.Properties);
        }

        public string WorkspaceName { get; set; }

        public PSDataset Properties { get; set; }

        public DatasetResource ToSdkObject()
        {
            return new DatasetResource(this.Properties?.ToSdkObject());
        }
    }
}
