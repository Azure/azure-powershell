using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSStagingSettings
    {
        public PSStagingSettings() { }

        [JsonProperty(PropertyName = "linkedServiceName")]
        public LinkedServiceReference LinkedServiceName { get; set; }

        [JsonProperty(PropertyName = "path")]
        public object Path { get; set; }

        [JsonProperty(PropertyName = "enableCompression")]
        public object EnableCompression { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
