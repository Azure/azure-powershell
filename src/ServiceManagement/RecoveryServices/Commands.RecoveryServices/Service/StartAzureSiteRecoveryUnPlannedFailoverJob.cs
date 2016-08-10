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
using System.Diagnostics;
using System.Management.Automation;
using System.Threading;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Used to initiate a commit operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureSiteRecoveryUnplannedFailoverJob", DefaultParameterSetName = ASRParameterSets.ByRPId)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryUnplannedFailoverJob : RecoveryServicesCmdletBase
    {
        /// <summary>
        /// Primary actions.
        /// </summary>
        private bool? primaryAction;       
        
        /// <summary>
        /// Perform Source SiteOperations.
        /// </summary>
        private bool? performSourceSiteOperations;

        /// <summary>
        /// Job response.
        /// </summary>
        private JobResponse jobResponse = null;    
        
        #region Parameters

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
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObject, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPId, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEId, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject, Mandatory = true)]
        [ValidateSet(
            Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether primary site actions are required or not.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObject, Mandatory = false)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPId, Mandatory = false)]
        public bool PrimaryAction 
        { 
            get
            {
                return this.primaryAction.HasValue ? this.primaryAction.Value : false;
            } 

            set
            {
                this.primaryAction = value;
                this.PerformSourceSideActions = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether can do source site operations.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEId, Mandatory = false)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject, Mandatory = false)]
        public bool PerformSourceSiteOperations
        {
            get
            {
                return this.performSourceSiteOperations.HasValue ?
                    this.performSourceSiteOperations.Value : 
                    false;
            } 

            set
            {
                this.performSourceSiteOperations = value;
                this.PerformSourceSideActions = value;
            }
        }

        /// <summary>
        /// Gets or sets switch parameter. This is required to PerformSourceSideActions.
        /// </summary>
        [Parameter]
        public SwitchParameter PerformSourceSideActions { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. This is required to wait for job completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }
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

                if (this.primaryAction.HasValue)
                {
                    this.WriteWarningWithTimestamp(
                          "PrimaryAction parameter will not be supported from next release. " +
                          "Please use PerformSourceSideActions parameter instead.");
                }

                if (this.performSourceSiteOperations.HasValue)
                {
                    this.WriteWarningWithTimestamp(
                          "PerformSourceSiteOperations parameter will not be supported from next release. " +
                          "Please use PerformSourceSideActions parameter instead.");
                }

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByRPObject:
                        this.RPId = this.RecoveryPlan.ID;
                        this.StartRpUnPlannedFailover();
                        break;
                    case ASRParameterSets.ByPEObject:
                        this.ProtectionEntityId = this.ProtectionEntity.ID;
                        this.ProtectionContainerId = this.ProtectionEntity.ProtectionContainerId;
                        this.StartPEUnplannedFailover();
                        break;
                    case ASRParameterSets.ByPEId:
                        this.StartPEUnplannedFailover();
                        break;
                    case ASRParameterSets.ByRPId:
                        this.StartRpUnPlannedFailover();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Starts PE Unplanned failover.
        /// </summary>
        private void StartPEUnplannedFailover()
        {
            var request = new UnplannedFailoverRequest();
            if (this.ProtectionEntity == null)
            {
                var pe = RecoveryServicesClient.GetAzureSiteRecoveryProtectionEntity(
                    this.ProtectionContainerId,
                    this.ProtectionEntityId);
                this.ProtectionEntity = new ASRProtectionEntity(pe.ProtectionEntity);

                this.ValidateUsageById(
                    this.ProtectionEntity.ReplicationProvider,
                    Constants.ProtectionEntityId);
            }

            request.ReplicationProviderSettings = string.Empty;

            if (this.ProtectionEntity.ReplicationProvider == Constants.HyperVReplicaAzure)
            {
                request.ReplicationProvider = this.ProtectionEntity.ReplicationProvider;
                if (this.Direction == Constants.PrimaryToRecovery)
                {
                    var blob = new AzureFailoverInput();
                    blob.VaultLocation = this.GetCurrentValutLocation();
                    request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailoverInput>(blob);
                }
            }

            request.ReplicationProvider = this.ProtectionEntity.ReplicationProvider;
            request.FailoverDirection = this.Direction;
            request.SourceSiteOperations = this.PerformSourceSideActions;
            this.jobResponse =
                RecoveryServicesClient.StartAzureSiteRecoveryUnplannedFailover(
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
        private void StartRpUnPlannedFailover()
        {
            RpUnplannedFailoverRequest request = new RpUnplannedFailoverRequest();

            if (this.RecoveryPlan == null)
            {
                var rp = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(
                    this.RPId);
                this.RecoveryPlan = new ASRRecoveryPlan(rp.RecoveryPlan);

                this.ValidateUsageById(
                    this.RecoveryPlan.ReplicationProvider,
                    Constants.RPId);
            }

            request.ReplicationProviderSettings = string.Empty;

            if (this.RecoveryPlan.ReplicationProvider == Constants.HyperVReplicaAzure)
            {
                request.ReplicationProvider = this.RecoveryPlan.ReplicationProvider;
                if (this.Direction == Constants.PrimaryToRecovery)
                {
                    var blob = new AzureFailoverInput();
                    blob.VaultLocation = this.GetCurrentValutLocation();
                    request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailoverInput>(blob);
                }
            }

            request.ReplicationProvider = this.RecoveryPlan.ReplicationProvider;
            request.FailoverDirection = this.Direction;
            request.PrimaryAction = this.PerformSourceSideActions;

            this.jobResponse = RecoveryServicesClient.StartAzureSiteRecoveryUnplannedFailover(
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