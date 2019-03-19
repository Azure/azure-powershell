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
using System.Globalization;
using System.Collections.Generic;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccountManagementPolicy", SupportsShouldProcess = true, DefaultParameterSetName = AccountNamePolicyRuleParameterSet), OutputType(typeof(PSManagementPolicy))]
    public class SetAzureStorageAccountManagementPolicyCommand : StorageAccountBaseCmdlet
    {
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNamePolicyRuleParameterSet = "AccountNamePolicyRule";

        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNamePolicyObjectParameterSet = "AccountNamePolicyObject";

        /// <summary>
        /// Account object PolicyRules parameter set 
        /// </summary>
        private const string AccountObjectPolicyRuleParameterSet = "AccountObjectPolicyRule";

        /// <summary>
        /// Account object Policy Object parameter set 
        /// </summary>
        private const string AccountObjectPolicyObjectParameterSet = "AccountObjectPolicyObject";

        /// <summary>
        /// Account ResourceId PolicyRules parameter set 
        /// </summary>
        private const string AccountResourceIdPolicyRuleParameterSet = "AccountResourceIdPolicyRule";

        /// <summary>
        /// Account ResourceId Policy Object parameter set 
        /// </summary>
        private const string AccountResourceIdPolicyObjectParameterSet = "AccountResourceIdPolicyObject";

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.",
           ParameterSetName = AccountNamePolicyRuleParameterSet)]       
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
           ParameterSetName = AccountNamePolicyRuleParameterSet)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
           ParameterSetName = AccountNamePolicyObjectParameterSet)]
        [ResourceNameCompleter("Microsoft.Storage/storageAccounts", nameof(ResourceGroupName))]
        [Alias(AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectPolicyRuleParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectPolicyObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Resource Id.",
           ParameterSetName = AccountResourceIdPolicyRuleParameterSet)]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Resource Id.",
           ParameterSetName = AccountResourceIdPolicyObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Management Policy rules. Get the object with New-AzStorageAccountManagementPolicyRule cmdlet.",
           ParameterSetName = AccountNamePolicyRuleParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Management Policy rules. Get the object with New-AzStorageAccountManagementPolicyRule cmdlet.",
           ParameterSetName = AccountObjectPolicyRuleParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Management Policy rules. Get the object with New-AzStorageAccountManagementPolicyRule cmdlet.",
           ParameterSetName = AccountResourceIdPolicyRuleParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagementPolicyRule[] Rule { get; set; }

        [Alias("ManagementPolicy")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Management Policy Object to Set",
            ValueFromPipeline = true,
            ParameterSetName = AccountNamePolicyObjectParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Management Policy Object to Set",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectPolicyObjectParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Management Policy Object to Set",
            ValueFromPipeline = true,
            ParameterSetName = AccountResourceIdPolicyObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSManagementPolicy Policy { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (ShouldProcess(this.StorageAccountName, "Set Storage Account Management Policy"))
            {
                if ((this.ParameterSetName == AccountObjectPolicyRuleParameterSet) 
                    || (this.ParameterSetName == AccountObjectPolicyObjectParameterSet))
                {
                    this.ResourceGroupName = StorageAccount.ResourceGroupName;
                    this.StorageAccountName = StorageAccount.StorageAccountName;
                }
                else if ((this.ParameterSetName == AccountResourceIdPolicyRuleParameterSet)
                    || (this.ParameterSetName == AccountResourceIdPolicyObjectParameterSet))
                {
                    ResourceIdentifier accountResource = new ResourceIdentifier(StorageAccountResourceId);
                    this.ResourceGroupName = accountResource.ResourceGroupName;
                    this.StorageAccountName = accountResource.ResourceName;
                }
                ManagementPolicy managementPolicy;

                switch (this.ParameterSetName)
                {
                    case AccountObjectPolicyRuleParameterSet:
                    case AccountNamePolicyRuleParameterSet:
                    case AccountResourceIdPolicyRuleParameterSet:
                        managementPolicy = this.StorageClient.ManagementPolicies.CreateOrUpdate(
                            this.ResourceGroupName,
                            this.StorageAccountName,
                            new ManagementPolicySchema(
                                //this.version,
                                PSManagementPolicyRule.ParseManagementPolicyRules(this.Rule)));
                        break;
                    case AccountObjectPolicyObjectParameterSet:
                    case AccountNamePolicyObjectParameterSet:
                    case AccountResourceIdPolicyObjectParameterSet:
                        managementPolicy = this.StorageClient.ManagementPolicies.CreateOrUpdate(
                            this.ResourceGroupName,
                            this.StorageAccountName,
                            new ManagementPolicySchema(
                                //this.Policy.Version,
                                PSManagementPolicyRule.ParseManagementPolicyRules(this.Policy.Rules)));
                        break;
                    default:
                        throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ParameterSet: {0}", this.ParameterSetName));
                }

                WriteObject(new PSManagementPolicy(managementPolicy, this.ResourceGroupName, this.StorageAccountName), true);
            }
        }
    }
}
