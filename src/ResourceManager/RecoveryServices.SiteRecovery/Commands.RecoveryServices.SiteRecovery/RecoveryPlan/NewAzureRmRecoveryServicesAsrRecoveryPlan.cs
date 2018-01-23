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
    [Cmdlet(
        VerbsCommon.New,
        "AzureRmRecoveryServicesAsrRecoveryPlan",
        DefaultParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
        SupportsShouldProcess = true)]
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
        ///     Gets or sets recovery plan object
        /// </summary>
        private RecoveryPlan recoveryPlan;

        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Points of the Policy.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric PrimaryFabric { get; set; }

        /// <summary>
        ///     Gets or sets Application Consistent Snapshot Frequency of the Policy in hours.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric RecoveryFabric { get; set; }

        /// <summary>
        ///     Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        public SwitchParameter Azure { get; set; }

        /// <summary>
        ///     Gets or sets Replication Provider of the Policy.
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
        ///     Gets or sets Replication Frequency of the Policy in seconds.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem[] ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets RP JSON FilePath.
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
                                new RecoveryPlanActionDetailsConverter());
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
                FailoverDeploymentModel = (FailoverDeploymentModel)Enum.Parse(
                    typeof(FailoverDeploymentModel),
                    this.failoverDeploymentModel),
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

                var recoveryPlanProtectedItem = new RecoveryPlanProtectedItem();
                recoveryPlanProtectedItem.Id = replicationProtectedItemResponse.Id;
                recoveryPlanProtectedItem.VirtualMachineId = VmId;
                recoveryPlanGroup.ReplicationProtectedItems.Add(recoveryPlanProtectedItem);
            }

            createRecoveryPlanInputProperties.Groups.Add(recoveryPlanGroup);

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
                FailoverDeploymentModel = (FailoverDeploymentModel)Enum.Parse(
                    typeof(FailoverDeploymentModel),
                    recoveryPlan.Properties.FailoverDeploymentModel),
                Groups = recoveryPlan.Properties.Groups,
                PrimaryFabricId = recoveryPlan.Properties.PrimaryFabricId,
                RecoveryFabricId = recoveryPlan.Properties.RecoveryFabricId
            };

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
