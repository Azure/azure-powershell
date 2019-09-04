using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSPrivateLinkServiceResourceSet
    {
        public List<string> Subscriptions { get; set; }

        [JsonIgnore]
        public string SubscriptionsText
        {
            get { return JsonConvert.SerializeObject(Subscriptions, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
