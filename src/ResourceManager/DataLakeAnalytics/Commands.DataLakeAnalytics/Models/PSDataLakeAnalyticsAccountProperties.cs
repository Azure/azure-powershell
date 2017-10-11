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
    [Obsolete("This class will be deprecated in a future release.")]
    public class PSDataLakeAnalyticsAccountProperties
    {
        /// <summary>
        /// Gets the provisioning status of the Data Lake Analytics account.
        /// Possible values include: 'Failed', 'Creating', 'Running',
        /// 'Succeeded', 'Patching', 'Suspending', 'Resuming', 'Deleting',
        /// 'Deleted'
        /// </summary>
        public DataLakeAnalyticsAccountStatus? ProvisioningState { get; private set; }

        /// <summary>
        /// Gets the state of the Data Lake Analytics account. Possible values
        /// include: 'active', 'suspended'
        /// </summary>
        public DataLakeAnalyticsAccountState? State { get; private set; }

        /// <summary>
        /// Gets or sets the default data lake storage account associated with
        /// this Data Lake Analytics account.
        /// </summary>
        public string DefaultDataLakeStoreAccount { get; set; }

        /// <summary>
        /// Gets or sets the maximum supported degree of parallelism for this
        /// account.
        /// </summary>
        public int? MaxDegreeOfParallelism { get; set; }

        /// <summary>
        /// Gets or sets the maximum supported jobs running under the account
        /// at the same time.
        /// </summary>
        public int? MaxJobCount { get; set; }

        /// <summary>
        /// Gets or sets the list of Data Lake storage accounts associated
        /// with this account.
        /// </summary>
        public IList<PSDataLakeStoreAccountInfo> DataLakeStoreAccounts { get; set; }

        /// <summary>
        /// Gets or sets the list of Azure Blob storage accounts associated
        /// with this account.
        /// </summary>
        public IList<PSStorageAccountInfo> StorageAccounts { get; set; }

        /// <summary>
        /// Gets the account creation time.
        /// </summary>
        public DateTime? CreationTime { get; private set; }

        /// <summary>
        /// Gets the account last modified time.
        /// </summary>
        public DateTime? LastModifiedTime { get; private set; }

        /// <summary>
        /// Gets the full CName endpoint for this account.
        /// </summary>
        public string Endpoint { get; private set; }

        public PSDataLakeAnalyticsAccountProperties(DataLakeAnalyticsAccount baseAccount)
        {
            MaxDegreeOfParallelism = baseAccount.MaxDegreeOfParallelism;
            MaxJobCount = baseAccount.MaxJobCount;
            LastModifiedTime = baseAccount.LastModifiedTime;
            CreationTime = baseAccount.CreationTime;
            State = baseAccount.State;
            ProvisioningState = baseAccount.ProvisioningState;
            DefaultDataLakeStoreAccount = baseAccount.DefaultDataLakeStoreAccount;
            Endpoint = baseAccount.Endpoint;

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