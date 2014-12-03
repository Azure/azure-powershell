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
        /// Gets Azure Site Recovery Network mappings.
        /// </summary>
        /// <param name="primaryServerId">Primary server ID</param>
        /// <param name="recoveryServerId">Recovery server ID</param>
        /// <returns>Network mapping list response</returns>
        public NetworkMappingListResponse GetAzureSiteRecoveryNetworkMappings(
            string primaryServerId, 
            string recoveryServerId)
        {
            return this.GetSiteRecoveryClient()
                .NetworkMappings
                .List(primaryServerId, recoveryServerId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Gets Azure Site Recovery Network mapping.
        /// </summary>
        /// <param name="networkId">Network ID</param>
        /// <param name="serverId">Server ID</param>
        /// <returns>Server response</returns>
        public NetworkMappingResponse GetAzureSiteRecoveryNetworkMapping(string networkId, string serverId)
        {
            return this.GetSiteRecoveryClient()
                .NetworkMappings
                .Get(networkId, serverId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Create Azure Site Recovery Network Mapping.
        /// </summary>
        /// <param name="primaryServerId">Primary server Id</param>
        /// <param name="primaryNetworkId">Primary network Id</param>
        /// <param name="recoveryServerId">Recovery server Id</param>
        /// <param name="recoveryNetworkId">Recovery network Id</param>
        /// <returns>Job response</returns>
        public JobResponse NewAzureSiteRecoveryNetworkMapping(
            string primaryServerId,
            string primaryNetworkId,
            string recoveryServerId,
            string recoveryNetworkId)
        {
            CreateNetworkMappingInput parameters = new CreateNetworkMappingInput();
            parameters.PrimaryServerId = primaryServerId;
            parameters.PrimaryNetworkId = primaryNetworkId;
            parameters.RecoveryServerId = recoveryServerId;
            parameters.RecoveryNetworkId = recoveryNetworkId;

            return this.GetSiteRecoveryClient()
                .NetworkMappings
                .Create(parameters, this.GetRequestHeaders());
        }

        /// <summary>
        /// Delete Azure Site Recovery Network Mapping.
        /// </summary>
        /// <param name="primaryServerId">Primary server Id</param>
        /// <param name="primaryNetworkId">Primary network Id</param>
        /// <param name="recoveryServerId">Recovery server Id</param>
        /// <returns>Job response</returns>
        public JobResponse RemoveAzureSiteRecoveryNetworkMapping(
            string primaryServerId,
            string primaryNetworkId,
            string recoveryServerId)
        {
            DeleteNetworkMappingInput parameters = new DeleteNetworkMappingInput();
            parameters.PrimaryServerId = primaryServerId;
            parameters.PrimaryNetworkId = primaryNetworkId;
            parameters.RecoveryServerId = recoveryServerId;

            return this.GetSiteRecoveryClient()
                .NetworkMappings
                .Delete(parameters, this.GetRequestHeaders());
        }
    }
}