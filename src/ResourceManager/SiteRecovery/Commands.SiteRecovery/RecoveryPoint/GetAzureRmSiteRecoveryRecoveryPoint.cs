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
    /// Retrieves Azure Site Recovery Points.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryRecoveryPoint", DefaultParameterSetName = ASRParameterSets.ByObject)]
    [OutputType(typeof(IEnumerable<ASRRecoveryPoint>))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Get-AzureRmRecoveryServicesAsrRecoveryPoint cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class GetAzureRmSiteRecoveryRecoveryPoint : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets Name of the Recovery Point.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Replication Protected Item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

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
                default:
                    throw new PSInvalidOperationException(Properties.Resources.InvalidParameterSet);
            }
        }

        /// <summary>
        /// Queries by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var recoveryPointResponse = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPoint(
                    Utilities.GetValueFromArmId(this.ReplicationProtectedItem.ID, ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(this.ReplicationProtectedItem.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                    this.ReplicationProtectedItem.Name,
                    this.Name);

                if (recoveryPointResponse.RecoveryPoint != null)
                {
                    WriteRecoveryPoint(recoveryPointResponse.RecoveryPoint);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(ex.Error.Code, "NotFound", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                        Properties.Resources.InvalidParameterSet,
                        this.Name,
                        this.ReplicationProtectedItem.FriendlyName));
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Queries all Protected Items under given Protection Container.
        /// </summary>
        private void GetAll()
        {
            var recoveryPointListResponse = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPoint(
                Utilities.GetValueFromArmId(this.ReplicationProtectedItem.ID, ARMResourceTypeConstants.ReplicationFabrics),
                Utilities.GetValueFromArmId(this.ReplicationProtectedItem.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                this.ReplicationProtectedItem.Name);

            WriteRecoveryPoints(recoveryPointListResponse.RecoveryPoints);
        }

        /// <summary>
        /// Write Recovery Points.
        /// </summary>
        /// <param name="recoveryPoints">List of recovery points.</param>
        private void WriteRecoveryPoints(IList<RecoveryPoint> recoveryPoints)
        {
            this.WriteObject(recoveryPoints.Select(recoveryPoint => new ASRRecoveryPoint(recoveryPoint)), true);
        }

        /// <summary>
        /// Write Recovery Point.
        /// </summary>
        /// <param name="recoveryPoint">Recovery point.</param>
        private void WriteRecoveryPoint(RecoveryPoint recoveryPoint)
        {
            this.WriteObject(new ASRRecoveryPoint(recoveryPoint));
        }
    }
}