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
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    internal class NewAzureHDInsightClusterCommand : AzureHDInsightClusterCommand<AzureHDInsightCluster>, INewAzureHDInsightClusterCommand
    {
        public NewAzureHDInsightClusterCommand()
        {
            this.AdditionalStorageAccounts = new List<AzureHDInsightStorageAccount>();
            this.ConfigActions = new List<AzureHDInsightConfigAction>();
            this.CoreConfiguration = new ConfigValuesCollection();
            this.YarnConfiguration = new ConfigValuesCollection();
            this.HdfsConfiguration = new ConfigValuesCollection();
            this.MapReduceConfiguration = new MapReduceConfiguration();
            this.HiveConfiguration = new HiveConfiguration();
            this.OozieConfiguration = new OozieConfiguration();
            this.StormConfiguration = new ConfigValuesCollection();
            this.SparkConfiguration = new ConfigValuesCollection();
            this.HBaseConfiguration = new HBaseConfiguration();

            // By default set OSType = Windows
            this.OSType = OSType.Windows;
        }

        public PSCredential RdpCredential { get; set; }

        public DateTime? RdpAccessExpiry { get; set; }

        public ICollection<AzureHDInsightStorageAccount> AdditionalStorageAccounts { get; private set; }

        /// <inheritdoc />
        public int ClusterSizeInNodes { get; set; }

        /// <inheritdoc />
        public string HeadNodeSize { get; set; }

        /// <inheritdoc />
        public string DataNodeSize { get; set; }

        /// <inheritdoc />
        public string ZookeeperNodeSize { get; set; }

        /// <inheritdoc />
        public ConfigValuesCollection CoreConfiguration { get; set; }

        /// <inheritdoc />
        public ConfigValuesCollection YarnConfiguration { get; set; }

        /// <inheritdoc />
        public PSCredential Credential { get; set; }

        /// <inheritdoc />
        public string DefaultStorageAccountKey { get; set; }

        /// <inheritdoc />
        public string DefaultStorageAccountName { get; set; }

        /// <inheritdoc />
        public string DefaultStorageContainerName { get; set; }

        /// <inheritdoc />
        public ConfigValuesCollection HdfsConfiguration { get; set; }

        /// <inheritdoc />
        public HiveConfiguration HiveConfiguration { get; set; }

        public AzureHDInsightMetastore HiveMetastore { get; set; }

        /// <inheritdoc />
        public string Location { get; set; }

        /// <inheritdoc />
        public bool EnableHighAvailability { get; set; }

        /// <inheritdoc />
        public MapReduceConfiguration MapReduceConfiguration { get; set; }

        /// <inheritdoc />
        public OozieConfiguration OozieConfiguration { get; set; }

        public AzureHDInsightMetastore OozieMetastore { get; set; }

        /// <inheritdoc />
        public ConfigValuesCollection StormConfiguration { get; set; }

        /// <inheritdoc />
        public ConfigValuesCollection SparkConfiguration { get; set; }

        /// <inheritdoc />
        public HBaseConfiguration HBaseConfiguration { get; set; }

        public ICollection<AzureHDInsightConfigAction> ConfigActions { get; set; }

        public ClusterState State { get; private set; }

        public ClusterType ClusterType { get; set; }

        public string VirtualNetworkId { get; set; }

        public string SubnetName { get; set; }

        /// <inheritdoc />
        public string Version { get; set; }

        /// <inheritdoc />
        public OSType OSType { get; set; }

        /// <inheritdoc />
        public PSCredential SshCredential { get; set; }

        /// <inheritdoc />
        public string SshPublicKey { get; set; }

        public override async Task EndProcessing()
        {
            IHDInsightClient client = this.GetClient(IgnoreSslErrors);
            client.ClusterProvisioning += this.ClientOnClusterProvisioning;
            ClusterCreateParametersV2 createClusterRequest = this.GetClusterCreateParameters();
            var cluster = await client.CreateClusterAsync(createClusterRequest);
            this.Output.Add(new AzureHDInsightCluster(cluster));
        }

        internal ClusterCreateParametersV2 GetClusterCreateParameters()
        {
            var createClusterRequest = new ClusterCreateParametersV2();

            createClusterRequest.Name = this.Name;
            createClusterRequest.Version = this.Version;
            createClusterRequest.Location = this.Location;
            createClusterRequest.CoreConfiguration.AddRange(this.CoreConfiguration);
            createClusterRequest.YarnConfiguration.AddRange(this.YarnConfiguration);
            createClusterRequest.HdfsConfiguration.AddRange(this.HdfsConfiguration);
            createClusterRequest.MapReduceConfiguration.ConfigurationCollection.AddRange(this.MapReduceConfiguration.ConfigurationCollection);
            createClusterRequest.MapReduceConfiguration.CapacitySchedulerConfigurationCollection.AddRange(
                this.MapReduceConfiguration.CapacitySchedulerConfigurationCollection);
            createClusterRequest.HiveConfiguration.AdditionalLibraries = this.HiveConfiguration.AdditionalLibraries;
            createClusterRequest.HiveConfiguration.ConfigurationCollection.AddRange(this.HiveConfiguration.ConfigurationCollection);
            createClusterRequest.OozieConfiguration.ConfigurationCollection.AddRange(this.OozieConfiguration.ConfigurationCollection);
            createClusterRequest.OozieConfiguration.AdditionalSharedLibraries = this.OozieConfiguration.AdditionalSharedLibraries;
            createClusterRequest.OozieConfiguration.AdditionalActionExecutorLibraries = this.OozieConfiguration.AdditionalActionExecutorLibraries;
            createClusterRequest.StormConfiguration.AddRange(this.StormConfiguration);
            createClusterRequest.SparkConfiguration.AddRange(this.SparkConfiguration);
            createClusterRequest.HBaseConfiguration.AdditionalLibraries = this.HBaseConfiguration.AdditionalLibraries;
            createClusterRequest.HBaseConfiguration.ConfigurationCollection.AddRange(this.HBaseConfiguration.ConfigurationCollection);
       
            createClusterRequest.DefaultStorageAccountName = this.DefaultStorageAccountName;
            createClusterRequest.DefaultStorageAccountKey = this.DefaultStorageAccountKey;
            createClusterRequest.DefaultStorageContainer = this.DefaultStorageContainerName;
            createClusterRequest.UserName = this.Credential.UserName;
            createClusterRequest.Password = this.Credential.GetCleartextPassword();
            createClusterRequest.ClusterSizeInNodes = this.ClusterSizeInNodes;
            createClusterRequest.ClusterType = this.ClusterType;
            if (!string.IsNullOrEmpty(this.VirtualNetworkId))
            {
                createClusterRequest.VirtualNetworkId = this.VirtualNetworkId;
            }
            if (!string.IsNullOrEmpty(this.SubnetName))
            {
                createClusterRequest.SubnetName = this.SubnetName;
            }
            createClusterRequest.AdditionalStorageAccounts.AddRange(
                this.AdditionalStorageAccounts.Select(act => new WabStorageAccountConfiguration(act.StorageAccountName, act.StorageAccountKey)));
            createClusterRequest.ConfigActions.AddRange(this.ConfigActions.Select(ca => ca.ToSDKConfigAction()));
            if (this.HiveMetastore.IsNotNull())
            {
                createClusterRequest.HiveMetastore = new Metastore(
                    this.HiveMetastore.SqlAzureServerName,
                    this.HiveMetastore.DatabaseName,
                    this.HiveMetastore.Credential.UserName,
                    this.HiveMetastore.Credential.GetCleartextPassword());
            }
            if (this.OozieMetastore.IsNotNull())
            {
                createClusterRequest.OozieMetastore = new Metastore(
                    this.OozieMetastore.SqlAzureServerName,
                    this.OozieMetastore.DatabaseName,
                    this.OozieMetastore.Credential.UserName,
                    this.OozieMetastore.Credential.GetCleartextPassword());
            }

            if (!string.IsNullOrEmpty(this.HeadNodeSize) && !this.HeadNodeSize.Equals("Default", StringComparison.OrdinalIgnoreCase))
            {
                createClusterRequest.HeadNodeSize = this.HeadNodeSize;
            }

            if (!string.IsNullOrEmpty(this.DataNodeSize))
            {
                createClusterRequest.DataNodeSize = this.DataNodeSize;
            }

            if (!string.IsNullOrEmpty(this.ZookeeperNodeSize))
            {
                createClusterRequest.ZookeeperNodeSize = this.ZookeeperNodeSize;
            }

            if (this.RdpCredential.IsNotNull())
            {
                createClusterRequest.RdpUsername = this.RdpCredential.UserName;
                createClusterRequest.RdpPassword = this.RdpCredential.GetCleartextPassword();
            }

            if (RdpAccessExpiry.IsNotNull())
            {
                createClusterRequest.RdpAccessExpiry = this.RdpAccessExpiry;
			}
			
            // Set IaaS specific parameters
            createClusterRequest.OSType = this.OSType;

            if (SshCredential != null)
            {
                createClusterRequest.SshUserName = this.SshCredential.UserName;
                createClusterRequest.SshPassword = this.SshCredential.GetCleartextPassword();
            }

            if (!string.IsNullOrEmpty(SshPublicKey))
            {
                createClusterRequest.SshPublicKey = this.SshPublicKey;
            }

            return createClusterRequest;
        }

        private void ClientOnClusterProvisioning(object sender, ClusterProvisioningStatusEventArgs clusterProvisioningStatusEventArgs)
        {
            this.State = clusterProvisioningStatusEventArgs.State;
        }
    }
}
