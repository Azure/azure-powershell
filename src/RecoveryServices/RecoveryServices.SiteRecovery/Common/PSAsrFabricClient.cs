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
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Creates Azure Site Recovery Fabric.
        /// </summary>
        /// <param name="fabricName">Fabric Name.</param>
        /// <param name="input">Fabric Creation input.</param>
        /// <returns>Long operation response</returns>
        public PSSiteRecoveryLongRunningOperation CreateAzureSiteRecoveryFabric(
            string fabricName,
            FabricCreationInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationFabrics.BeginCreateWithHttpMessagesAsync(
                    fabricName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Deletes Azure Site Recovery Fabric.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <returns>Long operation response</returns>
        public PSSiteRecoveryLongRunningOperation DeleteAzureSiteRecoveryFabric(
            string fabricName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationFabrics.BeginDeleteWithHttpMessagesAsync(
                    fabricName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Gets Azure Site Recovery Fabrics.
        /// </summary>
        /// <returns>Server list response</returns>
        public List<Fabric> GetAzureSiteRecoveryFabric()
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationFabrics.ListWithHttpMessagesAsync(this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;

            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationFabrics.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));

            pages.Insert(0, firstPage);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Azure Site Recovery Fabrics.
        /// </summary>
        /// <param name="fabricName">Server ID</param>
        /// <returns>Server response</returns>
        public Fabric GetAzureSiteRecoveryFabric(
            string fabricName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationFabrics.GetWithHttpMessagesAsync(
                    fabricName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Purge Azure Site Recovery Fabric.
        /// </summary>
        /// <param name="fabricName">Fabric name</param>
        /// <returns>Long operation response</returns>
        public PSSiteRecoveryLongRunningOperation PurgeAzureSiteRecoveryFabric(
            string fabricName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationFabrics.BeginPurgeWithHttpMessagesAsync(
                    fabricName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Reassociate replicated items with another Process Server.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="input">Input object for switching process server.</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation ReassociateProcessServer(
            string fabricName,
            FailoverProcessServerRequest input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationFabrics.BeginReassociateGatewayWithHttpMessagesAsync(
                    fabricName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}
