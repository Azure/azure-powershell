using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSDataFlowFolder
    {
        public PSDataFlowFolder(DataFlowFolder dataFlowFolder)
        {
            this.Name = dataFlowFolder?.Name;
        }

        public string Name { get; set; }

        public DataFlowFolder ToSdkObject()
        {
            return new DataFlowFolder()
            {
                Name = this.Name
            };
        }
    }
}
