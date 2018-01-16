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

using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.New, "AzureRmDataLakeStoreAccount", DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(PSDataLakeStoreAccount))]
    [Alias("New-AdlStore")]
    public class NewAzureDataLakeStoreAccount : DataLakeStoreCmdletBase
    {
        internal const string BaseParameterSetName = "UserOrSystemAssignedEncryption";
        internal const string  EncryptionDisabledParameterSetName = "DisableEncryption";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of resource group under which you want to create the account.",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of resource group under which you want to create the account.",
            ParameterSetName = EncryptionDisabledParameterSetName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "Name of the account to create.",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "Name of the account to create.",
            ParameterSetName = EncryptionDisabledParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "Azure region where the account should be created.",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = true,
            HelpMessage = "Azure region where the account should be created.",
            ParameterSetName = EncryptionDisabledParameterSetName)]
        [LocationCompleter("Microsoft.DataLakeStore/accounts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage =
                "Name of the default group to give permissions to for freshly created files and folders in the DataLakeStore.",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage =
                "Name of the default group to give permissions to for freshly created files and folders in the DataLakeStore.",
            ParameterSetName = EncryptionDisabledParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string DefaultGroup { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "A string,string dictionary of tags associated with this account",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "A string,string dictionary of tags associated with this account",
            ParameterSetName = EncryptionDisabledParameterSetName)]
        [Obsolete("New-AzureRmDataLakeStoreAccount: -Tags will be removed in favor of -Tag in an upcoming breaking change release.  Please start using the -Tag parameter to avoid breaking scripts.")]
        [Alias("Tags")]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage = "Indicates what type of encryption to provision the account with. By default, encryption is ServiceManaged. If no encryption is desired, it must be explicitly set with the -DisableEncryption flag",
            ParameterSetName = BaseParameterSetName)]
        [ValidateNotNull]
        public EncryptionConfigType? Encryption { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage = "Indicates that the account will not have any form of encryption applied to it.",
            ParameterSetName = EncryptionDisabledParameterSetName)]
        [ValidateNotNull]
        public SwitchParameter DisableEncryption { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 6, Mandatory = false,
            HelpMessage = "If the encryption type is User assigned, this is the key vault the user wishes to use",
            ParameterSetName = BaseParameterSetName)]
        [ValidateNotNull]
        public string KeyVaultId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 7, Mandatory = false,
            HelpMessage = "If the encryption type is User assigned, this is the key name in the key vault the user wishes to use",
            ParameterSetName = BaseParameterSetName)]
        [ValidateNotNull]
        public string KeyName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 8, Mandatory = false,
            HelpMessage = "If the encryption type is User assigned, this is the key version of the key the user wishes to use",
            ParameterSetName = BaseParameterSetName)]
        [ValidateNotNull]
        public string KeyVersion { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The desired commitment tier for this account to use.",
            ParameterSetName = BaseParameterSetName)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The desired commitment tier for this account to use.",
            ParameterSetName = EncryptionDisabledParameterSetName)]
        [ValidateNotNull]
        public TierType? Tier { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (DataLakeStoreClient.GetAccount(ResourceGroupName, Name) != null)
                {
                    throw new CloudException(string.Format(Resources.DataLakeStoreAccountExists, Name));
                }
            }
            catch (CloudException ex)
            {
                if (ex.Body != null && !string.IsNullOrEmpty(ex.Body.Code) && ex.Body.Code == "ResourceNotFound" ||
                    ex.Message.Contains("ResourceNotFound"))
                {
                    // account does not exists so go ahead and create one
                }
                else if (ex.Body != null && !string.IsNullOrEmpty(ex.Body.Code) &&
                         ex.Body.Code == "ResourceGroupNotFound" || ex.Message.Contains("ResourceGroupNotFound"))
                {
                    // resource group not found, let create throw error don't throw from here
                }
                else
                {
                    // all other exceptions should be thrown
                    throw;
                }
            }

            // validation of encryption parameters
            if (ParameterSetName.Equals(BaseParameterSetName))
            {
                var identity = new EncryptionIdentity();
                var config = new EncryptionConfig();

                if(!Encryption.HasValue)
                {
                    WriteWarning(Resources.DefaultingEncryptionType);
                    Encryption = EncryptionConfigType.ServiceManaged;
                }

                if (Encryption == EncryptionConfigType.UserManaged)
                {
                    if (string.IsNullOrEmpty(KeyVaultId) ||
                    string.IsNullOrEmpty(KeyName) ||
                    string.IsNullOrEmpty(KeyVersion))
                    {
                        throw new PSArgumentException(Resources.MissingKeyVaultParams);
                    }

                    config.KeyVaultMetaInfo = new KeyVaultMetaInfo
                    {
                        KeyVaultResourceId = KeyVaultId,
                        EncryptionKeyName = KeyName,
                        EncryptionKeyVersion = KeyVersion
                    };
                }
                else
                {
                    if (!string.IsNullOrEmpty(KeyVaultId) ||
                    !string.IsNullOrEmpty(KeyName) ||
                    !string.IsNullOrEmpty(KeyVersion))
                    {
                        WriteWarning(Resources.IgnoredKeyVaultParams);
                    }
                }

                config.Type = Encryption.Value;
                WriteObject(
                    new PSDataLakeStoreAccount(
                        DataLakeStoreClient.CreateAccount(
                            ResourceGroupName,
                            Name,
                            DefaultGroup,
                            Location,
                            Tag,
                            identity,
                            config,
                            encryptionType: Encryption,
                            tier: Tier)));
            }
            else
            {
                WriteObject(
                    new PSDataLakeStoreAccount(
                        DataLakeStoreClient.CreateAccount(
                            ResourceGroupName,
                            Name,
                            DefaultGroup,
                            Location,
                            Tag,
                            tier: Tier)));
            }
        }
    }
}