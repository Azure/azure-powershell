using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSPrivateLinkServiceResourceSet
    {
        public List<string> Subscriptions { get; set; }
    }
}
