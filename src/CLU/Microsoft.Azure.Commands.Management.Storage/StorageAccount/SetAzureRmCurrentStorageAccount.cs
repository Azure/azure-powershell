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
using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Storage;
using Microsoft.Azure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Storage;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet(VerbsCommon.Set, "AzureRmCurrentStorageAccount", DefaultParameterSetName=ResourceNameParameterSet), 
    OutputType(typeof(string))]
    [CliCommandAlias("storage account current set")]
    public class SetAzureRmCurrentStorageAccount : StorageAccountBaseCmdlet
    {
        private const string StorageContextParameterSet = "UsingStorageContext";
        private const string ResourceNameParameterSet = "UsingResourceGroupAndNameParameterSet";

        [Parameter(Mandatory=true, ParameterSetName=StorageContextParameterSet, ValueFromPipeline=true, 
            ValueFromPipelineByPropertyName = true, HelpMessage = "The Storage context for the storage account.")]
        [ValidateNotNull]
        public AzureStorageContext Context { get; set; }

        [Parameter(Mandatory=true, ParameterSetName=ResourceNameParameterSet, 
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("group", "g")]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory=true, ParameterSetName=ResourceNameParameterSet, 
        ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("name", "n")]
        public string StorageAccountName { get; set; }

        protected override void ProcessRecord()
        {
            CloudStorageAccount account;
            if (Context != null)
            {
                account = Context.StorageAccount;
            }
            else
            {
                account = StorageUtilities.GenerateCloudStorageAccount(StorageClient, ResourceGroupName, StorageAccountName);
            }

            // Clear the current storage account for both SM and RM
            GeneralUtilities.ClearCurrentStorageAccount(DataStore, DefaultProfile, true);
            DefaultContext.SetCurrentStorageAccount(account.ToString(true));
            WriteObject(account.Credentials.AccountName);
        }
    }
}
