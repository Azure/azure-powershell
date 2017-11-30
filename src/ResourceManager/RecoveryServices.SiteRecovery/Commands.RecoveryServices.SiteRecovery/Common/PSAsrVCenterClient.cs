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
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Gets Azure Site Recovery vCenter server.
        /// </summary>
        /// <param name="fabricId">Fabric ID.</param>
        /// <param name="vCenterName">vCenter name.</param>
        /// <returns>vCenter response.</returns>
        public VCenter GetAzureRmSiteRecoveryvCenter(string fabricId, string vCenterName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationvCenters.GetWithHttpMessagesAsync(
                    fabricId,
                    vCenterName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Gets all the vCenters in Fabric.
        /// </summary>
        /// <param name="fabricId">Fabric ID.</param>
        /// <returns>vCenter list response.</returns>
        public List<VCenter> ListAzureRmSiteRecoveryvCenter(string fabricId)
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationvCenters
                .ListByReplicationFabricsWithHttpMessagesAsync(
                    fabricId,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationvCenters
                    .ListByReplicationFabricsNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));

            pages.Insert(0, firstPage);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Adds the vCenter to Fabric and discovery its VMs.
        /// </summary>
        /// <param name="fabricName">Fabric ID.</param>
        /// <param name="vCenterName">vCenter Name.</param>
        /// <param name="input">Add vCenter input.</param>
        /// <returns>Job operation response</returns>
        public PSSiteRecoveryLongRunningOperation NewAzureRmSiteRecoveryvCenter(
            string fabricName,
            string vCenterName,
            AddVCenterRequest input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationvCenters.BeginCreateWithHttpMessagesAsync(
                    fabricName,
                    vCenterName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Update the vCenter server.
        /// </summary>
        /// <param name="fabricName">Fabric ID.</param>
        /// <param name="vCenterName">vCenter Name.</param>
        /// <param name="input">Update vCenter input.</param>
        /// <returns>Job operation response</returns>
        public PSSiteRecoveryLongRunningOperation UpdateAzureRmSiteRecoveryvCenter(
            string fabricName,
            string vCenterName,
            UpdateVCenterRequest input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationvCenters.BeginUpdateWithHttpMessagesAsync(
                    fabricName,
                    vCenterName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Remove Azure Site Recovery vCenter.
        /// </summary>
        /// <param name="fabricName">Fabric name.</param>
        /// <param name="vCenterName">vCenter Name.</param>
        /// <returns>Job operation response</returns>
        public PSSiteRecoveryLongRunningOperation RemoveAzureRmSiteRecoveryvCenter(
            string fabricName,
            string vCenterName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationvCenters.BeginDeleteWithHttpMessagesAsync(
                    fabricName,
                    vCenterName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}
