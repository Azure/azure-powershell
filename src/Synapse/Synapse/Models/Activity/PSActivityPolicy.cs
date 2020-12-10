using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSActivityPolicy
    {
        public PSActivityPolicy() { }

        public object Timeout { get; set; }

        public object Retry { get; set; }

        public int? RetryIntervalInSeconds { get; set; }

        public bool? SecureInput { get; set; }

        public bool? SecureOutput { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
