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
    [Cmdlet(VerbsLifecycle.Start, "AzureSiteRecoveryTestFailoverJob", DefaultParameterSetName = ASRParameterSets.ByPEId)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryTestFailoverJob : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Job response.
        /// </summary>
        private JobResponse jobResponse = null;

        /// <summary>
        /// Network ID.
        /// </summary>
        private string networkId = string.Empty;

        /// <summary>
        /// Network Type (Logical network or VM network).
        /// </summary>
        private string networkType = string.Empty;

        /// <summary>
        /// Gets or sets ID of the Recovery Plan.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPId, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPIdWithLogicalNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPIdWithVMNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPIdWithVMNetwork, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RpId { get; set; }

        /// <summary>
        /// Gets or sets Network.
        /// </summary>
        [Parameter]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithVMNetwork, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithVMNetwork, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPIdWithVMNetwork, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEIdWithVMNetwork, Mandatory = true)]
        public ASRNetwork Network { get; set; }

        /// <summary>
        /// Gets or sets NetworkType.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateSet(
            Constants.None,
            Constants.New,
            Constants.Existing)]
        public string NetworkType { get; set; }

        /// <summary>
        /// Gets or sets Recovery Plan object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObject, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithLogicalNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithVMNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithVMNetwork, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        /// <summary>
        /// Gets or sets failover direction for the recovery plan.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(
          Constants.PrimaryToRecovery,
          Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        /// Gets or sets ID of the PE.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEId, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEIdWithLogicalNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEIdWithVMNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEIdWithVMNetwork, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ProtectionEntityId { get; set; }

        /// <summary>
        /// Gets or sets ID of the Recovery Plan.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEId, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEIdWithLogicalNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEIdWithVMNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEIdWithVMNetwork, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ProtectionContainerId { get; set; }

        /// <summary>
        /// Gets or sets Protection Entity object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithLogicalNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithVMNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithVMNetwork, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity ProtectionEntity { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. This is required to wait for job completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }

        /// <summary>
        /// Gets or sets Logical network ID.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithLogicalNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEIdWithLogicalNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithLogicalNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPIdWithLogicalNetworkID, Mandatory = true)]
        public string LogicalNetworkId { get; set; }

        /// <summary>
        /// Gets or sets VM network ID.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithVMNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEIdWithVMNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithVMNetworkID, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPIdWithVMNetworkID, Mandatory = true)]
        public string VmNetworkId { get; set; }
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

                if (this.NetworkType == null)
                {
                    this.WriteWarningWithTimestamp(
                        string.Format(
                            Properties.Resources.MandatoryParamFromNextRelease,
                            Constants.NetworkType));
                }

                if (this.VmNetworkId != null)
                {
                    this.WriteWarningWithTimestamp(
                        string.Format(
                            Properties.Resources.IDBasedParamUsageNotSupportedFromNextRelease,
                            "VmNetworkId"));
                }

                if (this.NetworkType == Constants.Existing && (this.Network == null && this.VmNetworkId == null))
                {
                    throw new Exception("Existing Network details were not supplied.");
                }

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByRPObject:
                        this.RpId = this.RecoveryPlan.ID;
                        this.networkType = "DisconnectedVMNetworkTypeForTestFailover";
                        this.StartRpTestFailover();
                        break;
                    case ASRParameterSets.ByRPId:
                        this.networkType = "DisconnectedVMNetworkTypeForTestFailover";
                        this.StartRpTestFailover();
                        break;
                    case ASRParameterSets.ByRPObjectWithVMNetwork:
                        this.networkType = "UseVMNetworkTypeForTestFailover";
                        this.networkId = this.Network.ID;
                        this.StartRpTestFailover();
                        break;
                    case ASRParameterSets.ByRPObjectWithVMNetworkID:
                        this.networkType = "UseVMNetworkTypeForTestFailover";
                        this.networkId = this.VmNetworkId;
                        this.StartRpTestFailover();
                        break;
                    case ASRParameterSets.ByRPIdWithVMNetwork:
                        this.networkType = "UseVMNetworkTypeForTestFailover";
                        this.networkId = this.Network.ID;
                        this.StartRpTestFailover();
                        break;
                    case ASRParameterSets.ByRPIdWithVMNetworkID:
                        this.networkType = "UseVMNetworkTypeForTestFailover";
                        this.networkId = this.VmNetworkId;
                        this.StartRpTestFailover();
                        break;
                    case ASRParameterSets.ByRPIdWithLogicalNetworkID:
                        this.networkType = "CreateVMNetworkTypeForTestFailover";
                        this.networkId = this.LogicalNetworkId;
                        this.StartRpTestFailover();
                        break;
                    case ASRParameterSets.ByRPObjectWithLogicalNetworkID:
                        this.networkType = "CreateVMNetworkTypeForTestFailover";
                        this.networkId = this.LogicalNetworkId;
                        this.StartRpTestFailover();
                        break;
                    case ASRParameterSets.ByPEObject:
                        this.networkType = "DisconnectedVMNetworkTypeForTestFailover";
                        this.UpdateRequiredParametersAndStartFailover();
                        break;
                    case ASRParameterSets.ByPEObjectWithLogicalNetworkID:
                        this.networkType = "CreateVMNetworkTypeForTestFailover";
                        this.networkId = this.LogicalNetworkId;
                        this.UpdateRequiredParametersAndStartFailover();
                        break;
                    case ASRParameterSets.ByPEObjectWithVMNetworkID:
                        this.networkType = "UseVMNetworkTypeForTestFailover";
                        this.networkId = this.VmNetworkId;
                        this.UpdateRequiredParametersAndStartFailover();
                        break;
                    case ASRParameterSets.ByPEObjectWithVMNetwork:
                        this.networkType = "UseVMNetworkTypeForTestFailover";
                        this.networkId = this.Network.ID;
                        this.UpdateRequiredParametersAndStartFailover();
                        break;
                    case ASRParameterSets.ByPEId:
                        this.networkType = "DisconnectedVMNetworkTypeForTestFailover";
                        this.StartPETestFailover();
                        break;
                    case ASRParameterSets.ByPEIdWithLogicalNetworkID:
                        this.networkType = "CreateVMNetworkTypeForTestFailover";
                        this.networkId = this.LogicalNetworkId;
                        this.StartPETestFailover();
                        break;
                    case ASRParameterSets.ByPEIdWithVMNetworkID:
                        this.networkType = "UseVMNetworkTypeForTestFailover";
                        this.networkId = this.VmNetworkId;
                        this.StartPETestFailover();
                        break;
                    case ASRParameterSets.ByPEIdWithVMNetwork:
                        this.networkType = "UseVMNetworkTypeForTestFailover";
                        this.networkId = this.Network.ID;
                        this.StartPETestFailover();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Starts RP test failover.
        /// </summary>
        private void StartRpTestFailover()
        {
            RpTestFailoverRequest request = new RpTestFailoverRequest();

            if (this.RecoveryPlan == null)
            {
                var rp = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(
                    this.RpId);
                this.RecoveryPlan = new ASRRecoveryPlan(rp.RecoveryPlan);

                this.ValidateUsageById(
                    this.RecoveryPlan.ReplicationProvider,
                    Constants.RPId);
            }

            request.ReplicationProviderSettings = string.Empty;

            if (this.RecoveryPlan.ReplicationProvider == Constants.HyperVReplicaAzure)
            {
                if (this.Direction == Constants.PrimaryToRecovery)
                {
                    var blob = new AzureFailoverInput();
                    blob.VaultLocation = this.GetCurrentValutLocation();
                    request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailoverInput>(blob);
                }
            }

            request.NetworkID = this.networkId;
            request.NetworkType = this.networkType;

            request.ReplicationProvider = this.RecoveryPlan.ReplicationProvider;
            request.FailoverDirection = this.Direction;

            this.jobResponse = RecoveryServicesClient.StartAzureSiteRecoveryTestFailover(
                this.RpId, 
                request);

            this.WriteJob(this.jobResponse.Job);

            if (this.WaitForCompletion.IsPresent)
            {
                this.WaitForJobCompletion(this.jobResponse.Job.ID);
            }
        }

        /// <summary>
        /// Starts PE Test failover.
        /// </summary>
        private void StartPETestFailover()
        {
            var request = new TestFailoverRequest();

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
                if (this.Direction == Constants.PrimaryToRecovery)
                {
                    var blob = new AzureFailoverInput();
                    blob.VaultLocation = this.GetCurrentValutLocation();
                    request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailoverInput>(blob);
                }
            }

            request.ReplicationProvider = this.ProtectionEntity.ReplicationProvider;
            request.FailoverDirection = this.Direction;

            request.NetworkID = this.networkId;
            request.NetworkType = this.networkType;

            this.jobResponse =
                RecoveryServicesClient.StartAzureSiteRecoveryTestFailover(
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
        /// Updates required parameters and starts test failover.
        /// </summary>
        private void UpdateRequiredParametersAndStartFailover()
        {
            if (!this.ProtectionEntity.Protected)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ProtectionEntityNotProtected,
                    this.ProtectionEntity.Name));
            }

            this.ProtectionContainerId = this.ProtectionEntity.ProtectionContainerId;
            this.ProtectionEntityId = this.ProtectionEntity.ID;
            this.StartPETestFailover();
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