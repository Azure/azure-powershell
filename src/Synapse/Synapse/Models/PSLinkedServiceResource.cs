using Azure.Analytics.Synapse.Artifacts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLinkedServiceResource : PSSubResource
    {
        public PSLinkedServiceResource(LinkedServiceResource linkedServiceResource, string workspaceName) 
            : base(linkedServiceResource?.Id,
                  linkedServiceResource?.Name,
                  linkedServiceResource?.Type,
                  linkedServiceResource?.Etag)
        {
            this.WorkspaceName = workspaceName;
            this.Properties = linkedServiceResource?.Properties;
        }

        public string WorkspaceName { get; set; }

        public LinkedService Properties { get; set; }

        [Hidden]
        [JsonProperty(PropertyName = "properties")]
        public PSLinkedService PropertiesForCreate { get; set; }

        public LinkedServiceResource ToSdkObject()
        {
            LinkedService linkedService = this.PropertiesForCreate?.ToSdkObject();
            LinkedServiceResource linkedServiceResource = new LinkedServiceResource(linkedService);
            return linkedServiceResource;
        }
    }
}
