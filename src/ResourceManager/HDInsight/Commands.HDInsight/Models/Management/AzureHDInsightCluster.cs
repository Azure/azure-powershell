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

using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightCluster
    {
        public AzureHDInsightCluster(Cluster cluster)
        {
            Id = cluster.Id;
            Name = cluster.Name;
            Location = cluster.Location;
            ClusterVersion = cluster.Properties.ClusterVersion;
            OperatingSystemType = cluster.Properties.OperatingSystemType;
            ClusterTier = cluster.Properties.ClusterTier;
            ClusterState = cluster.Properties.ClusterState;
            ClusterType = cluster.Properties.ClusterDefinition.ClusterType;
            CoresUsed = cluster.Properties.QuotaInfo.CoresUsed;
            var httpEndpoint =
                cluster.Properties.ConnectivityEndpoints.FirstOrDefault(c => c.Name.Equals("HTTPS", StringComparison.OrdinalIgnoreCase));
            HttpEndpoint = httpEndpoint != null ? httpEndpoint.Location : null;
            Error = cluster.Properties.ErrorInfos.Select(s => s.Message).FirstOrDefault();
            ResourceGroup = ClusterConfigurationUtils.GetResourceGroupFromClusterId(cluster.Id);
        }

        public AzureHDInsightCluster(Cluster cluster, IDictionary<string, string> clusterConfiguration)
            : this(cluster)
        {
            if (clusterConfiguration != null)
            {
                var defaultAccount = ClusterConfigurationUtils.GetDefaultStorageAccountDetails(
                clusterConfiguration,
                cluster.Properties.ClusterVersion);

                DefaultStorageAccount = defaultAccount.StorageAccountName;
                DefaultStorageContainer = defaultAccount.StorageContainerName;

                AdditionalStorageAccounts = ClusterConfigurationUtils.GetAdditionStorageAccounts(clusterConfiguration, DefaultStorageAccount);
            }
        }

        /// <summary>
        /// The name of the resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The location of the resource.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The version of the cluster.
        /// </summary>
        public string ClusterVersion { get; set; }

        /// <summary>
        /// The type of operating system.
        /// </summary>
        public OSType OperatingSystemType { get; set; }

        /// <summary>
        /// Gets or sets the cluster tier.
        /// </summary>
        public Tier ClusterTier { get; set; }

        /// <summary>
        /// The state of the cluster.
        /// </summary>
        public string ClusterState { get; set; }

        /// <summary>
        /// The type of cluster.
        /// </summary>
        public string ClusterType { get; set; }

        /// <summary>
        /// The cores used by the cluster.
        /// </summary>
        public int CoresUsed { get; set; }

        /// <summary>
        /// The endpoint with which to connect to the cluster.
        /// </summary>
        public string HttpEndpoint { get; set; }

        /// <summary>
        /// The error (if any).
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Default storage account for this cluster.
        /// </summary>
        public string DefaultStorageAccount { get; set; }

        /// <summary>
        /// Default storage container for this cluster.
        /// </summary>
        public string DefaultStorageContainer { get; set; }

        /// <summary>
        /// Default storage container for this cluster.
        /// </summary>
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Additional storage accounts for this cluster
        /// </summary>
        public List<string> AdditionalStorageAccounts { get; set; }
    }
}
