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
        /// Gets Azure Site Recovery Protection Container.
        /// </summary>
        /// <returns>Protection Container list response</returns>
        public ProtectionContainerListResponse GetAzureSiteRecoveryProtectionContainer()
        {
            return this.GetSiteRecoveryClient().ProtectionContainer.List(this.GetRequestHeaders());
        }

        /// <summary>
        /// Gets Azure Site Recovery Protection Container.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <returns>Protection Container response</returns>
        public ProtectionContainerResponse GetAzureSiteRecoveryProtectionContainer(
            string protectionContainerId)
        {
            return this.GetSiteRecoveryClient().ProtectionContainer.Get(protectionContainerId, this.GetRequestHeaders());
        }
    }
}