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
        ///     Gets Azure Site Recovery Protection Container.
        /// </summary>
        /// <returns>Protection Container list response</returns>
        public List<ProtectionContainer> GetAzureSiteRecoveryProtectionContainer()
        {
            var firstPage = GetSiteRecoveryClient()
                .ReplicationProtectionContainers.ListWithHttpMessagesAsync(GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(GetSiteRecoveryClient()
                    .ReplicationProtectionContainers.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                GetRequestHeaders(true));
            pages.Insert(0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Azure Site Recovery Protection Container.
        /// </summary>
        /// <returns>Protection Container list response</returns>
        public List<ProtectionContainer> GetAzureSiteRecoveryProtectionContainer(string fabricName)
        {
            var firstPage = GetSiteRecoveryClient()
                .ReplicationProtectionContainers.ListByReplicationFabricsWithHttpMessagesAsync(
                    fabricName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(GetSiteRecoveryClient()
                    .ReplicationProtectionContainers
                    .ListByReplicationFabricsNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                GetRequestHeaders(true));
            pages.Insert(0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Azure Site Recovery Protection Container.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <returns>Protection Container response</returns>
        public ProtectionContainer GetAzureSiteRecoveryProtectionContainer(string fabricName,
            string protectionContainerName)
        {
            return GetSiteRecoveryClient()
                .ReplicationProtectionContainers.GetWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    GetRequestHeaders(true))
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
            var firstPage = GetSiteRecoveryClient()
                .ReplicationProtectionContainerMappings
                .ListByReplicationProtectionContainersWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(GetSiteRecoveryClient()
                    .ReplicationProtectionContainerMappings
                    .ListByReplicationProtectionContainersNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                GetRequestHeaders(true));
            pages.Insert(0,
                firstPage);

            return Utilities.IpageToList(pages);
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
            return GetSiteRecoveryClient()
                .ReplicationProtectionContainerMappings.GetWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    mappingName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Pair Cloud
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Input</param>
        /// <param name="mappingName">Mapping Name</param>
        /// <param name="input">Pairing input</param>
        /// <returns></returns>
        public PSSiteRecoveryLongRunningOperation ConfigureProtection(string fabricName,
            string protectionContainerName,
            string mappingName,
            CreateProtectionContainerMappingInput input)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationProtectionContainerMappings.BeginCreateWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    mappingName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
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
        public PSSiteRecoveryLongRunningOperation UnConfigureProtection(string fabricName,
            string protectionContainerName,
            string mappingName,
            RemoveProtectionContainerMappingInput input)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationProtectionContainerMappings.BeginDeleteWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    mappingName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Purge Cloud Mapping
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Input</param>
        /// <param name="mappingName">Mapping Name</param>
        /// <returns></returns>
        public PSSiteRecoveryLongRunningOperation PurgeCloudMapping(string fabricName,
            string protectionContainerName,
            string mappingName)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationProtectionContainerMappings.BeginPurgeWithHttpMessagesAsync(fabricName,
                    protectionContainerName,
                    mappingName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}