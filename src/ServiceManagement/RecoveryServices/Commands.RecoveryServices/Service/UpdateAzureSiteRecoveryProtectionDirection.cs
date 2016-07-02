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
    /// Used to initiate a recovery protection operation.
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzureSiteRecoveryProtectionDirection", DefaultParameterSetName = ASRParameterSets.ByRPObject)]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureSiteRecoveryProtection : RecoveryServicesCmdletBase
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
                        this.SetRpReprotect();
                        break;
                    case ASRParameterSets.ByPEObject:
                        this.ProtectionEntityId = this.ProtectionEntity.ID;
                        this.ProtectionContainerId = this.ProtectionEntity.ProtectionContainerId;
                        this.SetPEReprotect();
                        break;
                    case ASRParameterSets.ByPEId:
                        this.SetPEReprotect();
                        break;
                    case ASRParameterSets.ByRPId:
                        this.SetRpReprotect();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Sets RP Recovery protection.
        /// </summary>
        private void SetRpReprotect()
        {
            var request = new ReprotectRequest();

            if (this.RecoveryPlan == null)
            {
                var rp = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(
                    this.RPId);
                this.RecoveryPlan = new ASRRecoveryPlan(rp.RecoveryPlan);

                this.ValidateUsageById(
                    this.RecoveryPlan.ReplicationProvider,
                    Constants.RPId);
            }

            request.ReplicationProvider = this.RecoveryPlan.ReplicationProvider;
            request.ReplicationProviderSettings = string.Empty;

            request.FailoverDirection = this.Direction; 
            
            this.jobResponse = RecoveryServicesClient.UpdateAzureSiteRecoveryProtection(
                this.RPId);

            this.WriteJob(this.jobResponse.Job);

            if (this.WaitForCompletion.IsPresent)
            {
                this.WaitForJobCompletion(this.jobResponse.Job.ID);
            }
        }

        /// <summary>
        /// Set PE protection.
        /// </summary>
        private void SetPEReprotect()
        {
            if ((this.Direction == Constants.PrimaryToRecovery &&
                    this.ProtectionEntity.ActiveLocation == Constants.RecoveryLocation) ||
                (this.Direction == Constants.RecoveryToPrimary &&
                    this.ProtectionEntity.ActiveLocation == Constants.PrimaryLocation))
            {
                throw new ArgumentException("Parameter value is not correct.", "Direction");
            }

            var request = new ReprotectRequest();

            if (this.ProtectionEntity == null)
            {
                var pe = RecoveryServicesClient.GetAzureSiteRecoveryProtectionEntity(
                    this.ProtectionContainerId,
                    this.ProtectionEntityId);
                this.ProtectionEntity = new ASRProtectionEntity(pe.ProtectionEntity);

                this.ValidateUsageById(
                    this.ProtectionEntity.ReplicationProvider,
                    this.ProtectionEntityId);
            }

            request.ReplicationProviderSettings = string.Empty;

            if (this.ProtectionEntity.ReplicationProvider == Constants.HyperVReplicaAzure)
            {
                if (this.Direction == Constants.PrimaryToRecovery)
                {
                    var blob = new AzureReProtectionInput();
                    blob.HvHostVmId = this.ProtectionEntity.FabricObjectId;
                    blob.VmName = this.ProtectionEntity.Name;

                    blob.OSType = this.ProtectionEntity.OS;
                    blob.VHDId = this.ProtectionEntity.OSDiskId;

                    request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureReProtectionInput>(blob);
                }
            }

            request.ReplicationProvider = this.ProtectionEntity.ReplicationProvider;
            request.FailoverDirection = this.Direction;

            this.jobResponse = RecoveryServicesClient.StartAzureSiteRecoveryReprotection(
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
        /// Writes Job.
        /// </summary>
        /// <param name="job">JOB object</param>
        private void WriteJob(Microsoft.WindowsAzure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }
    }
}