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
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///    Starts a unplanned failover operation.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrResyncJob", DefaultParameterSetName = ASRParameterSets.ByRMIObject, SupportsShouldProcess = true)]
    [Alias("Start-ASRResyncJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrResyncJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets an ASR replication migration item.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRMIObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationMigrationItem ReplicationMigrationItem { get; set; }

        /// <summary>
        ///     Switch parameter indicating whether CBT is to reset.
        /// </summary>
        [Parameter]
        public SwitchParameter SkipCbtReset { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                "Migration item",
                "Start resync"))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByRMIObject:
                        this.protectionContainerName = Utilities.GetValueFromArmId(
                            this.ReplicationMigrationItem.Id,
                            ARMResourceTypeConstants.ReplicationProtectionContainers);
                        this.fabricName = Utilities.GetValueFromArmId(
                            this.ReplicationMigrationItem.Id,
                            ARMResourceTypeConstants.ReplicationFabrics);
                        this.StartRMIMigration();
                        break;
                }
            }
        }

        /// <summary>
        ///     Starts replication migration item resync.
        /// </summary>
        private void StartRMIMigration()
        {
            var resyncInputProperties = new ResyncInputProperties
            {
                ProviderSpecificDetails = new ResyncProviderSpecificInput()
            };

            var resyncInput = new ResyncInput { Properties = resyncInputProperties };

            if (0 ==
                string.Compare(
                    this.ReplicationMigrationItem.MigrationProvider,
                    Constants.VMwareCbt,
                    StringComparison.OrdinalIgnoreCase))
            {
                var vMwareCbtResyncInput = new VMwareCbtResyncInput
                {
                    SkipCbtReset = this.SkipCbtReset ? "true" : "false"
                };
                resyncInput.Properties.ProviderSpecificDetails = vMwareCbtResyncInput;
            }

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryResynchronizeReplication(
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationMigrationItem.Name,
                resyncInput);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        #region local parameters

        /// <summary>
        ///     Gets or sets Name of the Protection Container.
        /// </summary>
        public string protectionContainerName;

        /// <summary>
        ///     Gets or sets Name of the Fabric.
        /// </summary>
        public string fabricName;

        #endregion local parameters
    }

}

