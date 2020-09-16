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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure.OData;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    
    public class BackupUtils
    {
        /// <summary>
        /// Get Protected Items for particular workload type
        /// </summary>
        public static List<ProtectedItemResource> GetProtectedItems(
            string vaultName,
            string resourceGroupName,
            string BackupManagementType,
            string DataSourceType,
            ServiceClientAdapter serviceClientAdapter)
        {
                ODataQuery<ProtectedItemQueryObject> queryParams = new ODataQuery<ProtectedItemQueryObject>(
                                                                    q => q.BackupManagementType
                                                                            == BackupManagementType &&
                                                                         q.ItemType == DataSourceType);

                List<ProtectedItemResource> protectedItems = new List<ProtectedItemResource>();
                
                var listResponse = serviceClientAdapter.ListProtectedItem(
                    queryParams,
                    skipToken: null,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);
                protectedItems.AddRange(listResponse);

                return protectedItems;
        }

        /// <summary>
        /// Get protection containers count from BackupUsageSummary
        /// </summary>
        public static long? GetProtectionContainersCount(string vaultName, string resourceGroupName, ServiceClientAdapter serviceClientAdapter) {

            ODataQuery<BMSBackupSummariesQueryObject> queryFilter = new ODataQuery<BMSBackupSummariesQueryObject>(
                                                                q => q.Type == "BackupProtectionContainerCountSummary");

            long? containersCount = 0;
            IEnumerable<BackupManagementUsage> backupUsageSummary = serviceClientAdapter.GetBackupUsageSummary(
                vaultName, resourceGroupName, queryFilter);
            foreach (BackupManagementUsage containerSummary in backupUsageSummary)
            {
                containersCount += containerSummary.CurrentValue;
            }
            
            return containersCount;
        }
    }
}

