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
    ///     Starts the cancel failover action for a site recovery object.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrCancelFailoverJob", DefaultParameterSetName = ASRParameterSets.ByRPIObject, SupportsShouldProcess = true)]
    [Alias(
        "Start-ASRCancelFailover",
        "Start-ASRCancelFailoverJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrCancelFailoverJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets recovery plan object corresponding to recovery plan to cancel failover.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        /// <summary>
        ///     Gets or sets replication protected item object corresponding to replication protected item to cancel failover.
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
                "Cancel failover"))
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
                        this.StartRPICancelFailover();
                        break;

                    case ASRParameterSets.ByRPObject:
                        this.StartRpCancelFailover();
                        break;
                }
            }
        }

        /// <summary>
        ///     Start RPI cancel failover.
        /// </summary>
        private void StartRPICancelFailover()
        {
            if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMageRcmFailback,
                    StringComparison.OrdinalIgnoreCase) !=
                0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.UnsupportedReplicationProtectionActionForCancelFailover,
                        this.ReplicationProtectedItem.ReplicationProvider));
            }

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryCancelFailover(
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationProtectedItem.Name);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Starts RP cancel failover.
        /// </summary>
        private void StartRpCancelFailover()
        {
            var rp = this.RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(
                this.RecoveryPlan.Name);

            foreach (var replicationProvider in rp.Properties.ReplicationProviders)
            {
                if (string.Compare(
                        replicationProvider,
                        Constants.InMageRcmFailback,
                        StringComparison.OrdinalIgnoreCase) !=
                    0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            Resources.UnsupportedReplicationProtectionActionForCancelFailover,
                           replicationProvider));
                }
            }

            var response =
                this.RecoveryServicesClient.StartAzureSiteRecoveryCancelFailover(
                    this.RecoveryPlan.Name);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        #region local Variable

        /// <summary>
        ///     Gets or sets the name of the fabric.
        /// </summary>
        private string fabricName;

        /// <summary>
        ///     Gets or sets the name of the protection container.
        /// </summary>
        private string protectionContainerName;

        #endregion
    }
}
