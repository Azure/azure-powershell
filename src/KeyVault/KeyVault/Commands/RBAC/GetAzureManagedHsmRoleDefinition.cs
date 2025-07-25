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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + CmdletNoun.KeyVaultRoleDefinition, DefaultParameterSetName = InteractiveParameterSet)]
    [OutputType(typeof(PSKeyVaultRoleDefinition))]
    public class GetAzureManagedHsmRoleDefinition : RbacCmdletBase
    {
        private const string InteractiveParameterSet = "Interactive";
        private const string ByNameParameterSet = "ByName";
        private const string CustomOnlyParameterSet = "CustomOnly";

        [Parameter(Mandatory = true, Position = 1,
            HelpMessage = "Name of the HSM.")]
        [ResourceNameCompleter(ResourceType.ManagedHsm, "IntentionalFakeParameterName")]
        public string HsmName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Scope at which the role assignment or definition applies to, e.g., '/' or '/keys' or '/keys/{keyName}'.")]
        public string Scope { get; set; } = string.Empty;

        [Parameter(Mandatory = true, ParameterSetName = CustomOnlyParameterSet,
            HelpMessage = "If specified, only displays the custom created roles in the directory.")]
        public SwitchParameter Custom { get; set; }

        [Parameter(ParameterSetName = ByNameParameterSet, Mandatory = true,
            HelpMessage = "Name of the role definition to get.")]
        [Alias("RoleName")]
        public string RoleDefinitionName { get; set; }

        public override void ExecuteCmdlet()
        {
            var roleDefinitions = Track2DataClient.GetHsmRoleDefinitions(HsmName, Scope);
            switch (ParameterSetName)
            {
                case InteractiveParameterSet:
                    WriteObject(roleDefinitions, enumerateCollection: true);
                    break;
                case ByNameParameterSet:
                    WriteObject(roleDefinitions.FirstOrDefault(def => string.Equals(RoleDefinitionName, def.RoleName, StringComparison.OrdinalIgnoreCase)));
                    break;
                case CustomOnlyParameterSet:
                    WriteObject(roleDefinitions.Where(def => def.RoleType == PSKeyVaultRoleDefinition.CustomRoleType), enumerateCollection: true);
                    break;
            }
        }
    }
}