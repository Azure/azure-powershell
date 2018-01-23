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
        ///     Retrieves Protectable Items.
        /// </summary>
        /// <param name="fabricName">Fabric Name.</param>
        /// <param name="protectionContainerName">Protection Container Name.</param>
        /// <returns>Protection entity list response</returns>
        public List<ProtectableItem> GetAzureSiteRecoveryProtectableItem(
            string fabricName,
            string protectionContainerName)
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationProtectableItems
                .ListByReplicationProtectionContainersWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;

            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationProtectableItems
                    .ListByReplicationProtectionContainersNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));

            pages.Insert(0, firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Retrieves Protectable Item.
        /// </summary>
        /// <param name="fabricName">Fabric Name.</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="replicatedProtectedItemName">Virtual Machine Name</param>
        /// <returns>Replicated Protected Item response</returns>
        public ProtectableItem GetAzureSiteRecoveryProtectableItem(
            string fabricName,
            string protectionContainerName,
            string replicatedProtectedItemName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationProtectableItems.GetWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    replicatedProtectedItemName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Discovers Protectable Items.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="input">Discover Protectable Item Request</param>
        /// <returns>Long running operation response</returns>
        public PSSiteRecoveryLongRunningOperation NewAzureSiteRecoveryProtectableItem(
            string fabricName,
            string protectionContainerName,
            DiscoverProtectableItemRequest input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationProtectionContainers.BeginDiscoverProtectableItemWithHttpMessagesAsync(
                    fabricName,
                    protectionContainerName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}