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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultManagedStorageSasDefinitionIdentityItem : ObjectIdentifier
    {
        internal PSKeyVaultManagedStorageSasDefinitionIdentityItem()
        { }

        internal PSKeyVaultManagedStorageSasDefinitionIdentityItem( Azure.KeyVault.Models.SasDefinitionItem storageSasDefinitionItem, VaultUriHelper vaultUriHelper )
        {
            if ( storageSasDefinitionItem == null )
                throw new ArgumentNullException(nameof(storageSasDefinitionItem));

            if ( vaultUriHelper == null )
                throw new ArgumentNullException(nameof(vaultUriHelper));

            SetObjectIdentifier(vaultUriHelper, storageSasDefinitionItem.Identifier);

            Attributes = storageSasDefinitionItem.Attributes == null ? null : new PSKeyVaultManagedStorageSasDefinitionAttributes(storageSasDefinitionItem.Attributes);
            Tags = storageSasDefinitionItem.Tags == null ? null : storageSasDefinitionItem.Tags.ConvertToHashtable();
            Sid = storageSasDefinitionItem.SecretId;
            AccountName = storageSasDefinitionItem.Identifier.StorageAccount;
        }

        public string Sid { get; set; }

        public string AccountName { get; set; }

        public PSKeyVaultManagedStorageSasDefinitionAttributes Attributes { get; set; }

        public Hashtable Tags { get; set; }

        public string TagsTable
        {
            get
            {
                return ( Tags == null ) ? null : Tags.ConvertToTagsTable();
            }
        }

        public IDictionary<string, string> TagsDictionary
        {
            get
            {
                return ( Tags == null ) ? null : Tags.ConvertToDictionary();
            }
        }
    }
}
