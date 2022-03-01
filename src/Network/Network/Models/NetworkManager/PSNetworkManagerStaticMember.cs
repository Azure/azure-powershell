using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    class PSNetworkManagerStaticMember : PSNetworkManagerBaseResource
    {
        public List<PSNetworkManagerStaticMembersItem> StaticMembers { get; set; }
        
        [JsonIgnore]
        public string StaticMembersText
        {
            get { return JsonConvert.SerializeObject(StaticMembers, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
