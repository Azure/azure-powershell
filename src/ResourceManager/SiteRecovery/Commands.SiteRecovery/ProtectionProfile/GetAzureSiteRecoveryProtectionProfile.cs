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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Server.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSiteRecoveryProtectionProfile", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRProtectionProfile>))]
    public class GetAzureSiteRecoveryProtectionProfile : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets ID of the Server.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets name of the Server.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }
        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByFriendlyName:
                        this.GetByFriendlyName();
                        break;
                    case ASRParameterSets.ByName:
                        this.GetByName();
                        break;
                    case ASRParameterSets.Default:
                        this.GetAll();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Queries by Friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            ProtectionProfileListResponse profileListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionProfile();
            bool found = false;

            foreach (ProtectionProfile profile in profileListResponse.ProtectionProfiles)
            {
                if (0 == string.Compare(this.FriendlyName, profile.CustomData.FriendlyName, true))
                {
                    this.WriteProfile(profile);
                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ProtectionProfileNotFound,
                    this.FriendlyName,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }

        }

        /// <summary>
        /// Queries by Name.
        /// </summary>
        private void GetByName()
        {
            ProtectionProfileResponse profileResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionProfile(this.Name);

            this.WriteProfile(profileResponse.ProtectionProfile);
        }

        /// <summary>
        /// Queries all / by default.
        /// </summary>
        private void GetAll()
        {
            ProtectionProfileListResponse profileListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionProfile();

            this.WriteProfiles(profileListResponse.ProtectionProfiles);
        }

        /// <summary>
        /// Write Protection profiles.
        /// </summary>
        /// <param name="profiles">List of Profiles</param>
        private void WriteProfiles(IList<ProtectionProfile> profiles)
        {
            this.WriteObject(profiles.Select(p => new ASRProtectionProfile(p)), true);
        }

        /// <summary>
        /// Write Profile.
        /// </summary>
        /// <param name="profile">Profile object</param>
        private void WriteProfile(ProtectionProfile profile)
        {
            this.WriteObject(new ASRProtectionProfile(profile));
        }
    }
}