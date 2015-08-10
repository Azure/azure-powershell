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

using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightConfig
    {
        /// <summary>
        /// Gets additional Azure Storage Account that you want to enable access to.
        /// </summary>
        public Dictionary<string, string> AdditionalStorageAccounts { get; private set; }

        /// <summary>
        /// Gets or sets the StorageName for the default Azure Storage Account.
        /// </summary>
        public string DefaultStorageAccountName { get; set; }

        /// <summary>
        /// Gets or sets the StorageKey for the default Azure Storage Account.
        /// </summary>
        public string DefaultStorageAccountKey { get; set; }

        /// <summary>
        /// Gets or sets the size of the Head Node.
        /// </summary>
        public string HeadNodeSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the Data Node.
        /// </summary>
        public string WorkerNodeSize { get; set; }

        /// <summary>
        /// Gets or sets the size of the Zookeeper Node.
        /// </summary>
        public string ZookeeperNodeSize { get; set; }

        /// <summary>
        /// Gets or sets the flavor for a cluster.
        /// </summary>
        public HDInsightClusterType ClusterType { get; set; }
        
        /// <summary>
        /// Gets or sets the database to store the metadata for Oozie.
        /// </summary>
        public AzureHDInsightMetastore OozieMetastore { get; set; }

        /// <summary>
        /// Gets or sets the database to store the metadata for Hive.
        /// </summary>
        public AzureHDInsightMetastore HiveMetastore { get; set; }
        
        /// <summary>
        /// Gets the configurations of this HDInsight cluster.
        /// </summary>
        public Dictionary<string, Hashtable> Configurations { get; private set; }

        /// <summary>
        /// Gets config actions for the cluster.
        /// </summary>
        public Dictionary<ClusterNodeType, List<ScriptAction>> ScriptActions { get; private set; }

        public AzureHDInsightConfig()
        {
            ClusterType = HDInsightClusterType.Hadoop;
            AdditionalStorageAccounts = new Dictionary<string, string>();
            Configurations = new Dictionary<string, Hashtable>();
            ScriptActions = new Dictionary<ClusterNodeType, List<ScriptAction>>();
        }
    }
}
