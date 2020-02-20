using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSPrivateLinkResource
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Id { get; set; }

        public string GroupId { get; set; }

        public List<string> RequiredMembers { get; set; }

        [JsonIgnore]
        public string RequiredMembersText
        {
            get { return JsonConvert.SerializeObject(RequiredMembers, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
