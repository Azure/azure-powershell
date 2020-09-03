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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageObjectReplicationPolicy", DefaultParameterSetName = AccountNameParameterSet), OutputType(typeof(PSObjectReplicationPolicy))]
    public class GetAzureStorageAccountObjectReplicationPolicyCommand : StorageAccountBaseCmdlet
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
        [ResourceNameCompleter("Microsoft.Storage/storageAccounts", nameof(ResourceGroupName))]
        [Alias(AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Object Replication Policy Id.")]
        [ValidateNotNullOrEmpty]
        public string PolicyId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (ParameterSetName)
            {
                case AccountObjectParameterSet:
                    this.ResourceGroupName = StorageAccount.ResourceGroupName;
                    this.StorageAccountName = StorageAccount.StorageAccountName;
                    break;
                default:
                    // For AccountNameParameterSet, the ResourceGroupName and StorageAccountName can get from input directly
                    break;
            }
            if (!string.IsNullOrEmpty(PolicyId))
            {
                ObjectReplicationPolicy policy = this.StorageClient.ObjectReplicationPolicies.Get(
                     this.ResourceGroupName,
                     this.StorageAccountName,
                     PolicyId);

                WriteObject(new PSObjectReplicationPolicy(policy, this.ResourceGroupName, this.StorageAccountName));
            }
            else
            {
                IEnumerable<ObjectReplicationPolicy> policies = this.StorageClient.ObjectReplicationPolicies.List(
                     this.ResourceGroupName,
                     this.StorageAccountName);
                WriteObject(PSObjectReplicationPolicy.GetPSObjectReplicationPolicies(policies, this.ResourceGroupName, this.StorageAccountName), true);
            }
        }
    }
}
