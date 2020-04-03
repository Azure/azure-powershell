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
    ///     Starts the test failover cleanup operation.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrTestMigrateCleanupJob",DefaultParameterSetName = ASRParameterSets.ByRMIObject,SupportsShouldProcess = true)]
    [Alias("Start-ASRTestMigrateCleanupJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrTestMigrateCleanupJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets replication migration item to perform the test migration cleanup on.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRMIObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationMigrationItem ReplicationMigrationItem { get; set; }

        /// <summary>
        ///     Gets or sets user Comment for Test Migrate.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRMIObject, Mandatory = false)]
        public string Comment { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            if (this.ShouldProcess(
                "Migration item",
                "Cleanup Test Migration"))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByRMIObject:
                        this.StartRPITestFailoverCleanup();
                        break;
                }
            }
        }

        /// <summary>
        ///     Starts PE Test failover cleanup.
        /// </summary>
        private void StartRPITestFailoverCleanup()
        {
            this.protectionContainerName =
                            Utilities.GetValueFromArmId(
                                this.ReplicationMigrationItem.Id,
                                ARMResourceTypeConstants.ReplicationProtectionContainers);
            this.fabricName = Utilities.GetValueFromArmId(
                this.ReplicationMigrationItem.Id,
                ARMResourceTypeConstants.ReplicationFabrics);

            var rmiName = Utilities.GetValueFromArmId(
                this.ReplicationMigrationItem.Id,
                ARMResourceTypeConstants.ReplicationMigrationItems);

            var testMigrateCleanupInputProperties = new TestMigrateCleanupInputProperties
            {
                Comments = this.Comment == null ? "" : this.Comment
            };

            var input = new TestMigrateCleanupInput
            {
                Properties = testMigrateCleanupInputProperties
            };

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryTestMigrationCleanup(
                this.fabricName,
                this.protectionContainerName,
                rmiName,
                input);

            var jobResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient
                        .GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        #region Private Parameters

        /// <summary>
        ///     Gets or sets Name of the Protection Container.
        /// </summary>
        private string protectionContainerName;

        /// <summary>
        ///     Gets or sets Name of the Fabric.
        /// </summary>
        private string fabricName;

        #endregion
    }
}
