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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.New,
        Constants.CommandNames.AzureHDInsightCluster),
    OutputType(
        typeof(AzureHDInsightCluster))]
    public class NewAzureHDInsightClusterCommand : HDInsightCmdletBase
    {
        private ClusterCreateParameters parameters;
        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the datacenter location for the cluster.")]
        public string Location
        {
            get { return parameters.Location; }
            set { parameters.Location = value; }
        }

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
        public int ClusterSizeInNodes
        {
            get { return parameters.ClusterSizeInNodes; }
            set { parameters.ClusterSizeInNodes = value; }
        }

        [Parameter(
            Position = 4,
            Mandatory = true,
            HelpMessage = "Gets or sets the login for the cluster's user.")]
        public PSCredential HttpCredential { get; set; }

        [Parameter(
            Position = 5,
            HelpMessage = "Gets or sets the StorageName for the default Azure Storage Account.")]
        public string DefaultStorageAccountName
        {
            get { return parameters.DefaultStorageAccountName; }
            set { parameters.DefaultStorageAccountName = value; }
        }

        [Parameter(
            Position = 6,
            HelpMessage = "Gets or sets the StorageKey for the default Azure Storage Account.")]
        public string DefaultStorageAccountKey
        {
            get { return parameters.DefaultStorageAccountKey; }
            set { parameters.DefaultStorageAccountKey = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the database to store the metadata for Oozie.")]
        public AzureHDInsightMetastore OozieMetastore { get; set; }

        [Parameter(HelpMessage = "Gets or sets the database to store the metadata for Hive.")]
        public AzureHDInsightMetastore HiveMetastore { get; set; }

        [Parameter(HelpMessage = "Gets additional Azure Storage Account that you want to enable access to.")]
        public Dictionary<string, string> AdditionalStorageAccounts { get; private set; }

        [Parameter(HelpMessage = "Gets the configurations of this HDInsight cluster.")]
        public Dictionary<string, Dictionary<string, string>> Configurations { get; private set; }

        [Parameter(HelpMessage = "Gets config actions for the cluster.")]
        public Dictionary<ClusterNodeType, List<ScriptAction>> ScriptActions { get; private set; }

        [Parameter(HelpMessage = "Gets or sets the StorageContainer for the default Azure Storage Account.")]
        public string DefaultStorageContainer
        {
            get { return parameters.DefaultStorageContainer; }
            set { parameters.DefaultStorageContainer = value; }
        }
        
        [Parameter(HelpMessage = "Gets or sets the version of the HDInsight cluster.")]
        public string Version 
        {
            get { return parameters.Version; }
            set { parameters.Version = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the size of the Head Node.")]
        public string HeadNodeSize
        {
            get { return parameters.HeadNodeSize; }
            set { parameters.HeadNodeSize = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the size of the Data Node.")]
        public string WorkerNodeSize 
        {
            get { return parameters.WorkerNodeSize; }
            set { parameters.WorkerNodeSize = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the size of the Zookeeper Node.")]
        public string ZookeeperNodeSize
        {
            get { return parameters.ZookeeperNodeSize; }
            set { parameters.ZookeeperNodeSize = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the flavor for a cluster.")]
        public HDInsightClusterType ClusterType
        {
            get { return parameters.ClusterType; }
            set { parameters.ClusterType = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the virtual network guid for this HDInsight cluster.")]
        public string VirtualNetworkId
        {
            get { return parameters.VirtualNetworkId; }
            set { parameters.VirtualNetworkId = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the subnet name for this HDInsight cluster.")]
        public string SubnetName
        {
            get { return parameters.SubnetName; }
            set { parameters.SubnetName = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the type of operating system installed on cluster nodes.")]
        public OSType OSType
        {
            get { return parameters.OSType; }
            set { parameters.OSType = value; }
        }

        [Parameter(HelpMessage = "Gets or sets SSH credential.")]
        public PSCredential SshCredential { get; set; }

        [Parameter(HelpMessage = "Gets or sets the public key to be used for SSH.")]
        public string SshPublicKey { get; set; }

        [Parameter(HelpMessage = "Gets or sets the credential for RDP access to the cluster.")]
        public PSCredential RdpCredential { get; set; }

        [Parameter(HelpMessage = "Gets or sets the expiry DateTime for RDP access on the cluster.")]
        public DateTime RdpAccessExpiry
        {
            get { return parameters.RdpAccessExpiry; }
            set { parameters.RdpAccessExpiry = value; }
        }

        [Parameter(ValueFromPipeline = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster.")]
        public AzureHDInsightConfig Config {
            get
            {
                var result = new AzureHDInsightConfig
                {
                    ClusterType = parameters.ClusterType,
                    DefaultStorageAccountName = parameters.DefaultStorageAccountName,
                    DefaultStorageAccountKey = parameters.DefaultStorageAccountKey,
                    WorkerNodeSize = parameters.WorkerNodeSize,
                    HeadNodeSize = parameters.HeadNodeSize,
                    ZookeeperNodeSize = parameters.ZookeeperNodeSize,
                    HiveMetastore = HiveMetastore,
                    OozieMetastore = OozieMetastore
                };
                foreach (
                    var storageAccount in
                        parameters.AdditionalStorageAccounts.Where(
                            storageAccount => !result.AdditionalStorageAccounts.ContainsKey(storageAccount.Key)))
                {
                    result.AdditionalStorageAccounts.Add(storageAccount.Key, storageAccount.Value);
                }
                foreach (var val in parameters.Configurations.Where(val => !result.Configurations.ContainsKey(val.Key)))
                {
                    result.Configurations.Add(val.Key, DictionaryToHashtable(val.Value));
                }
                return result;
            }
            set
            {
                parameters.ClusterType = value.ClusterType;
                parameters.DefaultStorageAccountName = value.DefaultStorageAccountName;
                parameters.DefaultStorageAccountKey = value.DefaultStorageAccountKey;
                parameters.WorkerNodeSize = value.WorkerNodeSize;
                parameters.HeadNodeSize = value.HeadNodeSize;
                parameters.ZookeeperNodeSize = value.ZookeeperNodeSize;
                HiveMetastore = value.HiveMetastore;
                OozieMetastore = value.HiveMetastore;
                foreach (
                    var storageAccount in
                        value.AdditionalStorageAccounts.Where(
                            storageAccount => !parameters.AdditionalStorageAccounts.ContainsKey(storageAccount.Key)))
                {
                    parameters.AdditionalStorageAccounts.Add(storageAccount.Key, storageAccount.Value);
                }
                foreach (var val in value.Configurations.Where(val => !parameters.Configurations.ContainsKey(val.Key)))
                {
                    parameters.Configurations.Add(val.Key, HashtableToDictionary(val.Value));
                }
            } 
        }

        #endregion


        public NewAzureHDInsightClusterCommand()
        {
            parameters = new ClusterCreateParameters();
            AdditionalStorageAccounts = new Dictionary<string, string>();
            Configurations = new Dictionary<string, Dictionary<string, string>>();
            ScriptActions = new Dictionary<ClusterNodeType, List<ScriptAction>>();
        }

        public override void ExecuteCmdlet()
        {
            parameters.UserName = HttpCredential.UserName;
            parameters.Password = HttpCredential.Password.ConvertToString();

            if (RdpCredential != null)
            {
                parameters.RdpUsername = RdpCredential.UserName;
                parameters.RdpPassword = RdpCredential.Password.ConvertToString();
            }

            if (OSType == OSType.Linux)
            {
                parameters.SshUserName = SshCredential.UserName;
                if (!string.IsNullOrEmpty(SshCredential.Password.ConvertToString()))
                {
                    parameters.SshPassword = SshCredential.Password.ConvertToString();
                }
                if (!string.IsNullOrEmpty(SshPublicKey))
                {
                    parameters.SshPublicKey = SshPublicKey;
                }
            }

            foreach (
                var storageAccount in
                    AdditionalStorageAccounts.Where(
                        storageAccount => !parameters.AdditionalStorageAccounts.ContainsKey(storageAccount.Key)))
            {
                parameters.AdditionalStorageAccounts.Add(storageAccount.Key, storageAccount.Value);
            }
            foreach (var config in Configurations.Where(config => !parameters.Configurations.ContainsKey(config.Key)))
            {
                parameters.Configurations.Add(config.Key, config.Value);
            }
            foreach (var action in ScriptActions.Where(action => parameters.ScriptActions.ContainsKey(action.Key)))
            {
                parameters.ScriptActions.Add(action.Key, action.Value);
            }
            if (OozieMetastore != null)
            {
                var metastore = OozieMetastore;
                parameters.OozieMetastore = new Metastore(metastore.SqlAzureServerName, metastore.DatabaseName, metastore.Credential.UserName, metastore.Credential.Password.ConvertToString());
            }
            if (HiveMetastore != null)
            {
                var metastore = HiveMetastore;
                parameters.OozieMetastore = new Metastore(metastore.SqlAzureServerName, metastore.DatabaseName, metastore.Credential.UserName, metastore.Credential.Password.ConvertToString());
            }

            var cluster = HDInsightManagementClient.CreateNewCluster(ResourceGroupName, ClusterName, parameters);

            if (cluster != null)
            {
                WriteObject(new AzureHDInsightCluster(cluster.Cluster));
            }
        }

        private static Hashtable DictionaryToHashtable(Dictionary<string, string> dictionary)
        {
            return new Hashtable(dictionary);
        }

        private static Dictionary<string, string> HashtableToDictionary(Hashtable table)
        {
            return table
              .Cast<DictionaryEntry>()
              .ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value);
        }
    }
}
