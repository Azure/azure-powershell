using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSDatasetCompression
    {
        public PSDatasetCompression() { }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public DatasetCompression ToSdkObject()
        {
            var datasetCompression = new DatasetCompression();
            this.AdditionalProperties?.ForEach(item => datasetCompression.Add(item.Key, item.Value));
            return datasetCompression;
        }
    }
}
