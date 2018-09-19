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
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;


namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public sealed class PSDeletedKeyVaultManagedStorageAccount : PSDeletedKeyVaultManagedStorageAccountIdentityItem
    {
        public PSDeletedKeyVaultManagedStorageAccount()
        { }

        internal PSDeletedKeyVaultManagedStorageAccount(Azure.KeyVault.Models.DeletedStorageBundle deletedStorageAccountBundle, VaultUriHelper vaultUriHelper)
        {
            if (deletedStorageAccountBundle == null)
                throw new ArgumentNullException(nameof(deletedStorageAccountBundle));
            if (deletedStorageAccountBundle.Attributes == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidManagedStorageObjectAttributes);
            if (deletedStorageAccountBundle.Id == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidManagedStorageAccountIdentifier);

            SetObjectIdentifier(vaultUriHelper, new Azure.KeyVault.StorageAccountIdentifier(deletedStorageAccountBundle.Id));

            AccountName = this.Name;
            AccountResourceId = deletedStorageAccountBundle.ResourceId;
            ActiveKeyName = deletedStorageAccountBundle.ActiveKeyName;
            AutoRegenerateKey = deletedStorageAccountBundle.AutoRegenerateKey;
            RegenerationPeriod = string.IsNullOrWhiteSpace(deletedStorageAccountBundle.RegenerationPeriod) ? (TimeSpan?)null : XmlConvert.ToTimeSpan(deletedStorageAccountBundle.RegenerationPeriod);
            Attributes = deletedStorageAccountBundle.Attributes == null
                ? null
                : new PSKeyVaultManagedStorageAccountAttributes(deletedStorageAccountBundle.Attributes);
            Tags = deletedStorageAccountBundle.Tags == null ? null : deletedStorageAccountBundle.Tags.ConvertToHashtable();

            ScheduledPurgeDate = deletedStorageAccountBundle.ScheduledPurgeDate;
            DeletedDate = deletedStorageAccountBundle.DeletedDate;
        }

        public string ActiveKeyName { get; set; }

        public bool? AutoRegenerateKey { get; set; }

        public TimeSpan? RegenerationPeriod { get; set; }
    }
}
