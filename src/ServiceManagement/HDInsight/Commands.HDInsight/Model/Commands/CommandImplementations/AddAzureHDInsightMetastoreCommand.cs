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
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    internal class AddAzureHDInsightMetastoreCommand : AzureHDInsightCommand<AzureHDInsightConfig>, IAddAzureHDInsightMetastoreCommand
    {
        private readonly AzureHDInsightMetastore metastore = new AzureHDInsightMetastore();

        public AddAzureHDInsightMetastoreCommand()
        {
            this.Config = new AzureHDInsightConfig();
        }

        public AzureHDInsightConfig Config { get; set; }

        public PSCredential Credential
        {
            get { return this.metastore.Credential; }
            set { this.metastore.Credential = value; }
        }

        public string DatabaseName
        {
            get { return this.metastore.DatabaseName; }
            set { this.metastore.DatabaseName = value; }
        }

        public AzureHDInsightMetastoreType MetastoreType
        {
            get { return this.metastore.MetastoreType; }
            set { this.metastore.MetastoreType = value; }
        }

        public string SqlAzureServerName
        {
            get { return this.metastore.SqlAzureServerName; }
            set { this.metastore.SqlAzureServerName = value; }
        }

        public override Task EndProcessing()
        {
            if (this.MetastoreType == AzureHDInsightMetastoreType.HiveMetastore)
            {
                this.Config.HiveMetastore = this.metastore;
            }
            else
            {
                this.Config.OozieMetastore = this.metastore;
            }
            this.Output.Add(this.Config);
            return TaskEx.FromResult(0);
        }
    }
}
