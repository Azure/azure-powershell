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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using StorageModels = Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Text;

namespace Microsoft.Azure.Commands.Management.Storage
{
    /// <summary>
    /// Lists all storage services underneath the subscription.
    /// </summary>
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + StorageAccountFailoverNounStr, SupportsShouldProcess = true, DefaultParameterSetName = AccountNameParameterSet), OutputType(typeof(PSStorageAccount))]    
    public class InvokeAzureStorageAccountFailoverCommand : StorageAccountBaseCmdlet
    {  
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameParameterSet = "AccountName";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = AccountNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
            ParameterSetName = AccountNameParameterSet)]
        [Alias(StorageAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount InputObject { get; set; }

        [Parameter(HelpMessage = "Force to Failover the Account")]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }
        private bool force = false;      

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, "Invoke Failover of Storage Account"))
            {
                StringBuilder shouldContinuePrompt = new StringBuilder();
                shouldContinuePrompt.AppendLine("Failover the storage account, the secondary cluster will become primary after failover. Please understand the following impact to your storage account before you initiate the failover:");
                shouldContinuePrompt.AppendLine("  1. Please check the Last Sync Time using Get-"+ ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccount cmdlet with -IncludeGeoReplicationStats parameter, and check GeoReplicationStats property of your account. This is the data you may lose if you initiate the failover.");
                shouldContinuePrompt.AppendLine("  2. After the failover, your storage account type will be converted to locally redundant storage (LRS). You can convert your account to use geo-redundant storage (GRS).");
                shouldContinuePrompt.AppendLine("  3. Once you re-enable GRS for your storage account, Microsoft will replicate data to your new secondary region. Replication time is dependent on the amount of data to replicate. Please note that there are bandwidth charges for the bootstrap. Please refer to doc: https://azure.microsoft.com/en-us/pricing/details/bandwidth/");


                if (this.force || ShouldContinue(shouldContinuePrompt.ToString(), ""))
                {
                    if (ParameterSetName == AccountObjectParameterSet)
                    {
                        this.ResourceGroupName = InputObject.ResourceGroupName;
                        this.Name = InputObject.StorageAccountName;
                    }

                    this.StorageClient.StorageAccounts.Failover(
                        this.ResourceGroupName,
                        this.Name);

                    var storageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);

                    WriteStorageAccount(storageAccount, DefaultContext);
                }
            }
        }
    }
}
