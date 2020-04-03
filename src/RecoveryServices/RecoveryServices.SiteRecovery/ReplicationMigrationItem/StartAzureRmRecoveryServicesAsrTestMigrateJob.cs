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
    ///     Starts a test migrate operation.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrTestMigrateJob",DefaultParameterSetName = ASRParameterSets.ByRMIObjectWithAzureVMNetworkId, SupportsShouldProcess = true)]
    [Alias("Start-ASRTestMigrateJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrTestMigrateJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets an site recovery replication migration item.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRMIObjectWithAzureVMNetworkId,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationMigrationItem ReplicationMigrationItem { get; set; }

        /// <summary>
        ///     Gets or sets the Azure virtual network ID to connect the test fail over virtual machine(s) to.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRMIObjectWithAzureVMNetworkId,
            Mandatory = true)]
        public string AzureVMNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets Migration Recovery Point object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRMIObjectWithAzureVMNetworkId,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRMigrationRecoveryPoint MigrationRecoveryPoint { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                "Migration item",
                "Start test migrate"))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByRMIObjectWithAzureVMNetworkId:
                        this.networkId = this.AzureVMNetworkId;
                        this.protectionContainerName = Utilities.GetValueFromArmId(
                        this.ReplicationMigrationItem.Id,
                        ARMResourceTypeConstants.ReplicationProtectionContainers);
                        this.fabricName = Utilities.GetValueFromArmId(
                            this.ReplicationMigrationItem.Id,
                            ARMResourceTypeConstants.ReplicationFabrics);
                        this.StartRMITestMigrate();
                        break;
                }
            }
        }

        /// <summary>
        ///     Starts RMI Test migrate.
        /// </summary>
        private void StartRMITestMigrate()
        {
            var testMigrateInputProperties = new TestMigrateInputProperties
            {
                ProviderSpecificDetails = new TestMigrateProviderSpecificInput()
            };
            var testMigrateInput = new TestMigrateInput { Properties = testMigrateInputProperties };

            if (0 ==
                string.Compare(
                    this.ReplicationMigrationItem.MigrationProvider,
                    Constants.VMwareCbt,
                    StringComparison.OrdinalIgnoreCase))
            {
                var vMwareCbtTestMigrateInput = new VMwareCbtTestMigrateInput
                {
                    RecoveryPointId = this.MigrationRecoveryPoint != null ? this.MigrationRecoveryPoint.ID : null,
                    NetworkId = this.AzureVMNetworkId
                };
                testMigrateInput.Properties.ProviderSpecificDetails = vMwareCbtTestMigrateInput;
            }

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryTestMigration(
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationMigrationItem.Name,
                testMigrateInput);

            this.WriteObject(response);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        #region local parameters

        /// <summary>
        ///     Network ID.
        /// </summary>
        private string networkId = string.Empty; // Network ARM Id

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
