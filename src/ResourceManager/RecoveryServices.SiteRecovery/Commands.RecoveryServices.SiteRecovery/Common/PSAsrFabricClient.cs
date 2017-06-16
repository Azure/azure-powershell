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
        ///     Gets Azure Site Recovery Fabrics.
        /// </summary>
        /// <param name="shouldSignRequest">Boolean indicating if the request should be signed ACIK</param>
        /// <returns>Server list response</returns>
        public List<Fabric> GetAzureSiteRecoveryFabric(bool shouldSignRequest = true)
        {
            var firstPage = GetSiteRecoveryClient()
                .ReplicationFabrics.ListWithHttpMessagesAsync(GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(GetSiteRecoveryClient()
                    .ReplicationFabrics.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                GetRequestHeaders(true));
            pages.Insert(0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Azure Site Recovery Fabrics.
        /// </summary>
        /// <param name="fabricName">Server ID</param>
        /// <returns>Server response</returns>
        public Fabric GetAzureSiteRecoveryFabric(string fabricName)
        {
            return GetSiteRecoveryClient()
                .ReplicationFabrics.GetWithHttpMessagesAsync(fabricName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Creates Azure Site Recovery Fabric.
        /// </summary>
        /// <param name="createAndAssociatePolicyInput">Policy Input</param>
        /// <returns>Long operation response</returns>
        public PSSiteRecoveryLongRunningOperation CreateAzureSiteRecoveryFabric(string fabricName,
            FabricCreationInput input)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationFabrics.BeginCreateWithHttpMessagesAsync(fabricName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Deletes Azure Site Recovery Fabric.
        /// </summary>
        /// <param name="DeleteAzureSiteRecoveryFabric">Fabric Input</param>
        /// <returns>Long operation response</returns>
        public PSSiteRecoveryLongRunningOperation DeleteAzureSiteRecoveryFabric(string fabricName)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationFabrics.BeginDeleteWithHttpMessagesAsync(fabricName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Purge Azure Site Recovery Fabric.
        /// </summary>
        /// <param name="fabricName">Fabric name</param>
        /// <returns>Long operation response</returns>
        public PSSiteRecoveryLongRunningOperation PurgeAzureSiteRecoveryFabric(string fabricName)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationFabrics.BeginPurgeWithHttpMessagesAsync(fabricName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}