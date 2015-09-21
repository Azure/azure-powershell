using System;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.Websites.Validations
{
    public class ValidateServerFarmAttribute : ValidateArgumentsAttribute
    {
        protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            var serverFarm = arguments as ServerFarmWithRichSku;
            if (serverFarm == null)
            {
                throw new ValidationMetadataException("Argument 'ServerFarm' must be of type Microsoft.Azure.Management.WebSites.Models.ServerFarmWithRichSku");
            }

            ValidateSku(serverFarm.Sku);
        }

        private void ValidateSku(SkuDescription sku)
        {
            if (sku == null)
            {
                throw new ValidationMetadataException("Argument 'ServerFarm.SKU' cannot be null");
            }

            const string skuNamePattern = "^[fdbspFDBSP][1-9]$";
            if (!Regex.IsMatch(sku.Name, skuNamePattern))
            {
                throw new ValidationMetadataException("Argument 'ServerFarm.SKU.Name' must conform to format first letter of sku name and numerical value of worker size. Worker Size [Small = 1, Medium = 2, Large = 3, ExtraLarge = 4] For instance, F1 means free small workers, P3 means premium large workers. ");
            }

            const string tierPattern = "^(Free|Shared|Basic|Standard|Premium)$";
            if (!Regex.IsMatch(sku.Tier, tierPattern, RegexOptions.IgnoreCase))
            {
                throw new ValidationMetadataException("Argument 'ServerFarm.SKU.Tier' must be one of Free|Shared|Basic|Standard|Premium");
            }

            var firstLetter = string.Equals("Shared", sku.Tier, StringComparison.OrdinalIgnoreCase) ? 'D' : sku.Tier[0];
            if (char.ToUpperInvariant(firstLetter) != char.ToUpperInvariant(sku.Name[0]))
            {
                throw new ValidationMetadataException(string.Format("Arguments 'ServerFarm.SKU.Name' and 'ServerFarm.SKU.Tier' must point to the same tier. [F = Free, D = Shared, B = Basic, S = Standard, P = Premium]. Current values: SKU.Name = {0}, SKU.Tier = {1}", sku.Name, sku.Tier));
            }
        }

        public override string ToString()
        {
            return "[ValidateServerFarm]";
        }
    }
}
