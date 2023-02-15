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

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Batch.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        [Parameter(Mandatory = false, HelpMessage = "The type of identity associated with the BatchAccount.\r\nIf set to UserAssigned, the UserAssignedIdentities parameter must also be provided.")]
        public ResourceIdentityType IdentityType { get; set; } = ResourceIdentityType.None;

        [Parameter(Mandatory = false, HelpMessage = "An array containing user assigned identities associated with the BatchAccount. This parameter is only used when IdentityType is set to UserAssigned.")]
        public string[] IdentityId { get; set; }

        protected override void ExecuteCmdletImpl()
        {
            Dictionary<string, UserAssignedIdentities> identityDictionary = null;
            if (IdentityType == ResourceIdentityType.UserAssigned)
            {
                if (IdentityId == null)
                {
                    throw new PSArgumentNullException("IdentityId", "IdentityId must be provided when IdentityType is set to UserAssigned.");
                }

                identityDictionary = IdentityId.ToDictionary(i => i, i => new UserAssignedIdentities());
            }

            AccountCreateParameters parameters = new AccountCreateParameters(this.ResourceGroupName, this.AccountName, this.Location)
            {
                AutoStorageAccountId = this.AutoStorageAccountId,
                PoolAllocationMode = this.PoolAllocationMode,
                KeyVaultId = this.KeyVaultId,
                KeyVaultUrl = this.KeyVaultUrl,
                Tags = this.Tag,
                PublicNetworkAccess = this.PublicNetworkAccess,
                Identity = new BatchAccountIdentity(IdentityType, null, null, identityDictionary)
            };

            BatchAccountContext context = BatchClient.CreateAccount(parameters);
            WriteObject(context);
        }
    }
}
