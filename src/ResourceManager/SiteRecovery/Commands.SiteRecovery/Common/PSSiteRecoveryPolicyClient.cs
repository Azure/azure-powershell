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
        /// Gets Azure Site Recovery Policy.
        /// </summary>
        /// <returns>Policy list response</returns>
        public PolicyListResponse GetAzureSiteRecoveryPolicy()
        {
            return this.GetSiteRecoveryClient().Policies.List(this.GetRequestHeaders());
        }

        /// <summary>
        /// Gets Azure Site Recovery Policy given the ID.
        /// </summary>
        /// <param name="PolicyId">Policy ID</param>
        /// <returns>Policy response</returns>
        public PolicyResponse GetAzureSiteRecoveryPolicy(
            string PolicyId)
        {
            return this.GetSiteRecoveryClient().Policies.Get(
                PolicyId,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Creates Azure Site Recovery Policy.
        /// </summary>
        /// <param name="createAndAssociatePolicyInput">Policy Input</param>
        /// <returns>Long operation response</returns>
        public LongRunningOperationResponse CreatePolicy(string policyName,
            CreatePolicyInput Policy)
        {
            return this.GetSiteRecoveryClient().Policies.BeginCreating(policyName,
                Policy,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Deletes Azure Site Recovery Policy.
        /// </summary>
        /// <param name="createAndAssociatePolicyInput">Policy Input</param>
        /// <returns>Long operation response</returns>
        public LongRunningOperationResponse DeletePolicy(string profile)
        {
            return this.GetSiteRecoveryClient().Policies.BeginDeleting(
                profile,
                this.GetRequestHeaders());
        }
    }
}