using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Dns.Models;

namespace Microsoft.Azure.Commands.Dns.Models
{
    public static class DnsHelpers
    {
        public static IList<SubResource> ToVirtualNetworkResources(this IList<string> virtualNetworkIds)
        {
            if (virtualNetworkIds == null)
            {
                return null;
            }

            return virtualNetworkIds.Select(vn => new SubResource(vn)).ToList();
        }

        public static List<string> ToVirtualNetworkIds(this IList<SubResource> virtualNetworks)
        {
            return virtualNetworks != null ? virtualNetworks.Select(vn => vn.Id).ToList() : new List<string>();
        }
    }
}
