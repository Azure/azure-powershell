using Microsoft.Azure.Management.Reservations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Reservations.Models
{
    public class PSCatalog
    {
        public string ResourceType { get; private set; }

        public string Name { get; private set; }

        public string Tier { get; private set; }

        public string Size { get; private set; }

        public IList<string> Terms { get; private set; }

        public IList<string> Locations { get; private set; }

        public IList<SkuCapability> Capabilities { get; private set; }

        public IList<SkuRestriction> Restrictions { get; private set; }

        public PSCatalog()
        {

        }

        public PSCatalog(Catalog catalog)
        {
            if (catalog != null)
            {
                ResourceType = catalog.ResourceType;
                Name = catalog.Name;
                Tier = catalog.Tier;
                Size = catalog.Size;
                Terms = catalog.Terms;
                Locations = catalog.Locations;
                Capabilities = catalog.Capabilities;
                Restrictions = catalog.Restrictions;
            }
        }

        public string PrintTerms()
        {
            string builder = "";
            foreach (string term in Terms)
            {
                builder += ", " + term;
            }
            if (builder.Length > 2)
                builder = builder.Substring(2);
            return builder;
        }

        public string PrintLocations()
        {
            string builder = "";
            foreach (string location in Locations)
            {
                builder += ", " + location;
            }
            if (builder.Length > 2)
                builder = builder.Substring(2);
            return builder;
        }

        public string PrintCapabilities()
        {
            string builder = "";
            foreach (SkuCapability capability in Capabilities)
            {
                builder += $"Name: {capability.Name}\nValue: {capability.Value}\n";
            }
            return builder;
        }

        public string PrintRestrictions()
        {
            string builder = "";
            foreach (SkuRestriction restriction in Restrictions)
            {
                string values = restriction.Values.Aggregate("", (current, value) => current + ", " + value);
                values = values.Length > 2 ? values.Substring(2) : values;
                builder += $"Type: {restriction.Type}\nValues: {values}\nReasonCode: {restriction.ReasonCode}\n";
            }
            return builder;
        }
    }
}
