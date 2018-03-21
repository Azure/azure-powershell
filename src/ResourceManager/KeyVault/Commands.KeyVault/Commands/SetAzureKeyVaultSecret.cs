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
using System;
using System.Collections;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsCommon.Set, "AzureKeyVaultSecret",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultAttributeParameterSet)]
    [Alias("Set-AzureKeyVaultSecretAttribute")]
    [OutputType(typeof(PSKeyVaultSecret))]
    public class SetAzureKeyVaultSecret : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string DefaultParameterSet = "Default";
        private const string InputObjectParameterSet = "InputObject";
        private const string DefaultAttributeParameterSet = "DefaultAttribute";
        private const string InputObjectAttributeParameterSet = "InputObjectAttribute";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = DefaultAttributeParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Secret name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = DefaultAttributeParameterSet,
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.SecretName)]
        public string Name { get; set; }

        /// <summary>
        /// Secret object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Secret object")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectAttributeParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Secret object")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultSecretIdentityItem InputObject { get; set; }

        /// <summary>
        /// Secret value
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 2,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Secret value")]
        [Parameter(Mandatory = true,
            Position = 2,
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "Secret value")]
        public SecureString SecretValue { get; set; }

        /// <summary>
        /// Set secret in disabled state if present       
        /// </summary>        
        [Parameter(Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Set secret in disabled state if present. If not specified, the secret is enabled.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "Set secret in disabled state if present. If not specified, the secret is enabled.")]
        public SwitchParameter Disable { get; set; }

        /// <summary>
        /// Key version.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 2,
            ParameterSetName = DefaultAttributeParameterSet,
            HelpMessage = "Secret version. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment, secret name and secret version.")]
        [Parameter(Mandatory = false,
            Position = 2,
            ParameterSetName = InputObjectAttributeParameterSet,
            HelpMessage = "Secret version. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment, secret name and secret version.")]
        [Alias("SecretVersion")]
        public string Version { get; set; }

        /// <summary>
        /// If present, enable a secret if value is true. 
        /// Disable a secret if value is false.
        /// If not present, no change on current secret enabled/disabled state.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = DefaultAttributeParameterSet,
            HelpMessage = "If present, enable a secret if value is true. Disable a secret if value is false. If not specified, the existing value of the secret's enabled/disabled state remains unchanged.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectAttributeParameterSet,
            HelpMessage = "If present, enable a secret if value is true. Disable a secret if value is false. If not specified, the existing value of the secret's enabled/disabled state remains unchanged.")]
        public bool? Enable { get; set; }

        /// <summary>
        /// Secret expires time in UTC time
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The expiration time of a secret in UTC time. If not specified, the secret will not expire.")]
        public DateTime? Expires { get; set; }

        /// <summary>
        /// The UTC time before which secret can't be used 
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The UTC time before which secret can't be used. If not specified, there is no limitation.")]
        public DateTime? NotBefore { get; set; }

        /// <summary>
        /// Content type
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Secret's content type.")]
        public string ContentType { get; set; }

        /// <summary>
        /// Secret tags
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "A hashtable representing secret tags.")]
        [Alias(Constants.TagsAlias)]
        public Hashtable Tag { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                Name = InputObject.Name;
            }

            if (MyInvocation.BoundParameters.ContainsKey("SecretValue"))
            {
                if (ShouldProcess(Name, Properties.Resources.SetSecret))
                {
                    var secret = DataServiceClient.SetSecret(
                    VaultName,
                    Name,
                    SecretValue,
                    new PSKeyVaultSecretAttributes(!Disable.IsPresent, Expires, NotBefore, ContentType, Tag));
                    WriteObject(secret);
                }
            }
            else
            {
                if (ShouldProcess(Name, Properties.Resources.SetSecretAttribute))
                {
                    var secret = DataServiceClient.UpdateSecret(
                    VaultName,
                    Name,
                    Version ?? string.Empty,
                    new PSKeyVaultSecretAttributes(Enable, Expires, NotBefore, ContentType, Tag));
                    WriteObject(secret);
                }
            }
        }
    }
}
