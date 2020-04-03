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
    ///     Gets the available recovery points for a replication protected item.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrMigrationRecoveryPoint",DefaultParameterSetName = ASRParameterSets.ByObject)]
    [Alias("Get-ASRMigrationRecoveryPoint")]
    [OutputType(typeof(ASRMigrationRecoveryPoint))]
    public class GetAzureRmRecoveryServicesAsrMigrationRecoveryPoint : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the name of the recovery point to get.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the Azure Site Recovery Replication Migration Item object for which 
        ///     to get the list of available recovery points.
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
        public ASRReplicationMigrationItem ReplicationMigrationItem { get; set; }

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
                default:
                    throw new PSInvalidOperationException(Resources.InvalidParameterSet);
            }
        }

        /// <summary>
        ///     Queries all migration recovery points under given replication migration item.
        /// </summary>
        private void GetAll()
        {
            var migrationRecoveryPointListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryMigrationRecoveryPoints(
                    Utilities.GetValueFromArmId(
                        this.ReplicationMigrationItem.Id,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.ReplicationMigrationItem.Id,
                        ARMResourceTypeConstants.ReplicationProtectionContainers),
                    this.ReplicationMigrationItem.Name);

            this.WriteMigrationRecoveryPoints(migrationRecoveryPointListResponse);
        }

        /// <summary>
        ///     Queries Migration Recovery Point by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var migrationRecoveryPointResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryMigrationRecoveryPoint(
                        Utilities.GetValueFromArmId(
                            this.ReplicationMigrationItem.Id,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(
                            this.ReplicationMigrationItem.Id,
                            ARMResourceTypeConstants.ReplicationProtectionContainers),
                        this.ReplicationMigrationItem.Name,
                        this.Name);

                if (migrationRecoveryPointResponse != null)
                {
                    this.WriteMigrationRecoveryPoint(migrationRecoveryPointResponse);
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
                            Resources.InvalidParameterSet,
                            this.Name,
                            this.ReplicationMigrationItem.Name));
                }

                throw;
            }
        }

        /// <summary>
        ///     Write Migration Recovery Point.
        /// </summary>
        /// <param name="migrationRecoveryPoint">Migration Recovery point.</param>
        private void WriteMigrationRecoveryPoint(
            MigrationRecoveryPoint migrationRecoveryPoint)
        {
            this.WriteObject(new ASRMigrationRecoveryPoint(migrationRecoveryPoint));
        }

        /// <summary>
        ///     Write Migration Recovery Points.
        /// </summary>
        /// <param name="migrationRecoveryPoints">List of migration recovery points.</param>
        private void WriteMigrationRecoveryPoints(
            IList<MigrationRecoveryPoint> migrationRecoveryPoints)
        {
            this.WriteObject(
                migrationRecoveryPoints.Select(migrationRecoveryPoint => new ASRMigrationRecoveryPoint(migrationRecoveryPoint)),
                true);
        }
    }
}
