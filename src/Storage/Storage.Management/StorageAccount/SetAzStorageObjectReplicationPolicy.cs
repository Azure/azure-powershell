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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageObjectReplicationPolicy", SupportsShouldProcess = true, DefaultParameterSetName = AccountNameParameterSet), OutputType(typeof(PSObjectReplicationPolicy))]
    public class RSetAzureStorageAccountObjectReplicationPolicyCommand : StorageAccountBaseCmdlet
    {
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameParameterSet = "AccountName";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";

        /// <summary>
        /// ManagementPolicy object parameter set 
        /// </summary>
        private const string PolicyObjectParameterSet = "PolicyObject";

        [Parameter(
         Position = 0,
         Mandatory = true,
         HelpMessage = "Resource Group Name.",
        ParameterSetName = AccountNameParameterSet)]
        [Parameter(
         Position = 0,
         Mandatory = true,
         HelpMessage = "Resource Group Name.",
        ParameterSetName = PolicyObjectParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
           ParameterSetName = AccountNameParameterSet)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
           ParameterSetName = PolicyObjectParameterSet)]
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

        [Parameter(Mandatory = true,
            HelpMessage = "Object Replication Policy Object to Set to the specified Account.",
            ValueFromPipeline = true,
           ParameterSetName = PolicyObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSObjectReplicationPolicy InputObject{ get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Object Replication Policy Id. It should be a GUID or 'default'. If not input the PolicyId, will use 'default', which means to create a new policy and the Id of the new policy will be returned in the created policy.",
           ParameterSetName = AccountNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Object Replication Policy Id. It should be a GUID or 'default'. If not input the PolicyId, will use 'default', which means to create a new policy and the Id of the new policy will be returned in the created policy.",
           ParameterSetName = AccountObjectParameterSet)]
        [ValidatePattern("(\\{|\\()?[A-Za-z0-9]{4}([A-Za-z0-9]{4}\\-?){4}[A-Za-z0-9]{12}(\\}|\\()?|default")]
        public string PolicyId
        {
            get
            {
                return policyId;
            }
            set
            {
                policyId = value;
            }
        }
        private string policyId = "default";

        [Parameter(
            Mandatory = true,
            HelpMessage = "Object Replication Policy SourceAccount.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Object Replication Policy SourceAccount.",
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SourceAccount { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Object Replication Policy DestinationAccount. Default value will be the input StorageAccountName.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Object Replication Policy DestinationAccount. Default value will be the account name of the input account object.",
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DestinationAccount { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Object Replication Policy Rules.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Object Replication Policy Rules.",
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSObjectReplicationPolicyRule[] Rule { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.StorageAccountName, "Set Storage Account Object Replication Policy"))
            {
                ObjectReplicationPolicy policyToSet = null;
                switch (ParameterSetName)
                {
                    case AccountObjectParameterSet:
                        this.ResourceGroupName = StorageAccount.ResourceGroupName;
                        this.StorageAccountName = StorageAccount.StorageAccountName;
                        break;
                    case PolicyObjectParameterSet:
                        this.PolicyId = InputObject.PolicyId;
                        policyToSet = InputObject.ParseObjectReplicationPolicy();
                        break;
                    default:
                        // For AccountNameParameterSet, the ResourceGroupName and StorageAccountName can get from input directly
                        break;
                }

                // Build the policy object to set from the input policy properties
                if (ParameterSetName != PolicyObjectParameterSet)
                {
                    policyToSet = new ObjectReplicationPolicy()
                    {
                        SourceAccount = this.SourceAccount,
                        // If not specify the destination account, will set destination account to the account which the policy will be set to
                        DestinationAccount = string.IsNullOrWhiteSpace(this.DestinationAccount) ? this.StorageAccountName : this.DestinationAccount,
                        Rules = PSObjectReplicationPolicyRule.ParseObjectReplicationPolicyRules(this.Rule)
                    };
                }

                ObjectReplicationPolicy policy = this.StorageClient.ObjectReplicationPolicies.CreateOrUpdate(
                     this.ResourceGroupName,
                     this.StorageAccountName,
                     PolicyId,
                     policyToSet);

                WriteObject(new PSObjectReplicationPolicy(policy, this.ResourceGroupName, this.StorageAccountName));
            }
        }
    }
}
