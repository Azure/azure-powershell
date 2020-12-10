using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSCopySink
    {
        public PSCopySink() { }

        [JsonProperty(PropertyName = "writeBatchSize")]
        public object WriteBatchSize { get; set; }

        [JsonProperty(PropertyName = "writeBatchTimeout")]
        public object WriteBatchTimeout { get; set; }

        [JsonProperty(PropertyName = "sinkRetryCount")]
        public object SinkRetryCount { get; set; }

        [JsonProperty(PropertyName = "sinkRetryWait")]
        public object SinkRetryWait { get; set; }

        [JsonProperty(PropertyName = "maxConcurrentConnections")]
        public object MaxConcurrentConnections { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
