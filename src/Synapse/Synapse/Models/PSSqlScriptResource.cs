using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSqlScriptResource : PSSubResource
    {
        public PSSqlScriptResource(SqlScriptResource sqlscriptResource, string workspaceName)
            : base(sqlscriptResource?.Id,
                sqlscriptResource?.Name,
                sqlscriptResource?.Type,
                sqlscriptResource?.Etag)
        {
            this.WorkspaceName = workspaceName;            
            this.Properties = new PSSqlScript(sqlscriptResource?.Properties);
        }

        public string WorkspaceName { get; set; }

        public PSSqlScript Properties { get; set; }
    }
}
