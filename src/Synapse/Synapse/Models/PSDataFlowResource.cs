using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management.Automation;
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
            this.Properties = dataFlowResource?.Properties;
        }

        public string WorkspaceName { get; set; }

        public DataFlow Properties { get; set; }

        [Hidden]
        [JsonProperty(PropertyName = "properties")]
        public PSDataFlow PropertiesForCreate { get; set; }

        public DataFlowResource ToSdkObject()
        {
            return new DataFlowResource(this.PropertiesForCreate?.ToSdkObject());
        }
    }
}
