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

using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Models
{
    /// <summary>
    ///    A wrapper for all ADLA supported data sources.
    ///    This object is returned from a GET
    /// </summary>
    public class PSDataLakeAnalyticsAccount : DataLakeAnalyticsAccount
    {
        /// <summary>
        /// Gets or sets the list of Data Lake storage accounts associated
        /// with this account.
        /// </summary>
        public new IList<PSDataLakeStoreAccountInfo> DataLakeStoreAccounts { get; set; }

        /// <summary>
        /// Gets or sets the list of Azure Blob storage accounts associated
        /// with this account.
        /// </summary>
        public new IList<PSStorageAccountInfo> StorageAccounts { get; set; }

        public PSDataLakeAnalyticsAccount(DataLakeAnalyticsAccount baseAccount) :
            base(
                baseAccount.Location,
                baseAccount.DefaultDataLakeStoreAccount,
                baseAccount.DataLakeStoreAccounts,
                baseAccount.Id,
                baseAccount.Name,
                baseAccount.Type,
                baseAccount.Tags,
                baseAccount.ProvisioningState,
                baseAccount.State,
                baseAccount.CreationTime,
                baseAccount.LastModifiedTime,
                baseAccount.Endpoint,
                baseAccount.AccountId,
                baseAccount.MaxDegreeOfParallelism,
                baseAccount.QueryStoreRetention,
                baseAccount.MaxJobCount,
                baseAccount.SystemMaxDegreeOfParallelism,
                baseAccount.SystemMaxJobCount,
                baseAccount.StorageAccounts,
                baseAccount.NewTier,
                baseAccount.CurrentTier,
                baseAccount.FirewallState,
                baseAccount.FirewallAllowAzureIps,
                baseAccount.FirewallRules,
                baseAccount.MaxDegreeOfParallelismPerJob,
                baseAccount.MinPriorityPerJob,
                baseAccount.ComputePolicies)
        {
            if (baseAccount.DataLakeStoreAccounts != null)
            {
                DataLakeStoreAccounts = new List<PSDataLakeStoreAccountInfo>(baseAccount.DataLakeStoreAccounts.Count);
                foreach (var entry in baseAccount.DataLakeStoreAccounts)
                {
                    DataLakeStoreAccounts.Add(new PSDataLakeStoreAccountInfo(entry));
                }
            }

            if (baseAccount.StorageAccounts != null)
            {
                StorageAccounts = new List<PSStorageAccountInfo>(baseAccount.StorageAccounts.Count);
                foreach (var entry in baseAccount.StorageAccounts)
                {
                    StorageAccounts.Add(new PSStorageAccountInfo(entry));
                }
            }
        }
    }
}