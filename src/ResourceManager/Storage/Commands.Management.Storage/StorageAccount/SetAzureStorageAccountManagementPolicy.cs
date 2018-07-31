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
using System.Management.Automation;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet(VerbsCommon.Set, StorageAccountManagementPolicyNounStr, SupportsShouldProcess = true, DefaultParameterSetName = AccountNamePolicyStringParameterSet), OutputType(typeof(PSManagementPolicy))]
    public class SetAzureStorageAccountManagementPolicyCommand : StorageAccountBaseCmdlet
    {
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNamePolicyStringParameterSet = "AccountNamePolicyString";

        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNamePolicyObjectParameterSet = "AccountNamePolicyObject";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.",
           ParameterSetName = AccountNamePolicyStringParameterSet)]
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.",
           ParameterSetName = AccountNamePolicyObjectParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
           ParameterSetName = AccountNamePolicyStringParameterSet)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
           ParameterSetName = AccountNamePolicyObjectParameterSet)]
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
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Data Policy Rules.",
           ParameterSetName = AccountNamePolicyStringParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Data Policy Rules.",
           ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Alias("ManagementPolicy")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Management Object to Set",
            ValueFromPipeline = true,
            ParameterSetName = AccountNamePolicyObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagementPolicy InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (ShouldProcess(this.StorageAccountName, "Set Storage Account Management Policy"))
            {
                switch (ParameterSetName)
                {
                    case AccountObjectParameterSet:
                        this.ResourceGroupName = StorageAccount.ResourceGroupName;
                        this.StorageAccountName = StorageAccount.StorageAccountName;
                        break;
                    case AccountNamePolicyObjectParameterSet:
                        this.Policy = InputObject.Policy;
                        break;
                    default:
                        // For AccountNamePolicyStringParameterSet, the ResourceGroupName, StorageAccountName and policy can get from input directly
                        break;
                }

                JObject jsonRules = JObject.Parse(this.Policy);
                StorageAccountManagementPolicies managementPolicy = this.StorageClient.StorageAccounts.CreateOrUpdateManagementPolicies(
                 this.ResourceGroupName,
                 this.StorageAccountName,
                jsonRules);

                WriteObject(new PSManagementPolicy(managementPolicy, this.ResourceGroupName, this.StorageAccountName), true);
            }
        }
    }
}
