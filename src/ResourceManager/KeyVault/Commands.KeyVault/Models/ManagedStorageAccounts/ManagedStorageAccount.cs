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
using System.Xml;
using Microsoft.Azure.KeyVault;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class ManagedStorageAccount : ManagedStorageAccountListItem
    {
        public ManagedStorageAccount()
        { }

        /// <summary>
        /// Internal constructor used by KeyVaultDataServiceClient
        /// </summary>
        /// <param name="managedStorageAccountBundle">managed storage bundle returned from service</param>
        /// <param name="vaultUriHelper">helper class</param>
        internal ManagedStorageAccount( Azure.KeyVault.Models.StorageBundle managedStorageAccountBundle, VaultUriHelper vaultUriHelper )
        {
            if ( managedStorageAccountBundle == null )
                throw new ArgumentNullException( "managedStorageAccountBundle" );

            if ( vaultUriHelper == null )
                throw new ArgumentNullException( "vaultUriHelper" );

            var identifier = new StorageAccountIdentifier(managedStorageAccountBundle.Id);

            Id = identifier.Identifier;
            VaultName = vaultUriHelper.GetVaultName( identifier.Identifier );
            AccountName = identifier.Name;
            AccountResourceId = managedStorageAccountBundle.ResourceId;
            ActiveKeyName = managedStorageAccountBundle.ActiveKeyName;
            AutoRegenerateKey = managedStorageAccountBundle.AutoRegenerateKey;
            RegenerationPeriod = string.IsNullOrWhiteSpace( managedStorageAccountBundle.RegenerationPeriod ) ? (TimeSpan?) null : XmlConvert.ToTimeSpan( managedStorageAccountBundle.RegenerationPeriod );
            Attributes = managedStorageAccountBundle.Attributes == null ? null : new ManagedStorageAccountAttributes( managedStorageAccountBundle.Attributes.Enabled, managedStorageAccountBundle.Attributes.Created, managedStorageAccountBundle.Attributes.Updated );
            Tags = managedStorageAccountBundle.Tags == null ? null : managedStorageAccountBundle.Tags.ConvertToHashtable();
        }

        public string ActiveKeyName { get; set; }

        public bool? AutoRegenerateKey { get; set; }

        public TimeSpan? RegenerationPeriod { get; set; }
    }
}
