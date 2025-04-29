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
    ///     Gets Azure Site Recovery Replication Protection Cluster.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrReplicationProtectionCluster", DefaultParameterSetName = ASRParameterSets.Default)]
    [Alias("Get-ASRReplicationProtectionCluster")]
    [OutputType(typeof(ASRReplicationProtectionCluster))]
    public class GetAzureRmRecoveryServicesAsrReplicationProtectionCluster : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the name of the protection container mapping to get.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets protection container to look for.
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
                    this.GetAllByProtectionContainer();
                    break;
                case ASRParameterSets.ByObjectWithName:
                    this.GetByName();
                    break;
                case ASRParameterSets.Default:
                    this.GetAll();
                    break;
            }
        }

        /// <summary>
        ///     Queries all Protection Clusters for a given Protection Container
        /// </summary>
        private void GetAllByProtectionContainer()
        {
            var protectionClusterListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryReplicationProtectionCluster(
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainer.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    this.ProtectionContainer.Name);

            this.WriteProtectionClusters(protectionClusterListResponse);
        }

        /// <summary>
        ///     Queries all Protection Clusters in a vault
        /// </summary>
        private void GetAll()
        {
            var protectionClusterListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryReplicationProtectionCluster();

            this.WriteProtectionClusters(protectionClusterListResponse);
        }

        /// <summary>
        ///     Queries by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var protectionClusterResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryReplicationProtectionCluster(
                        Utilities.GetValueFromArmId(
                            this.ProtectionContainer.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        this.ProtectionContainer.Name,
                        this.Name);

                if (protectionClusterResponse != null)
                {
                    this.WriteProtectionCluster(protectionClusterResponse);
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
                            Resources.ProtectionClusterNotFound,
                            this.Name,
                            this.ProtectionContainer.FriendlyName));
                }

                throw;
            }
        }

        /// <summary>
        ///     Write Protection Cluster
        /// </summary>
        /// <param name="protectionCluster"></param>
        private void WriteProtectionCluster(
            ReplicationProtectionCluster protectionCluster)
        {
            this.WriteObject(new ASRReplicationProtectionCluster(protectionCluster));
        }

        /// <summary>
        ///     Write Protection Clusters
        /// </summary>
        /// <param name="protectionClusters"></param>
        private void WriteProtectionClusters(
            IList<ReplicationProtectionCluster> protectionClusters)
        {
            this.WriteObject(
                protectionClusters.Select(pc => new ASRReplicationProtectionCluster(pc)),
                true);
        }
    }
}
