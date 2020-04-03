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
    ///     Retrieves Azure Site Migration Item.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrReplicationMigrationItem", DefaultParameterSetName = ASRParameterSets.Default)]
    [Alias("Get-ASRReplicationMigrationItem")]
    [OutputType(typeof(ASRReplicationMigrationItem))]
    public class GetAzureRmRecoveryServicesAsrReplicationMigrationItem : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the name of the replication migration item to get.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the ASR protection container object of the ASR protection container corresponding
        ///     to the replication migration item.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithName,
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
                case ASRParameterSets.Default:
                    this.GetAllByVault();
                    break;
            }
        }

        /// <summary>
        ///     Queries all Migration Items under given Protection Container.
        /// </summary>
        private void GetAll()
        {
            var replicationMigrationItemListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryReplicationMigrationItem(
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainer.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    this.ProtectionContainer.Name);

            this.WriteReplicationMigrationItems(replicationMigrationItemListResponse);
        }

        /// <summary>
        ///     Queries by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var replicationMigrationItemResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryReplicationMigrationItem(
                        Utilities.GetValueFromArmId(
                            this.ProtectionContainer.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        this.ProtectionContainer.Name,
                        this.Name);

                if (replicationMigrationItemResponse != null)
                {
                    this.WriteReplicationMigrationItem(replicationMigrationItemResponse);
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
                            Resources.ReplicationMigrationItemNotFound,
                            this.Name,
                            this.ProtectionContainer.FriendlyName));
                }

                throw;
            }
        }

        /// <summary>
        ///     Queries all Migration Items under given vault.
        /// </summary>
        private void GetAllByVault()
        {
            var parameters = new MigrationItemsQueryParameter();

            parameters.InstanceType = Constants.VMwareCbt;

            var replicationMigrationItemListResponse = this.RecoveryServicesClient
                .ListAzureSiteRecoveryReplicationMigrationItems(parameters);

            this.WriteReplicationMigrationItems(replicationMigrationItemListResponse);
        }

        /// <summary>
        ///     Write Migration Item
        /// </summary>
        /// <param name="replicationMigrationItem"></param>
        private void WriteReplicationMigrationItem(
            MigrationItem replicationMigrationItem)
        {
            this.WriteObject(new ASRReplicationMigrationItem(replicationMigrationItem));
        }

        /// <summary>
        ///     Write Migration Items
        /// </summary>
        /// <param name="migrationItems">List of migration items</param>
        private void WriteReplicationMigrationItems(
            IList<MigrationItem> migrationItems)
        {
            this.WriteObject(
                migrationItems.Select(mi => new ASRReplicationMigrationItem(mi)),
                true);
        }
    }
}
