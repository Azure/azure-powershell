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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    /// <summary>
    ///     Adds a storage account to the HDInsight cluster configuration.
    /// </summary>
    internal class AddAzureHDInsightStorageCommand : IAddAzureHDInsightStorageCommand
    {
        /// <summary>
        ///     Initializes a new instance of the AddAzureHDInsightStorageCommand class.
        /// </summary>
        public AddAzureHDInsightStorageCommand()
        {
            this.Config = new AzureHDInsightConfig();
            this.Output = new Collection<AzureHDInsightConfig>();
        }

        public CancellationToken CancellationToken
        {
            get { return CancellationToken.None; }
        }

        public AzureHDInsightConfig Config { get; set; }

        public ICollection<AzureHDInsightConfig> Output { get; private set; }

        public string StorageAccountKey { get; set; }

        public string StorageAccountName { get; set; }

        public AzureSubscription CurrentSubscription { get; set; }

        public void Cancel()
        {
        }

        public Task EndProcessing()
        {
            var account = new AzureHDInsightStorageAccount();
            account.StorageAccountName = this.StorageAccountName;
            account.StorageAccountKey = this.StorageAccountKey;
            this.Config.AdditionalStorageAccounts.Add(account);
            this.Output.Add(this.Config);
            return TaskEx.FromResult(0);
        }
    }
}
