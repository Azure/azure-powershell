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
    [Cmdlet(
        VerbsCommon.Get,
        "AzureRmRecoveryServicesAsrRecoveryPoint",
        DefaultParameterSetName = ASRParameterSets.ByObject)]
    [Alias("Get-ASRRecoveryPoint")]
    [OutputType(typeof(IEnumerable<ASRRecoveryPoint>))]
    public class GetAzureRmRecoveryServicesAsrRecoveryPoint : SiteRecoveryCmdletBase
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
        ///     Gets or sets the Azure Site Recovery Replication Protected Item object for which 
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
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

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
        ///     Queries all Protected Items under given Protection Container.
        /// </summary>
        private void GetAll()
        {
            var recoveryPointListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryRecoveryPoint(
                    Utilities.GetValueFromArmId(
                        this.ReplicationProtectedItem.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.ReplicationProtectedItem.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers),
                    this.ReplicationProtectedItem.Name);

            this.WriteRecoveryPoints(recoveryPointListResponse);
        }

        /// <summary>
        ///     Queries by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var recoveryPointResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryRecoveryPoint(
                        Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers),
                        this.ReplicationProtectedItem.Name,
                        this.Name);

                if (recoveryPointResponse != null)
                {
                    this.WriteRecoveryPoint(recoveryPointResponse);
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
                            this.ReplicationProtectedItem.FriendlyName));
                }

                throw;
            }
        }

        /// <summary>
        ///     Write Recovery Point.
        /// </summary>
        /// <param name="recoveryPoint">Recovery point.</param>
        private void WriteRecoveryPoint(
            RecoveryPoint recoveryPoint)
        {
            this.WriteObject(new ASRRecoveryPoint(recoveryPoint));
        }

        /// <summary>
        ///     Write Recovery Points.
        /// </summary>
        /// <param name="recoveryPoints">List of recovery points.</param>
        private void WriteRecoveryPoints(
            IList<RecoveryPoint> recoveryPoints)
        {
            this.WriteObject(
                recoveryPoints.Select(recoveryPoint => new ASRRecoveryPoint(recoveryPoint)),
                true);
        }
    }
}