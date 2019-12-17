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
using Microsoft.Azure.KeyVault;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class ManagedStorageAccountListItem
    {
        public ManagedStorageAccountListItem()
        { }

        /// <summary>
        /// Internal constructor used by KeyVaultDataServiceClient
        /// </summary>
        /// <param name="managedStorageAccountBundleListItem">managed storage bundle returned from service</param>
        /// <param name="vaultUriHelper">helper class</param>
        internal ManagedStorageAccountListItem( Azure.KeyVault.Models.StorageAccountItem managedStorageAccountBundleListItem, VaultUriHelper vaultUriHelper )
        {
            if ( managedStorageAccountBundleListItem == null )
                throw new ArgumentNullException( "managedStorageAccountBundleListItem" );

            if ( vaultUriHelper == null )
                throw new ArgumentNullException( "vaultUriHelper" );

            var identifier = new StorageAccountIdentifier( managedStorageAccountBundleListItem.Id );

            Id = identifier.Identifier;
            VaultName = vaultUriHelper.GetVaultName( identifier.Identifier );
            AccountName = identifier.Name;
            AccountResourceId = managedStorageAccountBundleListItem.ResourceId;
            Attributes = managedStorageAccountBundleListItem.Attributes == null ? null : new ManagedStorageAccountAttributes( managedStorageAccountBundleListItem.Attributes.Enabled, managedStorageAccountBundleListItem.Attributes.Created, managedStorageAccountBundleListItem.Attributes.Updated );
            Tags = managedStorageAccountBundleListItem.Tags == null ? null : managedStorageAccountBundleListItem.Tags.ConvertToHashtable();
        }

        public string Id { get; set; }

        public string VaultName { get; set; }

        public string AccountName { get; set; }

        public string AccountResourceId { get; set; }

        public ManagedStorageAccountAttributes Attributes { get; set; }

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
