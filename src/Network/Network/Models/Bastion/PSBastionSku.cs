// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network.Models.Bastion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSBastionSku
    {
        [Ps1Xml(Target = ViewControl.All)]
        public string Name { get; set; }

        public const string Basic = "Basic";
        public const string Standard = "Standard";
        public const string Premium = "Premium";

        public PSBastionSku(string skuName = null)
        {
            Name = Standard;
            if (!string.IsNullOrWhiteSpace(skuName))
            {
                Name = GetSkuTier().FirstOrDefault(sku => sku.Equals(skuName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public static IEnumerable<string> GetSkuTier()
        {
            yield return Basic;
            yield return Standard;
            yield return Premium;
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
            if (string.Equals(skuTier, Premium, StringComparison.OrdinalIgnoreCase))
            {
                skuTierValue = Premium;
                return true;
            }
            return false;
        }
    }
}
