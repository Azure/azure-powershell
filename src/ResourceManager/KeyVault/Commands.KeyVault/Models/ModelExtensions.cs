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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using KeyVaultManagement = Microsoft.Azure.Management.KeyVault;
using PSModels = Microsoft.Azure.Commands.KeyVault.Models;
using ResourceManagement = Microsoft.Azure.Management.Resources.Models;
using ResourceManagerModels = Microsoft.Azure.Commands.Resources.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    static class ModelExtensions
    {

        //public static PSModels.Vault ToPSVault(this KeyVaultManagement.Vault vault, ActiveDirectoryClient adClient = null)
        //{
        //    var vaultTenantDisplayName = GetDisplayNameForTenant(vault.Properties.TenantId, adClient);
        //    return new PSModels.Vault()
        //    {
        //        VaultName = vault.Name,
        //        Location = vault.Location,
        //        ResourceId = vault.Id,
        //        ResourceGroupName = (new ResourceManagerModels.ResourceIdentifier(vault.Id)).ResourceGroupName,
        //        Tags = ResourceManagerModels.TagsConversionHelper.CreateTagHashtable(vault.Tags),
        //        Sku = vault.Properties.Sku.Name,
        //        TenantId = vault.Properties.TenantId,
        //        TenantName = vaultTenantDisplayName,
        //        VaultUri = vault.Properties.VaultUri,
        //        EnabledForDeployment = vault.Properties.EnabledForDeployment,
        //        AccessPolicies = vault.Properties.AccessPolicies.Select(s =>
        //            new PSModels.VaultAccessPolicy()
        //            {
        //                ObjectId = s.ObjectId,
        //                DisplayName = GetDisplayNameForADObject(s.ObjectId, adClient),
        //                TenantId = s.TenantId,
        //                TenantName = s.TenantId == vault.Properties.TenantId ? vaultTenantDisplayName : s.TenantId.ToString(),
        //                PermissionsToSecrets = s.PermissionsToSecrets,
        //                PermissionsToKeys = s.PermissionsToKeys
        //            }).ToArray(),
        //        OriginalVault = vault
        //    };
        //}

        public static string ConstructAccessPoliciesTableAsTable(IEnumerable<PSModels.VaultAccessPolicy> policies)
        {
            StringBuilder sb = new StringBuilder();

            if (policies != null && policies.Count() > 0)
            {                
                string rowFormat = "{0, -40}  {1, -40}  {2, -40} {3, -40}\r\n";
                sb.AppendLine();
                sb.AppendFormat(rowFormat, "Tenant ID", "Object ID", "Permissions to keys", "Permissions to secrets");
                sb.AppendFormat(rowFormat, 
                    GeneralUtilities.GenerateSeparator("Tenant ID".Length, "="), 
                    GeneralUtilities.GenerateSeparator("Object ID".Length, "="), 
                    GeneralUtilities.GenerateSeparator("Permissions To Keys".Length, "="), 
                    GeneralUtilities.GenerateSeparator("Permissions To Secrets".Length, "="));

                foreach(var policy in policies)
                {
                    sb.AppendFormat(rowFormat, policy.TenantId.ToString(), policy.DisplayName, TrimWithEllipsis(policy.PermissionsToKeysStr, 40), TrimWithEllipsis(policy.PermissionsToSecretsStr, 40));
                }

            }

            return sb.ToString();
        }

        public static string ConstructAccessPoliciesList(IEnumerable<PSModels.VaultAccessPolicy> policies)
        {
            StringBuilder sb = new StringBuilder();

            if (policies != null && policies.Count() > 0)
            {
                sb.AppendLine();
                foreach(var policy in policies)
                {                    
                    sb.AppendFormat("{0, -25}:\t{1}\r\n", "Tenant ID", policy.TenantName);
                    sb.AppendFormat("{0, -25}:\t{1}\r\n", "Object ID", policy.ObjectId);
                    sb.AppendFormat("{0, -25}:\t{1}\r\n", "Display Name", policy.DisplayName);
                    sb.AppendFormat("{0, -25}:\t{1}\r\n", "Permissions to Keys", policy.PermissionsToKeysStr);
                    sb.AppendFormat("{0, -25}:\t{1}\r\n", "Permissions to Secrets", policy.PermissionsToSecretsStr);
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }
        private static string TrimWithEllipsis(string str, int maxLen)
        {
            if (str != null && str.Length > maxLen)
            {
                return string.Concat(str.Substring(0, maxLen - 3), "...");
            }
            else
                return str;
        }

        public static string GetDisplayNameForADObject(Guid id, ActiveDirectoryClient adClient)
        {
            string displayName = "";            

            if (id == null || adClient == null || id == Guid.Empty)
                return displayName;
            else
            {
                string upnOrSpn = "";

                var obj = adClient.GetADObject(new ADObjectFilterOptions()
                {
                    Id = id.ToString(),                    
                    Paging = true,
                });

                if (obj != null)
                {
                    displayName = obj.DisplayName;
                    if (obj is PSADUser)
                        upnOrSpn = ((PSADUser)obj).UserPrincipalName;
                    else if (obj is PSADServicePrincipal)
                        upnOrSpn = ((PSADServicePrincipal)obj).ServicePrincipalName;
                }

                return displayName + (!string.IsNullOrWhiteSpace(upnOrSpn) ? (" (" + upnOrSpn + ")") : "");
            }
        }

        public static string GetDisplayNameForTenant(Guid id, ActiveDirectoryClient adClient)
        {
            return id.ToString();
        }
    }
}
