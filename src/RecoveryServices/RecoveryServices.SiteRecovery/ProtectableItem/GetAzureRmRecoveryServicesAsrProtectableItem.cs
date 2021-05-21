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
    ///     Get the protectable items in an ASR protection container.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrProtectableItem",DefaultParameterSetName = ASRParameterSets.ByObject)]
    [Alias("Get-ASRProtectableItem")]
    [OutputType(typeof(ASRProtectableItem))]
    public class GetAzureRmRecoveryServicesAsrProtectableItem : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the name of the ASR protectable item.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the friendly name of the ASR protectable item.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithSiteIdAndFriendlyName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets the site Id of the ASR protectable item.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithSiteId,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithSiteIdAndFriendlyName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SiteId { get; set; }

        /// <summary>
        ///     Gets or sets the Azure Site Recovery Protection Container object.
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
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithSiteId,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithSiteIdAndFriendlyName,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer ProtectionContainer { get; set; }

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
                case ASRParameterSets.ByObjectWithSiteId:
                    this.GetBySiteId();
                    break;
                case ASRParameterSets.ByObjectWithSiteIdAndFriendlyName:
                    this.GetBySiteIdAndFriendlyName();
                    break;
            }
        }

        /// <summary>
        ///     Queries all Protection Entities under given Protection Container.
        /// </summary>
        private void GetAll()
        {
            var protectableItemListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryProtectableItem(
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainer.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    this.ProtectionContainer.Name);

            this.WriteProtectableItems(protectableItemListResponse);
        }

        /// <summary>
        ///     Queries by friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            var found = false;

            var protectableItemListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryProtectableItem(
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainer.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    this.ProtectionContainer.Name);

            var friendlyNameListResponse = protectableItemListResponse.FindAll(
                t => string.Compare(
                    t.Properties.FriendlyName,
                    this.FriendlyName,
                    StringComparison.OrdinalIgnoreCase) ==
                    0);

            foreach (var protectableItem in friendlyNameListResponse)
            {
                var protectableItemResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryProtectableItem(
                        Utilities.GetValueFromArmId(
                            this.ProtectionContainer.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        this.ProtectionContainer.Name,
                        protectableItem.Name);
                this.WriteProtectableItem(protectableItemResponse);

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
                var protectableItemResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryProtectableItem(
                        Utilities.GetValueFromArmId(
                            this.ProtectionContainer.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        this.ProtectionContainer.Name,
                        this.Name);

                if (protectableItemResponse != null)
                {
                    this.WriteProtectableItem(protectableItemResponse);
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
                            Resources.ProtectableItemNotFound,
                            this.Name,
                            this.ProtectionContainer.FriendlyName));
                }

                throw;
            }
        }

        /// <summary>
        ///     Queries by site Id.
        /// </summary>
        private void GetBySiteId()
        {
            var machines =
                this.FabricDiscoveryClient
                .GetAzureSiteRecoveryDiscoveredMachines(this.SiteId)
                .Where(x => !x.Properties.IsDeleted)
                .ToList();
            if (!machines.Any())
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.NoProtectableMachinesInSite,
                        this.SiteId));
            }
            
            this.WriteProtectableItems(machines);
        }

        /// <summary>
        ///     Queries by site Id and friendly name.
        /// </summary>
        private void GetBySiteIdAndFriendlyName()
        {
            var machines =
                this.FabricDiscoveryClient
                .GetAzureSiteRecoveryDiscoveredMachines(this.SiteId)
                .Where(x => !x.Properties.IsDeleted)
                .ToList();
            if (!machines.Any())
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.NoProtectableMachinesInSite,
                        this.SiteId));
            }

            var filteredMachines =
                machines
                .Where(x => string.Equals(
                    x.Properties.DisplayName,
                    this.FriendlyName,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
            if (!filteredMachines.Any())
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.ProtectableMachineNotFound,
                        this.FriendlyName,
                        this.SiteId));
            }

            this.WriteProtectableItems(filteredMachines);
        }

        /// <summary>
        ///     Write Protection Items
        /// </summary>
        /// <param name="protectableItem"></param>
        private void WriteProtectableItem(
            ProtectableItem protectableItem)
        {
            this.WriteObject(new ASRProtectableItem(protectableItem));
        }

        /// <summary>
        ///     Write Protection Items
        /// </summary>
        /// <param name="protectableItems">List of protectable items</param>
        private void WriteProtectableItems(
            IList<ProtectableItem> protectableItems)
        {
            this.WriteObject(
                protectableItems.Select(pi => new ASRProtectableItem(pi)),
                true);
        }

        /// <summary>
        ///     Write Protection Items
        /// </summary>
        /// <param name="machines">List of discovered machines.</param>
        private void WriteProtectableItems(
            IList<VMwareMachine> machines)
        {
            this.WriteObject(
                machines.Select(x =>
                    new ASRProtectableItem(
                        this.ProtectionContainer,
                        this.SiteId,
                        x)),
                true);
        }
    }
}
