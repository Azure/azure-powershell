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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Used to initiate a commit operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureSiteRecoveryPlannedFailoverJob", DefaultParameterSetName = ASRParameterSets.ByRPId)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryPlannedFailoverJob : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Job response.
        /// </summary>
        private JobResponse jobResponse = null;

        /// <summary>
        /// Gets or sets ID of the Recovery Plan.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPId, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RPId { get; set; }

        /// <summary>
        /// Gets or sets ID of the PE.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEId, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ProtectionEntityId { get; set; }

        /// <summary>
        /// Gets or sets ID of the Recovery Plan.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEId, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ProtectionContainerId { get; set; }

        /// <summary>
        /// Gets or sets Recovery Plan object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        /// <summary>
        /// Gets or sets Protection Entity object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity ProtectionEntity { get; set; }

        /// <summary>
        /// Gets or sets Failover direction for the recovery plan.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(
            Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. This is required to wait for job completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }

        /// <summary>
        /// Gets or sets the Optimize value.
        /// </summary>
        [Parameter]
        [ValidateSet(
            Constants.ForDowntime,
            Constants.ForSynchronization)]
        public string Optimize { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. This is the failover is being done to on-prim and the 
        /// VM does not exist.
        /// </summary>
        public SwitchParameter CreateIfnotExists { get; set; }
        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.WriteWarningWithTimestamp(
                    string.Format(
                        Properties.Resources.CmdletWillBeDeprecatedSoon,
                        this.MyInvocation.MyCommand.Name));

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByRPObject:
                        this.RPId = this.RecoveryPlan.ID;
                        this.StartRpPlannedFailover();
                        break;
                    case ASRParameterSets.ByPEObject:
                       this.ProtectionEntityId = this.ProtectionEntity.ID;
                        this.ProtectionContainerId = this.ProtectionEntity.ProtectionContainerId;
                        this.StartPEPlannedFailover();
                        break;
                    case ASRParameterSets.ByPEId:
                        this.StartPEPlannedFailover();
                        break;
                    case ASRParameterSets.ByRPId:
                        this.StartRpPlannedFailover();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Starts PE Planned failover.
        /// </summary>
        private void StartPEPlannedFailover()
        {
            var request = new PlannedFailoverRequest();

            if (this.ProtectionEntity == null)
            {
                var pe = RecoveryServicesClient.GetAzureSiteRecoveryProtectionEntity(
                    this.ProtectionContainerId,
                    this.ProtectionEntityId);
                this.ProtectionEntity = new ASRProtectionEntity(pe.ProtectionEntity);

                this.ValidateUsageById(this.ProtectionEntity.ReplicationProvider, Constants.ProtectionEntityId);
            }

            if (this.ProtectionEntity.ReplicationProvider == Constants.HyperVReplicaAzure)
            {
                if (this.Direction == Constants.PrimaryToRecovery)
                {
                    var blob = new AzureFailoverInput();
                    blob.VaultLocation = this.GetCurrentValutLocation();
                    request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailoverInput>(blob);
                }
                else
                {
                    var blob = new AzureFailbackInput();
                    blob.CreateRecoveryVmIfDoesntExist = false;
                    blob.SkipDataSync = this.Optimize == Constants.ForDowntime ? true : false;
                    request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailbackInput>(blob);
                }
            }
            else
            {
                request.ReplicationProviderSettings = string.Empty;
            }

            request.ReplicationProvider = this.ProtectionEntity.ReplicationProvider;
            request.FailoverDirection = this.Direction;

            this.jobResponse =
                RecoveryServicesClient.StartAzureSiteRecoveryPlannedFailover(
                this.ProtectionContainerId,
                this.ProtectionEntityId,
                request);
            this.WriteJob(this.jobResponse.Job);

            if (this.WaitForCompletion.IsPresent)
            {
                this.WaitForJobCompletion(this.jobResponse.Job.ID);
            }
        }

        /// <summary>
        /// Starts RP Planned failover.
        /// </summary>
        private void StartRpPlannedFailover()
        {
            RpPlannedFailoverRequest request = new RpPlannedFailoverRequest();

            if (this.RecoveryPlan == null)
            {
                var rp = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(
                    this.RPId);
                this.RecoveryPlan = new ASRRecoveryPlan(rp.RecoveryPlan);

                this.ValidateUsageById(
                    this.RecoveryPlan.ReplicationProvider,
                    Constants.RPId);
            }

            if (this.RecoveryPlan.ReplicationProvider == Constants.HyperVReplicaAzure)
            {
                if (this.Direction == Constants.PrimaryToRecovery)
                {
                    var blob = new AzureFailoverInput();
                    blob.VaultLocation = this.GetCurrentValutLocation();
                    request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailoverInput>(blob);
                }
                else
                {
                    var blob = new AzureFailbackInput();
                    blob.CreateRecoveryVmIfDoesntExist = false;
                    blob.SkipDataSync = this.Optimize == Constants.ForDowntime ? true : false;
                    request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailbackInput>(blob);
                }
            }

            request.ReplicationProvider = this.RecoveryPlan.ReplicationProvider;
            request.FailoverDirection = this.Direction;

            this.jobResponse = RecoveryServicesClient.StartAzureSiteRecoveryPlannedFailover(
                this.RPId, 
                request);

            this.WriteJob(this.jobResponse.Job);

            if (this.WaitForCompletion.IsPresent)
            {
                this.WaitForJobCompletion(this.jobResponse.Job.ID);
            }
        }

        /// <summary>
        /// Writes Job.
        /// </summary>
        /// <param name="job">JOB object</param>
        private void WriteJob(Microsoft.WindowsAzure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }
    }
}