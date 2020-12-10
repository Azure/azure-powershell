using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSDatasetLocation
    {
        public PSDatasetLocation() { }

        [JsonProperty(PropertyName = "folderPath")]
        public object FolderPath { get; set; }

        [JsonProperty(PropertyName = "fileName")]
        public object FileName { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
