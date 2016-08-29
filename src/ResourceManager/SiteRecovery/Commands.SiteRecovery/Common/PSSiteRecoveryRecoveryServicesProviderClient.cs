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
        /// Gets Azure Site Recovery Providers.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <returns>Recovery Services Provider list response</returns>
        public RecoveryServicesProviderListResponse GetAzureSiteRecoveryProvider(string fabricId)
        {
            return this.GetSiteRecoveryClient().RecoveryServicesProvider.List(fabricId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Gets Azure Site Recovery Providers.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <param name="providerId">Provider ID</param>
        /// <returns>Provider response</returns>
        public RecoveryServicesProviderResponse GetAzureSiteRecoveryProvider(string fabricId, string providerId)
        {
            return this.GetSiteRecoveryClient().RecoveryServicesProvider.Get(fabricId, providerId, this.GetRequestHeaders());
        }


        /// <summary>
        /// Remove Azure Site Recovery Providers.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <param name="providerId">Provider ID</param>
        /// <returns>Provider response</returns>
        public LongRunningOperationResponse RemoveAzureSiteRecoveryProvider(string fabricId, string providerId)
        {
            return this.GetSiteRecoveryClient().RecoveryServicesProvider.BeginDeleting(fabricId, providerId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Purge Azure Site Recovery Providers.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <param name="providerId">Provider ID</param>
        /// <returns>Provider response</returns>
        public LongRunningOperationResponse PurgeAzureSiteRecoveryProvider(string fabricId, string providerId)
        {
            return this.GetSiteRecoveryClient().RecoveryServicesProvider.BeginPurging(fabricId, providerId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Refresh Azure Site Recovery Provider.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <param name="providerId">Provider ID</param>
        /// <returns>Operation response</returns>
        public LongRunningOperationResponse RefreshAzureSiteRecoveryProvider(string fabricId, string providerId)
        {
            return this.GetSiteRecoveryClient().RecoveryServicesProvider.BeginRefreshing(fabricId, providerId, this.GetRequestHeaders());
        }
    }
}