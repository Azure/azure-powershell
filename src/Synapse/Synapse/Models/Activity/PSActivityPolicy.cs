using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
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

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public ActivityPolicy ToSdkObject()
        {
            var policy = new ActivityPolicy()
            {
                Timeout = this.Timeout,
                Retry = this.Retry,
                RetryIntervalInSeconds = this.RetryIntervalInSeconds,
                SecureInput = this.SecureInput,
                SecureOutput = this.SecureOutput
            };
            this.AdditionalProperties?.ForEach(item => policy.Add(item.Key, item.Value));
            return policy;
        }
    }
}
