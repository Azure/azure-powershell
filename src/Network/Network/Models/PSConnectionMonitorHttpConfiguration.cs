using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSConnectionMonitorHttpConfiguration : PSNetworkWatcherConnectionMonitorProtocolConfiguration
    {
        public int? Port { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public Dictionary<string, string> RequestHeaders { get; set; }
        public List<string> ValidStatusCodeRanges { get; set; }
        public bool? PreferHTTPS { get; set; }

        [JsonIgnore]
        public string RequestHeadersText
        {
            get { return JsonConvert.SerializeObject(this.RequestHeaders, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
