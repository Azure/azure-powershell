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
using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Gets all Azure Site Recovery Network mappings.
        /// </summary>
        /// <returns>Network mappings list response</returns>
        public List<NetworkMapping> GetAzureSiteRecoveryNetworkMappings()
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationNetworkMappings.ListWithHttpMessagesAsync(this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationNetworkMappings.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));
            pages.Insert(
                0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     List Azure Site Recovery Network mappings by network.
        /// </summary>
        /// <returns>Network mappings list response</returns>
        public List<NetworkMapping> GetAzureSiteRecoveryNetworkMappings(
            string fabricName,
            string primaryNetworkName)
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationNetworkMappings.ListByReplicationNetworksWithHttpMessagesAsync(
                    fabricName,
                    primaryNetworkName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationNetworkMappings.ListByReplicationNetworksNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));
            pages.Insert(
                0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Get Azure Site Recovery Network mappings.
        /// </summary>
        /// <returns>Network mappings response</returns>
        public NetworkMapping GetAzureSiteRecoveryNetworkMappings(
            string fabricName,
            string primaryNetworkName,
            string networkMappingName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationNetworkMappings.GetWithHttpMessagesAsync(
                    fabricName,
                    primaryNetworkName,
                    networkMappingName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Creates a new Azure Site Recovery Network mapping.
        /// </summary>
        /// <param name="primaryFabricName">Primary fabric name</param>
        /// <param name="primaryNetworkName">Primary network name</param>
        /// <param name="mappingName">Mapping name</param>
        /// <param name="input"></param>
        /// <returns>Long running operation response</returns>
        public PSSiteRecoveryLongRunningOperation NewAzureSiteRecoveryNetworkMapping(
            string primaryFabricName,
            string primaryNetworkName,
            string mappingName,
            CreateNetworkMappingInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationNetworkMappings.BeginCreateWithHttpMessagesAsync(
                    primaryFabricName,
                    primaryNetworkName,
                    mappingName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Removes Azure Site Recovery Network Mapping.
        /// </summary>
        /// <param name="primaryFabricName">Primary fabric name</param>
        /// <param name="primaryNetworkName">Primary network name</param>
        /// <param name="mappingName">mapping name</param>
        /// <returns>Long running operation response</returns>
        public PSSiteRecoveryLongRunningOperation RemoveAzureSiteRecoveryNetworkMapping(
            string primaryFabricName,
            string primaryNetworkName,
            string mappingName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationNetworkMappings.BeginDeleteWithHttpMessagesAsync(
                    primaryFabricName,
                    primaryNetworkName,
                    mappingName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Updates an existing Azure Site Recovery Network mapping.
        /// </summary>
        /// <param name="primaryFabricName">Primary fabric name.</param>
        /// <param name="primaryNetworkName">Primary network name.</param>
        /// <param name="mappingName">Mapping name.</param>
        /// <param name="input">Input data to be passed as request body.</param>
        /// <returns>Long running operation response.</returns>
        public PSSiteRecoveryLongRunningOperation UpdateAzureSiteRecoveryNetworkMapping(
            string primaryFabricName,
            string primaryNetworkName,
            string mappingName,
            UpdateNetworkMappingInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationNetworkMappings.BeginUpdateWithHttpMessagesAsync(
                    primaryFabricName,
                    primaryNetworkName,
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