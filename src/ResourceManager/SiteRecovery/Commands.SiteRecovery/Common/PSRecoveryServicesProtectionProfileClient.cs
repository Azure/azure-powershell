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
        /// Creates Azure Site Recovery Protection Profile.
        /// </summary>
        /// <param name="createAndAssociateProtectionProfileInput">Protection Profile Input</param>
        /// <returns>Long operation response</returns>
        public LongRunningOperationResponse CreateProtectionProfile(
            CreateProtectionProfileInput createProtectionProfileInput)
        {
            return this.GetSiteRecoveryClient().ProtectionProfile.BeginCreating(
                createProtectionProfileInput,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Deletes Azure Site Recovery Protection Profile.
        /// </summary>
        /// <param name="createAndAssociateProtectionProfileInput">Protection Profile Input</param>
        /// <returns>Long operation response</returns>
        public LongRunningOperationResponse DeleteProtectionProfile(string profile)
        {
            return this.GetSiteRecoveryClient().ProtectionProfile.BeginDeleting(
                profile,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Associates Azure Site Recovery Protection Profile.
        /// </summary>
        /// <param name="ProtectionProfileAssociationInput">Protection Profile association input</param>
        /// <returns>Long running operation response</returns>
        public LongRunningOperationResponse AssociateAzureSiteRecoveryProtectionProfile(
            string profileName,
            ProtectionProfileAssociationInput protectionProfileAssociationInput)
        {
            return this.GetSiteRecoveryClient().ProtectionProfile.BeginAssociating(
                profileName,
                protectionProfileAssociationInput,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Dissociates Azure Site Recovery Protection Profile.
        /// </summary>
        /// <param name="protectionProfileId">Protection Profile ID</param>
        /// <param name="DisassociateProtectionProfileInput">Protection Profile disassociation Input</param>
        /// <returns>Long running operation response</returns>
        public LongRunningOperationResponse DissociateAzureSiteRecoveryProtectionProfile(
            string protectionProfileId,
            DisassociateProtectionProfileInput disassociateProtectionProfileInput)
        {
            return this.GetSiteRecoveryClient().ProtectionProfile.BeginDissociating(
                protectionProfileId,
                disassociateProtectionProfileInput,
                this.GetRequestHeaders());
        }
    }
}