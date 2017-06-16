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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Retrieves Azure Site Recovery Protection Conatiner Mapping
    /// </summary>
    [Cmdlet(VerbsCommon.Get,
        "AzureRmRecoveryServicesAsrProtectionContainerMapping",
        DefaultParameterSetName = ASRParameterSets.ByObject)]
    [Alias("Get-ASRProtectionContainerMapping")]
    [OutputType(typeof(IEnumerable<ASRProtectionContainerMapping>))]
    public class GetAzureRmRecoveryServicesAsrProtectionContainerMapping : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Name of the Protection Conatiner Mapping
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Protection Container Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer ProtectionContainer { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (ParameterSetName)
            {
                case ASRParameterSets.ByObject:
                    GetAll();
                    break;
                case ASRParameterSets.ByObjectWithName:
                    GetByName();
                    break;
            }
        }

        /// <summary>
        ///     Queries by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var protectionContainerMappingResponse =
                    RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainerMapping(
                        Utilities.GetValueFromArmId(ProtectionContainer.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        ProtectionContainer.Name,
                        Name);

                if (protectionContainerMappingResponse != null)
                {
                    WriteProtectionContainerMapping(protectionContainerMappingResponse);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(ex.Error.Code,
                        "NotFound",
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    throw new InvalidOperationException(string.Format(
                        Resources.ProtectionConatinerMappingNotFound,
                        Name,
                        ProtectionContainer.FriendlyName));
                }

                throw;
            }
        }

        /// <summary>
        ///     Queries all Protection Container Mappings for a given Protection Container
        /// </summary>
        private void GetAll()
        {
            var protectionContainerMappingListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainerMapping(
                    Utilities.GetValueFromArmId(ProtectionContainer.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    ProtectionContainer.Name);

            WriteProtectionContainerMappings(protectionContainerMappingListResponse);
        }

        /// <summary>
        ///     Write Protection Container Mappings
        /// </summary>
        /// <param name="protectableItems">List of protectable items</param>
        private void WriteProtectionContainerMappings(
            IList<ProtectionContainerMapping> protectionContainerMappings)
        {
            WriteObject(
                protectionContainerMappings.Select(pcm => new ASRProtectionContainerMapping(pcm)),
                true);
        }

        /// <summary>
        ///     Write Protection Container Mapping
        /// </summary>
        /// <param name="protectionContainerMapping"></param>
        private void WriteProtectionContainerMapping(
            ProtectionContainerMapping protectionContainerMapping)
        {
            WriteObject(new ASRProtectionContainerMapping(protectionContainerMapping));
        }
    }
}