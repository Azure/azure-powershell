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
        public string Name { get; set; }
        public int? TestFrequencySec { get; set; }
        public string Protocol { get; set; }
        public string PreferredIPVersion { get; set; }
        public PSConnectionMonitorHttpConfiguration HttpConfiguration { get; set; }
        public PSConnectionMonitorTcpConfiguration TcpConfiguration { get; set; }
        public PSConnectionMonitorIcmpConfiguration IcmpConfiguration { get; set; }
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
