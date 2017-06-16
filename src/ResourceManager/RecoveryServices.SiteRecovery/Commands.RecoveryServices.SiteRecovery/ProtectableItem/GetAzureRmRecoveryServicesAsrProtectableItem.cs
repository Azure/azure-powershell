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
    ///     Retrieves Azure Site Protectable Item.
    /// </summary>
    [Cmdlet(VerbsCommon.Get,
        "AzureRmRecoveryServicesAsrProtectableItem",
        DefaultParameterSetName = ASRParameterSets.ByObject)]
    [Alias("Get-ASRProtectableItem")]
    [OutputType(typeof(IEnumerable<ASRProtectableItem>))]
    public class GetAzureRmRecoveryServicesAsrProtectableItem : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Name of the Protectable Item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets friendly name of the Protectable Item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Server Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName,
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

            switch (ParameterSetName)
            {
                case ASRParameterSets.ByObject:
                    GetAll();
                    break;
                case ASRParameterSets.ByObjectWithName:
                    GetByName();
                    break;
                case ASRParameterSets.ByObjectWithFriendlyName:
                    GetByFriendlyName();
                    break;
            }
        }

        /// <summary>
        ///     Queries by friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            var found = false;

            var protectableItemListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(
                    Utilities.GetValueFromArmId(ProtectionContainer.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    ProtectionContainer.Name);
            var protectableItem = protectableItemListResponse.SingleOrDefault(
                t => string.Compare(t.Properties.FriendlyName,
                         FriendlyName,
                         StringComparison.OrdinalIgnoreCase) ==
                     0);

            if (protectableItem != null)
            {
                var protectableItemResponse =
                    RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(
                        Utilities.GetValueFromArmId(ProtectionContainer.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        ProtectionContainer.Name,
                        protectableItem.Name);
                WriteProtectableItem(protectableItemResponse);

                found = true;
            }

            if (!found)
            {
                throw new InvalidOperationException(string.Format(
                    Resources.ProtectionEntityNotFound,
                    FriendlyName,
                    ProtectionContainer.FriendlyName));
            }
        }

        /// <summary>
        ///     Queries by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var protectableItemResponse =
                    RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(
                        Utilities.GetValueFromArmId(ProtectionContainer.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        ProtectionContainer.Name,
                        Name);

                if (protectableItemResponse != null)
                {
                    WriteProtectableItem(protectableItemResponse);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(ex.Error.Code,
                        "NotFound",
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    throw new InvalidOperationException(string.Format(
                        Resources.ProtectableItemNotFound,
                        Name,
                        ProtectionContainer.FriendlyName));
                }

                throw;
            }
        }

        /// <summary>
        ///     Queries all Protection Entities under given Protection Container.
        /// </summary>
        private void GetAll()
        {
            var protectableItemListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(
                    Utilities.GetValueFromArmId(ProtectionContainer.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    ProtectionContainer.Name);

            WriteProtectableItems(protectableItemListResponse);
        }

        /// <summary>
        ///     Write Protection Items
        /// </summary>
        /// <param name="protectableItems">List of protectable items</param>
        private void WriteProtectableItems(IList<ProtectableItem> protectableItems)
        {
            WriteObject(protectableItems.Select(pi => new ASRProtectableItem(pi)),
                true);
        }

        /// <summary>
        ///     Write Protection Items
        /// </summary>
        /// <param name="protectableItem"></param>
        private void WriteProtectableItem(ProtectableItem protectableItem)
        {
            WriteObject(new ASRProtectableItem(protectableItem));
        }
    }
}