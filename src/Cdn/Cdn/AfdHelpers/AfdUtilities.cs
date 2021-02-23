// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Cdn.AfdModels;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;

namespace Microsoft.Azure.Commands.Cdn.AfdHelpers
{
    public static class AfdUtilities
    {
        public static bool IsValuePresent(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static string GetResourceName(this ResourceIdentifier resourceId, string resourceType)
        {
            string[] splitNames = resourceId.ToString().Split(new[] { '/' });

            for (int i = 0; i < splitNames.Length; i++)
            {
                if (splitNames[i].Equals(resourceType, StringComparison.OrdinalIgnoreCase))
                {
                    return splitNames[i + 1];
                }
            }

            return string.Empty;
        }
 
        public static Sku GenerateAfdProfileSku(string sku)
        {
            string lowercaseSku = sku.ToLower();

            Sku afdSku = new Sku();

            switch(lowercaseSku)
            {
                case "premium_azurefrontdoor":
                    afdSku.Name = AfdSkuConstants.PremiumAzureFrontDoor;
                    break;

                case "standard_azurefrontdoor":
                    afdSku.Name = AfdSkuConstants.StandardAzureFrontDoor;
                    break;

                default:
                    afdSku = null;
                    break;
            }

            return afdSku;
        }

        public static bool IsAfdProfile(PSAfdProfile psAfdProfile)
        {
            if (psAfdProfile.Sku == AfdSkuConstants.PremiumAzureFrontDoor || psAfdProfile.Sku == AfdSkuConstants.StandardAzureFrontDoor)
            {
                return true;
            }

            return false;
        }
    }
}
