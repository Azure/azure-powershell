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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrClusterRecoveryPoint",DefaultParameterSetName = ASRParameterSets.ByObject)]
    [Alias("Get-ASRClusterRecoveryPoint")]
    [OutputType(typeof(ASRClusterRecoveryPoint))]
    public class GetAzureRmRecoveryServicesAsrClusterRecoveryPoint : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the name of the cluster recovery point to get.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the Azure Site Recovery Replication protection Cluster object for which 
        ///     to get the list of available cluster recovery points.
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
        public ASRReplicationProtectionCluster ReplicationProtectionCluster { get; set; }

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
        ///     Queries all cluster recovery points under given Protection Cluster.
        /// </summary>
        private void GetAll()
        {
            var recoveryPointListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryClusterRecoveryPoint(
                    Utilities.GetValueFromArmId(
                        this.ReplicationProtectionCluster.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.ReplicationProtectionCluster.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers),
                    this.ReplicationProtectionCluster.Name);

            this.WriteClusterRecoveryPoints(recoveryPointListResponse);
        }

        /// <summary>
        ///     Queries by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var recoveryPointResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryClusterRecoveryPoint(
                        Utilities.GetValueFromArmId(
                            this.ReplicationProtectionCluster.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(
                            this.ReplicationProtectionCluster.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers),
                        this.ReplicationProtectionCluster.Name,
                        this.Name);

                if (recoveryPointResponse != null)
                {
                    this.WriteClusterRecoveryPoint(recoveryPointResponse);
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
                            this.ReplicationProtectionCluster.Name));
                }

                throw;
            }
        }

        /// <summary>
        ///     Write Cluster Recovery Point.
        /// </summary>
        /// <param name="clusterRecoveryPoint">Cluster Recovery point.</param>
        private void WriteClusterRecoveryPoint(
            ClusterRecoveryPoint clusterRecoveryPoint)
        {
            this.WriteObject(new ASRClusterRecoveryPoint(clusterRecoveryPoint));
        }

        /// <summary>
        ///     Write Cluster Recovery Points.
        /// </summary>
        /// <param name="clusterRecoveryPoints">List of cluster recovery points.</param>
        private void WriteClusterRecoveryPoints(
            IList<ClusterRecoveryPoint> clusterRecoveryPoints)
        {
            this.WriteObject(
                clusterRecoveryPoints.Select(clusterRecoveryPoint => new ASRClusterRecoveryPoint(clusterRecoveryPoint)),
                true);
        }
    }
}
