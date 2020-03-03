namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSNetworkWatcherConnectionMonitorTestConfigurationObject
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string Name { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public int? TestFrequencySec { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string PreferredIPVersion { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public PSNetworkWatcherConnectionMonitorProtocolConfiguration ProtocolConfiguration { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public PSNetworkWatcherConnectionMonitorSuccessThreshold SuccessThreshold { get; set; }

        [JsonIgnore]
        public string ProtocolConfigurationText
        {
            get { return JsonConvert.SerializeObject(this.ProtocolConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SuccessThresholdText
        {
            get { return JsonConvert.SerializeObject(this.SuccessThreshold, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

    }
}
