using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSNetworkWatcherConnectionMonitorTestConfigurationObject
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string Name { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public int? TestFrequencySec { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string Protocol { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string PreferredIPVersion { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public PSConnectionMonitorHttpConfiguration HttpConfiguration { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public PSConnectionMonitorTcpConfiguration TcpConfiguration { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public PSConnectionMonitorIcmpConfiguration IcmpConfiguration { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public PSConnectionMonitorSuccessThreshold SuccessThreshold { get; set; }

        [JsonIgnore]
        public string HttpConfigurationText
        {
            get { return JsonConvert.SerializeObject(this.HttpConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string TcpConfigurationText
        {
            get { return JsonConvert.SerializeObject(this.TcpConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string IcmpConfigurationText
        {
            get { return JsonConvert.SerializeObject(this.IcmpConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SuccessThresholdText
        {
            get { return JsonConvert.SerializeObject(this.SuccessThreshold, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

    }
}
