using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSConnectionMonitorTestGroup
    {
        public string Name { get; set; }
        public bool? Disable { get; set; }
        public PSConnectionMonitorTestConfiguration[] TestConfigurations { get; set; }
        public PSConnectionMonitorEndpoint[] Sources { get; set; }
        public PSConnectionMonitorEndpoint[] Destinations { get; set; }

        [JsonIgnore]
        public string TestConfigurationsText
        {
            get { return JsonConvert.SerializeObject(this.TestConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SourcesText
        {
            get { return JsonConvert.SerializeObject(this.Sources, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DestinationsText
        {
            get { return JsonConvert.SerializeObject(this.Destinations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
