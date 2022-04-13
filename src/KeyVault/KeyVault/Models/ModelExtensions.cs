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

using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.DirectoryObjects;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Groups;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSModels = Microsoft.Azure.Commands.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    internal static class ModelExtensions
    {
        public static string ConstructAccessPoliciesTableAsTable(IEnumerable<PSModels.PSKeyVaultAccessPolicy> policies)
        {
            if (policies == null || !policies.Any()) return string.Empty;

            const string rowFormat = "{0, -43}  {1, -43}  {2, -43} {3, -43} {4, -43} {5, -43} {6, -43}\r\n";
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendFormat(rowFormat, "Tenant ID", "Object ID", "Application ID", "Permissions to keys", "Permissions to secrets", "Permissions to certificates", "Permissions to (Key Vault Managed) storage");
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
                    TrimWithEllipsis(policy.PermissionsToCertificatesStr, 40), TrimWithEllipsis(policy.PermissionsToStorageStr, 40));
            }

            return sb.ToString();
        }

        public static string ConstructAccessPoliciesList(IEnumerable<PSModels.PSKeyVaultAccessPolicy> policies)
        {
            if (policies == null || !policies.Any()) return string.Empty;

            var sb = new StringBuilder();
            sb.AppendLine();
            foreach (var policy in policies)
            {
                sb.AppendFormat("{0, -43}: {1}\r\n", "Tenant ID", policy.TenantName);
                sb.AppendFormat("{0, -43}: {1}\r\n", "Object ID", policy.ObjectId);
                sb.AppendFormat("{0, -43}: {1}\r\n", "Application ID", policy.ApplicationIdDisplayName);
                sb.AppendFormat("{0, -43}: {1}\r\n", "Display Name", policy.DisplayName);
                sb.AppendFormat("{0, -43}: {1}\r\n", "Permissions to Keys", policy.PermissionsToKeysStr);
                sb.AppendFormat("{0, -43}: {1}\r\n", "Permissions to Secrets", policy.PermissionsToSecretsStr);
                sb.AppendFormat("{0, -43}: {1}\r\n", "Permissions to Certificates", policy.PermissionsToCertificatesStr);
                sb.AppendFormat("{0, -43}: {1}\r\n", "Permissions to (Key Vault Managed) Storage", policy.PermissionsToStorageStr);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static string ConstructNetworkRuleSet(PSModels.PSKeyVaultNetworkRuleSet ruleSet)
        {
            if (ruleSet == null) return string.Empty;

            var sb = new StringBuilder();
            sb.AppendLine();

            sb.AppendFormat("{0, -43}: {1}\r\n", "Default Action", ruleSet.DefaultAction);
            sb.AppendFormat("{0, -43}: {1}\r\n", "Bypass", ruleSet.Bypass);

            sb.AppendFormat("{0, -43}: {1}\r\n", "IP Rules", ruleSet.IpAddressRangesText);
            sb.AppendFormat("{0, -43}: {1}\r\n", "Virtual Network Rules", ruleSet.VirtualNetworkResourceIdsText);

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

        public static string GetDisplayNameForADObject(string objectId, IMicrosoftGraphClient graphClient) =>
            GetDetailsFromADObjectId(objectId, graphClient).Item1;

        public static (string, string) GetDetailsFromADObjectId(string objectId, IMicrosoftGraphClient graphClient)
        {
            var displayName = "";
            var upnOrSpn = "";
            var objectType = "Unknown";

            if (graphClient == null || string.IsNullOrWhiteSpace(objectId))
                return (displayName, objectType);

            try
            {
                var obj = graphClient.DirectoryObjects.GetDirectoryObject(objectId);
                if (obj != null)
                {
                    if (obj.Odatatype.Equals("#microsoft.graph.user", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var user = graphClient.Users.GetUser(objectId);
                        displayName = user.DisplayName;
                        upnOrSpn = user.UserPrincipalName;
                        objectType = "User";
                    }
                    else if (obj.Odatatype.Equals("#microsoft.graph.serviceprincipal", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var servicePrincipal = graphClient.ServicePrincipals.GetServicePrincipal(objectId);
                        displayName = servicePrincipal.DisplayName;
                        upnOrSpn = servicePrincipal.ServicePrincipalNames.FirstOrDefault();
                        objectType = "Service Principal";
                    }
                    else if (obj.Odatatype.Equals("#microsoft.graph.group", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var group = graphClient.Groups.GetGroup(objectId);
                        displayName = group.DisplayName;
                        objectType = "Group";
                    }
                }
            }
            catch
            {
                // Error occurred. Don't get the friendly name
            }

            return (
                displayName + (!string.IsNullOrWhiteSpace(upnOrSpn) ? (" (" + upnOrSpn + ")") : ""),
                objectType
            );

        }

        public static string GetDisplayNameForTenant(Guid id, IMicrosoftGraphClient graphClient)
        {
            if (id == null)
                return string.Empty;
            return id.ToString();
        }
    }
}
