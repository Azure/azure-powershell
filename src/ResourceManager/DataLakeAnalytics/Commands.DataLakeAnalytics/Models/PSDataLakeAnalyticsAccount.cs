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

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Models
{
    /// <summary>
    ///    A wrapper for all ADLA supported data sources.
    ///    This object is returned from a GET
    /// </summary>
    [Obsolete("In a future release this object will have all 'Properties' properties flattened and the 'Properties' property will be removed. Until then, nested properies will be duplicated.")]
    public class PSDataLakeAnalyticsAccount : DataLakeAnalyticsAccount
    {
        [Obsolete("This property will be removed in a future release")]
        public PSDataLakeAnalyticsAccountProperties Properties { get; set; }

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
                baseAccount.MaxDegreeOfParallelism,
                baseAccount.QueryStoreRetention,
                baseAccount.MaxJobCount,
                baseAccount.SystemMaxDegreeOfParallelism,
                baseAccount.SystemMaxJobCount,
                baseAccount.StorageAccounts,
                baseAccount.CreationTime,
                baseAccount.LastModifiedTime,
                baseAccount.Endpoint,
                baseAccount.NewTier,
                baseAccount.CurrentTier,
                baseAccount.FirewallState,
                baseAccount.FirewallAllowAzureIps,
                baseAccount.FirewallRules)
        {
            Properties = new PSDataLakeAnalyticsAccountProperties(baseAccount);
        }
    }
}