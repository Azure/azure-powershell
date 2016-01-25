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
using System.Management.Automation;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet(VerbsCommon.New, StorageAccountKeyNounStr), OutputType(typeof(StorageAccountKeys))]
    [CliCommandAlias("storage key create")]
    public class NewAzureStorageAccountKeyCommand : StorageAccountBaseCmdlet
    {
        private const string Key1 = "Key1";

        private const string Key2 = "Key2";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        [Alias("group", "g")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(StorageAccountNameAlias, AccountNameAlias, "n")]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Key Name ('Key1' or 'Key2'.")]
        [ValidateSet(Key1, Key2, IgnoreCase = true)]
        [Alias("k")]
        public string KeyName { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var keys = this.StorageClient.StorageAccounts.RegenerateKey(
                this.ResourceGroupName,
                this.Name,
                this.KeyName);

            WriteObject(keys);
        }
    }
}
