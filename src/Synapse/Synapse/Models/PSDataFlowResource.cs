using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSDataFlowResource : PSSubResource
    {
        public PSDataFlowResource(DataFlowResource dataFlowResource, string workspaceName)
            : base(dataFlowResource?.Id,
                  dataFlowResource?.Name,
                  dataFlowResource?.Type,
                  dataFlowResource?.Etag)
        {
            this.WorkspaceName = workspaceName;
            this.Properties = new PSDataFlow(dataFlowResource?.Properties);
        }

        public string WorkspaceName { get; set; }

        public PSDataFlow Properties { get; set; }

        public DataFlowResource ToSdkObject()
        {
            return new DataFlowResource(this.Properties?.ToSdkObject());
        }
    }
}
