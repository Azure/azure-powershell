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
        ///     Creates Azure Site Recovery Policy.
        /// </summary>
        /// <param name="policyName">Policy Name</param>
        /// <param name="input">Policy Input</param>
        /// <returns>Long operation response</returns>
        public PSSiteRecoveryLongRunningOperation CreatePolicy(
            string policyName,
            CreatePolicyInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationPolicies.BeginCreateWithHttpMessagesAsync(
                    policyName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Deletes Azure Site Recovery Policy.
        /// </summary>
        /// <param name="policyName">Policy Name</param>
        /// <returns>Long operation response</returns>
        public PSSiteRecoveryLongRunningOperation DeletePolicy(
            string policyName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationPolicies.BeginDeleteWithHttpMessagesAsync(
                    policyName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Gets Azure Site Recovery Policy.
        /// </summary>
        /// <returns>Policy list response</returns>
        public List<Policy> GetAzureSiteRecoveryPolicy()
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationPolicies.ListWithHttpMessagesAsync(this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationPolicies.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));
            pages.Insert(
                0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Azure Site Recovery Policy given the ID.
        /// </summary>
        /// <param name="PolicyName">Policy Name</param>
        /// <returns>Policy response</returns>
        public Policy GetAzureSiteRecoveryPolicy(
            string PolicyName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationPolicies.GetWithHttpMessagesAsync(
                    PolicyName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Update Azure Site Recovery Policy.
        /// </summary>
        /// <param name="input">Policy Input</param>
        /// <param name="policyName">Policy Name</param>
        /// <returns>Long operation response</returns>
        public PSSiteRecoveryLongRunningOperation UpdatePolicy(
            string policyName,
            UpdatePolicyInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationPolicies.BeginUpdateWithHttpMessagesAsync(
                    policyName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}