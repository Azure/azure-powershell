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
using System.Collections;
using System.Management.Automation;
using System.Xml;
using Microsoft.Azure.Commands.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet( VerbsCommon.Set, CmdletNoun.AzureKeyVaultManagedStorageSasDefinition,
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType( typeof( PSKeyVaultManagedStorageSasDefinition ) )]
    public class SetAzureKeyVaultManagedStorageSasDefinition : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string DefaultParameterSet = "Default";
        private const string ByInputObjectParameterSet = "ByInputObject";

        #endregion

        #region Input Parameter Definitions
        [Parameter( Mandatory = true,
            Position = 0,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment." )]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter( Mandatory = true,
            Position = 1,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Key Vault managed storage account name. Cmdlet constructs the FQDN of a managed storage account name from vault name, currently " +
                          "selected environment and manged storage account name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.StorageAccountName )]
        public string AccountName { get; set; }

        /// <summary>
        /// PSKeyVaultManagedStorageAccountIdentityItem object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "ManagedStorageAccount object.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultManagedStorageAccountIdentityItem InputObject { get; set; }

        [Parameter( Mandatory = true,
            Position = 2,
            HelpMessage = "Storage sas definition name. Cmdlet constructs the FQDN of a storage sas definition from vault name, currently " +
                          "selected environment, storage account name and sas definition name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.SasDefinitionName )]
        public string Name { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter( Mandatory = true,
            Position = 3,
            HelpMessage = "Storage SAS definition template uri.")]
        public string TemplateUri { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter( Mandatory = true,
            Position = 4,
            HelpMessage = "Storage SAS type.")]
        public string SasType { get; set; }

        [Parameter( Mandatory = false,
            HelpMessage = "Disables the use of sas definition for generation of sas token." )]
        public SwitchParameter Disable { get; set; }

        [Parameter( Mandatory = false,
            HelpMessage = "A hashtable representing tags of sas definition." )]
        [Alias( Constants.TagsAlias )]
        public Hashtable Tag { get; set; }

        private const string ValidityPeriodHelpMessage = "Validity period that will get used to set the expiry time of sas token from the time it gets generated";
        [Parameter( Mandatory = true,
            HelpMessage = ValidityPeriodHelpMessage)]
        [ValidateNotNull]
        public TimeSpan? ValidityPeriod { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                AccountName = InputObject.AccountName;
            }

            if ( ShouldProcess( Name, Properties.Resources.SetManagedStorageSasDefinition ) )
            {
                var sasDefinition = DataServiceClient.SetManagedStorageSasDefinition( 
                    VaultName,
                    AccountName,
                    Name, 
                    TemplateUri, 
                    SasType,
                    XmlConvert.ToString(ValidityPeriod.Value), 
                    new PSKeyVaultManagedStorageSasDefinitionAttributes( !Disable.IsPresent ),
                    Tag );

                WriteObject( sasDefinition );
            }
        }
    }
}
