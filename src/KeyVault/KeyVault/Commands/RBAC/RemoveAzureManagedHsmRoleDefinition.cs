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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzurePrefix + CmdletNoun.KeyVaultRoleDefinition, SupportsShouldProcess = true, DefaultParameterSetName = ByNameParameterSet)]
    [OutputType(typeof(bool))]
    public class RemoveAzureManagedHsmRoleDefinition : RbacCmdletBase
    {
        private const string ByNameParameterSet = "ByName";
        private const string InputObjectParameterSet = "InputObject";

        [Parameter(Mandatory = true, Position = 1,
            HelpMessage = "Name of the HSM.")]
        [ResourceNameCompleter(ResourceType.ManagedHsm, "IntentionalFakeParameterName")]
        public string HsmName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Scope at which the role assignment or definition applies to, e.g., '/' or '/keys' or '/keys/{keyName}'.")]
        public string Scope { get; set; } = string.Empty;

        [Parameter(ParameterSetName = ByNameParameterSet, Mandatory = true,
            HelpMessage = "Name of the role definition to get.")]
        [Alias("RoleDefinitionName")]
        public string RoleName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.InputObject, HelpMessage = "The object representing the role definition to be removed.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultRoleDefinition InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirm.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "This cmdlet does not return an object by default. If this switch is specified, it returns true if successful.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ByNameParameterSet:
                    var roles = Track2DataClient.GetHsmRoleDefinitions(HsmName, Scope).Where(r => r.RoleName == RoleName);
                    if (roles.Count() > 1)
                    {
                        WriteWarning($"There are more than 1 role definitions with the name {RoleName}. Please use `-InputObject` instead to specify which role to remove.");
                        if (PassThru)
                        {
                            WriteObject(false);
                        }
                        return;
                    }
                    if (!roles.Any())
                    {
                        throw new AzPSArgumentException(
                            $"Could not find any role definition matching the name {RoleName} at scope {Scope}",
                            nameof(RoleName));
                    }
                    InputObject = roles.First();
                    break;
                case InputObjectParameterSet:
                    break;
            }

            ConfirmAction(
                Force,
                $"Removing role definition {InputObject.Name} (RoleName: \"{InputObject.RoleName}\")",
                "Removing role definition",
                InputObject.Name,
                () =>
                {
                    Track2DataClient.RemoveHsmRoleDefinition(HsmName, Scope, InputObject.Name);
                }
            );

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
