using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.PowerBIDedicated.Models;

namespace Microsoft.Azure.Commands.PowerBIDedicated.Models
{
    public class CapacitySku
    {
        public string Name { get; set; }

        public string Tier { get; set; }

        internal static Dictionary<string, string> FromResourceSku(ResourceSku resourceSku)
        {
            Dictionary<string, string> sku = new Dictionary<string, string>();
            sku["Name"] = resourceSku.Name;
            sku["Tier"] = resourceSku.Tier;
            return sku;
        }
    }
}
