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
using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects
{
    /// <summary>
    ///     Represents an Azure Configuration to be used when creating new clusters.
    /// </summary>
    public class AzureHDInsightConfig
    {
        /// <summary>
        ///     Initializes a new instance of the AzureHDInsightConfig class.
        /// </summary>
        public AzureHDInsightConfig()
        {
            this.DefaultStorageAccount = new AzureHDInsightDefaultStorageAccount();
            this.AdditionalStorageAccounts = new List<AzureHDInsightStorageAccount>();
            this.ConfigActions = new List<AzureHDInsightConfigAction>();
            this.CoreConfiguration = new ConfigValuesCollection();
            this.YarnConfiguration = new ConfigValuesCollection();
            this.HdfsConfiguration = new ConfigValuesCollection();
            this.MapReduceConfiguration = new MapReduceConfiguration();
            this.HiveConfiguration = new HiveConfiguration();
            this.OozieConfiguration = new OozieConfiguration();
            this.HeadNodeVMSize = NodeVMSize.Large.ToString();
            this.DataNodeVMSize = NodeVMSize.Large.ToString();
            this.ZookeeperNodeVMSize = null;
            this.ClusterType = ClusterType.Hadoop;
            this.StormConfiguration = new ConfigValuesCollection();
            this.SparkConfiguration = new ConfigValuesCollection();
            this.HBaseConfiguration = new HBaseConfiguration();
        }

        /// <summary>
        ///     Gets the additional storage accounts for the HDInsight cluster.
        /// </summary>
        public ICollection<AzureHDInsightStorageAccount> AdditionalStorageAccounts { get; private set; }

        /// <summary>
        /// Gets or sets the size of the head node VM.
        /// </summary>
        /// <value>
        /// The size of the head node VM.
        /// </value>
        public string HeadNodeVMSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the head node VM.
        /// </summary>
        /// <value>
        /// The size of the head node VM.
        /// </value>
        public string DataNodeVMSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the head node VM.
        /// </summary>
        /// <value>
        /// The size of the head node VM.
        /// </value>
        public string ZookeeperNodeVMSize { get; set; }

        /// <summary>
        ///     Gets or sets the size of the cluster in data nodes.
        /// </summary>
        public int ClusterSizeInNodes { get; set; }

        /// <summary>
        /// Gets or sets the type of the cluster.
        /// </summary>
        public ClusterType ClusterType { get; set; }

         /// <summary>
        /// Gets or sets the virtual network id.
        /// </summary>
        public string VirtualNetworkId { get; set; }

        /// <summary>
        /// Gets or sets the subnet name.
        /// </summary>
        public string SubnetName { get; set; }

        /// <summary>
        ///     Gets a collection of configuration properties to customize the Core Hadoop service.
        /// </summary>
        public ConfigValuesCollection CoreConfiguration { get; private set; }

        /// <summary>
        ///     Gets a collection of configuration properties to customize the Yarn Hadoop service.
        /// </summary>
        public ConfigValuesCollection YarnConfiguration { get; private set; }

        /// <summary>
        ///     Gets or sets the default storage account for the HDInsight cluster.
        /// </summary>
        public AzureHDInsightDefaultStorageAccount DefaultStorageAccount { get; set; }

        /// <summary>
        ///     Gets a collection of configuration properties to customize the Hdfs Hadoop service.
        /// </summary>
        public ConfigValuesCollection HdfsConfiguration { get; private set; }

        /// <summary>
        ///     Gets a collection of configuration properties to customize the Hive Hadoop service.
        /// </summary>
        public HiveConfiguration HiveConfiguration { get; private set; }

        /// <summary>
        ///     Gets or sets the Hive Metastore.
        /// </summary>
        public AzureHDInsightMetastore HiveMetastore { get; set; }

        /// <summary>  
        ///     Gets the config actions for the HDInsight cluster.  
        /// </summary>  
        public ICollection<AzureHDInsightConfigAction> ConfigActions { get; private set; }  

        /// <summary>
        ///     Gets a collection of configuration properties to customize the MapReduce Hadoop service.
        /// </summary>
        public MapReduceConfiguration MapReduceConfiguration { get; private set; }

        /// <summary>
        ///     Gets a collection of configuration properties to customize the Oozie Hadoop service.
        /// </summary>
        public OozieConfiguration OozieConfiguration { get; private set; }

        /// <summary>
        ///     Gets or sets the Oozie Metastore.
        /// </summary>
        public AzureHDInsightMetastore OozieMetastore { get; set; }

        /// <summary>
        ///     Gets a collection of configuration properties to customize the Storm service.
        /// </summary>
        public ConfigValuesCollection StormConfiguration { get; private set; }

        /// <summary>
        ///     Gets a collection of configuration properties to customize the Spark service.
        /// </summary>
        public ConfigValuesCollection SparkConfiguration { get; private set; }

        /// <summary>
        ///     Gets a collection of configuration properties to customize the HBase service.
        /// </summary>
        public HBaseConfiguration HBaseConfiguration { get; private set; }


        /// <summary>
        ///     Copies all parameters from the provided AzureHDInsightConfig object into this object, replacing
        ///     single-value attributes, and merging collection attributes.
        /// </summary>
        public virtual void CopyFrom(AzureHDInsightConfig value)
        {
            if (value==null)
            {
                throw new ArgumentNullException("value", "The value for the configuration cannot be null.");
            }

            this.ClusterSizeInNodes = value.ClusterSizeInNodes;
            this.DefaultStorageAccount = new AzureHDInsightDefaultStorageAccount(value.DefaultStorageAccount);
            this.AdditionalStorageAccounts.AddRange(value.AdditionalStorageAccounts);
            this.ConfigActions.AddRange(value.ConfigActions);
            this.HiveMetastore = value.HiveMetastore ?? this.HiveMetastore;
            this.OozieMetastore = value.OozieMetastore ?? this.OozieMetastore;
            this.CoreConfiguration.AddRange(value.CoreConfiguration);
            this.YarnConfiguration.AddRange(value.YarnConfiguration);
            this.HdfsConfiguration.AddRange(value.HdfsConfiguration);
            this.MapReduceConfiguration.ConfigurationCollection.AddRange(value.MapReduceConfiguration.ConfigurationCollection);
            this.MapReduceConfiguration.CapacitySchedulerConfigurationCollection.AddRange(
                value.MapReduceConfiguration.CapacitySchedulerConfigurationCollection);
            this.HiveConfiguration.ConfigurationCollection.AddRange(value.HiveConfiguration.ConfigurationCollection);
            this.HiveConfiguration.AdditionalLibraries = 
                 value.HiveConfiguration.AdditionalLibraries ?? this.HiveConfiguration.AdditionalLibraries;
            this.OozieConfiguration.ConfigurationCollection.AddRange(value.OozieConfiguration.ConfigurationCollection);
            this.OozieConfiguration.AdditionalActionExecutorLibraries =
                value.OozieConfiguration.AdditionalActionExecutorLibraries ?? this.OozieConfiguration.AdditionalActionExecutorLibraries;
            this.OozieConfiguration.AdditionalSharedLibraries =
                value.OozieConfiguration.AdditionalSharedLibraries ?? this.OozieConfiguration.AdditionalSharedLibraries;
            this.HeadNodeVMSize = value.HeadNodeVMSize;
            this.DataNodeVMSize = value.DataNodeVMSize;
            this.ZookeeperNodeVMSize = value.ZookeeperNodeVMSize;
            this.ClusterType = value.ClusterType;
            this.VirtualNetworkId = value.VirtualNetworkId;
            this.SubnetName = value.SubnetName;
            this.StormConfiguration.AddRange(value.StormConfiguration);
            this.HBaseConfiguration.ConfigurationCollection.AddRange(value.HBaseConfiguration.ConfigurationCollection);
            this.HBaseConfiguration.AdditionalLibraries = 
                value.HBaseConfiguration.AdditionalLibraries ?? this.HBaseConfiguration.AdditionalLibraries;
            this.SparkConfiguration.AddRange(value.SparkConfiguration);
        }
    }
}
