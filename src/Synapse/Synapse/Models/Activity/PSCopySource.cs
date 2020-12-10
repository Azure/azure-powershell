using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSCopySource
    {
        public PSCopySource() { }

        public object SourceRetryCount { get; set; }

        public object SourceRetryWait { get; set; }

        public object MaxConcurrentConnections { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
