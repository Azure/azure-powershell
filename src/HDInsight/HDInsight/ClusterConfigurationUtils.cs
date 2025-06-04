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

using Azure.Identity;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public static List<EntraUserInfo> GetHDInsightGatewayEntraUser(string EntraUserData)
        {
            List<EntraUserInfo> restAuthEntraUsers = new List<EntraUserInfo>();
            if (String.IsNullOrEmpty(EntraUserData))
            {
                return restAuthEntraUsers;
            }
            bool parsedFromJson = false;
            try
            {
                var jsonEntraUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(EntraUserData);
                if (jsonEntraUsers != null && jsonEntraUsers.Count > 0)
                    foreach (var userDict in jsonEntraUsers)
                    {
                        var dict = new Dictionary<string, string>(userDict, StringComparer.OrdinalIgnoreCase);
                        string objectId = dict.ContainsKey("ObjectId") ? dict["ObjectId"] : null;
                        string upn = dict.ContainsKey("Upn") ? dict["Upn"] : null;
                        string displayName = dict.ContainsKey("DisplayName") ? dict["DisplayName"] : null;
                        restAuthEntraUsers.Add(
                            new EntraUserInfo
                            {
                                ObjectId = objectId,
                                DisplayName = displayName,
                                Upn = upn
                            }
                        );
                    }
                parsedFromJson = true;
            }
            catch
            { // Ignore JSON parse errors
            }
            if (!parsedFromJson)
            {
                try
                {
                    var userdata = EntraUserData
                     .Split(new[] { ';',','}, StringSplitOptions.RemoveEmptyEntries)
                     .Select(s => s.Trim())
                     .Where(s => !string.IsNullOrEmpty(s))
                     .ToList();
                    var graphClient = new GraphServiceClient(new DefaultAzureCredential());
                    foreach (var data in userdata)
                    {
                        try
                        {
                            var user = graphClient.Users[data].GetAsync().GetAwaiter().GetResult();
                            restAuthEntraUsers.Add(new EntraUserInfo
                            {
                                ObjectId = user.Id,
                                DisplayName = user.DisplayName,
                                Upn = user.UserPrincipalName
                            });
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Failed to resolve Entra user from input: {data}", ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to resolve EntraUserData from input: {EntraUserData}", ex);
                }
            }
            return restAuthEntraUsers;
        }

    }
}
