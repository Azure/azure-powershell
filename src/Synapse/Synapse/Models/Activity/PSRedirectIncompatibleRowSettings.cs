using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRedirectIncompatibleRowSettings
    {
        public PSRedirectIncompatibleRowSettings() { }

        [JsonProperty(PropertyName = "linkedServiceName")]
        public object LinkedServiceName { get; set; }

        [JsonProperty(PropertyName = "path")]
        public object Path { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
