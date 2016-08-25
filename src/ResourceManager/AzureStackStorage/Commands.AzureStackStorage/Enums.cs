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

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    public enum TimeGrain
    {
        Daily = 0,
        Hourly,
        Minutely
    }

    /// <summary>
    /// 
    /// </summary>
    public enum RoleType
    {
        /// <summary>
        /// 
        /// </summary>
        TableServer,

        /// <summary>
        /// 
        /// </summary>
        BlobServer,

        /// <summary>
        /// 
        /// </summary>
        TableMaster,

        /// <summary>
        /// 
        /// </summary>
        AccountContainerserver,

        /// <summary>
        /// 
        /// </summary>
        TableFrontend,

        /// <summary>
        /// 
        /// </summary>
        BlobFrontend,

        /// <summary>
        /// 
        /// </summary>
        MetricsServer,

        /// <summary>
        /// 
        /// </summary>
        HealthMonitoringserver
    }

    public enum StorageAccountSearchFilterParameter
    {
        TenantSubscriptionId,
        PartialAccountName,
        StorageAccountStatus,
        VersionedAccountName
    }
}
