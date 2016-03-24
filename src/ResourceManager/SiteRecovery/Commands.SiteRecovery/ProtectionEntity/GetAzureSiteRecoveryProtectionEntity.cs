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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Protection Entity.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryProtectionEntity", DefaultParameterSetName = ASRParameterSets.ByObject)]
    [OutputType(typeof(IEnumerable<ASRProtectionEntity>))]
    public class GetAzureSiteRecoveryProtectionEntity : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Name of the Replicated Protected Item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets friendly name of the Protection Entity.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets Server Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer ProtectionContainer { get; set; }
        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByObject:
                        this.GetAll();
                        break;
                    case ASRParameterSets.ByObjectWithName:
                        this.GetByName();
                        break;
                    case ASRParameterSets.ByObjectWithFriendlyName:
                        this.GetByFriendlyName();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Queries by friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            bool found = false;

            ProtectableItemListResponse protectableItemListResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(
                Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                this.ProtectionContainer.Name);
            ProtectableItem protectableItem = protectableItemListResponse.ProtectableItems.SingleOrDefault(t => t.Properties.FriendlyName.CompareTo(this.FriendlyName) == 0);

            if (protectableItem != null)
            {              
                WriteProtectionEntity(protectableItem);
                found = true;
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ProtectionEntityNotFound,
                    this.FriendlyName,
                    this.ProtectionContainer.FriendlyName));
            }
        }

        /// <summary>
        /// Queries by Name.
        /// </summary>
        private void GetByName()
        {
            bool found = false;

            ProtectableItemResponse protectableItemResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(
                Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                this.ProtectionContainer.Name, 
                this.Name);
           
            if (protectableItemResponse.ProtectableItem != null)
            {
                WriteProtectionEntity(protectableItemResponse.ProtectableItem);
                found = true;
            }     
       
            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ProtectionEntityNotFound,
                    this.Name,
                    this.ProtectionContainer.FriendlyName));
            }
        }

        /// <summary>
        /// Queries all Protection Entities under given Protection Container.
        /// </summary>
        private void GetAll()
        {
            ProtectableItemListResponse protectableItemListResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(
                Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                this.ProtectionContainer.Name);
                    
            WriteProtectionEntities(protectableItemListResponse.ProtectableItems);
        }

        /// <summary>
        /// Write Protection Entities
        /// </summary>
        /// <param name="protectableItems">List of protectable items</param>
        private void WriteProtectionEntities(IList<ProtectableItem> protectableItems)
        {
            List<ASRProtectionEntity> asrProtectionEntityList = new List<ASRProtectionEntity>();
            foreach (ProtectableItem protectableItem in protectableItems)
            {
                ReplicationProtectedItemResponse replicationProtectedItemResponse = null;
                if (!String.IsNullOrEmpty(protectableItem.Properties.ReplicationProtectedItemId))
                {
                    replicationProtectedItemResponse = RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(
                        Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                        this.ProtectionContainer.Name,
                        Utilities.GetValueFromArmId(protectableItem.Properties.ReplicationProtectedItemId,  ARMResourceTypeConstants.ReplicationProtectedItems));
                }

                if (replicationProtectedItemResponse != null && replicationProtectedItemResponse.ReplicationProtectedItem != null)
                {
                    PolicyResponse policyResponse = RecoveryServicesClient.GetAzureSiteRecoveryPolicy(Utilities.GetValueFromArmId(replicationProtectedItemResponse.ReplicationProtectedItem.Properties.PolicyID, ARMResourceTypeConstants.ReplicationPolicies));
                    asrProtectionEntityList.Add(new ASRProtectionEntity(protectableItem, replicationProtectedItemResponse.ReplicationProtectedItem, policyResponse.Policy));
                }
                else
                {
                    asrProtectionEntityList.Add(new ASRProtectionEntity(protectableItem));
                }
            }

            this.WriteObject(asrProtectionEntityList, true);
        }

        /// <summary>
        /// Write Protection Entity
        /// </summary>
        /// <param name="protectableItem"></param>
        private void WriteProtectionEntity(ProtectableItem protectableItem)
        {
            ReplicationProtectedItemResponse replicationProtectedItemResponse = null;
            if (!String.IsNullOrEmpty(protectableItem.Properties.ReplicationProtectedItemId))
            {
                replicationProtectedItemResponse = RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(
                    Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                    this.ProtectionContainer.Name,
                    Utilities.GetValueFromArmId(protectableItem.Properties.ReplicationProtectedItemId,  ARMResourceTypeConstants.ReplicationProtectedItems));
            }

            if (replicationProtectedItemResponse != null && replicationProtectedItemResponse.ReplicationProtectedItem != null)
            {
                PolicyResponse policyResponse = RecoveryServicesClient.GetAzureSiteRecoveryPolicy(Utilities.GetValueFromArmId(replicationProtectedItemResponse.ReplicationProtectedItem.Properties.PolicyID, ARMResourceTypeConstants.ReplicationPolicies));
                this.WriteObject(new ASRProtectionEntity(protectableItem, replicationProtectedItemResponse.ReplicationProtectedItem, policyResponse.Policy));
            }
            else
            {
                this.WriteObject(new ASRProtectionEntity(protectableItem));
            }
        }
    }
}