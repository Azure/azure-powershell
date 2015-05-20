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

using System.Management.Automation;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.New,
        Constants.CommandNames.AzureHDInsightClusterConfig),
    OutputType(
        typeof(AzureHDInsightConfig))]
    public class NewAzureHDInsightClusterConfigCommand : HDInsightCmdletBase
    {
        private readonly AzureHDInsightConfig config = new AzureHDInsightConfig();

        #region Input Parameter Definitions

        [Parameter(HelpMessage = "Gets or sets the StorageName for the default Azure Storage Account.")]
        public string DefaultStorageAccountName {
            get { return this.config.DefaultStorageAccountName; }
            set { this.config.DefaultStorageAccountName = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the StorageKey for the default Azure Storage Account.")]
        public string DefaultStorageAccountKey
        {
            get { return this.config.DefaultStorageAccountKey; }
            set { this.config.DefaultStorageAccountKey = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the database to store the metadata for Oozie.")]
        public AzureHDInsightMetastore OozieMetastore
        {
            get { return this.config.OozieMetastore; }
            set { this.config.OozieMetastore = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the database to store the metadata for Hive.")]
        public AzureHDInsightMetastore HiveMetastore
        {
            get { return this.config.HiveMetastore; }
            set { this.config.HiveMetastore = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the size of the Head Node.")]
        public string HeadNodeSize
        {
            get { return this.config.HeadNodeSize; }
            set { this.config.HeadNodeSize = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the size of the Data Node.")]
        public string DataNodeSize
        {
            get { return this.config.DataNodeSize; }
            set { this.config.DataNodeSize = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the size of the Zookeeper Node.")]
        public string ZookeeperNodeSize
        {
            get { return this.config.ZookeeperNodeSize; }
            set { this.config.ZookeeperNodeSize = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the flavor for a cluster.")]
        public HDInsightClusterType ClusterType
        {
            get { return this.config.ClusterType; }
            set { this.config.ClusterType = value; }
        }

        #endregion

        public override void ExecuteCmdlet()
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
            this.WriteObject(result);
        }
    }
}
