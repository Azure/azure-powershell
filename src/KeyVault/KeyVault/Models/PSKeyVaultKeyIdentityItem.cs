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
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Track2Sdk = Azure.Security.KeyVault.Keys;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultKeyIdentityItem : ObjectIdentifier
    {
        public PSKeyVaultKeyIdentityItem()
        { }

        internal PSKeyVaultKeyIdentityItem(Azure.KeyVault.Models.KeyItem keyItem, VaultUriHelper vaultUriHelper)
        {
            if (keyItem == null)
                throw new ArgumentNullException("keyItem");
            if (keyItem.Attributes == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidKeyAttributes);
            if (keyItem.Identifier == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidKeyIdentifier);

            SetObjectIdentifier(vaultUriHelper, keyItem.Identifier);

            Enabled = keyItem.Attributes.Enabled;
            Expires = keyItem.Attributes.Expires;
            NotBefore = keyItem.Attributes.NotBefore;
            Created = keyItem.Attributes.Created;
            Updated = keyItem.Attributes.Updated;
            RecoveryLevel = keyItem.Attributes.RecoveryLevel;
            Tags = (keyItem.Tags == null) ? null : keyItem.Tags.ConvertToHashtable();
        }

        internal PSKeyVaultKeyIdentityItem(PSKeyVaultKey keyBundle)
        {
            if (keyBundle == null)
                throw new ArgumentNullException("keyBundle");
            if (keyBundle.Attributes == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidKeyAttributes);

            SetObjectIdentifier(keyBundle);

            Enabled = keyBundle.Attributes.Enabled;
            Expires = keyBundle.Attributes.Expires;
            NotBefore = keyBundle.Attributes.NotBefore;
            Created = keyBundle.Attributes.Created;
            Updated = keyBundle.Attributes.Updated;
            RecoveryLevel = keyBundle.Attributes.RecoveryLevel;
            Tags = keyBundle.Attributes.Tags;
        }
        internal PSKeyVaultKeyIdentityItem(Track2Sdk.KeyProperties keyProperties, VaultUriHelper vaultUriHelper)
        {
            if (keyProperties == null)
                throw new ArgumentNullException("keyProperties");
            if (keyProperties.Id == null || keyProperties.Name == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidKeyProperties);

            SetObjectIdentifier(vaultUriHelper, new Microsoft.Azure.KeyVault.KeyIdentifier(keyProperties.Id.ToString()));

            Enabled = keyProperties.Enabled;
            Expires = keyProperties.ExpiresOn?.UtcDateTime;
            NotBefore = keyProperties.NotBefore?.UtcDateTime;
            Created = keyProperties.CreatedOn?.UtcDateTime;
            Updated = keyProperties.UpdatedOn?.UtcDateTime;
            RecoveryLevel = keyProperties.RecoveryLevel;
            Tags = keyProperties.Tags.ConvertToHashtable();
        }

        public bool? Enabled { get; set; }

        public DateTime? Expires { get; set; }

        public DateTime? NotBefore { get; set; }

        public DateTime? Created { get; protected set; }

        public DateTime? Updated { get; protected set; }

        public string RecoveryLevel { get; protected set; }

        public Hashtable Tags { get; set; }

        public string TagsTable
        {
            get { return (Tags == null) ? null : Tags.ConvertToTagsTable(); }
        }
    }
}
