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

using System;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Gets Azure Site Recovery Storage mappings.
        /// </summary>
        /// <param name="primaryServerId">Primary server ID</param>
        /// <param name="recoveryServerId">Recovery server ID</param>
        /// <returns>Storage mapping list response</returns>
        public StorageMappingListResponse GetAzureSiteRecoveryStorageMappings(
            string primaryServerId, 
            string recoveryServerId)
        {
            return this.GetSiteRecoveryClient()
                .StorageMappings
                .List(primaryServerId, recoveryServerId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Create Azure Site Recovery Storage Mapping.
        /// </summary>
        /// <param name="primaryServerId">Primary server Id</param>
        /// <param name="primaryStorageId">Primary storage Id</param>
        /// <param name="recoveryServerId">Recovery server Id</param>
        /// <param name="recoveryStorageId">Recovery storage Id</param>
        /// <returns>Job response</returns>
        public JobResponse NewAzureSiteRecoveryStorageMapping(
            string primaryServerId,
            string primaryStorageId,
            string recoveryServerId,
            string recoveryStorageId)
        {
            StorageMappingInput parameters = new StorageMappingInput();
            parameters.PrimaryServerId = primaryServerId;
            parameters.PrimaryStorageId = primaryStorageId;
            parameters.RecoveryServerId = recoveryServerId;
            parameters.RecoveryStorageId = recoveryStorageId;

            return this.GetSiteRecoveryClient()
                .StorageMappings
                .Create(parameters, this.GetRequestHeaders());
        }

        /// <summary>
        /// Delete Azure Site Recovery Storage Mapping.
        /// </summary>
        /// <param name="primaryServerId">Primary server Id</param>
        /// <param name="primaryStorageId">Primary storage Id</param>
        /// <param name="recoveryServerId">Recovery server Id</param>
        /// <param name="recoveryStorageId">Recovery storage Id</param>
        /// <returns>Job response</returns>
        public JobResponse RemoveAzureSiteRecoveryStorageMapping(
            string primaryServerId,
            string primaryStorageId,
            string recoveryServerId,
            string recoveryStorageId)
        {
            StorageMappingInput parameters = new StorageMappingInput();
            parameters.PrimaryServerId = primaryServerId;
            parameters.PrimaryStorageId = primaryStorageId;
            parameters.RecoveryServerId = recoveryServerId;
            parameters.RecoveryStorageId = recoveryStorageId;

            return this.GetSiteRecoveryClient()
                .StorageMappings
                .Delete(parameters, this.GetRequestHeaders());
        }
    }
}