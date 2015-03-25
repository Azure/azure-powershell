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
using Microsoft.WindowsAzure;
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
        /// Gets Azure Site Recovery Storage pool mappings.
        /// </summary>
        /// <param name="primaryServerId">Primary server ID</param>
        /// <param name="recoveryServerId">Recovery server ID</param>
        /// <returns>Storage pool mapping list response</returns>
        public StoragePoolMappingListResponse GetAzureSiteRecoveryStoragePoolMappings(
            string primaryServerId, 
            string recoveryServerId)
        {
            return this.GetSiteRecoveryClient()
                .StoragePoolMappings
                .List(primaryServerId, recoveryServerId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Create Azure Site Recovery Storage pool mapping.
        /// </summary>
        /// <param name="primaryServerId">Primary server Id</param>
        /// <param name="primaryArrayId">Primary array Id</param>
        /// <param name="primaryStoragePoolId">Primary storage pool Id</param>
        /// <param name="recoveryServerId">Recovery server Id</param>
        /// <param name="recoveryArrayId">Recovery array Id</param>
        /// <param name="recoveryStoragePoolId">Recovery storage pool Id</param>
        /// <returns>Job response</returns>
        public JobResponse NewAzureSiteRecoveryStoragePoolMapping(
            string primaryServerId,
            string primaryArrayId,
            string primaryStoragePoolId,            
            string recoveryServerId,
            string recoveryArrayId,
            string recoveryStoragePoolId)
        {
            StoragePoolMappingInput parameters = new StoragePoolMappingInput();
            parameters.PrimaryServerId = primaryServerId;
            parameters.PrimaryArrayId = primaryArrayId;
            parameters.PrimaryStoragePoolId = primaryStoragePoolId;
            parameters.RecoveryServerId = recoveryServerId;
            parameters.RecoveryArrayId = recoveryArrayId;
            parameters.RecoveryStoragePoolId = recoveryStoragePoolId;

            return this.GetSiteRecoveryClient()
                .StoragePoolMappings
                .Create(parameters, this.GetRequestHeaders());
        }

        /// <summary>
        /// Delete Azure Site Recovery Storage pool mapping.
        /// </summary>
        /// <param name="primaryServerId">Primary server Id</param>
        /// <param name="primaryArrayId">Primary array Id</param>
        /// <param name="primaryStoragePoolId">Primary storage pool Id</param>
        /// <param name="recoveryServerId">Recovery server Id</param>
        /// <param name="recoveryArrayId">Recovery array Id</param>
        /// <param name="recoveryStoragePoolId">Recovery storage pool Id</param>
        /// <returns>Job response</returns>
        public JobResponse RemoveAzureSiteRecoveryStoragePoolMapping(
            string primaryServerId,
            string primaryArrayId,
            string primaryStoragePoolId,
            string recoveryServerId,
            string recoveryArrayId,
            string recoveryStoragePoolId)
        {
            StoragePoolMappingInput parameters = new StoragePoolMappingInput();
            parameters.PrimaryServerId = primaryServerId;
            parameters.PrimaryArrayId = primaryArrayId;
            parameters.PrimaryStoragePoolId = primaryStoragePoolId;
            parameters.RecoveryServerId = recoveryServerId;
            parameters.RecoveryArrayId = recoveryArrayId;
            parameters.RecoveryStoragePoolId = recoveryStoragePoolId;

            return this.GetSiteRecoveryClient()
                .StoragePoolMappings
                .Delete(parameters, this.GetRequestHeaders());
        }
    }
}