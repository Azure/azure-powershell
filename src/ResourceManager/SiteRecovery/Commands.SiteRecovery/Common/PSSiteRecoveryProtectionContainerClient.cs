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

using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.SiteRecovery
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
            return this.GetSiteRecoveryClient().ProtectionContainer.ListAll(this.GetRequestHeaders());
        }

        /// <summary>
        /// Gets Azure Site Recovery Protection Container.
        /// </summary>
        /// <returns>Protection Container list response</returns>
        public ProtectionContainerListResponse GetAzureSiteRecoveryProtectionContainer(string fabricName)
        {
            return this.GetSiteRecoveryClient().ProtectionContainer.List(fabricName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Gets Azure Site Recovery Protection Container.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <returns>Protection Container response</returns>
        public ProtectionContainerResponse GetAzureSiteRecoveryProtectionContainer(string fabricName,
            string protectionContainerName)
        {
            return this.GetSiteRecoveryClient().ProtectionContainer.Get(fabricName, protectionContainerName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Gets Azure Site Recovery Protection Container Mapping. 
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <returns></returns>
        public ProtectionContainerMappingListResponse GetAzureSiteRecoveryProtectionContainerMapping(string fabricName,
            string protectionContainerName)
        {
            return this.GetSiteRecoveryClient().ProtectionContainerMapping.List(fabricName, protectionContainerName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Gets Azure Site Recovery Protection Container Mapping. 
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="mappingName">Mapping Name</param>
        /// <returns></returns>
        public ProtectionContainerMappingResponse GetAzureSiteRecoveryProtectionContainerMapping(string fabricName,
            string protectionContainerName, string mappingName)
        {
            return this.GetSiteRecoveryClient().ProtectionContainerMapping.Get(fabricName, protectionContainerName, mappingName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Pair Cloud
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Input</param>
        /// <param name="mappingName">Mapping Name</param>
        /// <param name="input">Pairing input</param>
        /// <returns></returns>
        public LongRunningOperationResponse ConfigureProtection(string fabricName,
            string protectionContainerName, string mappingName, CreateProtectionContainerMappingInput input)
        {
            return this.GetSiteRecoveryClient().ProtectionContainerMapping.BeginConfigureProtection(fabricName, protectionContainerName, mappingName, input, this.GetRequestHeaders());
        }

        /// <summary>
        /// UnPair Cloud
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Input</param>
        /// <param name="mappingName">Mapping Name</param>
        /// <param name="input">UnPairing input</param>
        /// <returns></returns>
        public LongRunningOperationResponse UnConfigureProtection(string fabricName,
            string protectionContainerName, string mappingName, RemoveProtectionContainerMappingInput input)
        {
            return this.GetSiteRecoveryClient().ProtectionContainerMapping.BeginUnconfigureProtection(fabricName, protectionContainerName, mappingName, input, this.GetRequestHeaders());
        }
    }
}