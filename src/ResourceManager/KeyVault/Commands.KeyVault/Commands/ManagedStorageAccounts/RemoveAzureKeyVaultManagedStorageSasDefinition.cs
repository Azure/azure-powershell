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
using System.Globalization;
using System.Management.Automation;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultManagedStorageSasDefinition",DefaultParameterSetName = ByDefinitionNameParameterSet, SupportsShouldProcess = true)]
    [OutputType( typeof( PSDeletedKeyVaultManagedStorageSasDefinition ) )]
    public class RemoveAzureKeyVaultSasDefinition : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByDefinitionNameParameterSet = "ByDefinitionName";
        private const string ByInputObjectParameterSet = "ByInputObject";

        #endregion

        #region Input Parameter Definitions
        [Parameter( Mandatory = true,
            Position = 0,
            ParameterSetName = ByDefinitionNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment." )]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter( Mandatory = true,
            Position = 1,
            ParameterSetName = ByDefinitionNameParameterSet,
            HelpMessage = "Key Vault managed storage account name. Cmdlet constructs the FQDN of a managed storage account name from vault name, currently " +
                          "selected environment and manged storage account name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.StorageAccountName )]
        public string AccountName { get; set; }

        [Parameter( Mandatory = true,
            Position = 2,
            ParameterSetName = ByDefinitionNameParameterSet,
            HelpMessage = "Storage sas definition name. Cmdlet constructs the FQDN of a storage sas definition from vault name, currently " +
                          "selected environment, storage account name and sas definition name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.SasDefinitionName )]
        public string Name { get; set; }

        /// <summary>
        /// PSKeyVaultManagedStorageSasDefinitionIdentityItem object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "ManagedStorageSasDefinition object.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultManagedStorageSasDefinitionIdentityItem InputObject { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter( Mandatory = false,
            HelpMessage = "Do not ask for confirmation." )]
        public SwitchParameter Force { get; set; }

        [Parameter( Mandatory = false,
            HelpMessage = "Cmdlet does not return an object by default. If this switch is specified, cmdlet returns the sas definition that was deleted." )]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                AccountName = InputObject.AccountName;
                Name = InputObject.Name;
            }

            PSDeletedKeyVaultManagedStorageSasDefinition managedStorageSasDefinition = null;
            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    KeyVaultProperties.Resources.RemoveManagedStorageSasDefinitionWarning,
                    Name ),
                string.Format(
                    CultureInfo.InvariantCulture,
                    KeyVaultProperties.Resources.RemoveManagedStorageSasDefinitionWhatIfMessage,
                    Name ),
                Name,
               () => { managedStorageSasDefinition = DataServiceClient.DeleteManagedStorageSasDefinition( VaultName, AccountName, Name ); } );

            if( PassThru )
            {
                WriteObject( managedStorageSasDefinition );
            }
        }
    }
}
