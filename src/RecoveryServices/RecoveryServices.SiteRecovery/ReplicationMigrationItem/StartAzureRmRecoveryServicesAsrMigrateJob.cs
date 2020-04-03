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
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///    Starts a unplanned failover operation.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrMigrateJob", DefaultParameterSetName = ASRParameterSets.ByRMIObject, SupportsShouldProcess = true)]
    [Alias("Start-ASRMigrateJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrMigrateJob : SiteRecoveryCmdletBase
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
        ///     Switch parameter to perform operation indicating whether VM is to be shutdown..
        /// </summary>
        [Parameter]
        [Alias("PerformsShutdown")]
        public SwitchParameter PerformShutdown { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                "Migration item",
                "Start migrate"))
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
        ///     Starts replication migration item migrate.
        /// </summary>
        private void StartRMIMigration()
        {
            var migrateInputProperties = new MigrateInputProperties
            {
                ProviderSpecificDetails = new MigrateProviderSpecificInput()
            };

            var migrateInput = new MigrateInput { Properties = migrateInputProperties };

            if (0 ==
                string.Compare(
                    this.ReplicationMigrationItem.MigrationProvider,
                    Constants.VMwareCbt,
                    StringComparison.OrdinalIgnoreCase))
            {
                var vMwareCbtMigrateInput = new VMwareCbtMigrateInput
                {
                    PerformShutdown = this.PerformShutdown ? "true" : "false"
                };
                migrateInput.Properties.ProviderSpecificDetails = vMwareCbtMigrateInput;
            }

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryMigration(
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationMigrationItem.Name,
                migrateInput);

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