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
    /// Retrieves Azure Site Recovery Protection Container.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSiteRecoveryProtectionContainer", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRProtectionContainer>))]
    public class GetAzureSiteRecoveryProtectionContainer : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets ID of the Protection Container.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets name of the Protection Container.
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
                        this.GetByDefault();
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
            ProtectionContainerListResponse protectionContainerListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer();

            bool found = false;
            foreach (
                ProtectionContainer protectionContainer in
                protectionContainerListResponse.ProtectionContainers)
            {
                if (0 == string.Compare(this.FriendlyName, protectionContainer.Properties.FriendlyName, true))
                {
                    this.WriteProtectionContainer(protectionContainer);
                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ProtectionContainerNotFound,
                    this.FriendlyName,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        /// Queries by Name.
        /// </summary>
        private void GetByName()
        {
            ProtectionContainerResponse protectionContainerResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer(this.Name);

            this.WriteProtectionContainer(protectionContainerResponse.ProtectionContainer);
        }

        /// <summary>
        /// Queries all, by default.
        /// </summary>
        private void GetByDefault()
        {
            ProtectionContainerListResponse protectionContainerListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer();

            this.WriteProtectionContainers(protectionContainerListResponse.ProtectionContainers);
        }

        /// <summary>
        /// Writes Protection Containers.
        /// </summary>
        /// <param name="protectionContainers">List of Protection Containers</param>
        private void WriteProtectionContainers(IList<ProtectionContainer> protectionContainers)
        {
            this.WriteObject(protectionContainers.Select(pc => new ASRProtectionContainer(pc)), true);
        }

        /// <summary>
        /// Write Protection Container.
        /// </summary>
        /// <param name="protectionContainer">Protection Container</param>
        private void WriteProtectionContainer(ProtectionContainer protectionContainer)
        {
            this.WriteObject(new ASRProtectionContainer(protectionContainer));
        }
    }
}