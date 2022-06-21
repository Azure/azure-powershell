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

using System.Collections.Generic;
using AutoMapper;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Pair Cloud
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Input</param>
        /// <param name="mappingName">Mapping Name</param>
        /// <param name="input">Pairing input</param>
        /// <returns></returns>
        public PSSiteRecoveryLongRunningOperation ConfigureProtection(
            string fabricName,
            string protectionContainerName,
            string mappingName,
            CreateProtectionContainerMappingInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationProtectionContainerMappings.BeginCreateWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    mappingName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Create protection container.
        /// </summary>
        /// <param name="fabricName">Fabric Name.</param>
        /// <param name="protectionContainerName">Protection Container name.</param>
        /// <param name="input">Creation input.</param>
        /// <returns>A long running operation response.</returns>
        public PSSiteRecoveryLongRunningOperation CreateProtectionContainer(
            string fabricName,
            string protectionContainerName,
            CreateProtectionContainerInput input)
        {
            var op = this.GetSiteRecoveryClient().ReplicationProtectionContainers.BeginCreateWithHttpMessagesAsync(
                fabricName,
                protectionContainerName,
                input,
                this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Gets Azure Site Recovery Protection Container.
        /// </summary>
        /// <returns>Protection Container list response</returns>
        public List<ProtectionContainer> GetAzureSiteRecoveryProtectionContainer()
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationProtectionContainers
                .ListWithHttpMessagesAsync(this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationProtectionContainers.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));
            pages.Insert(
                0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Azure Site Recovery Protection Container.
        /// </summary>
        /// <returns>Protection Container list response</returns>
        public List<ProtectionContainer> GetAzureSiteRecoveryProtectionContainer(
            string fabricName)
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationProtectionContainers.ListByReplicationFabricsWithHttpMessagesAsync(
                    fabricName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationProtectionContainers
                    .ListByReplicationFabricsNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));
            pages.Insert(
                0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Azure Site Recovery Protection Container.
        /// </summary>
        /// <param name="fabricName"></param>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <returns>Protection Container response</returns>
        public ProtectionContainer GetAzureSiteRecoveryProtectionContainer(
            string fabricName,
            string protectionContainerName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationProtectionContainers.GetWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Gets Azure Site Recovery Protection Container Mapping.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <returns></returns>
        public List<ProtectionContainerMapping> GetAzureSiteRecoveryProtectionContainerMapping(
            string fabricName,
            string protectionContainerName)
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationProtectionContainerMappings
                .ListByReplicationProtectionContainersWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationProtectionContainerMappings
                    .ListByReplicationProtectionContainersNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));
            pages.Insert(
                0,
                firstPage);

            return Utilities.IpageToList(pages);
        }


        /// <summary>
        ///     Update Azure Site Recovery Protection Container Mapping.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="mappingName">Protection Container Mapping Name</param>
        /// <param name="updateInput">Update ProtectionContainerMapping Input</param>
        /// <returns></returns>
        public PSSiteRecoveryLongRunningOperation UpdateAzureSiteRecoveryProtectionContainerMapping(
            string fabricName,
            string protectionContainerName,
            string mappingName,
            UpdateProtectionContainerMappingInput updateInput)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationProtectionContainerMappings.BeginUpdateWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    mappingName,
                    updateInput,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Gets Azure Site Recovery Protection Container Mapping.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="mappingName">Mapping Name</param>
        /// <returns></returns>
        public ProtectionContainerMapping GetAzureSiteRecoveryProtectionContainerMapping(
            string fabricName,
            string protectionContainerName,
            string mappingName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationProtectionContainerMappings.GetWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    mappingName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Purge Cloud Mapping
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Input</param>
        /// <param name="mappingName">Mapping Name</param>
        /// <returns></returns>
        public PSSiteRecoveryLongRunningOperation PurgeCloudMapping(
            string fabricName,
            string protectionContainerName,
            string mappingName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationProtectionContainerMappings.BeginPurgeWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    mappingName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Remove protection container.
        /// </summary>
        /// <param name="fabricName">Fabric Name.</param>
        /// <param name="protectionContainerName">Protection Container name.</param>
        /// <returns>A long running operation response.</returns>
        public PSSiteRecoveryLongRunningOperation RemoveProtectionContainer(
            string fabricName,
            string protectionContainerName)
        {
            var op = this.GetSiteRecoveryClient().ReplicationProtectionContainers.BeginDeleteWithHttpMessagesAsync(
                fabricName,
                protectionContainerName,
                this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     UnPair Cloud
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Input</param>
        /// <param name="mappingName">Mapping Name</param>
        /// <param name="input">UnPairing input</param>
        /// <returns></returns>
        public PSSiteRecoveryLongRunningOperation UnConfigureProtection(
            string fabricName,
            string protectionContainerName,
            string mappingName,
            RemoveProtectionContainerMappingInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationProtectionContainerMappings.BeginDeleteWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    mappingName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}
