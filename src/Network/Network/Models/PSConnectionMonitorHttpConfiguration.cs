namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSNetworkWatcherConnectionMonitorHttpConfiguration : PSNetworkWatcherConnectionMonitorProtocolConfiguration
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public int? Port { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string Method { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string Path { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public List<PSHTTPHeader> RequestHeaders { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public List<string> ValidStatusCodeRanges { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool? PreferHTTPS { get; set; }

        [JsonIgnore]
        public string RequestHeadersText
        {
            get { return JsonConvert.SerializeObject(this.RequestHeaders, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ValidStatusCodeRangesText
        {
            get { return JsonConvert.SerializeObject(this.ValidStatusCodeRanges, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
