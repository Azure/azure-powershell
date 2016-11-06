﻿// ----------------------------------------------------------------------------------
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
    /// Retrieves Azure Site Protectable Item.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryProtectableItem", DefaultParameterSetName = ASRParameterSets.ByObject)]
    [OutputType(typeof(IEnumerable<ASRProtectableItem>))]
    public class GetAzureRmSiteRecoveryProtectableItem : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Name of the Protectable Item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets friendly name of the Protectable Item.
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
            ProtectableItem protectableItem = 
                protectableItemListResponse.ProtectableItems.SingleOrDefault(t => 
                string.Compare(t.Properties.FriendlyName, this.FriendlyName, StringComparison.OrdinalIgnoreCase) == 0);

            if (protectableItem != null)
            {
                ProtectableItemResponse protectableItemResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(
                    Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                    this.ProtectionContainer.Name,
                    protectableItem.Name);
                WriteProtectableItem(protectableItemResponse.ProtectableItem);

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
                var protectableItemResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(
                    Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                    this.ProtectionContainer.Name,
                    this.Name);

                if (protectableItemResponse.ProtectableItem != null)
                {
                    WriteProtectableItem(protectableItemResponse.ProtectableItem);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(ex.Error.Code, "NotFound", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                        Properties.Resources.ProtectableItemNotFound,
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
        /// Queries all Protection Entities under given Protection Container.
        /// </summary>
        private void GetAll()
        {
            ProtectableItemListResponse protectableItemListResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(
                Utilities.GetValueFromArmId(this.ProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics),
                this.ProtectionContainer.Name);

            WriteProtectableItems(protectableItemListResponse.ProtectableItems);
        }

        /// <summary>
        /// Write Protection Items
        /// </summary>
        /// <param name="protectableItems">List of protectable items</param>
        private void WriteProtectableItems(IList<ProtectableItem> protectableItems)
        {
            this.WriteObject(protectableItems.Select(pi => new ASRProtectableItem(pi)), true);
        }

        /// <summary>
        /// Write Protection Items
        /// </summary>
        /// <param name="protectableItem"></param>
        private void WriteProtectableItem(ProtectableItem protectableItem)
        {
            this.WriteObject(new ASRProtectableItem(protectableItem));
        }
    }
}