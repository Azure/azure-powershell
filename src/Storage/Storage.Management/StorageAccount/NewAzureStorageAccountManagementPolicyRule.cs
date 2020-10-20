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

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccountManagementPolicyRule"), OutputType(typeof(PSManagementPolicyRule))]
    public class NewAzureStorageAccountManagementPolicyRuleCommand : StorageAccountBaseCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The rule is disabled if set it.")]
        public SwitchParameter Disabled { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "An object that defines the action set. Get the Object with cmdlet Add-AzureStorageAccountManagementPolicyAction",
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSManagementPolicyActionGroup Action { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "An object that defines the filter set. Get the Object with cmdlet New-AzureStorageAccountManagementPolicyFilter",
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSManagementPolicyRuleFilter Filter { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            PSManagementPolicyRule rule = new PSManagementPolicyRule()
            {
                Name = this.Name,
                Enabled = Disabled.IsPresent ? false : true,
                Definition = new PSManagementPolicyDefinition()
                {
                    Actions = this.Action,
                    Filters = this.Filter
                }
            };

            WriteObject(rule);
        }
    }
}
