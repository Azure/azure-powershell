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
        ///     Gets Azure Site Recovery Providers.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <returns>Recovery Services Provider list response</returns>
        public List<RecoveryServicesProvider> GetAzureSiteRecoveryProvider(
            string fabricId)
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationRecoveryServicesProviders.ListByReplicationFabricsWithHttpMessagesAsync(
                    fabricId,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationRecoveryServicesProviders
                    .ListByReplicationFabricsNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));
            pages.Insert(
                0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Azure Site Recovery Providers.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <param name="providerId">Provider ID</param>
        /// <returns>Provider response</returns>
        public RecoveryServicesProvider GetAzureSiteRecoveryProvider(
            string fabricId,
            string providerId)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationRecoveryServicesProviders.GetWithHttpMessagesAsync(
                    fabricId,
                    providerId,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Purge Azure Site Recovery Providers.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <param name="providerId">Provider ID</param>
        /// <returns>Provider response</returns>
        public PSSiteRecoveryLongRunningOperation PurgeAzureSiteRecoveryProvider(
            string fabricId,
            string providerId)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationRecoveryServicesProviders.BeginPurgeWithHttpMessagesAsync(
                    fabricId,
                    providerId,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Refresh Azure Site Recovery Provider.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <param name="providerId">Provider ID</param>
        /// <returns>Operation response</returns>
        public PSSiteRecoveryLongRunningOperation RefreshAzureSiteRecoveryProvider(
            string fabricId,
            string providerId)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationRecoveryServicesProviders.BeginRefreshProviderWithHttpMessagesAsync(
                    fabricId,
                    providerId,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Remove Azure Site Recovery Providers.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <param name="providerId">Provider ID</param>
        /// <returns>Provider response</returns>
        public PSSiteRecoveryLongRunningOperation RemoveAzureSiteRecoveryProvider(
            string fabricId,
            string providerId)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationRecoveryServicesProviders.BeginDeleteWithHttpMessagesAsync(
                    fabricId,
                    providerId,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}