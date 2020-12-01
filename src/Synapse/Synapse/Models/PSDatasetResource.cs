using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management.Automation;
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
            this.Properties = dataset?.Properties;
        }

        public string WorkspaceName { get; set; }

        public Dataset Properties { get; set; }

        [Hidden]
        [JsonProperty(PropertyName = "properties")]
        public PSDataset PropertiesForCreate { get; set; }

        public DatasetResource ToSdkObject()
        {
            return new DatasetResource(this.PropertiesForCreate?.ToSdkObject());
        }
    }
}
