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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Starts the commit failover action for a site recovery object.
    /// </summary>
    [Cmdlet(
        VerbsLifecycle.Start,
        "AzureRmRecoveryServicesAsrCommitFailoverJob",
        DefaultParameterSetName = ASRParameterSets.ByRPIObject,
        SupportsShouldProcess = true)]
    [Alias(
        "Start-ASRCommitFailover",
        "Start-ASRCommitFailoverJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrCommitFailoverJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets recovery plan object corresponding to recovery plan to be failovered .
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        /// <summary>
        ///     Gets or sets replication protected item object corresponding to replication protected item  to be failovered.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObject,
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
                "Protected item or Recovery plan",
                "Commit failover"))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByRPIObject:
                        this.protectionContainerName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers);
                        this.fabricName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationFabrics);
                        this.SetRPICommit();
                        break;
                    case ASRParameterSets.ByRPObject:
                        this.StartRpCommit();
                        break;
                }
            }
        }

        /// <summary>
        ///     Start RPI Commit.
        /// </summary>
        private void SetRPICommit()
        {
            // Check if the Replication Provider is InMageAzureV2.
            if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMageAzureV2,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                // Validate if the Replication Protection Item is part of any Replication Group.
                Guid guidResult;
                var parseFlag = Guid.TryParse(
                    ((ASRInMageAzureV2SpecificRPIDetails)this
                        .ReplicationProtectedItem
                        .ProviderSpecificDetails).MultiVmGroupName,
                    out guidResult);
                if (parseFlag == false ||
                    guidResult == Guid.Empty ||
                    string.Compare(
                        ((ASRInMageAzureV2SpecificRPIDetails)this
                            .ReplicationProtectedItem
                            .ProviderSpecificDetails).MultiVmGroupName,
                        ((ASRInMageAzureV2SpecificRPIDetails)this
                            .ReplicationProtectedItem
                            .ProviderSpecificDetails).MultiVmGroupId) !=
                    0)
                {
                    // Replication Group was created at the time of Protection.
                    throw new InvalidOperationException(
                        string.Format(
                            Resources
                                .UnsupportedReplicationProtectionActionForCommit,
                            this.ReplicationProtectedItem
                                .ReplicationProvider));
                }
            }
            else if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMage,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                // Validate if the Replication Protection Item is part of any Replication Group.
                Guid guidResult;
                var parseFlag = Guid.TryParse(
                    ((ASRInMageSpecificRPIDetails)this
                        .ReplicationProtectedItem
                        .ProviderSpecificDetails).MultiVmGroupName,
                    out guidResult);
                if (parseFlag == false ||
                    guidResult == Guid.Empty ||
                    string.Compare(
                        ((ASRInMageSpecificRPIDetails)this.ReplicationProtectedItem
                            .ProviderSpecificDetails)
                        .MultiVmGroupName,
                        ((ASRInMageSpecificRPIDetails)this.ReplicationProtectedItem
                            .ProviderSpecificDetails)
                        .MultiVmGroupId) !=
                    0)
                {
                    // Replication Group was created at the time of Protection.
                    throw new InvalidOperationException(
                        string.Format(
                            Resources
                                .UnsupportedReplicationProtectionActionForCommit,
                            this.ReplicationProtectedItem
                                .ReplicationProvider));
                }
            }

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryCommitFailover(
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationProtectedItem.Name);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Starts RP Commit.
        /// </summary>
        private void StartRpCommit()
        {
            var response =
                this.RecoveryServicesClient.StartAzureSiteRecoveryCommitFailover(
                    this.RecoveryPlan.Name);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        #region local Variable

        /// <summary>
        ///     Gets or sets Name of the Fabric.
        /// </summary>
        private string fabricName;

        /// <summary>
        ///     Gets or sets ID of the Protection Container.
        /// </summary>
        private string protectionContainerName;

        /// <summary>
        ///     Gets or sets ID of the PE.
        /// </summary>
        private string protectionEntityName;

        #endregion
    }
}