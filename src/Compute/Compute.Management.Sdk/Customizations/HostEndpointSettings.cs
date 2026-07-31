namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;

    public partial class HostEndpointSettings
    {
        [JsonProperty(PropertyName = "useLocalFileRules")]
        public bool? UseLocalFileRules { get; set; }
    }
}
