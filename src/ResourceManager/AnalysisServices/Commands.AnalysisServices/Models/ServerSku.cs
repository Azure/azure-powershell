using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Analysis.Models;

namespace Microsoft.Azure.Commands.AnalysisServices.Models
{
    public class ServerSku
    {
        public string Name { get; set; }

        public string Tier { get; set; }

        public int Capacity { get; set; }

        internal static ServerSku FromResourceSku(ResourceSku resourceSku)
        {
			ServerSku sku = new ServerSku();
            sku.Name = resourceSku.Name;
            sku.Tier = resourceSku.Tier;
            sku.Capacity = resourceSku.Capacity == null ? 1 : resourceSku.Capacity.Value;
            return sku;
        }
    }
}
