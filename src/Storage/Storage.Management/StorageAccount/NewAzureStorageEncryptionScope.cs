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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageEncryptionScope", DefaultParameterSetName = AccountNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSEncryptionScope))]
    public class NewAzureStorageEncryptionScopeCommand : StorageFileBaseCmdlet
    {
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameParameterSet = "AccountName";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";

        /// <summary>
        /// AccountName KeyVault Parameter Set
        /// </summary>
        private const string AccountNameKeyVaultParameterSet = "AccountNameKeyVault";

        /// <summary>
        /// Account object KeyVault parameter set 
        /// </summary>
        private const string AccountObjectKeyVaultParameterSet = "AccountObjectKeyVault";

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = AccountNameKeyVaultParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
            ParameterSetName = AccountNameKeyVaultParameterSet)]
        [Alias(AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectKeyVaultParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Alias("Name")]
        [Parameter(Mandatory = true, 
            HelpMessage = "Azure Storage EncryptionScope name")]
        [ValidateNotNullOrEmpty]
        public string EncryptionScopeName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Create encryption scope with keySource as Microsoft.Storage.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Create encryption scope with keySource as Microsoft.Storage.",
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter StorageEncryption { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Create encryption scope with keySource as Microsoft.Keyvault",
            ParameterSetName = AccountNameKeyVaultParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Create encryption scope with keySource as Microsoft.Keyvault",
            ParameterSetName = AccountObjectKeyVaultParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter KeyvaultEncryption { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The key Uri ",
            ParameterSetName = AccountNameKeyVaultParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Create encryption scope with keySource as Microsoft.Keyvault",
            ParameterSetName = AccountObjectKeyVaultParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyUri { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The encryption scope will apply a secondary layer of encryption with platform managed keys for data at rest.")]
        public SwitchParameter RequireInfrastructureEncryption { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.EncryptionScopeName, "Create Encryption scope"))
            {
                switch (ParameterSetName)
                {
                    case AccountObjectParameterSet:
                    case AccountObjectKeyVaultParameterSet:
                        this.ResourceGroupName = StorageAccount.ResourceGroupName;
                        this.StorageAccountName = StorageAccount.StorageAccountName;
                        break;
                    default:
                        // For AccountNameParameterSet, the ResourceGroupName and StorageAccountName can get from input directly
                        break;
                }

                EncryptionScope scope = new EncryptionScope();
                if (this.KeyvaultEncryption.IsPresent)
                {
                    scope.Source = EncryptionScopeSource.MicrosoftKeyVault;
                    scope.KeyVaultProperties = new EncryptionScopeKeyVaultProperties(this.KeyUri);
                }
                else
                {
                    scope.Source = EncryptionScopeSource.MicrosoftStorage;
                }
                if (this.RequireInfrastructureEncryption.IsPresent)
                {
                    scope.RequireInfrastructureEncryption = true;
                }

                scope = this.StorageClient.EncryptionScopes.Put(
                            this.ResourceGroupName,
                            this.StorageAccountName,
                            this.EncryptionScopeName,
                            scope);

                WriteObject(new PSEncryptionScope(scope));
            }
        }
    }
}
