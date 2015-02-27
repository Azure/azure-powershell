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

using System;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Gets Azure Site Recovery Protection Profile.
        /// </summary>
        /// <returns>Protection Profile list response</returns>
        public ProtectionProfileListResponse GetAzureSiteRecoveryProtectionProfile()
        {
            return this.GetSiteRecoveryClient().ProtectionProfile.List(this.GetRequestHeaders());
        }

        /// <summary>
        /// Gets Azure Site Recovery Protection Profile given the ID.
        /// </summary>
        /// <param name="protectionProfileId">Protection Profile ID</param>
        /// <returns>Protection Profile response</returns>
        public ProtectionProfileResponse GetAzureSiteRecoveryProtectionProfile(
            string protectionProfileId)
        {
            return this.GetSiteRecoveryClient().ProtectionProfile.Get(
                protectionProfileId,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Updates Azure Site Recovery Protection Profile given the ID.
        /// </summary>
        /// <param name="updateProtectionProfileInput">Protection Profile Input</param>
        /// <param name="protectionProfileId">Protection Profile ID</param>
        /// <returns>Job response</returns>
        public JobResponse UpdateAzureSiteRecoveryProtectionProfile(
            UpdateProtectionProfileInput updateProtectionProfileInput,
            string protectionProfileId)
        {
            return this.GetSiteRecoveryClient().ProtectionProfile.Update(
                updateProtectionProfileInput,
                protectionProfileId,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Creates and Associates Azure Site Recovery Protection Profile.
        /// </summary>
        /// <param name="createAndAssociateProtectionProfileInput">Protection Profile Input</param>
        /// <returns>Job response</returns>
        public JobResponse StartCreateAndAssociateAzureSiteRecoveryProtectionProfileJob(
            CreateAndAssociateProtectionProfileInput createAndAssociateProtectionProfileInput)
        {
            return this.GetSiteRecoveryClient().ProtectionProfile.CreateAndAssociate(
                createAndAssociateProtectionProfileInput,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Deletes and Dissociates Azure Site Recovery Protection Profile.
        /// </summary>
        /// <param name="protectionProfileId">Protection Profile ID</param>
        /// <param name="protectionProfileAssociationInput">Protection Profile Association Input</param>
        /// <returns>Job response</returns>
        public JobResponse StartDeleteAndDissociateAzureSiteRecoveryProtectionProfileJob(
            string protectionProfileId,
            ProtectionProfileAssociationInput protectionProfileAssociationInput)
        {
            return this.GetSiteRecoveryClient().ProtectionProfile.DissociateAndDelete(
                protectionProfileId,
                protectionProfileAssociationInput,
                this.GetRequestHeaders());
        }
    }
}