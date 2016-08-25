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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Creates Azure Site Recovery Recovery Plan object.
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzureRmSiteRecoveryRecoveryPlan", DefaultParameterSetName = ASRParameterSets.ByRPObject)]
    public class UpdateAzureSiteRecoveryRecoveryPlan : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets Name of the Recovery Plan.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObject, Mandatory = true, ValueFromPipeline = true)]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

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
                case ASRParameterSets.ByRPObject:
                    UpdateRecoveryPlan(this.RecoveryPlan);
                    break;
                case ASRParameterSets.ByRPFile:

                    if (!File.Exists(this.Path))
                    {
                        throw new FileNotFoundException(string.Format(Properties.Resources.FileNotFound, this.Path)); ;
                    }

                    string filePath = this.Path;
                    RecoveryPlan recoveryPlan = null;

                    using (System.IO.StreamReader file = new System.IO.StreamReader(filePath))
                    {
                        recoveryPlan = JsonConvert.DeserializeObject<RecoveryPlan>(file.ReadToEnd(), new RecoveryPlanActionDetailsConverter());
                    }

                    UpdateRecoveryPlan(recoveryPlan);
                    break;
            }
        }

        /// <summary>
        /// Update Recovery Plan: By powerShell Recovery Plan object
        /// </summary>
        private void UpdateRecoveryPlan(ASRRecoveryPlan asrRecoveryPlan)
        {
            UpdateRecoveryPlanInputProperties updateRecoveryPlanInputProperties = new UpdateRecoveryPlanInputProperties()
            {
                Groups = new List<RecoveryPlanGroup>(),
            };

            foreach (ASRRecoveryPlanGroup asrRecoveryPlanGroup in asrRecoveryPlan.Groups)
            {
                RecoveryPlanGroup recoveryPlanGroup = new RecoveryPlanGroup()
                {
                    GroupType = asrRecoveryPlanGroup.GroupType,

                    // Initialize ReplicationProtectedItems with empty List if asrRecoveryPlanGroup.ReplicationProtectedItems is null
                    // otherwise assign respective values
                    ReplicationProtectedItems = asrRecoveryPlanGroup.ReplicationProtectedItems == null ? new List<RecoveryPlanProtectedItem>() :
                    asrRecoveryPlanGroup.ReplicationProtectedItems.Select(item =>
                        {
                            var newItem = new RecoveryPlanProtectedItem(item.Id);

                            string VmId = null;

                            if (item.Properties.ProviderSpecificDetails.GetType() == typeof(HyperVReplicaAzureReplicationDetails))
                            {
                                VmId = ((HyperVReplicaAzureReplicationDetails)item.Properties.ProviderSpecificDetails).VmId;
                            }
                            else if (item.Properties.ProviderSpecificDetails.GetType() == typeof(HyperVReplica2012ReplicationDetails))
                            {
                                VmId = ((HyperVReplica2012ReplicationDetails)item.Properties.ProviderSpecificDetails).VmId;
                            }

                            newItem.VirtualMachineId = VmId;

                            return newItem;

                        }).ToList(),
                    StartGroupActions = asrRecoveryPlanGroup.StartGroupActions,
                    EndGroupActions = asrRecoveryPlanGroup.EndGroupActions
                };

                updateRecoveryPlanInputProperties.Groups.Add(recoveryPlanGroup);
            }

            UpdateRecoveryPlanInput updateRecoveryPlanInput = new UpdateRecoveryPlanInput()
            {
                Properties = updateRecoveryPlanInputProperties
            };

            UpdateRecoveryPlan(asrRecoveryPlan.Name, updateRecoveryPlanInput);
        }

        /// <summary>
        /// Update Recovery Plan: By Service object
        /// </summary>
        private void UpdateRecoveryPlan(RecoveryPlan recoveryPlan)
        {
            UpdateRecoveryPlanInputProperties updateRecoveryPlanInputProperties = new UpdateRecoveryPlanInputProperties()
            {
                Groups = recoveryPlan.Properties.Groups,
            };

            UpdateRecoveryPlanInput updateRecoveryPlanInput = new UpdateRecoveryPlanInput()
            {
                Properties = updateRecoveryPlanInputProperties
            };

            UpdateRecoveryPlan(recoveryPlan.Name, updateRecoveryPlanInput);
        }

        /// <summary>
        /// Update Replication Plan: Utility call
        /// </summary>
        private void UpdateRecoveryPlan(string recoveryPlanName, UpdateRecoveryPlanInput updateRecoveryPlanInput)
        {
            LongRunningOperationResponse response =
            RecoveryServicesClient.UpdateAzureSiteRecoveryRecoveryPlan(recoveryPlanName, updateRecoveryPlanInput);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }

    }
}
