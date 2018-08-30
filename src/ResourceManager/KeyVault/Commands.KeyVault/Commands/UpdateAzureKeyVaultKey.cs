﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Update attribute of a key vault key.
    /// </summary>
    [Alias("Set-" + ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKey", "Set-" + ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyAttribute")]
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKey",SupportsShouldProcess = true,DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSKeyVaultKey))]
    public class UpdateAzureKeyVaultKey : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string DefaultParameterSet = "Default";
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
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// key name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
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
           HelpMessage = "A hashtable represents key tags. If not specified, the existings tags of the key remain unchanged.")]
        [Alias(Constants.TagsAlias)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false,
           HelpMessage = "Cmdlet does not return an object by default. If this switch is specified, returns the updated key bundle object.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                Name = InputObject.Name;
            }

            if (ShouldProcess(Name, Properties.Resources.SetKeyAttribute))
            {
                var keyBundle = DataServiceClient.UpdateKey(
                VaultName,
                Name,
                Version ?? string.Empty,
                new PSKeyVaultKeyAttributes(Enable, Expires, NotBefore, null, KeyOps, Tag));

                if (PassThru)
                {
                    WriteObject(keyBundle);
                }
            }
        }
    }
}
