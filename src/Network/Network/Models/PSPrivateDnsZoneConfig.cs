using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSPrivateDnsZoneConfig
    {
        public string Name { get; set; }

        public string PrivateDnsZoneId { get; set; }

        public string ProvisioningState { get; set; }

        public IList<PSPrivateDnsZoneConfigRecordSet> RecordSets { get; set; }

        [JsonIgnore]
        public string RecordSetsText
        {
            get { return JsonConvert.SerializeObject(RecordSets, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

    }
}
