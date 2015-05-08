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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects
{
    /// <summary>
    ///     Represents an Azure HD Insight Cluster for the PowerShell Cmdlets.
    /// </summary>
    public class AzureHDInsightCluster
    {
        private readonly ClusterDetails cluster;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AzureHDInsightCluster" /> class.
        /// </summary>
        /// <param name="cluster">
        ///     The underlying SDK data object representing the cluster.
        /// </param>
        public AzureHDInsightCluster(ClusterDetails cluster)
        {
            this.cluster = cluster;
        }

        /// <summary>
        ///     Gets the size of the Azure HD Insight cluster in units of worker nodes.
        /// </summary>
        public int ClusterSizeInNodes
        {
            get { return this.cluster.ClusterSizeInNodes; }
        }

        /// <summary>
        ///     Gets the type of the Azure HD Insight cluster.
        /// </summary>
        public ClusterType ClusterType
        {
            get { return this.cluster.ClusterType; }
        }

        /// <summary>
        ///     Gets the virtual network Id of the cluster.
        /// </summary>
        public string VirtualNetworkId
        {
            get { return this.cluster.VirtualNetworkId; }
        }

        /// <summary>
        ///     Gets the subnet name of the cluster.
        /// </summary>
        public string SubnetName
        {
            get { return this.cluster.SubnetName; }
        }

        /// <summary>
        ///     Gets the connection Url for the Azure HD Insight Cluster.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings",
            Justification = "this is a read only property coming from the server.  It is safer to leave as a string. [tgs]")]
        public string ConnectionUrl
        {
            get { return this.cluster.ConnectionUrl; }
        }

        /// <summary>
        ///     Gets the Date the Azure HD Insight Cluster was created.
        /// </summary>
        public DateTime CreateDate
        {
            get { return this.cluster.CreatedDate; }
        }

        /// <summary>
        ///     Gets the default storage accounts associated with the Azure HDInsight cluster.
        /// </summary>
        public AzureHDInsightDefaultStorageAccount DefaultStorageAccount
        {
            get
            {
                return new AzureHDInsightDefaultStorageAccount
                {
                    StorageAccountName = this.cluster.DefaultStorageAccount.Name,
                    StorageAccountKey = this.cluster.DefaultStorageAccount.Key,
                    StorageContainerName = this.cluster.DefaultStorageAccount.Container
                };
            }
        }

        /// <summary>
        ///     Gets the password associated with Http requests to the cluster.
        /// </summary>
        internal string HttpPassword
        {
            get { return this.cluster.HttpPassword; }
        }

        /// <summary>
        ///     Gets the login username for the cluster.
        /// </summary>
        public string HttpUserName
        {
            get { return this.cluster.HttpUserName; }
        }

        /// <summary>
        /// Gets the RDP username for the cluster.
        /// </summary>
        public string RdpUserName
        {
            get { return this.cluster.RdpUserName; }
        }

        /// <summary>
        ///     Gets the Azure location where the Azure HD Insight Cluster is located.
        /// </summary>
        public string Location
        {
            get { return this.cluster.Location; }
        }

        /// <summary>
        ///     Gets the name of the Azure HD Insight Cluster.
        /// </summary>
        public string Name
        {
            get { return this.cluster.Name; }
        }

        /// <summary>
        ///     Gets the ClusterState for the Azure HD Insight Cluster.
        /// </summary>
        public ClusterState State
        {
            get { return this.cluster.State; }
        }

        /// <summary>
        ///     Gets any storage accounts associated with the Azure HDInsight cluster.
        /// </summary>
        public IEnumerable<AzureHDInsightStorageAccount> StorageAccounts
        {
            get
            {
                return
                    this.cluster.AdditionalStorageAccounts.Select(
                        acc => new AzureHDInsightStorageAccount { StorageAccountName = acc.Name, StorageAccountKey = acc.Key });
            }
        }

        /// <summary>
        ///     Gets the subscriptionid associated with this cluster.
        /// </summary>
        public Guid SubscriptionId
        {
            get { return this.cluster.SubscriptionId; }
        }

        /// <summary>
        ///     Gets the username used when creating the Azure HD Insight Cluster.
        /// </summary>
        public string UserName
        {
            get { return this.cluster.HttpUserName; }
        }

        /// <summary>
        ///     Gets the name of the Azure HD Insight Cluster.
        /// </summary>
        public string Version
        {
            get { return this.cluster.Version; }
        }

        /// <summary>
        ///     Gets the version status of the Azure HD Insight Cluster.
        /// </summary>
        public string VersionStatus
        {
            get { return this.cluster.VersionStatus.ToString(); }
        }

        /// <summary>
        /// Gets the type of Operating System installed on cluster nodes.
        /// </summary>
        public OSType OSType
        {
            get { return this.cluster.OSType; }
        }
    }
}
