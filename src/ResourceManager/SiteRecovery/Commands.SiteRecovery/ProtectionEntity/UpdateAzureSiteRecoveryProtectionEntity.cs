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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.Azure.Management.SiteRecovery.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    ///// <summary>
    ///// Used to initiate a recovery protection operation.
    ///// </summary>
    //[Cmdlet(VerbsData.Update, "AzureRmSiteRecoveryProtectionEntity", DefaultParameterSetName = ASRParameterSets.ByPEObject)]
    //[OutputType(typeof(ASRJob))]
    public class UpdateAzureSiteRecoveryProtectionEntity : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets Name of the PE.
        /// </summary>
        private string protectionEntityName;

        /// <summary>
        /// Gets or sets Name of the Protection Container.
        /// </summary>
        private string protectionContainerName;

        /// <summary>
        /// Gets or sets Name of the Fabric.
        /// </summary>
        private string fabricName;

        /// <summary>
        /// Gets or sets Protection Entity object.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity ProtectionEntity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets switch parameter. This is required to wait for job completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion
        {
            get;
            set;
        }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.protectionEntityName = this.ProtectionEntity.Name;
                this.protectionContainerName = this.ProtectionEntity.ProtectionContainerId;
                this.fabricName = Utilities.GetValueFromArmId(this.ProtectionEntity.ID, ARMResourceTypeConstants.ReplicationFabrics);
                this.SyncOwnerInformationOnPE();
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Handles interrupts.
        /// </summary>
        protected override void StopProcessing()
        {
            // Ctrl + C and etc
            base.StopProcessing();
            this.StopProcessingFlag = true;
        }

        /// <summary>
        /// Syncs the owner information.
        /// </summary>
        private void SyncOwnerInformationOnPE()
        {
            // fetch the latest PE object
            ProtectableItemResponse protectableItemResponse =
                                        RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(this.fabricName,
                                        this.ProtectionEntity.ProtectionContainerId, this.ProtectionEntity.Name);

            ReplicationProtectedItemResponse replicationProtectedItemResponse =
                        RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(this.fabricName,
                        this.ProtectionEntity.ProtectionContainerId, Utilities.GetValueFromArmId(protectableItemResponse.ProtectableItem.Properties.ReplicationProtectedItemId,  ARMResourceTypeConstants.ReplicationProtectedItems));

            PolicyResponse policyResponse = RecoveryServicesClient.GetAzureSiteRecoveryPolicy(Utilities.GetValueFromArmId(replicationProtectedItemResponse.ReplicationProtectedItem.Properties.PolicyID, ARMResourceTypeConstants.ReplicationPolicies));

            this.ProtectionEntity = new ASRProtectionEntity(protectableItemResponse.ProtectableItem, replicationProtectedItemResponse.ReplicationProtectedItem);

            LongRunningOperationResponse response = RecoveryServicesClient.UpdateAzureSiteRecoveryProtectionEntity(               
                this.fabricName,
                this.protectionContainerName,
                Utilities.GetValueFromArmId(replicationProtectedItemResponse.ReplicationProtectedItem.Id,  ARMResourceTypeConstants.ReplicationProtectedItems),
                new Object()
                );

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));       

            if (this.WaitForCompletion)
            {
                this.WaitForJobCompletion(jobResponse.Job.Name);

                jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                WriteObject(new ASRJob(jobResponse.Job));
            }
        }
    }
}