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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.SiteRecovery.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Adds Azure Site Recovery Policy settings to a Protection Container.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSiteRecoveryProtectionContainerMapping", DefaultParameterSetName = ASRParameterSets.ByObject, SupportsShouldProcess = true)]
    [OutputType(typeof(ASRJob))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class RemoveAzureRmSiteRecoveryProtectionContainerMapping : SiteRecoveryCmdletBase
    {

        #region Parameters

        /// <summary>
        /// Gets or sets Protection Container Mapping
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainerMapping ProtectionContainerMapping { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (ShouldProcess(this.ProtectionContainerMapping.Name, VerbsCommon.Remove))
            {
                LongRunningOperationResponse response = null;

                if (!this.Force.IsPresent)
                {
                    RemoveProtectionContainerMappingInputProperties inputProperties = new RemoveProtectionContainerMappingInputProperties()
                    {
                        ProviderSpecificInput = new ReplicationProviderContainerUnmappingInput()
                    };

                    RemoveProtectionContainerMappingInput input = new RemoveProtectionContainerMappingInput()
                    {
                        Properties = inputProperties
                    };

                    response = RecoveryServicesClient.UnConfigureProtection(
                        Utilities.GetValueFromArmId(this.ProtectionContainerMapping.ID, ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(this.ProtectionContainerMapping.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                        this.ProtectionContainerMapping.Name,
                        input);
                }
                else
                {
                    response = RecoveryServicesClient.PurgeCloudMapping(
                        Utilities.GetValueFromArmId(this.ProtectionContainerMapping.ID, ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(this.ProtectionContainerMapping.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                        this.ProtectionContainerMapping.Name);
                }

                JobResponse jobResponse =
                    RecoveryServicesClient
                    .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(jobResponse.Job));
            }
        }
    }
}
