using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLogStorageSettings
    {
        public PSLogStorageSettings() { }

        [JsonProperty(PropertyName = "linkedServiceName")]
        public LinkedServiceReference LinkedServiceName { get; set; }

        [JsonProperty(PropertyName = "path")]
        public object Path { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public LogStorageSettings ToSdkObject()
        {
            var logStorageSettings = new LogStorageSettings(this.LinkedServiceName)
            {
                Path = this.Path
            };
            this.AdditionalProperties?.ForEach(item => logStorageSettings.Add(item.Key, item.Value));
            return logStorageSettings;
        }
    }
}
