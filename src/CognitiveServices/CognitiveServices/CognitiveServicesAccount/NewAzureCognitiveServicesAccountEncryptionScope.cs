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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Create or update a Cognitive Services Account EncryptionScope
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesAccountEncryptionScope", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet), OutputType(typeof(EncryptionScope))]
    public class NewAzureCognitiveServicesAccountEncryptionScopeCommand : CognitiveServicesAccountBaseCmdlet
    {
        private const string DefaultParameterSet = "DefaultParameterSet";
        private const string AccountKeyVaultParameterSet = "AccountKeyVaultParameterSet";
        private const string CognitiveServicesEncryptionParameterSet = "CognitiveServicesEncryptionParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [Parameter(Mandatory = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = AccountKeyVaultParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Name.")]
        [Parameter(Mandatory = true,
            HelpMessage = "Cognitive Services Account Name.",
            ParameterSetName = AccountKeyVaultParameterSet)]
        [Alias(CognitiveServicesAccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services EncryptionScope Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Create encryption scope with keySource as Microsoft.CognitiveServices.",
            ParameterSetName = DefaultParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter CognitiveServicesEncryption { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Create encryption scope with keySource as Microsoft.CognitiveServices.",
            ParameterSetName = AccountKeyVaultParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter KeyVaultEncryption { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Create encryption scope with keySource as Microsoft.Keyvault.",
            ParameterSetName = AccountKeyVaultParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyUri { get; set; }



        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            EncryptionScopeProperties scope = new EncryptionScopeProperties();

            if (this.KeyVaultEncryption.IsPresent)
            {
                scope.KeySource = "Microsoft.KeyVault";
                scope.KeyVaultProperties = new KeyVaultProperties(this.KeyUri);
            }
            else
            {
                scope.KeySource = "Microsoft.CognitiveServices";
            }

            RunCmdLet(() =>
            {
                var createResponse = CognitiveServicesClient.EncryptionScopes.CreateOrUpdate(
                                    ResourceGroupName,
                                    AccountName,
                                    Name,
                                    null,
                                    scope);
                WriteObject(createResponse);
            });
        }
    }
}