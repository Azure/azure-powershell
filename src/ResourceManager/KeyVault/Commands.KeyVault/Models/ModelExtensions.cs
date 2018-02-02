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

#if NETSTANDARD
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
#else
using Microsoft.Azure.ActiveDirectory.GraphClient;
#endif
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSModels = Microsoft.Azure.Commands.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    static class ModelExtensions
    {

        public static string ConstructAccessPoliciesTableAsTable(IEnumerable<PSModels.PSVaultAccessPolicy> policies)
        {
            StringBuilder sb = new StringBuilder();

            if (policies != null && policies.Any())
            {
                string rowFormat = "{0, -43}  {1, -43}  {2, -43} {3, -43} {4, -43} {5, -43} {6, -43}\r\n";
                sb.AppendLine();
                sb.AppendFormat( rowFormat, "Tenant ID", "Object ID", "Application ID", "Permissions to keys", "Permissions to secrets", "Permissions to certificates", "Permissions to (Key Vault Managed) storage" );
                sb.AppendFormat(rowFormat,
                    GeneralUtilities.GenerateSeparator("Tenant ID".Length, "="),
                    GeneralUtilities.GenerateSeparator("Object ID".Length, "="),
                    GeneralUtilities.GenerateSeparator("Application ID".Length, "="),
                    GeneralUtilities.GenerateSeparator("Permissions To Keys".Length, "="),
                    GeneralUtilities.GenerateSeparator("Permissions To Secrets".Length, "="),
                    GeneralUtilities.GenerateSeparator("Permissions To Certificates".Length, "="),
                    GeneralUtilities.GenerateSeparator("Permissions To (Key Vault Managed) Storage".Length, "="));

                foreach (var policy in policies)
                {
                    sb.AppendFormat(rowFormat, policy.TenantId.ToString(), policy.DisplayName, policy.ApplicationIdDisplayName,
                        TrimWithEllipsis(policy.PermissionsToKeysStr, 40), TrimWithEllipsis(policy.PermissionsToSecretsStr, 40),
                        TrimWithEllipsis( policy.PermissionsToCertificatesStr, 40 ), TrimWithEllipsis( policy.PermissionsToStorageStr, 40 ) );
                }

            }

            return sb.ToString();
        }

        public static string ConstructAccessPoliciesList(IEnumerable<PSModels.PSVaultAccessPolicy> policies)
        {
            StringBuilder sb = new StringBuilder();

            if (policies != null && policies.Any())
            {
                sb.AppendLine();
                foreach(var policy in policies)
                {
                    sb.AppendFormat( "{0, -43}: {1}\r\n", "Tenant ID", policy.TenantName );
                    sb.AppendFormat( "{0, -43}: {1}\r\n", "Object ID", policy.ObjectId );
                    sb.AppendFormat( "{0, -43}: {1}\r\n", "Application ID", policy.ApplicationIdDisplayName );
                    sb.AppendFormat( "{0, -43}: {1}\r\n", "Display Name", policy.DisplayName );
                    sb.AppendFormat( "{0, -43}: {1}\r\n", "Permissions to Keys", policy.PermissionsToKeysStr );
                    sb.AppendFormat( "{0, -43}: {1}\r\n", "Permissions to Secrets", policy.PermissionsToSecretsStr );
                    sb.AppendFormat( "{0, -43}: {1}\r\n", "Permissions to Certificates", policy.PermissionsToCertificatesStr );
                    sb.AppendFormat( "{0, -43}: {1}\r\n", "Permissions to (Key Vault Managed) Storage", policy.PermissionsToStorageStr );
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

            return str;
        }

        public static string GetDisplayNameForADObject(string objectId, ActiveDirectoryClient adClient)
        {
            string displayName = "";
            string upnOrSpn = "";

            if (adClient == null || string.IsNullOrWhiteSpace(objectId))
                return displayName;

            try
            {
#if NETSTANDARD
                var obj = adClient.GetObjectsByObjectId(new List<string> { objectId }).FirstOrDefault();
                if (obj != null)
                {
                    if (obj.Type.Equals("user", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var user = adClient.FilterUsers(new ADObjectFilterOptions { Id = objectId }).FirstOrDefault();
                        displayName = user.DisplayName;
                        upnOrSpn = user.UserPrincipalName;
                    }
                    else if (obj.Type.Equals("serviceprincipal", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var servicePrincipal = adClient.FilterServicePrincipals(new ADObjectFilterOptions { Id = objectId }).FirstOrDefault();
                        displayName = servicePrincipal.DisplayName;
                        upnOrSpn = servicePrincipal.ServicePrincipalNames.FirstOrDefault();
                    }
                }
#else
                var obj = adClient.GetObjectsByObjectIdsAsync(new[] { objectId }, new string[] { }).GetAwaiter().GetResult().FirstOrDefault();
                if (obj != null)
                {
                    if (obj.ObjectType.Equals("user", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var user = adClient.Users.GetByObjectId(objectId).ExecuteAsync().GetAwaiter().GetResult();
                        displayName = user.DisplayName;
                        upnOrSpn = user.UserPrincipalName;
                    }
                    else if (obj.ObjectType.Equals("serviceprincipal", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var servicePrincipal = adClient.ServicePrincipals.GetByObjectId(objectId).ExecuteAsync().GetAwaiter().GetResult();
                        displayName = servicePrincipal.AppDisplayName;
                        upnOrSpn = servicePrincipal.ServicePrincipalNames.FirstOrDefault();
                    }
                }

#endif
            }
            catch
            {
                // Error occured. Don't get the friendly name
            }

            return displayName + (!string.IsNullOrWhiteSpace(upnOrSpn) ? (" (" + upnOrSpn + ")") : "");
        }

        public static string GetDisplayNameForTenant(Guid id, ActiveDirectoryClient adClient)
        {
            return id.ToString();
        }
    }
}
