using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSPrivateDnsZoneGroup : PSChildResource
    {
        public string ProvisioningState { get; set; }

        public List<PSPrivateDnsZoneConfig> PrivateDnsZoneConfigs { get; set; }

        [JsonIgnore]
        public string PrivateDnsZoneConfigsText
        {
            get { return JsonConvert.SerializeObject(PrivateDnsZoneConfigs, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
