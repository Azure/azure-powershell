using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRedirectIncompatibleRowSettings
    {
        public PSRedirectIncompatibleRowSettings() { }

        [JsonProperty(PropertyName = "linkedServiceName")]
        public object LinkedServiceName { get; set; }

        [JsonProperty(PropertyName = "path")]
        public object Path { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public RedirectIncompatibleRowSettings ToSdkObject()
        {
            var settings = new RedirectIncompatibleRowSettings(this.LinkedServiceName)
            {
                Path = this.Path
            };
            this.AdditionalProperties?.ForEach(item => settings.Add(item.Key, item.Value));
            return settings;
        }
    }
}
