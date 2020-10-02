using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSDatasetFolder
    {
        public PSDatasetFolder(DatasetFolder folder)
        {
            this.Name = folder?.Name;
        }

        public string Name { get; set; }

        public DatasetFolder ToSdkObject()
        {
            return new DatasetFolder()
            {
                Name = this.Name
            };
        }
    }
}
