namespace Microsoft.Azure.Commands.Network.Models.Bastion
{
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MNM = Management.Network.Models;

    public class PSBastionSku
    {
        [Ps1Xml(Target = ViewControl.List)]
        public string Name { get; set; }

        public const string Basic = "Basic";
        public const string Standard = "Standard";

        public PSBastionSku(string skuName = null)
        {
            if (string.IsNullOrWhiteSpace(skuName))
            {
                this.Name = MNM.BastionHostSkuName.Standard;
            }

            this.Name = GetSkuTier().FirstOrDefault(sku => sku.Equals(skuName, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<string> GetSkuTier()
        {
            yield return Basic;
            yield return Standard;
        }

        public static bool TryGetSkuTier(string skuTier, out string skuTierValue)
        {
            skuTierValue = null;
            if (string.Equals(skuTier, Basic, StringComparison.OrdinalIgnoreCase))
            {
                skuTierValue = Basic;
                return true;
            }
            if (string.Equals(skuTier, Standard, StringComparison.OrdinalIgnoreCase))
            {
                skuTierValue = Standard;
                return true;
            }
            return false;
        }
    }
}
