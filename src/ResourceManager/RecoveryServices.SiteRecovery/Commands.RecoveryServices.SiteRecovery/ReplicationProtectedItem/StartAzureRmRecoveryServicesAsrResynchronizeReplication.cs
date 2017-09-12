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

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Used to initiate resync / repair replication.
    /// </summary>
    [Cmdlet(
        VerbsLifecycle.Start,
        "AzureRmRecoveryServicesAsrResynchronizeReplication",
        DefaultParameterSetName = ASRParameterSets.Default,
        SupportsShouldProcess = true)]
    [Alias(
        "Start-ASRResynchronizeReplication",
        "Start-ASRResync")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrResynchronizeReplication : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Replication Protected Item.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
               "Resyncronize replicated item ",
               ReplicationProtectedItem.FriendlyName))
            {
                // Set the Fabric Name and Protection Container Name.
                this.fabricName =
                Utilities.GetValueFromArmId(
                    this.ReplicationProtectedItem.ID,
                    ARMResourceTypeConstants.ReplicationFabrics);
                this.protectionContainerName =
                    Utilities.GetValueFromArmId(
                        this.ReplicationProtectedItem.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers);

                // Resync Replication of the Protected Item.
                var response = this.RecoveryServicesClient.StartAzureSiteRecoveryResynchronizeReplication(
                    this.fabricName,
                    this.protectionContainerName,
                    this.ReplicationProtectedItem.Name);

                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails
                    (PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }

        #region Private Parameters

        /// <summary>
        ///     Gets or sets Name of the Fabric.
        /// </summary>
        private string fabricName;

        /// <summary>
        ///     Gets or sets Name of the Protection Container.
        /// </summary>
        private string protectionContainerName;

        #endregion Local Parameters
    }
}