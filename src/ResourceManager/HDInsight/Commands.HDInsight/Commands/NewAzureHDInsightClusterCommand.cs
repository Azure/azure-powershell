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
using System.Management.Automation;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.New,
        Constants.CommandNames.AzureHDInsightCluster),
    OutputType(
        typeof(ClusterGetResponse))]
    public class NewAzureHDInsightCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions


        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the datacenter location for the cluster.")]
        public string Location { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the resource group.")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = "Gets or sets the number of workernodes for the cluster.")]
        public int ClusterSizeInNodes { get; set; }

        [Parameter(
            Position = 4,
            Mandatory = true,
            HelpMessage = "Gets or sets the StorageName for the default Azure Storage Account.")]
        public string DefaultStorageAccountName { get; set; }

        [Parameter(
            Position = 5,
            Mandatory = true,
            HelpMessage = "Gets or sets the StorageKey for the default Azure Storage Account.")]
        public string DefaultStorageAccountKey { get; set; }

        [Parameter(HelpMessage = "Gets or sets the database to store the metadata for Oozie.")]
        public AzureHDInsightMetastore OozieMetastore { get; set; }

        [Parameter(HelpMessage = "Gets or sets the database to store the metadata for Hive.")]
        public AzureHDInsightMetastore HiveMetastore { get; set; }

        [Parameter(HelpMessage = "Gets additional Azure Storage Account that you want to enable access to.")]
        public Dictionary<string, string> AdditionalStorageAccounts { get; private set; }

        [Parameter(HelpMessage = "Gets the configurations of this HDInsight cluster.")]
        public Dictionary<string, Dictionary<string, string>> Configurations { get; private set; }

        [Parameter(HelpMessage = "Gets or sets the StorageContainer for the default Azure Storage Account.")]
        public string DefaultStorageContainer { get; set; }

        [Parameter(HelpMessage = "Gets or sets the login for the cluster's user.")]
        public PSCredential HttpUser { get; set; }

        [Parameter(HelpMessage = "Gets or sets the version of the HDInsight cluster.")]
        public string Version { get; set; }

        [Parameter(HelpMessage = "Gets or sets the size of the Head Node.")]
        public string HeadNodeSize { get; set; }

        [Parameter(HelpMessage = "Gets or sets the size of the Data Node.")]
        public string DataNodeSize { get; set; }

        [Parameter(HelpMessage = "Gets or sets the size of the Zookeeper Node.")]
        public string ZookeeperNodeSize { get; set; }

        [Parameter(HelpMessage = "Gets or sets the flavor for a cluster.")]
        public HDInsightClusterType ClusterType { get; set; }

        [Parameter(HelpMessage = "Gets or sets the virtual network guid for this HDInsight cluster.")]
        public string VirtualNetworkId { get; set; }

        [Parameter(HelpMessage = "Gets or sets the subnet name for this HDInsight cluster.")]
        public string SubnetName { get; set; }

        [Parameter(HelpMessage = "Gets or sets the type of operating system installed on cluster nodes.")]
        public OSType OSType { get; set; }

        [Parameter(HelpMessage = "Gets or sets SSH user name.")]
        public string SshUserName { get; set; }

        [Parameter(HelpMessage = "Gets or sets SSH password.")]
        public string SshPassword { get; set; }

        [Parameter(HelpMessage = "Gets or sets the public key to be used for SSH.")]
        public string SshPublicKey { get; set; }

        [Parameter(HelpMessage = "Gets or sets the username for RDP access to the cluster.")]
        public PSCredential RdpUser { get; set; }

        [Parameter(HelpMessage = "Gets or sets the expiry DateTime for RDP access on the cluster.")]
        public DateTime RdpAccessExpiry { get; set; }

        [Parameter(ValueFromPipeline = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster")]
        public AzureHDInsightConfig Config {
            get
            {
                var result = new AzureHDInsightConfig
                {
                    ClusterType = this.ClusterType,
                    DefaultStorageAccountName = this.DefaultStorageAccountName,
                    DefaultStorageAccountKey = this.DefaultStorageAccountKey,
                    DataNodeSize = this.DataNodeSize,
                    HeadNodeSize = this.HeadNodeSize,
                    ZookeeperNodeSize = this.ZookeeperNodeSize,
                    HiveMetastore = this.HiveMetastore,
                    OozieMetastore = this.OozieMetastore
                };
                foreach (var storageAccount in this.AdditionalStorageAccounts)
                {
                    result.AdditionalStorageAccounts.Add(storageAccount.Key, storageAccount.Value);
                }
                foreach (var val in this.Configurations)
                {
                    result.Configurations.Add(val.Key, val.Value);
                }
                return result;
            }
            set
            {
                this.ClusterType = value.ClusterType;
                this.DefaultStorageAccountName = value.DefaultStorageAccountName;
                this.DefaultStorageAccountKey = value.DefaultStorageAccountKey;
                this.DataNodeSize = value.DataNodeSize;
                this.HeadNodeSize = value.HeadNodeSize;
                this.ZookeeperNodeSize = value.ZookeeperNodeSize;
                this.HiveMetastore = value.HiveMetastore;
                this.OozieMetastore = value.HiveMetastore;
                foreach (var storageAccount in value.AdditionalStorageAccounts)
                {
                    this.AdditionalStorageAccounts.Add(storageAccount.Key, storageAccount.Value);
                }
                foreach (var val in value.Configurations)
                {
                    this.Configurations.Add(val.Key, val.Value);
                }
            } 
        }

        #endregion

        public NewAzureHDInsightCommand()
        {
            this.AdditionalStorageAccounts = new Dictionary<string, string>();
            this.Configurations = new Dictionary<string, Dictionary<string, string>>();
        }

        public override void ExecuteCmdlet()
        {
            var parameters = new ClusterCreateParameters
            {
                Location = this.Location,
                DefaultStorageAccountName = this.DefaultStorageAccountName,
                DefaultStorageAccountKey = this.DefaultStorageAccountKey,
                ClusterSizeInNodes = this.ClusterSizeInNodes,
                DefaultStorageContainer = this.DefaultStorageContainer,
                UserName = this.HttpUser.UserName,
                Password = this.HttpUser.Password.ToString(),
                RdpUsername = this.RdpUser.UserName,
                RdpPassword = this.RdpUser.Password.ToString(),
                RdpAccessExpiry = this.RdpAccessExpiry,
                Version = this.Version,
                HeadNodeSize = this.HeadNodeSize,
                DataNodeSize = this.DataNodeSize,
                ZookeeperNodeSize = this.ZookeeperNodeSize,
                ClusterType = this.ClusterType,
                VirtualNetworkId = this.VirtualNetworkId,
                SubnetName = this.SubnetName,
                OSType = this.OSType,
                SshUserName = this.SshUserName,
                SshPassword = this.SshPassword,
                SshPublicKey = this.SshPublicKey
            };

            foreach (var storageAccount in this.AdditionalStorageAccounts)
            {
                parameters.AdditionalStorageAccounts.Add(storageAccount.Key, storageAccount.Value);
            }
            foreach (var config in this.Configurations)
            {
                parameters.Configurations.Add(config.Key, config.Value);
            }
            if (this.OozieMetastore != null)
            {
                var metastore = this.OozieMetastore;
                parameters.OozieMetastore = new Metastore(metastore.SqlAzureServerName, metastore.DatabaseName, metastore.Credential.UserName, metastore.Credential.Password.ToString());
            }
            if (this.HiveMetastore != null)
            {
                var metastore = this.HiveMetastore;
                parameters.OozieMetastore = new Metastore(metastore.SqlAzureServerName, metastore.DatabaseName, metastore.Credential.UserName, metastore.Credential.Password.ToString());
            }

            var cluster = HDInsightManagementClient.CreateNewCluster(ResourceGroupName, ClusterName, parameters);

            this.WriteObject(cluster);
        }
    }
}
