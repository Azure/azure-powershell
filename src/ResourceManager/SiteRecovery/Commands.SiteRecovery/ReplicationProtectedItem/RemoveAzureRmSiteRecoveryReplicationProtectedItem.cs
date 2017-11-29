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
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Set Protection Entity protection state.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSiteRecoveryReplicationProtectedItem", DefaultParameterSetName = ASRParameterSets.DisableDR, SupportsShouldProcess = true)]
    [OutputType(typeof(ASRJob))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Remove-AzureRmRecoveryServicesAsrReplicationProtectedItem cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class RemoveAzureRmSiteRecoveryReplicationProtectedItem : SiteRecoveryCmdletBase
    {
        /// <summary>
        /// Long Running Operation Response
        /// </summary>
        private LongRunningOperationResponse response = null;

        /// <summary>
        /// Job Response
        /// </summary>
        private JobResponse jobResponse = null;

        /// <summary>
        /// Holds either Name (if object is passed) or ID (if IDs are passed) of the PE.
        /// </summary>
        private string targetNameOrId = string.Empty;

        #region Parameters

        /// <summary>
        /// Gets or sets Replication Protected Item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.DisableDR, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command waits till completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }

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

            if (ShouldProcess(this.ReplicationProtectedItem.FriendlyName, VerbsCommon.Remove))
            {
                this.targetNameOrId = this.ReplicationProtectedItem.FriendlyName;

                if (!Force.IsPresent)
                {
                    DisableProtectionInput input = new DisableProtectionInput();
                    input.Properties = new DisableProtectionInputProperties()
                    {
                        ProviderSettings = new DisableProtectionProviderSpecificInput()
                    };
                    this.response =
                        RecoveryServicesClient.DisableProtection(
                        Utilities.GetValueFromArmId(this.ReplicationProtectedItem.ID, ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(this.ReplicationProtectedItem.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                        ReplicationProtectedItem.Name,
                        input);
                }
                else
                {
                    this.response =
                        RecoveryServicesClient.PurgeProtection(
                        Utilities.GetValueFromArmId(this.ReplicationProtectedItem.ID, ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(this.ReplicationProtectedItem.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                        ReplicationProtectedItem.Name);
                }

                jobResponse =
                    RecoveryServicesClient
                    .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                WriteObject(new ASRJob(jobResponse.Job));

                if (this.WaitForCompletion.IsPresent)
                {
                    this.WaitForJobCompletion(this.jobResponse.Job.Name);

                    jobResponse =
                    RecoveryServicesClient
                    .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                    WriteObject(new ASRJob(jobResponse.Job));
                }
            }
        }

        /// <summary>
        /// Writes Job.
        /// </summary>
        /// <param name="job">JOB object</param>
        private void WriteJob(Microsoft.Azure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }
    }
}