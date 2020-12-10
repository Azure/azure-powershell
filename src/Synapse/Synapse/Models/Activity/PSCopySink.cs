using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSCopySink
    {
        public PSCopySink() { }

        public object WriteBatchSize { get; set; }

        public object WriteBatchTimeout { get; set; }

        public object SinkRetryCount { get; set; }

        public object SinkRetryWait { get; set; }

        public object MaxConcurrentConnections { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
