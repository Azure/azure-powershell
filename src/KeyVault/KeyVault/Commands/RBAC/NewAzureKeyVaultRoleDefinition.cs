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
using Newtonsoft.Json;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzurePrefix + CmdletNoun.KeyVaultRoleDefinition, DefaultParameterSetName = InputObjectParameterSet, SupportsShouldProcess = true)]
    [Alias("Set-" + ResourceManager.Common.AzureRMConstants.AzurePrefix + CmdletNoun.KeyVaultRoleDefinition)]
    [OutputType(typeof(PSKeyVaultRoleDefinition))]
    public class NewAzureKeyVaultRoleDefinition : RbacCmdletBase
    {
        private const string InputObjectParameterSet = "InputObject";
        private const string InputFileParameterSet = "InputFile";

        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Name of the HSM.")]
        [ResourceNameCompleter(ResourceType.ManagedHsm, "IntentionalFakeParameterName")]
        public string HsmName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Scope at which the role assignment or definition applies to, e.g., '/' or '/keys' or '/keys/{keyName}'. '/' is used when omitted.")]
        public string Scope { get; set; } = "/";

        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = InputObjectParameterSet, Mandatory = true, Position = 2, HelpMessage = "A role definition object.")]
        public PSKeyVaultRoleDefinition Role { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = InputFileParameterSet, Mandatory = true, Position = 2, HelpMessage = "File name containing a single role definition.")]
        public string InputFile { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == InputFileParameterSet)
            {
                string fileName = this.TryResolvePath(InputFile);
                if (!(new FileInfo(fileName)).Exists)
                {
                    throw new AzPSArgumentException(string.Format("File {0} does not exist", fileName), nameof(InputFile));
                }

                try
                {
                    Role = JsonConvert.DeserializeObject<PSKeyVaultRoleDefinition>(File.ReadAllText(fileName));
                }
                catch (JsonException)
                {
                    WriteVerbose("Failed to deserialize the input role definition file.");
                    throw;
                }
            }
            base.ConfirmAction(
                "Creating custom role",
                HsmName, () =>
            {
                WriteObject(Track2DataClient.CreateOrUpdateHsmRoleDefinition(HsmName, Scope, Role));
            });
        }
    }
}
