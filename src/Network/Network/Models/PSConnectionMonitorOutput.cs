namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSNetworkWatcherConnectionMonitorOutputObject
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string Type { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public PSConnectionMonitorWorkspaceSettings WorkspaceSettings { get; set; }

        [JsonIgnore]
        public string WorkspaceSettingsText
        {
            get { return JsonConvert.SerializeObject(this.WorkspaceSettings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
