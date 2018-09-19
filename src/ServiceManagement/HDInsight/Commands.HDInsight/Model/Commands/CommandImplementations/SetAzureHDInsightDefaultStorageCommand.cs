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

using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    internal class SetAzureHDInsightDefaultStorageCommand : AzureHDInsightCommand<AzureHDInsightConfig>, ISetAzureHDInsightDefaultStorageCommand
    {
        public SetAzureHDInsightDefaultStorageCommand()
        {
            this.Config = new AzureHDInsightConfig();
        }

        public AzureHDInsightConfig Config { get; set; }

        public string StorageAccountKey { get; set; }

        public string StorageAccountName { get; set; }

        public string StorageContainerName { get; set; }

        public override Task EndProcessing()
        {
            this.Config.DefaultStorageAccount.StorageAccountName = this.StorageAccountName;
            this.Config.DefaultStorageAccount.StorageAccountKey = this.StorageAccountKey;
            this.Config.DefaultStorageAccount.StorageContainerName = this.StorageContainerName;
            this.Output.Add(this.Config);
            return TaskEx.FromResult(0);
        }
    }
}
