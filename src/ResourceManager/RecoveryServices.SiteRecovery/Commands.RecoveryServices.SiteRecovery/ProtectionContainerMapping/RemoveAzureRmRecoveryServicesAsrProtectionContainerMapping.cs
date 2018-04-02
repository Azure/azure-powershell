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

using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Deletes the specified Azure Site Recovery protection container mapping.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        "AzureRmRecoveryServicesAsrProtectionContainerMapping",
        DefaultParameterSetName = ASRParameterSets.ByObject,
        SupportsShouldProcess = true)]
    [Alias("Remove-ASRProtectionContainerMapping")]
    [OutputType(typeof(ASRJob))]
    public class RemoveAzureRmRecoveryServicesAsrProtectionContainerMapping : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets protection container mapping object corresponding to the protection container to be deleted.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("ProtectionContainerMapping")]
        public ASRProtectionContainerMapping InputObject { get; set; }

        /// <summary>
        ///     Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.InputObject.Name,
                VerbsCommon.Remove))
            {
                PSSiteRecoveryLongRunningOperation response = null;

                if (!this.Force.IsPresent)
                {
                    var inputProperties = new RemoveProtectionContainerMappingInputProperties
                    {
                        ProviderSpecificInput = new ReplicationProviderContainerUnmappingInput()
                    };

                    var input =
                        new RemoveProtectionContainerMappingInput { Properties = inputProperties };

                    response = this.RecoveryServicesClient.UnConfigureProtection(
                        Utilities.GetValueFromArmId(
                            this.InputObject.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(
                            this.InputObject.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers),
                        this.InputObject.Name,
                        input);
                }
                else
                {
                    response = this.RecoveryServicesClient.PurgeCloudMapping(
                        Utilities.GetValueFromArmId(
                            this.InputObject.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(
                            this.InputObject.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers),
                        this.InputObject.Name);
                }

                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }
    }
}