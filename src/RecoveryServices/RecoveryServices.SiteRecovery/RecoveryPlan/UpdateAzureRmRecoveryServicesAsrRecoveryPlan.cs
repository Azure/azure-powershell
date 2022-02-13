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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Updates the contents of an Azure Site recovery plan.
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrRecoveryPlan", DefaultParameterSetName = ASRParameterSets.ByRPObject, SupportsShouldProcess = true)]
    [Alias("Update-ASRRecoveryPlan")]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureRmRecoveryServicesAsrRecoveryPlan : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Name of the Recovery Plan object,
        ///     the contents of which are used to update the recovery plan referred to by the object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Alias("RecoveryPlan")]
        public ASRRecoveryPlan InputObject { get; set; }

        /// <summary>
        ///     Gets or sets the path of the recovery plan definition json file used to update the recovery plan.
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
                VerbsData.Update))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByRPObject:
                        this.UpdateRecoveryPlan(this.InputObject);
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

                        RecoveryPlan recoveryPlan = null;

                        using (var file = new StreamReader(filePath))
                        {
                            recoveryPlan = JsonConvert.DeserializeObject<RecoveryPlan>(
                                file.ReadToEnd(),
                                new RecoveryPlanActionDetailsConverter());
                        }

                        this.UpdateRecoveryPlan(recoveryPlan);

                        break;
                }
            }
        }

        /// <summary>
        ///     Update Recovery Plan: By powerShell Recovery Plan object
        /// </summary>
        private void UpdateRecoveryPlan(
            ASRRecoveryPlan asrRecoveryPlan)
        {
            var updateRecoveryPlanInputProperties =
                new UpdateRecoveryPlanInputProperties { Groups = new List<RecoveryPlanGroup>() };

            foreach (var asrRecoveryPlanGroup in asrRecoveryPlan.Groups)
            {
                var recoveryPlanGroup = new RecoveryPlanGroup
                {
                    GroupType = asrRecoveryPlanGroup.GroupType,

                    // Initialize ReplicationProtectedItems with empty List if asrRecoveryPlanGroup.ReplicationProtectedItems is null
                    // otherwise assign respective values
                    ReplicationProtectedItems =
                        asrRecoveryPlanGroup.ReplicationProtectedItems == null
                            ? new List<RecoveryPlanProtectedItem>() : asrRecoveryPlanGroup
                                .ReplicationProtectedItems.Select(
                                    item =>
                                    {
                                        var newItem = new RecoveryPlanProtectedItem(item.ID);

                                        string VmId = null;

                                        if (item.ProviderSpecificDetails.GetType() ==
                                            typeof(ASRHyperVReplicaAzureSpecificRPIDetails))
                                        {
                                            VmId = ((ASRHyperVReplicaAzureSpecificRPIDetails)item.ProviderSpecificDetails).VmId;
                                        }
                                        else if (item.ProviderSpecificDetails.GetType() == typeof(ASRHyperVReplicaRPIDetails))
                                        {
                                            VmId = ((ASRHyperVReplicaRPIDetails)item.ProviderSpecificDetails).VmId;
                                        }
                                        else if (item.ProviderSpecificDetails.GetType() == typeof(ASRHyperVReplicaBlueRPIDetails))
                                        {
                                            VmId = ((ASRHyperVReplicaBlueRPIDetails)item.ProviderSpecificDetails).VmId;
                                        }
                                        else if (item.ProviderSpecificDetails.GetType() == typeof(ASRInMageSpecificRPIDetails))
                                        {
                                            VmId = ((ASRInMageSpecificRPIDetails)item.ProviderSpecificDetails).VmId;
                                        }
                                        else if (item.ProviderSpecificDetails.GetType() == typeof(ASRInMageSpecificRPIDetails))
                                        {
                                            VmId = ((ASRInMageSpecificRPIDetails)item.ProviderSpecificDetails).VmId;
                                        }
                                        else if (item.ProviderSpecificDetails.GetType() == typeof(ASRInMageRcmSpecificRPIDetails))
                                        {
                                            VmId = ((ASRInMageRcmSpecificRPIDetails)item.ProviderSpecificDetails).InternalIdentifier;
                                        }
                                        else if (item.ProviderSpecificDetails.GetType() == typeof(ASRInMageRcmFailbackSpecificRPIDetails))
                                        {
                                            VmId = ((ASRInMageRcmFailbackSpecificRPIDetails)item.ProviderSpecificDetails).InternalIdentifier;
                                        }

                                        newItem.VirtualMachineId = VmId;

                                        return newItem;
                                    })
                                .ToList(),
                    StartGroupActions = asrRecoveryPlanGroup.StartGroupActions == null ?
                    null : asrRecoveryPlanGroup.StartGroupActions.ToList().ConvertAll(
                        action => ASRRecoveryPlanAction.GetSrsRecoveryPlanAction(action)),
                    EndGroupActions = asrRecoveryPlanGroup.EndGroupActions == null ?
                    null : asrRecoveryPlanGroup.EndGroupActions.ToList().ConvertAll(
                        action => ASRRecoveryPlanAction.GetSrsRecoveryPlanAction(action)),
                };

                updateRecoveryPlanInputProperties.Groups.Add(recoveryPlanGroup);
            }

            var updateRecoveryPlanInput =
                new UpdateRecoveryPlanInput { Properties = updateRecoveryPlanInputProperties };

            this.UpdateRecoveryPlan(
                asrRecoveryPlan.Name,
                updateRecoveryPlanInput);
        }

        /// <summary>
        ///     Update Recovery Plan: By Service object
        /// </summary>
        private void UpdateRecoveryPlan(
            RecoveryPlan recoveryPlan)
        {
            var updateRecoveryPlanInputProperties =
                new UpdateRecoveryPlanInputProperties { Groups = recoveryPlan.Properties.Groups };

            var updateRecoveryPlanInput =
                new UpdateRecoveryPlanInput { Properties = updateRecoveryPlanInputProperties };

            this.UpdateRecoveryPlan(
                recoveryPlan.Name,
                updateRecoveryPlanInput);
        }

        /// <summary>
        ///     Update Replication Plan: Utility call
        /// </summary>
        private void UpdateRecoveryPlan(
            string recoveryPlanName,
            UpdateRecoveryPlanInput updateRecoveryPlanInput)
        {
            var response = this.RecoveryServicesClient.UpdateAzureSiteRecoveryRecoveryPlan(
                recoveryPlanName,
                updateRecoveryPlanInput);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }
    }
}
