using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    class PSNetworkWatcherConnectionMonitorObject
    {
        public PSNetworkWatcher NetworkWatcher { get; set; }
        public string NetworkWatcherName { get; set; }
        public string ResourceGroupName { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public List<PSNetworkWatcherConnectionMonitorTestGroupObject> TestGroup { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public List<PSNetworkWatcherConnectionMonitorOutputObject> Output { get; set; }
        public string Notes { get; set; }

        [JsonIgnore]
        public string NetworkWatcherText
        {
            get { return JsonConvert.SerializeObject(this.NetworkWatcher, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string TestGroupText
        {
            get { return JsonConvert.SerializeObject(this.TestGroup, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string OutputText
        {
            get { return JsonConvert.SerializeObject(this.Output, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}