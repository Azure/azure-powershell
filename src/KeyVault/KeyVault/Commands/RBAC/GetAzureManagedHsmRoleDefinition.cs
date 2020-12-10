using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + CmdletNoun.ManagedHsmRoleDefinition, DefaultParameterSetName = InteractiveCreateParameterSet)]
    [OutputType(typeof(PSKeyVaultRoleDefinition))]
    public class GetAzureManagedHsmRoleDefinition : RbacCmdletBase
    {
        private const string InteractiveCreateParameterSet = "Interactive";
        private const string ByNameParameterSet = "ByName";

        [Parameter(Mandatory = true, Position = 1,
            HelpMessage = "Name of the HSM.")]
        [ResourceNameCompleter(ResourceType.ManagedHsm, "IntentionalFakeParameterName")]
        public string HsmName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Scope at which the role assignment or definition applies to, e.g., '/' or '/keys' or '/keys/{keyName}'.")]
        public string Scope { get; set; } = string.Empty;

        [Parameter(ParameterSetName = ByNameParameterSet, Mandatory = true,
            HelpMessage = "Name of the role definition to get.")]
        [Alias("RoleName")]
        public string RoleDefinitionName { get; set; }

        public override void ExecuteCmdlet()
        {
            var roleDefinitions = Track2DataClient.GetHsmRoleDefinitions(HsmName, Scope);
            switch (ParameterSetName)
            {
                case InteractiveCreateParameterSet:
                    WriteObject(roleDefinitions, enumerateCollection: true);
                    break;
                case ByNameParameterSet:
                    WriteObject(roleDefinitions.FirstOrDefault(def => string.Equals(RoleDefinitionName, def.RoleName, StringComparison.OrdinalIgnoreCase)));
                    break;
            }
        }
    }
}