using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSNotebookResource : PSSubResource
    {
        public PSNotebookResource(NotebookResource notebookResource, string workspaceName)
            : base(notebookResource?.Id,
                notebookResource?.Name,
                notebookResource?.Type,
                notebookResource?.Etag)
        {
            this.WorkspaceName = workspaceName;
            this.Properties = new PSNotebook(notebookResource?.Properties);
        }

        public string WorkspaceName { get; set; }

        public PSNotebook Properties { get; set; }

        public NotebookResource ToSdkObject()
        {
            return new NotebookResource(this.Properties?.ToSdkObject());
        }
    }
}
