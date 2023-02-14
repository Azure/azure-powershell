using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSPrivateDnsZoneConfigRecordSet
    {
        public string RecordType { get; set; }

        public string RecordSetName { get; set; }

        public string Fqdn { get; set; }
        public string ProvisioningState { get; set; }

        public int Ttl { get; set; }

        public IList<string> IpAddresses { get; set; }

        [JsonIgnore]
        public string IpAddressesText
        {
            get { return JsonConvert.SerializeObject(IpAddresses, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
