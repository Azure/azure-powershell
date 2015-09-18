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
            IDictionary<string, string> configuration,
            string version)
        {
            string key = version.Equals("2.1") ? Constants.ClusterConfiguration.DefaultStorageAccountNameKeyOld
                : Constants.ClusterConfiguration.DefaultStorageAccountNameKey;

            string accountAndContainerStr;

            if (configuration.TryGetValue(key, out accountAndContainerStr))
            {
                string[] accountAndContainer = accountAndContainerStr.Substring("wasb://".Length).Split('@');

                return new AzureHDInsightDefaultStorageAccount
                {
                    StorageContainerName = accountAndContainer[0],
                    StorageAccountName = accountAndContainer[1],
                    StorageAccountKey = configuration[Constants.ClusterConfiguration.StorageAccountKeyPrefix + accountAndContainer[1]]
                };
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
    }
}
