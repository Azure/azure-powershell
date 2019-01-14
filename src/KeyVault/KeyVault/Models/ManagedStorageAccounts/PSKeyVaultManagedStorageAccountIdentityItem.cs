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
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultManagedStorageAccountIdentityItem : ObjectIdentifier
    {
        public PSKeyVaultManagedStorageAccountIdentityItem()
        { }

        /// <summary>
        /// Internal constructor used by KeyVaultDataServiceClient
        /// </summary>
        /// <param name="managedStorageAccountBundleListItem">managed storage bundle returned from service</param>
        /// <param name="vaultUriHelper">helper class</param>
        internal PSKeyVaultManagedStorageAccountIdentityItem( Azure.KeyVault.Models.StorageAccountItem managedStorageAccountBundleListItem, VaultUriHelper vaultUriHelper )
        {
            if ( managedStorageAccountBundleListItem == null )
                throw new ArgumentNullException(nameof(managedStorageAccountBundleListItem));

            if ( vaultUriHelper == null )
                throw new ArgumentNullException(nameof(vaultUriHelper));

            SetObjectIdentifier(vaultUriHelper, managedStorageAccountBundleListItem.Identifier);

            AccountName = this.Name;
            AccountResourceId = managedStorageAccountBundleListItem.ResourceId;
            Attributes = managedStorageAccountBundleListItem.Attributes == null 
                ? null 
                : new PSKeyVaultManagedStorageAccountAttributes(managedStorageAccountBundleListItem.Attributes);
            Tags = managedStorageAccountBundleListItem.Tags == null ? null : managedStorageAccountBundleListItem.Tags.ConvertToHashtable();
        }

        internal PSKeyVaultManagedStorageAccountIdentityItem(PSKeyVaultManagedStorageAccount managedStorageAccountBundle)
        {
            if (managedStorageAccountBundle == null)
                throw new ArgumentNullException(nameof(managedStorageAccountBundle));
            if (managedStorageAccountBundle.Attributes == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidManagedStorageObjectAttributes);

            SetObjectIdentifier(managedStorageAccountBundle);

            AccountName = this.Name;
            AccountResourceId = managedStorageAccountBundle.AccountResourceId;
            Attributes = managedStorageAccountBundle.Attributes;
            Tags = managedStorageAccountBundle.Tags;
        }

        public string AccountName { get; set; }

        public string AccountResourceId { get; set; }

        public PSKeyVaultManagedStorageAccountAttributes Attributes { get; set; }

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
