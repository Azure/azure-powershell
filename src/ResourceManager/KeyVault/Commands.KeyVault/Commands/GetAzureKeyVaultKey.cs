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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsCommon.Get, "AzureKeyVaultKey",        
        DefaultParameterSetName = ByVaultNameParameterSet,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(List<KeyIdentityItem>), typeof(KeyBundle))]
    public class GetAzureKeyVaultKey : KeyVaultCmdletBase
    {

        #region Parameter Set Names

        private const string ByKeyNameParameterSet = "ByKeyName";
        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string ByKeyVersionsParameterSet = "ByKeyVersions";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByKeyNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByKeyVersionsParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]

        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Key name.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyNameParameterSet,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyVersionsParameterSet,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        public string Name { get; set; }

        /// <summary>
        /// Key version.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByKeyNameParameterSet,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key version. Cmdlet constructs the FQDN of a key from vault name, currently selected environment, key name and key version.")]
        [Alias("KeyVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the key in the output.")]
        public SwitchParameter IncludeVersions { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            KeyBundle keyBundle;
            switch (ParameterSetName)
            {
                case ByKeyNameParameterSet:                    
                    keyBundle = DataServiceClient.GetKey(VaultName, Name, Version ?? string.Empty);
                    WriteObject(keyBundle);
                    break;
                case ByKeyVersionsParameterSet:
                    keyBundle = DataServiceClient.GetKey(VaultName, Name, string.Empty);
                    if (keyBundle != null)
                    {
                        WriteObject(new KeyIdentityItem(keyBundle));
                        GetAndWriteKeyVersions(VaultName, Name, keyBundle.Version);
                    }
                    break;
                case ByVaultNameParameterSet:
                    GetAndWriteKeys(VaultName);
                    break;

                default:
                    throw new ArgumentException(KeyVaultProperties.Resources.BadParameterSetName);
            }
        }

        private void GetAndWriteKeys(string vaultName)
        {
            KeyVaultObjectFilterOptions options = new KeyVaultObjectFilterOptions
            {
                VaultName = vaultName,
                NextLink = null
            };

            do
            {
                var pageResults = DataServiceClient.GetKeys(options);
                WriteObject(pageResults, true);
            } while (!string.IsNullOrEmpty(options.NextLink));
        }

        private void GetAndWriteKeyVersions(string vaultName, string name, string currentKeyVersion)
        {
            KeyVaultObjectFilterOptions options = new KeyVaultObjectFilterOptions
            {
                VaultName = vaultName,
                NextLink = null,
                Name = name
            };

            do
            {
                var pageResults = DataServiceClient.GetKeyVersions(options).Where(k => k.Version != currentKeyVersion);
                WriteObject(pageResults, true);
            } while (!string.IsNullOrEmpty(options.NextLink));
        }
    }
}
