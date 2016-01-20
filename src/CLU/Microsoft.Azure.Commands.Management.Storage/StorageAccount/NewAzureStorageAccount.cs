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
using System.Management.Automation;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using StorageModels = Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet(VerbsCommon.New, StorageAccountNounStr), OutputType(typeof(PSStorageAccount))]
    [CliCommandAlias("storage account create")]
    public class NewAzureStorageAccountCommand : StorageAccountBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group StorageAccountName.")]
        [ValidateNotNullOrEmpty]
        [Alias("group", "g")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account StorageAccountName.")]
        [ValidateNotNullOrEmpty]
        [Alias(StorageAccountNameAlias, AccountNameAlias, "n")]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Type.")]
        [ValidateSet(AccountTypeString.StandardLRS,
            AccountTypeString.StandardZRS,
            AccountTypeString.StandardGRS,
            AccountTypeString.StandardRAGRS,
            AccountTypeString.PremiumLRS,
            IgnoreCase = true)]
        [Alias(StorageAccountTypeAlias, AccountTypeAlias, "t")]
        public string Type { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Location.")]
        [ValidateNotNullOrEmpty]
        [Alias("l")]
        public string Location { get; set; }

        [Parameter(
            Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Tags.")]
        [ValidateNotNull]
        public Hashtable[] Tags { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            StorageAccountCreateParameters createParameters = new StorageAccountCreateParameters()
            {
                Location = this.Location,
                AccountType = ParseAccountType(this.Type),
                Tags = TagsConversionHelper.CreateTagDictionary(Tags, validate: true)
            };

            var createAccountResponse = this.StorageClient.StorageAccounts.Create(
                this.ResourceGroupName,
                this.Name,
                createParameters);

            var storageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);

            this.WriteStorageAccount(storageAccount);
        }
    }
}
