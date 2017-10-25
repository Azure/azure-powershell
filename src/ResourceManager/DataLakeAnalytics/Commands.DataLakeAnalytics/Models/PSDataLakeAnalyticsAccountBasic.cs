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
    public class PSDataLakeAnalyticsAccountBasic : DataLakeAnalyticsAccountBasic
    {
        /// <summary>
        /// Gets or sets the default data lake storage account associated with
        /// this Data Lake Analytics account.
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public string DefaultDataLakeStoreAccount { get; private set; }

        /// <summary>
        /// Gets or sets the list of Data Lake storage accounts associated
        /// with this account.
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public IList<PSDataLakeStoreAccountInfo> DataLakeStoreAccounts { get; private set; }

        /// <summary>
        /// Gets or sets the maximum supported degree of parallelism for this
        /// account.
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public int? MaxDegreeOfParallelism { get; private set; }

        /// <summary>
        /// Gets or sets the number of days that job metadata is retained.
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public int? QueryStoreRetention { get; private set; }

        /// <summary>
        /// Gets or sets the maximum supported jobs running under the account
        /// at the same time.
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public int? MaxJobCount { get; private set; }

        /// <summary>
        /// Gets the system defined maximum supported degree of parallelism for
        /// this account, which restricts the maximum value of parallelism the
        /// user can set for the account..
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public int? SystemMaxDegreeOfParallelism { get; private set; }

        /// <summary>
        /// Gets the system defined maximum supported jobs running under the
        /// account at the same time, which restricts the maximum number of
        /// running jobs the user can set for the account.
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public int? SystemMaxJobCount { get; private set; }

        /// <summary>
        /// Gets or sets the list of Azure Blob storage accounts associated
        /// with this account.
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public IList<StorageAccountInfo> StorageAccounts { get; private set; }

        /// <summary>
        /// Gets or sets the commitment tier for the next month. Possible
        /// values include: 'Consumption', 'Commitment_100AUHours',
        /// 'Commitment_500AUHours', 'Commitment_1000AUHours',
        /// 'Commitment_5000AUHours', 'Commitment_10000AUHours',
        /// 'Commitment_50000AUHours', 'Commitment_100000AUHours',
        /// 'Commitment_500000AUHours'
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public TierType? NewTier { get; private set; }

        /// <summary>
        /// Gets the commitment tier in use for the current month. Possible
        /// values include: 'Consumption', 'Commitment_100AUHours',
        /// 'Commitment_500AUHours', 'Commitment_1000AUHours',
        /// 'Commitment_5000AUHours', 'Commitment_10000AUHours',
        /// 'Commitment_50000AUHours', 'Commitment_100000AUHours',
        /// 'Commitment_500000AUHours'
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public TierType? CurrentTier { get; private set; }

        /// <summary>
        /// Gets or sets the current state of the IP address firewall for this
        /// Data Lake Analytics account. Possible values include: 'Enabled',
        /// 'Disabled'
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public FirewallState? FirewallState { get; private set; }

        /// <summary>
        /// Gets or sets the current state of allowing or disallowing IPs
        /// originating within Azure through the firewall. If the firewall is
        /// disabled, this is not enforced. Possible values include: 'Enabled',
        /// 'Disabled'
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public FirewallAllowAzureIpsState? FirewallAllowAzureIps { get; private set; }

        /// <summary>
        /// Gets or sets the list of firewall rules associated with this Data
        /// Lake Analytics account.
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public IList<FirewallRule> FirewallRules { get; private set; }

        /// <summary>
        /// Gets or sets the maximum supported degree of parallelism per job
        /// for this account.
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public int? MaxDegreeOfParallelismPerJob { get; private set; }

        /// <summary>
        /// Gets or sets the minimum supported priority per job for this
        /// account.
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public int? MinPriorityPerJob { get; private set; }

        /// <summary>
        /// Gets or sets the list of compute policies to create in this
        /// account.
        /// </summary>
        [Obsolete("This property is in DataLakeAnalyticsAccount but removed in DataLakeAnalyticsAccountBasic because the server does not return this property when listing accounts. This will be removed in a future release.")]
        public IList<ComputePolicyAccountCreateParameters> ComputePolicies { get; private set; }

        public PSDataLakeAnalyticsAccountBasic(DataLakeAnalyticsAccountBasic baseAccount) :
            base(
                baseAccount.Location,
                baseAccount.Id,
                baseAccount.Name,
                baseAccount.Type,
                baseAccount.Tags,
                baseAccount.ProvisioningState,
                baseAccount.State,
                baseAccount.CreationTime,
                baseAccount.LastModifiedTime,
                baseAccount.Endpoint,
                baseAccount.AccountId)
        {
            this.DefaultDataLakeStoreAccount = null;
            this.DataLakeStoreAccounts = null;
            this.MaxDegreeOfParallelism = null;
            this.QueryStoreRetention = null;
            this.MaxJobCount = null;
            this.SystemMaxDegreeOfParallelism = null;
            this.SystemMaxJobCount = null;
            this.StorageAccounts = null;
            this.NewTier = null;
            this.CurrentTier = null;
            this.FirewallState = null;
            this.FirewallAllowAzureIps = null;
            this.FirewallRules = null;
            this.MaxDegreeOfParallelismPerJob = null;
            this.MinPriorityPerJob = null;
            this.ComputePolicies = null;
        }
    }
}
