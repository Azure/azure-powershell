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

using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
namespace Microsoft.Azure.Commands.HDInsight.Models
{
    internal class ClusterConfigurationUtils
    {
        public static string GetResourceGroupFromClusterId(string clusterId)
        {
            // Parse resource group from cluster Id
            // The code expects Id to be of the format \
            // /subscriptions/<subscription ID>/resourceGroups/<Resource Group Id>/providers/Microsoft.HDInsight/clusters/<cluster name>

            string resourceGroup = null;
            int index = clusterId.IndexOf("resourceGroups", StringComparison.OrdinalIgnoreCase);

            if (index >= 0)
            {
                index += "resourceGroups".Length;
                string[] parts = clusterId.Substring(index).Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length > 0)
                {
                    resourceGroup = parts[0];
                }
            }

            return resourceGroup;
        }

        public static AzureHDInsightDefaultStorageAccount GetDefaultStorageAccountDetails(
            string version,
            IDictionary<string, string> coreSiteConfiguration,
            IDictionary<string, string> clusterIdentityConfiguration = null)
        {
            string key = version.Equals("2.1") ? Constants.ClusterConfiguration.DefaultStorageAccountNameKeyOld
                : Constants.ClusterConfiguration.DefaultStorageAccountNameKey;

            string defaultFSUrl;
            const string AdlPrefix = "adl://";
            const string WasbPrefix = "wasb://";
            const string SecureWasbPrefix = "wasbs://";
            const string AdlsGen2Prefix = "abfs://";
            const string AdlsGen2TLSPrefix = "abfss://";

            if (coreSiteConfiguration.TryGetValue(key, out defaultFSUrl))
            {
                if (defaultFSUrl.StartsWith(AdlPrefix))
                {
                    string appId, tenantId, certContents, certPassword, resourceUri, storageRootPath;
                    clusterIdentityConfiguration = clusterIdentityConfiguration ?? new Dictionary<string, string> { };
                    clusterIdentityConfiguration.TryGetValue("clusterIdentity.applicationId", out appId);
                    clusterIdentityConfiguration.TryGetValue("clusterIdentity.aadTenantId", out tenantId);
                    clusterIdentityConfiguration.TryGetValue("clusterIdentity.certificate", out certContents);
                    clusterIdentityConfiguration.TryGetValue("clusterIdentity.certificatePassword", out certPassword);
                    clusterIdentityConfiguration.TryGetValue("clusterIdentity.resourceUri", out resourceUri);
                    storageRootPath = coreSiteConfiguration.Single(k => k.Key.StartsWith("dfs.adls.") && k.Key.EndsWith(".mountpoint")).Value;

                    return new AzureHDInsightDataLakeDefaultStorageAccount
                    (
                        storageAccountName: coreSiteConfiguration.Single(k => k.Key.StartsWith("dfs.adls.") && k.Key.EndsWith(".hostname")).Value,
                        storageRootPath: storageRootPath,
                        applicationId: appId,
                        tenantId: tenantId,
                        certificateContents: null,
                        certificatePassword: certPassword,
                        resourceUri: resourceUri
                    );
                }
                else if (defaultFSUrl.StartsWith(WasbPrefix) || defaultFSUrl.StartsWith(SecureWasbPrefix))
                {
                    string[] accountAndContainer;
                    if (defaultFSUrl.StartsWith(WasbPrefix))
                    {
                        accountAndContainer = defaultFSUrl.Substring(WasbPrefix.Length).Split('@');
                    }
                    else
                    {
                        accountAndContainer = defaultFSUrl.Substring(SecureWasbPrefix.Length).Split('@');
                    }

                    string storageAccountKey;
                    coreSiteConfiguration.TryGetValue(Constants.ClusterConfiguration.StorageAccountKeyPrefix + accountAndContainer[1], out storageAccountKey);

                    return new AzureHDInsightWASBDefaultStorageAccount
                    (
                        storageContainerName: accountAndContainer[0],
                        storageAccountName: accountAndContainer[1],
                        storageAccountKey: storageAccountKey
                    );
                }
                else if (defaultFSUrl.StartsWith(AdlsGen2Prefix) || defaultFSUrl.StartsWith(AdlsGen2TLSPrefix))
                {
                    string[] accountAndFileSystem;
                    accountAndFileSystem = defaultFSUrl.Substring(AdlsGen2Prefix.Length).Split('@');
                    return new AzureHDInsightDataLakeGen2DefaultStorageAccount(storageAccountName: accountAndFileSystem[1], storageFileSystem: accountAndFileSystem[0]);
                }
            }

            return null;
        }

        public static List<string> GetAdditionStorageAccounts(IDictionary<string, string> configuration, string defaultAccount)
        {
            // Parse the storage account names from the key and exclude the default one
            return (from key in configuration.Keys
                    where key.StartsWith(Constants.ClusterConfiguration.StorageAccountKeyPrefix, StringComparison.OrdinalIgnoreCase) &&
                    !key.EndsWith(defaultAccount, StringComparison.OrdinalIgnoreCase)
                    select key.Remove(0, Constants.ClusterConfiguration.StorageAccountKeyPrefix.Length)).ToList();
        }

        public static List<EntraUserInfo> GetHDInsightGatewayEntraUser(string[] EntraUserIdentity, Hashtable[] EntraUserFullInfo, IMicrosoftGraphClient graphClient)
        {
            List<EntraUserInfo> restAuthEntraUsers = new List<EntraUserInfo>();
            if (EntraUserIdentity!=null)
            {
                if (graphClient == null)
                {
                    throw new AzPSArgumentException(
                     "Your Azure credentials have not been set up or have expired, please run Connect-AzAccount to set up your Azure credentials.\n" +
                     "Authentication failed against resource MicrosoftGraphEndpointResourceId. User interaction is required. This may be due to the conditional access policy settings such as multi-factor authentication (MFA). Please rerun 'Connect-AzAccount' with additional parameter '-AuthScope MicrosoftGraphEndpointResourceId'.\n" +
                     "Alternatively, you can use the 'EntraUserFullInfo' parameter to manually specify the user details.", ErrorKind.UserError
                     );
                }
                List<string> userdata = EntraUserIdentity
                     .Select(s => s.Trim())
                     .Where(s => !string.IsNullOrEmpty(s))
                     .ToList();
                foreach (var data in userdata)
                {
                    try
                    {
                        var user = graphClient.Users.GetUser(data);
                        if(user == null)
                        {
                            throw new InvalidOperationException($"The Entra user retrieved for input \"{data}\" is null. Please confirm that the user exists in Microsoft Entra ID. ");
                        }
                        restAuthEntraUsers.Add(new EntraUserInfo
                        {
                            ObjectId = user.Id,
                            DisplayName = user.DisplayName,
                            Upn = user.UserPrincipalName
                        });
                    }
                    catch (InvalidOperationException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        throw new AzPSException($"Failed to retrieve Entra user info from input: \"{data}\". Please check the EntraUserIdentity parameter, or consider using the EntraUserFullInfo approach to specify user details.", ErrorKind.UserError, ex);
                    }
                }
            }
            else if (EntraUserFullInfo != null && EntraUserFullInfo.Length > 0)
            {
                var userDicts = EntraUserFullInfo.Select(user =>
                {
                    var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    foreach (DictionaryEntry entry in user)
                    {
                        dict[entry.Key.ToString()] = entry.Value.ToString();
                    }
                    return (IDictionary<string, string>)dict;
                });
                foreach (var userDict in userDicts)
                {
                    string objectId = userDict.TryGetValue("ObjectId", out var oid) ? oid : null;
                    string upn = userDict.TryGetValue("Upn", out var u) ? u : null;
                    string displayName = userDict.TryGetValue("DisplayName", out var dn) ? dn : null;
                    restAuthEntraUsers.Add(new EntraUserInfo
                    {
                        ObjectId = objectId,
                        DisplayName = displayName,
                        Upn = upn
                    });
                }
            }
            return restAuthEntraUsers;
        }
    }
}
