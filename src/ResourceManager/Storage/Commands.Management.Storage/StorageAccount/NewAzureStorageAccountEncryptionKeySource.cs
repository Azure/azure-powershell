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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using StorageModels = Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Commands.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    /// <summary>
    /// Create PSKeySource Object which will be used in Set-AzureRmStorageAccount as keysource
    /// </summary>
    [Cmdlet(VerbsCommon.New, StorageAccountKeySourceStr, SupportsShouldProcess = false), OutputType(typeof(PSKeySource))]
    public class NewAzureStorageEncryptionKeySourceCommand : StorageAccountBaseCmdlet
    {

        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string StorageParameterSet = "StorageKeySourceInstance";

        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string KeyVaultParameterSet = "KeyVaultKeySourceInstance";

        [Parameter(Position = 0, HelpMessage = "Storage Account encryption keySource Type", Mandatory = true, ParameterSetName = StorageParameterSet)]
        [Parameter(Position = 0, HelpMessage = "Storage Account encryption keySource Type", Mandatory = true, ParameterSetName = KeyVaultParameterSet)]
        [ValidateNotNullOrEmpty]
        public PsKeySourceTypeEnum Type { get; set; }


        [Parameter(HelpMessage = "Storage Account encryption keySource KeyVault KeyName",
            Mandatory = true,
            ParameterSetName = KeyVaultParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(HelpMessage = "Storage Account encryption keySource KeyVault KeyVersion",
            Mandatory = true,
            ParameterSetName = KeyVaultParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyVersion { get; set; }

        [Parameter(HelpMessage = "Storage Account encryption keySource KeyVault KeyVaultUri",
            Mandatory = true,
            ParameterSetName = KeyVaultParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyVaultUri { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            PSKeySource keySource = new PSKeySource();

            if (ParameterSetName == StorageParameterSet)
            {
                if (Type != PsKeySourceTypeEnum.MicrosoftStorage)
                    throw new System.ArgumentException("KeySource Type \"MicrosoftStorage\" must be choosed when not specify KeyName, KeyVersion, KeyVaultUri.");
                keySource.KeySource = Type;
            }
            else
            {
                if (Type != PsKeySourceTypeEnum.MicrosoftKeyvault)
                    throw new System.ArgumentException("KeySource Type \"MicrosoftKeyVault\" must be choosed when specify KeyName, KeyVersion, KeyVaultUri.");
                keySource.KeySource = Type;
                keySource.Keyvaultproperties.Keyname = KeyName;
                keySource.Keyvaultproperties.KeyVersion = KeyVersion;
                keySource.Keyvaultproperties.KeyVaultUri = KeyVaultUri;
            }

            this.WriteObject(keySource);
        }
    }
}
