using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
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
            this.Properties = new PSLinkedService(linkedServiceResource?.Properties);
        }

        public string WorkspaceName { get; set; }

        public PSLinkedService Properties { get; set; }

        public LinkedServiceResource ToSdkObject()
        {
            LinkedService linkedService = this.Properties?.ToSdkObject();
            LinkedServiceResource linkedServiceResource = new LinkedServiceResource(linkedService);
            return linkedServiceResource;
        }
    }
}
