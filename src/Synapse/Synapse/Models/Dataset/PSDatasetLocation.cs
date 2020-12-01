using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
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

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public DatasetLocation ToSdkObject()
        {
            var datasetLocation = new DatasetLocation()
            {
                FolderPath = this.FolderPath,
                FileName = this.FileName
            };
            this.AdditionalProperties?.ForEach(item => datasetLocation.Add(item.Key, item.Value));
            return datasetLocation;
        }
    }
}
