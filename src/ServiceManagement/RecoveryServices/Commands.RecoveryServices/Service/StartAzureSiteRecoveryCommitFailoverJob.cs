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
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Used to initiate a commit operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureSiteRecoveryCommitFailoverJob", DefaultParameterSetName = ASRParameterSets.ByRPId)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryCommitFailoverJob : RecoveryServicesCmdletBase
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
        [Parameter(Mandatory = false)]
        [ValidateSet(
            Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

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

                if (string.IsNullOrEmpty(this.Direction))
                {
                    this.WriteWarningWithTimestamp(
                        string.Format(
                            Properties.Resources.MandatoryParamFromNextRelease,
                            Constants.Direction));
                }

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByRPObject:
                        this.RPId = this.RecoveryPlan.ID;
                        this.SetRpCommit();
                        break;
                    case ASRParameterSets.ByPEObject:
                        this.ProtectionEntityId = this.ProtectionEntity.ID;
                        this.ProtectionContainerId = this.ProtectionEntity.ProtectionContainerId;
                        this.SetPECommit();
                        break;
                    case ASRParameterSets.ByPEId:
                        this.SetPECommit();
                        break;
                    case ASRParameterSets.ByRPId:
                        this.SetRpCommit();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Sets RP Commit.
        /// </summary>
        private void SetRpCommit()
        {
            var request = new CommitFailoverRequest();

            if (this.RecoveryPlan == null)
            {
                var rp = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(
                    this.RPId);
                this.RecoveryPlan = new ASRRecoveryPlan(rp.RecoveryPlan);

                this.ValidateUsageById(this.RecoveryPlan.ReplicationProvider, "RPId");
            }

            request.ReplicationProvider = this.RecoveryPlan.ReplicationProvider;
            request.ReplicationProviderSettings = string.Empty;

            request.FailoverDirection = this.Direction;

            this.jobResponse = RecoveryServicesClient.StartAzureSiteRecoveryCommitFailover(
                this.RPId);

            this.WriteJob(this.jobResponse.Job);

            if (this.WaitForCompletion.IsPresent)
            {
                this.WaitForJobCompletion(this.jobResponse.Job.ID);
            }
        }

        /// <summary>
        /// Start PE Commit.
        /// </summary>
        private void SetPECommit()
        {
            var request = new CommitFailoverRequest();

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

            request.ReplicationProvider = this.ProtectionEntity.ReplicationProvider;
            request.ReplicationProviderSettings = string.Empty;
 
            if (this.ProtectionEntity.ActiveLocation == Constants.PrimaryLocation)
            {
                request.FailoverDirection = Constants.RecoveryToPrimary;
            }
            else
            {
                request.FailoverDirection = Constants.PrimaryToRecovery;
            }

            this.jobResponse = RecoveryServicesClient.StartAzureSiteRecoveryCommitFailover(
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
        /// Writes Job
        /// </summary>
        /// <param name="job">Job object</param>
        private void WriteJob(Microsoft.WindowsAzure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }
    }
}