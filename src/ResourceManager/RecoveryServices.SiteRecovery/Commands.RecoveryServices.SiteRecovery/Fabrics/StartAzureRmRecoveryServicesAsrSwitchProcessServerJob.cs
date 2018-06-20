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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Switch replication from one Process server to another for load balancing.
    /// </summary>
    [Cmdlet(
        VerbsLifecycle.Start,
        "AzureRmRecoveryServicesAsrSwitchProcessServerJob",
        DefaultParameterSetName = ASRParameterSets.Default,
        SupportsShouldProcess = true)]
    [Alias("Start-ASRSwitchProcessServerJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrSwitchProcessServerJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the fabric corresponding to the Configuration Server.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [Alias("ConfigServer")]
        public ASRFabric Fabric { get; set; }

        /// <summary>
        ///     Gets or sets the process server to switch replication out from.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProcessServer SourceProcessServer { get; set; }

        /// <summary>
        ///     Gets or sets process server to switch replication to.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProcessServer TargetProcessServer { get; set; }

        /// <summary>
        ///     Gets or sets list of replication protected item whose process server to be switched.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [Alias("ReplicatedItem")]
        public ASRReplicationProtectedItem[] ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                TargetProcessServer.FriendlyName,
                "Switch the process server"))
            {
                // Set the Fabric Name and Protection Container Name.
                this.fabricName = this.Fabric.Name;
                var protectionContainerList = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryProtectionContainer(this.fabricName);
                this.protectionContainerName = protectionContainerList[0].Name;

                var failoverPSRequestProperties = new FailoverProcessServerRequestProperties();
                failoverPSRequestProperties.SourceProcessServerId = this.SourceProcessServer.Id;
                failoverPSRequestProperties.TargetProcessServerId = this.TargetProcessServer.Id;
                failoverPSRequestProperties.ContainerName = this.protectionContainerName;

                if (this.ReplicationProtectedItem!= null)
                {
                    this.protectedItemsIdsForRpi = new List<string>();
                    foreach (var replicationProtectedItem in this.ReplicationProtectedItem)
                    {
                        this.protectedItemsIdsForRpi.Add(
                            Utilities.GetValueFromArmId(
                                replicationProtectedItem.ProtectableItemId,
                                ARMResourceTypeConstants.ProtectableItems));
                    }

                    failoverPSRequestProperties.VmsToMigrate = this.protectedItemsIdsForRpi;
                    failoverPSRequestProperties.UpdateType =
                        ProcessServerFailoverType.ServerLevel.ToString();
                }
                else
                {
                    failoverPSRequestProperties.UpdateType =
                        ProcessServerFailoverType.SystemLevel.ToString();
                }

                var failoverPSRequest = new FailoverProcessServerRequest
                {
                    Properties = failoverPSRequestProperties
                };

                // Switch the process server.
                var response = this.RecoveryServicesClient.ReassociateProcessServer(
                    this.fabricName,
                    failoverPSRequest);

                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }

        #region Private parameters

        /// <summary>
        ///     Gets or sets Name of the Fabric.
        /// </summary>
        private string fabricName;

        /// <summary>
        ///     Gets or sets Name of the Protection Container.
        /// </summary>
        private string protectionContainerName;

        /// <summary>
        ///     Gets or sets List of id Protected Items for passed replicated item.
        /// </summary>
        private IList<string> protectedItemsIdsForRpi;

        #endregion
    }
}