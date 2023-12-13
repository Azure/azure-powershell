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
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.DirectoryObjects;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Groups;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users.Models;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Models.ADObject;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PSModels = Microsoft.Azure.Commands.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    internal static class ModelExtensions
    {
        public const string UnknownType = "Unknown";

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
                    if (obj.IsUser())
                    {

                        var user = JsonConvert.DeserializeObject<MicrosoftGraphUser>(JsonConvert.SerializeObject(obj)).ToPSADUser();
                        displayName = user.DisplayName;
                        upnOrSpn = user.UserPrincipalName;
                        objectType = "User";
                    }
                    else if (obj.IsServicePrincipal())
                    {
                        var servicePrincipal = JsonConvert.DeserializeObject<MicrosoftGraphServicePrincipal>(JsonConvert.SerializeObject(obj)).ToPSADServicePrincipal();
                        displayName = servicePrincipal.DisplayName;
                        upnOrSpn = servicePrincipal.ServicePrincipalNames.FirstOrDefault();
                        objectType = "Service Principal";
                    }
                    else if (obj.IsGroup())
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

        private static List<PSADObject> GetObjectsByObjectIds(List<string> objectIds, IMicrosoftGraphClient graphClient)
        {
            // todo: do we want to use 1000 as batch count in msgraph API?
            List<PSADObject> result = new List<PSADObject>();

            if (graphClient == null || objectIds == null || !objectIds.Any())
                return result;
            
            IList<Common.MSGraph.Version1_0.DirectoryObjects.Models.MicrosoftGraphDirectoryObject> adObjects;
            int objectIdBatchCount;
            const int batchCount = 1000;
            for (int i = 0; i < objectIds.Count; i += batchCount)
            {
                if ((i + batchCount) > objectIds.Count)
                {
                    objectIdBatchCount = objectIds.Count - i;
                }
                else
                {
                    objectIdBatchCount = batchCount;
                }
                List<string> objectIdBatch = objectIds.GetRange(i, objectIdBatchCount);
                try
                {
                    adObjects = graphClient.DirectoryObjects.GetByIds(
                        new Common.MSGraph.Version1_0.DirectoryObjects.Models.Body()
                        {
                            Ids = objectIdBatch
                        })?.Value;
                    result.AddRange(adObjects?.Select(o => o.ToPSADObject()));
                }
                catch (Common.MSGraph.Version1_0.DirectoryObjects.Models.OdataErrorException)
                {
                    // Swallow OdataErroException
                }
            }
            return result;
        }

        internal static IEnumerable<PSKeyVaultAccessPolicy> ToPSKeyVaultAccessPolicies(this IEnumerable<AccessPolicyEntry> accessPolicies, IMicrosoftGraphClient graphClient)
        {
            if (graphClient == null)
            {
                return accessPolicies.Select(s => new PSKeyVaultAccessPolicy(s, graphClient));
            }
            
            List<PSKeyVaultAccessPolicy> psAccessPolicies = new List<PSKeyVaultAccessPolicy>();

            // The size of accessPolicies is 0
            if (accessPolicies == null || !accessPolicies.Any())
                {
                    return psAccessPolicies;
            }

            //  size of accessPolicies is 1
            if (accessPolicies.Count() == 1)
            {
                // Get assignment
                psAccessPolicies.Add(new PSKeyVaultAccessPolicy(accessPolicies.FirstOrDefault(), graphClient));
                return psAccessPolicies;
            }

            // The size of accessPolicies > 1
            // List ad objects
            List<string> objectIds = accessPolicies.Select(r => r.ObjectId).Distinct().ToList();
            List<PSADObject> adObjects = null;
            try
            {
                adObjects = GetObjectsByObjectIds(objectIds, graphClient);
            }
            catch (Common.MSGraph.Version1_0.DirectoryObjects.Models.OdataErrorException)
            {
                // Swallow OdataErrorException
                adObjects = new List<PSADObject>();
            }


            // Union role definition and ad objects
            foreach (AccessPolicyEntry accessPolicy in accessPolicies)
            {
                PSADObject adObject = adObjects.SingleOrDefault(o => o.Id == accessPolicy.ObjectId) ?? new PSADObject() { Id = accessPolicy.ObjectId, Type = UnknownType };
                psAccessPolicies.Add(new PSKeyVaultAccessPolicy(accessPolicy, adObject.DisplayName));
            }
            return psAccessPolicies;
        }
    }
}
