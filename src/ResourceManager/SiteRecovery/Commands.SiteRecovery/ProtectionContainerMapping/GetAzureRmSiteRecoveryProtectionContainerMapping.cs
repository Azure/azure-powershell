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
using Hyak.Common;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Protection Conatiner Mapping
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryProtectionContainerMapping", DefaultParameterSetName = ASRParameterSets.ByObject)]
    [OutputType(typeof(IEnumerable<ASRProtectionContainerMapping>))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Get-AzureRmRecoveryServicesAsrProtectionContainerMapping cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class GetAzureRmSiteRecoveryProtectionContainerMapping : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Name of the Protection Conatiner Mapping
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Protection Container Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer ProtectionContainer { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByObject:
                    this.GetAll();
                    break;
                case ASRParameterSets.ByObjectWithName:
                    this.GetByName();
                    break;
            }
        }


        /// <summary>
        /// Queries by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var protectionContainerMappingResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainerMapping(
                    Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                    this.ProtectionContainer.Name,
                    this.Name);

                if (protectionContainerMappingResponse.ProtectionContainerMapping != null)
                {
                    this.WriteProtectionContainerMapping(protectionContainerMappingResponse.ProtectionContainerMapping);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(ex.Error.Code, "NotFound", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                        Properties.Resources.ProtectionConatinerMappingNotFound,
                        this.Name,
                        this.ProtectionContainer.FriendlyName));
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Queries all Protection Container Mappings for a given Protection Container
        /// </summary>
        private void GetAll()
        {
            ProtectionContainerMappingListResponse protectionContainerMappingListResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainerMapping(
                Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                this.ProtectionContainer.Name);

            WriteProtectionContainerMappings(protectionContainerMappingListResponse.ProtectionContainerMappings);
        }

        /// <summary>
        /// Write Protection Container Mappings
        /// </summary>
        /// <param name="protectableItems">List of protectable items</param>
        private void WriteProtectionContainerMappings(IList<ProtectionContainerMapping> protectionContainerMappings)
        {
            this.WriteObject(protectionContainerMappings.Select(pcm => new ASRProtectionContainerMapping(pcm)), true);
        }

        /// <summary>
        /// Write Protection Container Mapping
        /// </summary>
        /// <param name="protectionContainerMapping"></param>
        private void WriteProtectionContainerMapping(ProtectionContainerMapping protectionContainerMapping)
        {
            this.WriteObject(new ASRProtectionContainerMapping(protectionContainerMapping));
        }
    }
}