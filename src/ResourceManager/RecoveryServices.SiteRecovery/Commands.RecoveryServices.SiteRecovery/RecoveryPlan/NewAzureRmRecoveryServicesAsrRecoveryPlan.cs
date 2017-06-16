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
    [Cmdlet(VerbsCommon.New,
        "AzureRmRecoveryServicesAsrRecoveryPlan",
        DefaultParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
    [Alias("New-ASRRP",
        "New-ASRRecoveryPlan")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrRecoveryPlan : SiteRecoveryCmdletBase
    {
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Points of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric PrimaryFabric { get; set; }

        /// <summary>
        ///     Gets or sets Application Consistent Snapshot Frequency of the Policy in hours.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric RecoveryFabric { get; set; }

        /// <summary>
        ///     Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        public SwitchParameter Azure { get; set; }

        /// <summary>
        ///     Gets or sets Replication Provider of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.Classic,
            Constants.ResourceManager)]
        public string FailoverDeploymentModel { get; set; }

        /// <summary>
        ///     Gets or sets Replication Frequency of the Policy in seconds.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem[] ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets RP JSON FilePath.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPFile,
            Mandatory = true)]
        public string Path { get; set; }

        /// <summary>
        ///     Gets or sets failover deployment model
        /// </summary>
        public string failoverDeploymentModel;

        /// <summary>
        ///     Gets or sets Name of the primary server.
        /// </summary>
        public string primaryserver;

        /// <summary>
        ///     Gets or sets recovery plan object
        /// </summary>
        private RecoveryPlan recoveryPlan;

        /// <summary>
        ///     Gets or sets Name of the recovery server.
        /// </summary>
        public string recoveryserver;

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (ParameterSetName)
            {
                case ASRParameterSets.EnterpriseToEnterprise:
                    failoverDeploymentModel = Constants.NotApplicable;
                    primaryserver = PrimaryFabric.ID;
                    recoveryserver = RecoveryFabric.ID;
                    break;
                case ASRParameterSets.EnterpriseToAzure:
                    failoverDeploymentModel = FailoverDeploymentModel;
                    primaryserver = PrimaryFabric.ID;
                    recoveryserver = Constants.AzureContainer;
                    break;
                case ASRParameterSets.ByRPFile:

                    if (!File.Exists(Path))
                    {
                        throw new FileNotFoundException(string.Format(Resources.FileNotFound,
                            Path));

                        ;
                    }

                    var filePath = Path;

                    using (var file = new StreamReader(filePath))
                    {
                        recoveryPlan = JsonConvert.DeserializeObject<RecoveryPlan>(file.ReadToEnd(),
                            new RecoveryPlanActionDetailsConverter());
                    }

                    break;
            }

            if (string.Compare(ParameterSetName,
                    ASRParameterSets.ByRPFile,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                CreateRecoveryPlan(recoveryPlan);
            }
            else
            {
                CreateRecoveryPlan();
            }
        }

        /// <summary>
        ///     Creates Replication Plan
        /// </summary>
        private void CreateRecoveryPlan()
        {
            var createRecoveryPlanInputProperties = new CreateRecoveryPlanInputProperties
            {
                FailoverDeploymentModel = (FailoverDeploymentModel) Enum.Parse(
                    typeof(FailoverDeploymentModel),
                    failoverDeploymentModel),
                Groups = new List<RecoveryPlanGroup>(),
                PrimaryFabricId = primaryserver,
                RecoveryFabricId = recoveryserver
            };

            var recoveryPlanGroup = new RecoveryPlanGroup
            {
                GroupType = RecoveryPlanGroupType.Boot,
                ReplicationProtectedItems = new List<RecoveryPlanProtectedItem>(),
                StartGroupActions = new List<RecoveryPlanAction>(),
                EndGroupActions = new List<RecoveryPlanAction>()
            };

            foreach (var rpi in ReplicationProtectedItem)
            {
                var fabricName = Utilities.GetValueFromArmId(rpi.ID,
                    ARMResourceTypeConstants.ReplicationFabrics);

                var replicationProtectedItemResponse = RecoveryServicesClient
                    .GetAzureSiteRecoveryReplicationProtectedItem(fabricName,
                        Utilities.GetValueFromArmId(rpi.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers),
                        rpi.Name);

                string VmId = null;

                if (replicationProtectedItemResponse.Properties.ProviderSpecificDetails.GetType() ==
                    typeof(HyperVReplicaAzureReplicationDetails))
                {
                    VmId = ((HyperVReplicaAzureReplicationDetails) replicationProtectedItemResponse
                        .Properties.ProviderSpecificDetails).VmId;
                }
                else if (replicationProtectedItemResponse.Properties.ProviderSpecificDetails
                             .GetType() ==
                         typeof(HyperVReplicaReplicationDetails))
                {
                    VmId = ((HyperVReplicaReplicationDetails) replicationProtectedItemResponse
                        .Properties.ProviderSpecificDetails).VmId;
                }
                else if (replicationProtectedItemResponse.Properties.ProviderSpecificDetails
                             .GetType() ==
                         typeof(HyperVReplicaBlueReplicationDetails))
                {
                    VmId = ((HyperVReplicaBlueReplicationDetails) replicationProtectedItemResponse
                        .Properties.ProviderSpecificDetails).VmId;
                }

                var recoveryPlanProtectedItem = new RecoveryPlanProtectedItem();
                recoveryPlanProtectedItem.Id = replicationProtectedItemResponse.Id;
                recoveryPlanProtectedItem.VirtualMachineId = VmId;
                recoveryPlanGroup.ReplicationProtectedItems.Add(recoveryPlanProtectedItem);
            }

            createRecoveryPlanInputProperties.Groups.Add(recoveryPlanGroup);

            var createRecoveryPlanInput =
                new CreateRecoveryPlanInput {Properties = createRecoveryPlanInputProperties};

            CreateRecoveryPlan(Name,
                createRecoveryPlanInput);
        }

        /// <summary>
        ///     Create Recovery Plan: By Service object
        /// </summary>
        private void CreateRecoveryPlan(RecoveryPlan recoveryPlan)
        {
            var createRecoveryPlanInputProperties = new CreateRecoveryPlanInputProperties
            {
                FailoverDeploymentModel = (FailoverDeploymentModel) Enum.Parse(
                    typeof(FailoverDeploymentModel),
                    recoveryPlan.Properties.FailoverDeploymentModel),
                Groups = recoveryPlan.Properties.Groups,
                PrimaryFabricId = recoveryPlan.Properties.PrimaryFabricId,
                RecoveryFabricId = recoveryPlan.Properties.RecoveryFabricId
            };

            var createRecoveryPlanInput =
                new CreateRecoveryPlanInput {Properties = createRecoveryPlanInputProperties};

            CreateRecoveryPlan(recoveryPlan.Name,
                createRecoveryPlanInput);
        }

        /// <summary>
        ///     Create Replication Plan: Utility call
        /// </summary>
        private void CreateRecoveryPlan(string recoveryPlanName,
            CreateRecoveryPlanInput createRecoveryPlanInput)
        {
            var response = RecoveryServicesClient.CreateAzureSiteRecoveryRecoveryPlan(
                recoveryPlanName,
                createRecoveryPlanInput);

            var jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient
                    .GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }
    }
}