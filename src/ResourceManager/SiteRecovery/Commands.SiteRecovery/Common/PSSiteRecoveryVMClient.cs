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

using AutoMapper;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Update Azure VM Properties
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Update Replication Protected Item Input</param>
        /// <returns></returns>
        public PSSiteRecoveryLongRunningOperation UpdateVmProperties(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            UpdateReplicationProtectedItemInput input)
        {
            var op = this.GetSiteRecoveryClient().ReplicationProtectedItems.BeginUpdateWithHttpMessagesAsync(fabricName, protectionContainerName, replicationProtectedItemName, input, this.GetRequestHeaders(true)).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}