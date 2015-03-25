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

using System;
using System.Linq;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureKeyVaultKey",
        DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(List<KeyIdentityItem>), typeof(KeyBundle))]
    public class GetAzureKeyVaultKey : KeyVaultCmdletBase
    {

        #region Parameter Set Names

        private const string ByKeyNameParameterSet = "ByKeyName";
        private const string ByVaultNameParameterSet = "ByVaultName";

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

        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Key name.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByKeyNameParameterSet,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [ValidateNotNullOrEmpty]
        [Alias("KeyName")]
        public string Name { get; set; }

        /// <summary>
        /// Key version.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByKeyNameParameterSet,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "key version. Cmdlet constructs the FQDN of a key from vault name, currently selected environment, key name and key version.")]
        [ValidateNotNullOrEmpty]
        [Alias("KeyVersion")]
        public string Version { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ByKeyNameParameterSet:
                    var keyBundle = DataServiceClient.GetKey(VaultName, Name, Version);
                    WriteObject(keyBundle);
                    break;

                case ByVaultNameParameterSet:
                    IEnumerable<KeyIdentityItem> keyBundles = DataServiceClient.GetKeys(VaultName);
                    WriteObject(keyBundles, true);
                    break;

                default:
                    throw new ArgumentException(Resources.BadParameterSetName);
            }
        }
    }
}
