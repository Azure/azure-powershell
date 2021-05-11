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
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Creates Azure Site Recovery Recovery Plan object.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrRecoveryPlan", DefaultParameterSetName = ASRParameterSets.EnterpriseToEnterprise, SupportsShouldProcess = true)]
    [Alias(
        "New-ASRRP",
        "New-ASRRecoveryPlan")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrRecoveryPlan : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets failover deployment model
        /// </summary>
        public string failoverDeploymentModel;

        /// <summary>
        ///     Gets or sets Name of the primary server.
        /// </summary>
        public string primaryserver;

        /// <summary>
        ///     Gets or sets Name of the recovery server.
        /// </summary>
        public string recoveryserver;

        /// <summary>
        ///     Gets or sets name of the recovery plan.
        /// </summary>
        private RecoveryPlan recoveryPlan;

        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureZoneToZone,
            Mandatory = true)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the ASR fabric object for the primary ASR fabric
        ///     of the replication protected items that will be part of this recovery plan.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureZoneToZone,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric PrimaryFabric { get; set; }

        /// <summary>
        ///     Gets or sets the ASR fabric object for the recovery ASR fabric 
        ///     of the replication protected items that will be part of this recovery plan.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        public ASRFabric RecoveryFabric { get; set; }

        /// <summary>
        ///     Gets or sets the primary zone of the replication protected items that will be part of this recovery plan.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureZoneToZone,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string PrimaryZone { get; set; }

        /// <summary>
        ///     Gets or sets the recovery zone of the replication protected items that will be part of this recovery plan.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureZoneToZone,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryZone { get; set; }

        /// <summary>
        ///     Switch parameter to specify that the recovery location for recovery plan is Azure.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        public SwitchParameter Azure { get; set; }

        /// <summary>
        ///    Switch parameter to specify that the replicated item is an Azure virtual machine 
        ///    replicating from one Azure zone to another Azure zone.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureZoneToZone,
            Mandatory = true,
            HelpMessage = "Switch parameter specifies creating the replicated item in azure zone to zone scenario.")]
        public SwitchParameter AzureZoneToZone { get; set; }

        /// <summary>
        ///     Gets or sets the failover deployment model (Classic or Resource Manager)
        ///     of the replication protected items that will be part of this recovery plan.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.Classic,
            Constants.ResourceManager)]
        public string FailoverDeploymentModel { get; set; }

        /// <summary>
        ///     Gets or sets the  list of replication protected items to add to the first group of the recovery plan.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureZoneToZone,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem[] ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets the path to the recovery plan definition json file. 
        ///     A recovery plan definition json can be used to create the recovery plan.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPFile,
            Mandatory = true)]
        public string Path { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                "Recovery plan",
                VerbsCommon.New))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.EnterpriseToEnterprise:
                        this.failoverDeploymentModel = Constants.NotApplicable;
                        this.primaryserver = this.PrimaryFabric.ID;
                        this.recoveryserver = this.RecoveryFabric.ID;
                        break;
                    case ASRParameterSets.AzureZoneToZone:
                        this.failoverDeploymentModel = Constants.NotApplicable;
                        this.primaryserver = this.PrimaryFabric.ID;
                        this.recoveryserver = this.PrimaryFabric.ID;
                        break;
                    case ASRParameterSets.EnterpriseToAzure:
                        this.failoverDeploymentModel = this.FailoverDeploymentModel;
                        this.primaryserver = this.PrimaryFabric.ID;
                        this.recoveryserver = Constants.AzureContainer;
                        break;
                    case ASRParameterSets.ByRPFile:

                        if (!File.Exists(this.Path))
                        {
                            throw new FileNotFoundException(
                                string.Format(
                                    Resources.FileNotFound,
                                    this.Path));

                            ;
                        }

                        var filePath = this.Path;

                        using (var file = new StreamReader(filePath))
                        {
                            this.recoveryPlan = JsonConvert.DeserializeObject<RecoveryPlan>(
                                file.ReadToEnd(),
                                new RecoveryPlanActionDetailsConverter(),
                                new RecoveryPlanProviderSpecificDetailsConverter());
                        }

                        break;
                }

                if (string.Compare(
                        this.ParameterSetName,
                        ASRParameterSets.ByRPFile,
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    this.CreateRecoveryPlan(this.recoveryPlan);
                }
                else
                {
                    this.CreateRecoveryPlan();
                }
            }
        }

        /// <summary>
        ///     Creates Replication Plan
        /// </summary>
        private void CreateRecoveryPlan()
        {
            var createRecoveryPlanInputProperties = new CreateRecoveryPlanInputProperties
            {
                FailoverDeploymentModel = this.failoverDeploymentModel,
                Groups = new List<RecoveryPlanGroup>(),
                PrimaryFabricId = this.primaryserver,
                RecoveryFabricId = this.recoveryserver
            };

            var recoveryPlanGroup = new RecoveryPlanGroup
            {
                GroupType = RecoveryPlanGroupType.Boot,
                ReplicationProtectedItems = new List<RecoveryPlanProtectedItem>(),
                StartGroupActions = new List<RecoveryPlanAction>(),
                EndGroupActions = new List<RecoveryPlanAction>()
            };

            foreach (var rpi in this.ReplicationProtectedItem)
            {
                var fabricName = Utilities.GetValueFromArmId(
                    rpi.ID,
                    ARMResourceTypeConstants.ReplicationFabrics);

                var replicationProtectedItemResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryReplicationProtectedItem(
                        fabricName,
                        Utilities.GetValueFromArmId(
                            rpi.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers),
                        rpi.Name);

                string VmId = null;

                if (replicationProtectedItemResponse.Properties.ProviderSpecificDetails.GetType() ==
                    typeof(HyperVReplicaAzureReplicationDetails))
                {
                    VmId = ((HyperVReplicaAzureReplicationDetails)replicationProtectedItemResponse
                        .Properties.ProviderSpecificDetails).VmId;
                }
                else if (replicationProtectedItemResponse.Properties.ProviderSpecificDetails
                             .GetType() ==
                         typeof(HyperVReplicaReplicationDetails))
                {
                    VmId = ((HyperVReplicaReplicationDetails)replicationProtectedItemResponse
                        .Properties.ProviderSpecificDetails).VmId;
                }
                else if (replicationProtectedItemResponse.Properties.ProviderSpecificDetails
                             .GetType() ==
                         typeof(HyperVReplicaBlueReplicationDetails))
                {
                    VmId = ((HyperVReplicaBlueReplicationDetails)replicationProtectedItemResponse
                        .Properties.ProviderSpecificDetails).VmId;
                }
                else if (replicationProtectedItemResponse.Properties.ProviderSpecificDetails
                        .GetType() ==
                    typeof(InMageAzureV2ReplicationDetails))
                {
                    VmId = ((InMageAzureV2ReplicationDetails)replicationProtectedItemResponse
                        .Properties.ProviderSpecificDetails).VmId;
                }
                else if (replicationProtectedItemResponse.Properties.ProviderSpecificDetails
                        .GetType() ==
                    typeof(InMageReplicationDetails))
                {
                    VmId = ((InMageReplicationDetails)replicationProtectedItemResponse
                        .Properties.ProviderSpecificDetails).VmId;
                }
                else if (replicationProtectedItemResponse.Properties.ProviderSpecificDetails.GetType() == typeof(A2AReplicationDetails))
                {
                    A2AReplicationDetails a2aReplicationDetails =
                        ((A2AReplicationDetails)replicationProtectedItemResponse
                        .Properties
                        .ProviderSpecificDetails);
                    if (a2aReplicationDetails.FabricObjectId.IndexOf(
                        Constants.ClassicCompute,
                        StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        createRecoveryPlanInputProperties.FailoverDeploymentModel =
                            Management.RecoveryServices.SiteRecovery.Models.FailoverDeploymentModel.Classic;
                    }
                    else if (a2aReplicationDetails.FabricObjectId.IndexOf(
                        Constants.Compute,
                        StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        createRecoveryPlanInputProperties.FailoverDeploymentModel =
                            Management.RecoveryServices.SiteRecovery.Models.FailoverDeploymentModel.ResourceManager;
                    }
                }
                else if (replicationProtectedItemResponse.Properties.ProviderSpecificDetails
                        .GetType() ==
                    typeof(InMageRcmReplicationDetails))
                {
                    VmId = ((InMageRcmReplicationDetails)replicationProtectedItemResponse
                        .Properties.ProviderSpecificDetails).InternalIdentifier;
                    createRecoveryPlanInputProperties.FailoverDeploymentModel =
                            Management.RecoveryServices.SiteRecovery.Models.FailoverDeploymentModel.ResourceManager;
                }
                else if (replicationProtectedItemResponse.Properties.ProviderSpecificDetails
                        .GetType() ==
                    typeof(InMageRcmFailbackReplicationDetails))
                {
                    VmId = ((InMageRcmFailbackReplicationDetails)replicationProtectedItemResponse
                        .Properties.ProviderSpecificDetails).InternalIdentifier;
                    createRecoveryPlanInputProperties.FailoverDeploymentModel =
                            Management.RecoveryServices.SiteRecovery.Models.FailoverDeploymentModel.ResourceManager;
                }

                var recoveryPlanProtectedItem = new RecoveryPlanProtectedItem();
                recoveryPlanProtectedItem.Id = replicationProtectedItemResponse.Id;
                recoveryPlanProtectedItem.VirtualMachineId = VmId;
                recoveryPlanGroup.ReplicationProtectedItems.Add(recoveryPlanProtectedItem);
            }

            createRecoveryPlanInputProperties.Groups.Add(recoveryPlanGroup);

            // Add zone to zone details.
            if (this.ParameterSetName == ASRParameterSets.AzureZoneToZone)
            {
                var recoveryPlanA2AInput = new RecoveryPlanA2AInput
                {
                    PrimaryZone = this.PrimaryZone,
                    RecoveryZone = this.RecoveryZone
                };

                createRecoveryPlanInputProperties.ProviderSpecificInput = new List<RecoveryPlanProviderSpecificInput>();
                createRecoveryPlanInputProperties.ProviderSpecificInput.Add(recoveryPlanA2AInput);
            }


            var createRecoveryPlanInput =
                new CreateRecoveryPlanInput { Properties = createRecoveryPlanInputProperties };

            this.CreateRecoveryPlan(
                this.Name,
                createRecoveryPlanInput);
        }

        /// <summary>
        ///     Create Recovery Plan: By Service object
        /// </summary>
        private void CreateRecoveryPlan(
            RecoveryPlan recoveryPlan)
        {
            var createRecoveryPlanInputProperties = new CreateRecoveryPlanInputProperties
            {
                FailoverDeploymentModel = recoveryPlan.Properties.FailoverDeploymentModel,
                Groups = recoveryPlan.Properties.Groups,
                PrimaryFabricId = recoveryPlan.Properties.PrimaryFabricId,
                RecoveryFabricId = recoveryPlan.Properties.RecoveryFabricId
            };

            if (recoveryPlan.Properties.ProviderSpecificDetails != null &&
                recoveryPlan.Properties.ProviderSpecificDetails.Count > 0)
            {
                createRecoveryPlanInputProperties.ProviderSpecificInput = 
                    new List<RecoveryPlanProviderSpecificInput>();
                foreach (var providerSpecificDetails in recoveryPlan.Properties.ProviderSpecificDetails)
                {
                    if (providerSpecificDetails is RecoveryPlanA2ADetails)
                    {
                        var a2aProviderDetails = (RecoveryPlanA2ADetails)providerSpecificDetails;
                        var psd = new RecoveryPlanA2AInput
                        {
                            RecoveryZone = a2aProviderDetails.RecoveryZone,
                            PrimaryZone = a2aProviderDetails.PrimaryZone
                        };

                        createRecoveryPlanInputProperties.ProviderSpecificInput.Add(psd);
                    }
                }
            }

            var createRecoveryPlanInput =
                new CreateRecoveryPlanInput { Properties = createRecoveryPlanInputProperties };

            this.CreateRecoveryPlan(
                recoveryPlan.Name,
                createRecoveryPlanInput);
        }

        /// <summary>
        ///     Create Replication Plan: Utility call
        /// </summary>
        private void CreateRecoveryPlan(
            string recoveryPlanName,
            CreateRecoveryPlanInput createRecoveryPlanInput)
        {
            var response = this.RecoveryServicesClient.CreateAzureSiteRecoveryRecoveryPlan(
                recoveryPlanName,
                createRecoveryPlanInput);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }
    }
}
