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
    ///     Used to initiate a test failover cleanup operation.
    /// </summary>
    [Cmdlet(
        VerbsLifecycle.Start,
        "AzureRmRecoveryServicesAsrTestFailoverCleanupJob",
        DefaultParameterSetName = ASRParameterSets.ByRPIObject,
        SupportsShouldProcess = true)]
    [Alias("Start-ASRTestFailoverCleanupJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrTestFailoverCleanupJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Resource Id.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string ResourceId { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Plan object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        /// <summary>
        ///     Gets or sets Replication Protected Item.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets test failover cleanup comments.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObject, Mandatory = false)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPIObject, Mandatory = false)]
        [Parameter(ParameterSetName = ASRParameterSets.ByResourceId, Mandatory = false)]
        public string Comment { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            if (this.ShouldProcess(
                "Protected item or Recovery plan",
                "Cleanup Test Failover"))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByRPObject:
                        // Refresh RP Object
                        var rp = this.RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(
                            this.RecoveryPlan.Name);
                        this.recoveryPlanName = this.RecoveryPlan.Name;
                        this.StartRpTestFailoverCleanup();
                        break;
                    case ASRParameterSets.ByRPIObject:
                        this.rpiId = this.ReplicationProtectedItem.ID;
                        this.StartRPITestFailoverCleanup();
                        break;
                    case ASRParameterSets.ByResourceId:
                        this.StartTFOCleanupByResourceId();
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
                                this.ReplicationProtectedItem.ID,
                                ARMResourceTypeConstants.ReplicationProtectionContainers);
            this.fabricName = Utilities.GetValueFromArmId(
                this.ReplicationProtectedItem.ID,
                ARMResourceTypeConstants.ReplicationFabrics);

            var rpiName = Utilities.GetValueFromArmId(
                this.ReplicationProtectedItem.ID,
                ARMResourceTypeConstants.ReplicationProtectedItems);

            var testFailoverCleanupInputProperties = new TestFailoverCleanupInputProperties
            {
                Comments = this.Comment == null ? "" : this.Comment
            };

            var input = new TestFailoverCleanupInput
            {
                Properties = testFailoverCleanupInputProperties
            };

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryTestFailoverCleanup(
                this.fabricName,
                this.protectionContainerName,
                rpiName,
                input);

            var jobResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient
                        .GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Starts RP Test failover cleanup.
        /// </summary>
        private void StartRpTestFailoverCleanup()
        {
           var recoveryPlanTestFailoverCleanupInputProperties =
                new RecoveryPlanTestFailoverCleanupInputProperties
                {
                    Comments = this.Comment
                };

            var recoveryPlanTestFailoverCleanupInput = new RecoveryPlanTestFailoverCleanupInput
            {
                Properties = recoveryPlanTestFailoverCleanupInputProperties
            };

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryTestFailoverCleanup(
                this.RecoveryPlan.Name,
                recoveryPlanTestFailoverCleanupInput);

            var jobResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient
                        .GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }


        /// <summary>
        ///     Starts Test failover cleanup by resource ID.
        /// </summary>
        private void StartTFOCleanupByResourceId()
        {
            if (this.ResourceId.ToLower().Contains("/" + ARMResourceTypeConstants.RecoveryPlans.ToLower() + "/"))
            {
                this.recoveryPlanName = Utilities.GetValueFromArmId(
                    this.ResourceId,
                    ARMResourceTypeConstants.RecoveryPlans);

                this.StartRpTestFailoverCleanup();
            }
            else
            {
                this.rpiId = this.ResourceId;
                this.StartRPITestFailoverCleanup();
            }
           
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

        /// <summary>
        ///     Gets or sets Name of the RecoveryPlan.
        /// </summary>
        private string recoveryPlanName;

        /// <summary>
        ///     Gets or sets Name of the RPI Id.
        /// </summary>
        private string rpiId;
        #endregion
    }
}