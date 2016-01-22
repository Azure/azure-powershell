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
using System.ComponentModel;
using System.Management.Automation;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;
using System.Collections.Generic;

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
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVSiteToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity[] ProtectionEntityList { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                switch(this.ParameterSetName)
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

                }
                this.CreateReplicationPlan();
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Creates Replication Plan
        /// </summary>
        private void CreateReplicationPlan()
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

                RecoveryPlanProtectedItem recoveryPlanProtectedItem = new RecoveryPlanProtectedItem();
                recoveryPlanProtectedItem.Id = replicationProtectedItemResponse.ReplicationProtectedItem.Id;
                recoveryPlanGroup.ReplicationProtectedItems.Add(recoveryPlanProtectedItem);

            }

            createRecoveryPlanInputProperties.Groups.Add(recoveryPlanGroup);

            CreateRecoveryPlanInput createRecoveryPlanInput = new CreateRecoveryPlanInput()
            {
                Properties = createRecoveryPlanInputProperties
            };

            LongRunningOperationResponse response =
                RecoveryServicesClient.CreateAzureSiteRecoveryRecoveryPlan(this.Name, createRecoveryPlanInput);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
