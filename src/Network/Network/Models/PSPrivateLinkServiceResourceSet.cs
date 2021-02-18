using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSPrivateLinkServiceResourceSet
    {
        public List<string> Subscriptions { get; set; }
<<<<<<< HEAD
=======

        [JsonIgnore]
        public string SubscriptionsText
        {
            get { return JsonConvert.SerializeObject(Subscriptions, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
