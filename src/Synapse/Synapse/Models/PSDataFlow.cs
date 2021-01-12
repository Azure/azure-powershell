using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSDataFlow
    {
        public PSDataFlow(DataFlow dataFlow)
        {
            this.Description = dataFlow?.Description;
            this.Annotations = dataFlow?.Annotations;
            this.Folder = new PSDataFlowFolder(dataFlow?.Folder);
        }

        public PSDataFlow() { }

        public string Description { get; set; }

        public IList<object> Annotations { get; set; }

        public PSDataFlowFolder Folder { get; set; }
    }
}
