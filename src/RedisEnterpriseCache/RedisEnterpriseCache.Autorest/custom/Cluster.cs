// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models
{
    public partial class Cluster
    {
        public System.Collections.Hashtable Database { get; set; }

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject container)
        {
            if (SkuName?.StartsWith("Enterprise_", System.StringComparison.Ordinal) == true ||
                SkuName?.StartsWith("EnterpriseFlash_", System.StringComparison.Ordinal) == true)
            {
                return;
            }

            if (container.TryGetValue("sku", out var skuNode) &&
                skuNode is Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonObject sku)
            {
                sku.Remove("capacity");
            }
        }
    }
}