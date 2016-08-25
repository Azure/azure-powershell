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

using Microsoft.Azure.Management.SiteRecovery.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Creates Azure Site Recovery Recovery Plan object.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSiteRecoveryRecoveryPlan", DefaultParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
    public class NewAzureSiteRecoveryRecoveryPlan : SiteRecoveryCmdletBase
    {
        /// <summary>
        /// Gets or sets Name of the primary server.
        /// </summary>
        public string primaryserver;

        /// <summary>
        /// Gets or sets Name of the recovery server.
        /// </summary>
        public string recoveryserver;

        /// <summary>
        /// Gets or sets failover deployment model
        /// </summary>
        public string failoverDeploymentModel;

        /// <summary>
        /// Gets or sets recovery plan object
        /// </summary>
        RecoveryPlan recoveryPlan = null;

        #region Parameters

        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Recovery Points of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRServer PrimaryServer { get; set; }

        /// <summary>
        /// Gets or sets Application Consistent Snapshot Frequency of the Policy in hours.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRServer RecoveryServer { get; set; }

        /// <summary>
        /// Gets or sets Application Consistent Snapshot Frequency of the Policy in hours.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRSite PrimarySite { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        public SwitchParameter Azure { get; set; }

        /// <summary>
        /// Gets or sets Replication Provider of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.Classic,
            Constants.ResourceManager)]
        public string FailoverDeploymentModel { get; set; }

        /// <summary>
        /// Gets or sets Replication Frequency of the Policy in seconds.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity[] ProtectionEntityList { get; set; }

        /// <summary>
        /// Gets or sets RP JSON FilePath.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPFile, Mandatory = true)]
        public string Path { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.EnterpriseToEnterprise:
                    failoverDeploymentModel = Constants.NotApplicable;
                    this.primaryserver = RecoveryServicesClient.GetAzureSiteRecoveryFabric(Utilities.GetValueFromArmId(this.PrimaryServer.ID, ARMResourceTypeConstants.ReplicationFabrics)).Fabric.Id;
                    this.recoveryserver = RecoveryServicesClient.GetAzureSiteRecoveryFabric(Utilities.GetValueFromArmId(this.RecoveryServer.ID, ARMResourceTypeConstants.ReplicationFabrics)).Fabric.Id;
                    break;
                case ASRParameterSets.EnterpriseToAzure:
                    failoverDeploymentModel = this.FailoverDeploymentModel;
                    this.primaryserver = RecoveryServicesClient.GetAzureSiteRecoveryFabric(Utilities.GetValueFromArmId(this.PrimaryServer.ID, ARMResourceTypeConstants.ReplicationFabrics)).Fabric.Id;
                    this.recoveryserver = Constants.AzureContainer;
                    break;
                case ASRParameterSets.HyperVSiteToAzure:
                    failoverDeploymentModel = this.FailoverDeploymentModel;
                    this.primaryserver = this.PrimarySite.ID;
                    this.recoveryserver = Constants.AzureContainer;
                    break;
                case ASRParameterSets.ByRPFile:

                    if (!File.Exists(this.Path))
                    {
                        throw new FileNotFoundException(string.Format(Properties.Resources.FileNotFound, this.Path)); ;
                    }

                    string filePath = this.Path;

                    using (System.IO.StreamReader file = new System.IO.StreamReader(filePath))
                    {
                        recoveryPlan = JsonConvert.DeserializeObject<RecoveryPlan>(file.ReadToEnd(), new RecoveryPlanActionDetailsConverter());
                    }

                    break;

            }

            if (string.Compare(this.ParameterSetName, ASRParameterSets.ByRPFile, StringComparison.OrdinalIgnoreCase) == 0)
            {
                CreateRecoveryPlan(recoveryPlan);
            }
            else
            {
                this.CreateRecoveryPlan();
            }
        }

        /// <summary>
        /// Creates Replication Plan
        /// </summary>
        private void CreateRecoveryPlan()
        {
            CreateRecoveryPlanInputProperties createRecoveryPlanInputProperties = new CreateRecoveryPlanInputProperties()
            {
                FailoverDeploymentModel = failoverDeploymentModel,
                Groups = new List<RecoveryPlanGroup>(),
                PrimaryFabricId = this.primaryserver,
                RecoveryFabricId = this.recoveryserver
            };

            RecoveryPlanGroup recoveryPlanGroup = new RecoveryPlanGroup()
            {
                GroupType = Constants.Boot,
                ReplicationProtectedItems = new List<RecoveryPlanProtectedItem>(),
                StartGroupActions = new List<RecoveryPlanAction>(),
                EndGroupActions = new List<RecoveryPlanAction>()
            };

            foreach (ASRProtectionEntity pe in ProtectionEntityList)
            {
                string fabricName = Utilities.GetValueFromArmId(pe.ID, ARMResourceTypeConstants.ReplicationFabrics);
                // fetch the latest PE object
                ProtectableItemResponse protectableItemResponse =
                                            RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(fabricName,
                                            pe.ProtectionContainerId, pe.Name);

                ReplicationProtectedItemResponse replicationProtectedItemResponse =
                            RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(fabricName,
                            pe.ProtectionContainerId, Utilities.GetValueFromArmId(protectableItemResponse.ProtectableItem.Properties.ReplicationProtectedItemId, ARMResourceTypeConstants.ReplicationProtectedItems));

                string VmId = null;

                if (replicationProtectedItemResponse.ReplicationProtectedItem.Properties.ProviderSpecificDetails.GetType() == typeof(HyperVReplicaAzureReplicationDetails))
                {
                    VmId = ((HyperVReplicaAzureReplicationDetails)replicationProtectedItemResponse.ReplicationProtectedItem.Properties.ProviderSpecificDetails).VmId;
                }
                else if (replicationProtectedItemResponse.ReplicationProtectedItem.Properties.ProviderSpecificDetails.GetType() == typeof(HyperVReplica2012ReplicationDetails))
                {
                    VmId = ((HyperVReplica2012ReplicationDetails)replicationProtectedItemResponse.ReplicationProtectedItem.Properties.ProviderSpecificDetails).VmId;
                }

                RecoveryPlanProtectedItem recoveryPlanProtectedItem = new RecoveryPlanProtectedItem();
                recoveryPlanProtectedItem.Id = replicationProtectedItemResponse.ReplicationProtectedItem.Id;
                recoveryPlanProtectedItem.VirtualMachineId = VmId;
                recoveryPlanGroup.ReplicationProtectedItems.Add(recoveryPlanProtectedItem);
            }

            createRecoveryPlanInputProperties.Groups.Add(recoveryPlanGroup);

            CreateRecoveryPlanInput createRecoveryPlanInput = new CreateRecoveryPlanInput()
            {
                Properties = createRecoveryPlanInputProperties
            };

            CreateRecoveryPlan(this.Name, createRecoveryPlanInput);
        }

        /// <summary>
        /// Create Recovery Plan: By Service object
        /// </summary>
        private void CreateRecoveryPlan(RecoveryPlan recoveryPlan)
        {
            CreateRecoveryPlanInputProperties createRecoveryPlanInputProperties = new CreateRecoveryPlanInputProperties()
            {
                FailoverDeploymentModel = recoveryPlan.Properties.FailoverDeploymentModel,
                Groups = recoveryPlan.Properties.Groups,
                PrimaryFabricId = recoveryPlan.Properties.PrimaryFabricId,
                RecoveryFabricId = recoveryPlan.Properties.RecoveryFabricId
            };

            CreateRecoveryPlanInput createRecoveryPlanInput = new CreateRecoveryPlanInput()
            {
                Properties = createRecoveryPlanInputProperties
            };

            CreateRecoveryPlan(recoveryPlan.Name, createRecoveryPlanInput);
        }

        /// <summary>
        /// Create Replication Plan: Utility call
        /// </summary>
        private void CreateRecoveryPlan(string recoveryPlanName, CreateRecoveryPlanInput createRecoveryPlanInput)
        {
            LongRunningOperationResponse response =
                RecoveryServicesClient.CreateAzureSiteRecoveryRecoveryPlan(recoveryPlanName, createRecoveryPlanInput);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
