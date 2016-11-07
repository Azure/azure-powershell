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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.DataLake.Store.Models;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Set, "AzureRmDataLakeStoreAccount"), OutputType(typeof(DataLakeStoreAccount))]
    [Alias("Set-AdlStore")]
    public class SetAzureDataLakeStoreAccount : DataLakeStoreCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of the account.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "Name of default group to use for all newly created files and folders in the Data Lake Store."
            )]
        [ValidateNotNullOrEmpty]
        public string DefaultGroup { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage =
                "A string,string dictionary of tags associated with this account that should replace the current set of tags"
            )]
        [ValidateNotNull]
        public Hashtable Tags { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "Indicates what type of encryption to provision the account with, if any.")]
        [ValidateNotNull]
        public EncryptionConfigType? Encryption { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "If the encryption type is User assigned, this is the key vault the user wishes to use")]
        [ValidateNotNull]
        public string KeyVaultId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            HelpMessage = "If the encryption type is User assigned, this is the key name in the key vault the user wishes to use")]
        [ValidateNotNull]
        public string KeyName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 6, Mandatory = false,
            HelpMessage = "If the encryption type is User assigned, this is the key version of the key the user wishes to use")]
        [ValidateNotNull]
        public string KeyVersion { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "Name of resource group under which you want to update the account.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            var currentAccount = DataLakeStoreClient.GetAccount(ResourceGroupName, Name);
            var location = currentAccount.Location;

            if (string.IsNullOrEmpty(DefaultGroup))
            {
                DefaultGroup = currentAccount.Properties.DefaultGroup;
            }

            if (Tags == null)
            {
                Tags = TagsConversionHelper.CreateTagHashtable(currentAccount.Tags);
            }

            // validation of encryption parameters
            if (Encryption != null)
            {
                var identity = new EncryptionIdentity
                {
                    Type = EncryptionIdentityType.SystemAssigned,
                };
                var config = new EncryptionConfig
                {
                    Type = Encryption.Value,
                };

                if (Encryption.Value == EncryptionConfigType.UserManaged)
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

                WriteObject(DataLakeStoreClient.CreateOrUpdateAccount(ResourceGroupName, Name, DefaultGroup, location, Tags, identity, config));
            }
            else
            {
                WriteObject(DataLakeStoreClient.CreateOrUpdateAccount(ResourceGroupName, Name, DefaultGroup, location, Tags));
            }
        }
    }
}