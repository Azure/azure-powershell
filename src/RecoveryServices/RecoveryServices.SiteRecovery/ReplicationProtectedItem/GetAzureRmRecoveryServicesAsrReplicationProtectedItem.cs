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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Retrieves Azure Site Protected Item.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrReplicationProtectedItem",DefaultParameterSetName = ASRParameterSets.ByObject)]
    [Alias("Get-ASRReplicationProtectedItem")]
    [OutputType(typeof(ASRReplicationProtectedItem))]
    public class GetAzureRmRecoveryServicesAsrReplicationProtectedItem : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the name of the replication protected item to get.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the friendly name of the replication protected item to get.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets the ASR protection container object of the ASR protection container corresponding
        ///     to the replication protected item. 
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer ProtectionContainer { get; set; }

        /// <summary>
        ///     Gets or sets an ASR protectable item object. The cmdlet gets the ASR replication protected item corresponding 
        ///     to the specified ASR protectable item if the item is protected.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByProtectableItemObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectableItem ProtectableItem { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
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
        ///     Queries all Protected Items under given Protection Container.
        /// </summary>
        private void GetAll()
        {
            var replicationProtectedItemListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryReplicationProtectedItem(
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainer.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    this.ProtectionContainer.Name);

            this.WriteReplicationProtectedItems(replicationProtectedItemListResponse);
        }

        /// <summary>
        ///     Queries by friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            var found = false;

            var replicationProtectedItemListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryReplicationProtectedItem(
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainer.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    this.ProtectionContainer.Name);
            var replicationProtectedItem = replicationProtectedItemListResponse.SingleOrDefault(
                t => string.Compare(
                         t.Properties.FriendlyName,
                         this.FriendlyName,
                         StringComparison.OrdinalIgnoreCase) ==
                     0);

            if (replicationProtectedItem != null)
            {
                var replicationProtectedItemResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryReplicationProtectedItem(
                        Utilities.GetValueFromArmId(
                            this.ProtectionContainer.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        this.ProtectionContainer.Name,
                        replicationProtectedItem.Name);
                this.WriteReplicationProtectedItem(replicationProtectedItemResponse);

                found = true;
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.ProtectionEntityNotFound,
                        this.FriendlyName,
                        this.ProtectionContainer.FriendlyName));
            }
        }

        /// <summary>
        ///     Queries by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var replicationProtectedItemResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryReplicationProtectedItem(
                        Utilities.GetValueFromArmId(
                            this.ProtectionContainer.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        this.ProtectionContainer.Name,
                        this.Name);

                if (replicationProtectedItemResponse != null)
                {
                    this.WriteReplicationProtectedItem(replicationProtectedItemResponse);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(
                        ex.Error.Code,
                        "NotFound",
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            Resources.ReplicationProtectedItemNotFound,
                            this.Name,
                            this.ProtectionContainer.FriendlyName));
                }

                throw;
            }
        }

        /// <summary>
        ///     Queries by Protectable Item
        /// </summary>
        private void GetByProtectableItem()
        {
            var found = false;

            var protectableItemResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryProtectableItem(
                    Utilities.GetValueFromArmId(
                        this.ProtectableItem.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.ProtectableItem.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers),
                    this.ProtectableItem.Name);

            if (protectableItemResponse != null)
            {
                var replicationProtectedItemResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryReplicationProtectedItem(
                        Utilities.GetValueFromArmId(
                            this.ProtectableItem.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(
                            this.ProtectableItem.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers),
                        Utilities.GetValueFromArmId(
                            protectableItemResponse.Properties.ReplicationProtectedItemId,
                            ARMResourceTypeConstants.ReplicationProtectedItems));

                this.WriteReplicationProtectedItem(replicationProtectedItemResponse);

                found = true;
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.ProtectionEntityNotFound,
                        this.FriendlyName,
                        this.ProtectionContainer.FriendlyName));
            }
        }

        /// <summary>
        ///     Write Protected Items
        /// </summary>
        /// <param name="replicationProtectedItem"></param>
        private void WriteReplicationProtectedItem(
            ReplicationProtectedItem replicationProtectedItem)
        {
            this.WriteObject(new ASRReplicationProtectedItem(replicationProtectedItem));
        }

        /// <summary>
        ///     Write Protected Items
        /// </summary>
        /// <param name="replicationProtectedItems"></param>
        private void WriteReplicationProtectedItems(
            IList<ReplicationProtectedItem> replicationProtectedItems)
        {
            this.WriteObject(
                replicationProtectedItems.Select(pi => new ASRReplicationProtectedItem(pi)),
                true);
        }
    }
}
