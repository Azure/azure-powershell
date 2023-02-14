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

using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Update attribute of a key vault key.
    /// </summary>
    [Alias("Set-" + ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKey", "Set-" + ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyAttribute")]
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKey", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSKeyVaultKey))]
    public class UpdateAzureKeyVaultKey : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string DefaultParameterSet = "Default";
        private const string HsmInteractiveParameterSet = "HsmInteractive";
        private const string InputObjectParameterSet = "InputObject";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = HsmInteractiveParameterSet,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

        /// <summary>
        /// key name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = HsmInteractiveParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        public string Name { get; set; }

        /// <summary>
        /// key object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Key object")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultKeyIdentityItem InputObject { get; set; }

        /// <summary>
        /// Key version.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 2,
            HelpMessage = "Key version. Cmdlet constructs the FQDN of a key from vault name, currently selected environment, key name and key version.")]
        [Alias("KeyVersion")]
        public string Version { get; set; }

        /// <summary>
        /// If present, enable a key if value is true.
        /// Disable a key if value is false.
        /// If not present, no change on current key enabled/disabled state.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Value of true enables the key and a value of false disabless the key. If not specified, the existing enabled/disabled state remains unchanged.")]
        public bool? Enable { get; set; }

        /// <summary>
        /// Key expires time in UTC time
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The expiration time of a key in UTC time. If not specified, the existing expiration time of the key remains unchanged.")]
        public DateTime? Expires { get; set; }

        /// <summary>
        /// The UTC time before which key can't be used
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The UTC time before which key can't be used. If not specified, the existing NotBefore attribute of the key remains unchanged.")]
        public DateTime? NotBefore { get; set; }

        /// <summary>
        /// Key operations
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The operations that can be performed with the key. If not specified, the existing key operations of the key remain unchanged.")]
        public string[] KeyOps { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = HsmInteractiveParameterSet,
            HelpMessage = "Sets the release policy as immutable state. Once marked immutable, this flag cannot be reset and the policy cannot be changed under any circumstances.")]
        public SwitchParameter Immutable { get; set; }

        /// <summary>
        /// A path to the release policy file that contains JSON policy definition. The policy rules under which a key can be exported.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = HsmInteractiveParameterSet,
            HelpMessage = "A path to the release policy file that contains JSON policy definition. The policy rules under which a key can be exported.")]
        public string ReleasePolicyPath { get; set; }


        [Parameter(Mandatory = false,
            HelpMessage = "A hashtable represents key tags. If not specified, the existings tags of the key remain unchanged.")]
        [Alias(Constants.TagsAlias)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Cmdlet does not return an object by default. If this switch is specified, returns the updated key bundle object.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();
            ValidateParameters();

            if (ShouldProcess(Name, Properties.Resources.SetKeyAttribute))
            {
                PSKeyVaultKey keyBundle;
                if (string.IsNullOrEmpty(HsmName))
                {
                    keyBundle = DataServiceClient.UpdateKey(
                        VaultName,
                        Name,
                        Version ?? string.Empty,
                        new PSKeyVaultKeyAttributes(Enable, Expires, NotBefore, null, KeyOps, Tag));
                }
                else
                {
                    keyBundle = this.Track2DataClient.UpdateManagedHsmKey(
                        HsmName,
                        Name,
                        Version,
                        new PSKeyVaultKeyAttributes(Enable, Expires, NotBefore, null, KeyOps, Tag)
                        {
                            ReleasePolicy = this.IsParameterBound(c => c.ReleasePolicyPath) && File.Exists(this.ReleasePolicyPath) ? 
                                new PSKeyReleasePolicy(this.ReleasePolicyPath) 
                                {
                                    Immutable = this.Immutable.IsPresent ? (true as bool?) : null
                                } : null,                            
                        });
                }

                if (PassThru)
                {
                    WriteObject(keyBundle);
                }
            }
        }

        private void ValidateParameters()
        {
            if (this.IsParameterBound(c => c.Immutable) && !this.IsParameterBound(c => c.ReleasePolicyPath))
            {
                throw new AzPSArgumentException("Please provide release policy when Immutable is present.", nameof(Immutable), ErrorKind.UserError);
            }

            if (this.IsParameterBound(c => c.ReleasePolicyPath) && !File.Exists(ReleasePolicyPath))
            {
                throw new AzPSArgumentException(string.Format(Resources.FileNotFound, this.ReleasePolicyPath), nameof(ReleasePolicyPath));
            }
        }

        private void NormalizeParameterSets()
        {
            if (InputObject != null)
            {
                if (InputObject.IsHsm)
                {
                    HsmName = InputObject.VaultName;
                }
                else
                {
                    VaultName = InputObject.VaultName;
                }
                Name = InputObject.Name;
                Version = InputObject.Version;
            }
        }
    }
}
