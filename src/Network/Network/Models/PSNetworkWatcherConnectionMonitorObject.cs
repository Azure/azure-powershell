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
        public string NetworkWatcherName { get; set; }
        public string ResourceGroupName { get; set; }
        public string Name { get; set; }
        public List<PSNetworkWatcherConnectionMonitorTestGroupObject> TestGroup { get; set; }
        public List<PSNetworkWatcherConnectionMonitorOutputObject> Output { get; set; }

        [JsonIgnore]
        public string TestGroupText
        {
            get { return JsonConvert.SerializeObject(this.TestGroup, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }    
    }
}