﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Batch.Models;
using System.Collections;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BatchAccount"), OutputType(typeof(BatchAccountContext))]
    public class NewBatchAccountCommand : BatchCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Batch service account to create.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The region where the account will be created.")]
        [LocationCompleter("Microsoft.Batch/batchAccounts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group where the account will be created.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string AutoStorageAccountId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public PoolAllocationMode? PoolAllocationMode { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string KeyVaultId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string KeyVaultUrl { get; set; }

        [Alias("Tags")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The public network access type")]
        public PublicNetworkAccessType PublicNetworkAccess { get; set; }

        protected override void ExecuteCmdletImpl()
        {
            AccountCreateParameters parameters = new AccountCreateParameters(this.ResourceGroupName, this.AccountName, this.Location)
            {
                AutoStorageAccountId = this.AutoStorageAccountId,
                PoolAllocationMode = this.PoolAllocationMode,
                KeyVaultId = this.KeyVaultId,
                KeyVaultUrl = this.KeyVaultUrl,
                Tags = this.Tag,
                PublicNetworkAccess = this.PublicNetworkAccess
            };
            BatchAccountContext context = BatchClient.CreateAccount(parameters);
            WriteObject(context);
        }
    }
}
