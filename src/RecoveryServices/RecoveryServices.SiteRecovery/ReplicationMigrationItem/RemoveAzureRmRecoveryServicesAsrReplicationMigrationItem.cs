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
using Job = Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models.Job;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Stops/Disables replication for an Azure Site Recovery replication migration item.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrReplicationMigrationItem", DefaultParameterSetName = ASRParameterSets.DisableMigration, SupportsShouldProcess = true)]
    [Alias("Remove-ASRReplicationMigrationItem")]
    [OutputType(typeof(ASRJob))]
    public class RemoveAzureRmRecoveryServicesAsrReplicationMigrationItem : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Job Response
        /// </summary>
        private Job jobResponse;

        /// <summary>
        ///     Long Running Operation Response
        /// </summary>
        private PSSiteRecoveryLongRunningOperation response;

        /// <summary>
        ///     Gets or sets replication protected item object corresponding to the 
        ///     replication protected item for which replication is to be disabled.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.DisableMigration,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.DisableMigrationWithDeleteOption,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("ReplicationMigrationItem")]
        public ASRReplicationMigrationItem InputObject { get; set; }

        /// <summary>
        ///     Gets or sets switch parameter. On passing, command waits till completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }

        /// <summary>
        ///     Gets or sets The delete option.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.DisableMigrationWithDeleteOption,
            Mandatory = true)]
        [ValidateSet(Constants.Complete,
            Constants.Purge)]
        public string DeleteOption { get; set; }

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
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.DisableMigration:
                        this.StartDisableMigration();
                        break;
                    case ASRParameterSets.DisableMigrationWithDeleteOption:
                        this.StartDisableMigrationWithDeleteOption();
                        break;
                }
            }
        }

        /// <summary>
        ///     Starts Disable Migration.
        /// </summary>
        private void StartDisableMigration()
        {
            this.response = this.RecoveryServicesClient.DisableMigration(
                            Utilities.GetValueFromArmId(
                                this.InputObject.Id,
                                ARMResourceTypeConstants.ReplicationFabrics),
                            Utilities.GetValueFromArmId(
                                this.InputObject.Id,
                                ARMResourceTypeConstants.ReplicationProtectionContainers),
                            this.InputObject.Name,
                            null);

            this.jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(this.response.Location));

            this.WriteObject(new ASRJob(this.jobResponse));

            if (this.WaitForCompletion.IsPresent)
            {
                this.WaitForJobCompletion(this.jobResponse.Name);

                this.jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient
                        .GetJobIdFromReponseLocation(this.response.Location));

                this.WriteObject(new ASRJob(this.jobResponse));
            }
        }

        /// <summary>
        ///     Starts Disable Migration with delete option.
        /// </summary>
        private void StartDisableMigrationWithDeleteOption()
        {
            this.response = this.RecoveryServicesClient.DisableMigration(
                            Utilities.GetValueFromArmId(
                                this.InputObject.Id,
                                ARMResourceTypeConstants.ReplicationFabrics),
                            Utilities.GetValueFromArmId(
                                this.InputObject.Id,
                                ARMResourceTypeConstants.ReplicationProtectionContainers),
                            this.InputObject.Name,
                            this.DeleteOption);

            this.jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(this.response.Location));

            this.WriteObject(new ASRJob(this.jobResponse));

            if (this.WaitForCompletion.IsPresent)
            {
                this.WaitForJobCompletion(this.jobResponse.Name);

                this.jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient
                        .GetJobIdFromReponseLocation(this.response.Location));

                this.WriteObject(new ASRJob(this.jobResponse));
            }
        }
    }
}
