namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSNetworkWatcherConnectionMonitorObject
    {
        public string NetworkWatcherName { get; set; }

        public string ResourceGroupName { get; set; }

        public string Name { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public List<PSNetworkWatcherConnectionMonitorTestGroupObject> TestGroups { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public List<PSNetworkWatcherConnectionMonitorOutputObject> Outputs { get; set; }

        public string Notes { get; set; }

        public Dictionary<string, string> Tags { get; set; }

        public string TagsText
        {
            get { return JsonConvert.SerializeObject(this.Tags, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string TestGroupsText
        {
            get { return JsonConvert.SerializeObject(this.TestGroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string OutputsText
        {
            get { return JsonConvert.SerializeObject(this.Outputs, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}