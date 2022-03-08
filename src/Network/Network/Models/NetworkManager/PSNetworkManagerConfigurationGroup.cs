using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerConfigurationGroup
    {
        public string Id { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string MemberType { get; set; }

        public IList<PSNetworkManagerGroupMembersItem> GroupMembers { get; set; }

        public string ConditionalMembership { get; set; }

        public string ProvisioningState { get; private set; }

        [JsonIgnore]
        public string GroupMembersText
        {
            get { return JsonConvert.SerializeObject(GroupMembers, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
