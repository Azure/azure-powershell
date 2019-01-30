using Microsoft.Azure.Management.Reservations.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Reservations.Models
{
    public class PSCatalog
    {
        public string ResourceType { get; private set; }

        public string Name { get; private set; }

        public IList<string> Terms { get; private set; }

        public IList<string> Locations { get; private set; }

        public IList<SkuProperty> SkuProperties { get; private set; }

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
                Terms = catalog.Terms;
                Locations = catalog.Locations;
                SkuProperties = catalog.SkuProperties;
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

        public string PrintSkuProperties()
        {
            bool first = true;
            string builder = "";
            foreach (SkuProperty skuProperty in SkuProperties)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    builder += "\n";
                }
                builder += $"{skuProperty.Name}: {skuProperty.Value}";
            }
            return builder;
        }

        public string PrintRestrictions()
        {
            bool first = true;
            string builder = "";
            foreach (SkuRestriction restriction in Restrictions)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    builder += "\n";
                }
                string values = restriction.Values.Aggregate("", (current, value) => current + ", " + value);
                values = values.Length > 2 ? values.Substring(2) : values;
                builder += $"Type: {restriction.Type}\nValues: {values}\nReasonCode: {restriction.ReasonCode}";
            }
            return builder;
        }
    }
}
