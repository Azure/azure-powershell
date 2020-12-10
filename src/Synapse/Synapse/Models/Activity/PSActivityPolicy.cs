using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSActivityPolicy
    {
        public PSActivityPolicy() { }

        [JsonProperty(PropertyName = "timeout")]
        public object Timeout { get; set; }

        [JsonProperty(PropertyName = "retry")]
        public object Retry { get; set; }

        [JsonProperty(PropertyName = "retryIntervalInSeconds")]
        public int? RetryIntervalInSeconds { get; set; }

        [JsonProperty(PropertyName = "secureInput")]
        public bool? SecureInput { get; set; }

        [JsonProperty(PropertyName = "secureOutput")]
        public bool? SecureOutput { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
