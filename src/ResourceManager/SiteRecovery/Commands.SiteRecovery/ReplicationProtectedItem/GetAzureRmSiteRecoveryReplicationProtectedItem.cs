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
using Hyak.Common;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Protected Item.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryReplicationProtectedItem", DefaultParameterSetName = ASRParameterSets.ByObject)]
    [OutputType(typeof(IEnumerable<ASRReplicationProtectedItem>))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Get-AzureRmRecoveryServicesAsrReplicationProtectedItem cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class GetAzureRmSiteRecoveryReplicationProtectedItem : SiteRecoveryCmdletBase
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
        /// Gets or sets Protection Container Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer ProtectionContainer { get; set; }

        /// <summary>
        /// Gets or sets Protectable Item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByProtectableItemObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectableItem ProtectableItem { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

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
                case ASRParameterSets.ByProtectableItemObject:
                    this.GetByProtectableItem();
                    break;
            }
        }

        /// <summary>
        /// Queries by friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            bool found = false;

            ReplicationProtectedItemListResponse replicationProtectedItemListResponse = RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(
                Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                this.ProtectionContainer.Name);
            ReplicationProtectedItem replicationProtectedItem =
                replicationProtectedItemListResponse.ReplicationProtectedItems.SingleOrDefault(t =>
                string.Compare(t.Properties.FriendlyName, this.FriendlyName, StringComparison.OrdinalIgnoreCase) == 0);

            if (replicationProtectedItem != null)
            {
                ReplicationProtectedItemResponse replicationProtectedItemResponse = RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(
                    Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                    this.ProtectionContainer.Name,
                    replicationProtectedItem.Name);
                WriteReplicationProtectedItem(replicationProtectedItemResponse.ReplicationProtectedItem);

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
            try
            {
                var replicationProtectedItemResponse = RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(
                    Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                    this.ProtectionContainer.Name,
                    this.Name);

                if (replicationProtectedItemResponse.ReplicationProtectedItem != null)
                {
                    this.WriteReplicationProtectedItem(replicationProtectedItemResponse.ReplicationProtectedItem);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(ex.Error.Code, "NotFound", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                        Properties.Resources.ReplicationProtectedItemNotFound,
                        this.Name,
                        this.ProtectionContainer.FriendlyName));
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Queries by Protectable Item
        /// </summary>
        private void GetByProtectableItem()
        {
            bool found = false;

            ProtectableItemResponse protectableItemResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(
               Utilities.GetValueFromArmId(this.ProtectableItem.ID, ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(this.ProtectableItem.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                    this.ProtectableItem.Name);

            if (protectableItemResponse.ProtectableItem != null)
            {
                ReplicationProtectedItemResponse replicationProtectedItemResponse = RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(
                    Utilities.GetValueFromArmId(this.ProtectableItem.ID, ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(this.ProtectableItem.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                    Utilities.GetValueFromArmId(protectableItemResponse.ProtectableItem.Properties.ReplicationProtectedItemId, ARMResourceTypeConstants.ReplicationProtectedItems));

                WriteReplicationProtectedItem(replicationProtectedItemResponse.ReplicationProtectedItem);

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
        /// Queries all Protected Items under given Protection Container.
        /// </summary>
        private void GetAll()
        {
            ReplicationProtectedItemListResponse replicationProtectedItemListResponse = RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(
                Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                this.ProtectionContainer.Name);

            WriteReplicationProtectedItems(replicationProtectedItemListResponse.ReplicationProtectedItems);
        }

        /// <summary>
        /// Write Protected Items
        /// </summary>
        /// <param name="protectableItems">List of protectable items</param>
        private void WriteReplicationProtectedItems(IList<ReplicationProtectedItem> replicationProtectedItems)
        {
            this.WriteObject(replicationProtectedItems.Select(pi => new ASRReplicationProtectedItem(pi)), true);
        }

        /// <summary>
        /// Write Protected Items
        /// </summary>
        /// <param name="replicationProtectedItem"></param>
        private void WriteReplicationProtectedItem(ReplicationProtectedItem replicationProtectedItem)
        {
            this.WriteObject(new ASRReplicationProtectedItem(replicationProtectedItem));
        }
    }
}