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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CurrentStorageAccount", DefaultParameterSetName = ResourceNameParameterSet),OutputType(typeof(string))]
    public class SetAzureRmCurrentStorageAccount : StorageAccountBaseCmdlet
    {
        private const string StorageContextParameterSet = "UsingStorageContext";
        private const string ResourceNameParameterSet = "UsingResourceGroupAndNameParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = StorageContextParameterSet, ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public IStorageContext Context { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceNameParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceNameParameterSet,
        ValueFromPipelineByPropertyName = true)]
        [Alias(StorageAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            CloudStorageAccount account;
            if (Context != null)
            {
                account = Context.GetCloudStorageAccount();
            }
            else
            {
                account = (new ARMStorageProvider(StorageClient)).GetCloudStorageAccount(Name, ResourceGroupName);
            }

            // Clear the current storage account for both SM and RM
            GeneralUtilities.ClearCurrentStorageAccount(true);
            DefaultContext.SetCurrentStorageAccount(account.ToString(true));
            WriteObject(account.Credentials.AccountName);
        }
    }
}
