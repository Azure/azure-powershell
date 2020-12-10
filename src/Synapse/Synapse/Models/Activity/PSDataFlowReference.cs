using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSDataFlowReference
    {
        public PSDataFlowReference() { }

        public DataFlowReferenceType? Type { get; set; }

        public string ReferenceName { get; set; }

        public object DatasetParameters { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
