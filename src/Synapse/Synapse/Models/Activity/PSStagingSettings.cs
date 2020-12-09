using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSStagingSettings
    {
        public PSStagingSettings() { }

        [JsonProperty(PropertyName = "linkedServiceName")]
        public LinkedServiceReference LinkedServiceName { get; set; }

        [JsonProperty(PropertyName = "path")]
        public object Path { get; set; }

        [JsonProperty(PropertyName = "enableCompression")]
        public object EnableCompression { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public StagingSettings ToSdkObject()
        {
            var settings = new StagingSettings(this.LinkedServiceName)
            {
                Path = this.Path,
                EnableCompression = this.EnableCompression
            };
            this.AdditionalProperties?.ForEach(item => settings.Add(item.Key, item.Value));
            return settings;
        }
    }
}
