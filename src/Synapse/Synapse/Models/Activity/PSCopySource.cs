using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSCopySource
    {
        public PSCopySource() { }

        [JsonProperty(PropertyName = "sourceRetryCount")]
        public object SourceRetryCount { get; set; }

        [JsonProperty(PropertyName = "sourceRetryWait")]
        public object SourceRetryWait { get; set; }

        [JsonProperty(PropertyName = "maxConcurrentConnections")]
        public object MaxConcurrentConnections { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public CopySource ToSdkObject()
        {
            var copySource = new CopySource()
            {
                SourceRetryCount = this.SourceRetryCount,
                SourceRetryWait = this.SourceRetryWait,
                MaxConcurrentConnections = this.MaxConcurrentConnections
            };
            this.AdditionalProperties?.ForEach(item => copySource.Add(item.Key, item.Value));
            return copySource;
        }
    }
}
