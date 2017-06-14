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

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class SecretIdentityItem : ObjectIdentifier
    {
        internal SecretIdentityItem(Azure.KeyVault.Models.SecretItem secretItem, VaultUriHelper vaultUriHelper)
        {
            if (secretItem == null)
                throw new ArgumentNullException("secretItem");
            if (secretItem.Attributes == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidSecretAttributes);
            if (secretItem.Identifier == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidSecretIdentifier);

            SetObjectIdentifier(vaultUriHelper, secretItem.Identifier);
            Enabled = secretItem.Attributes.Enabled;
            Expires = secretItem.Attributes.Expires;
            NotBefore = secretItem.Attributes.NotBefore;
            Created = secretItem.Attributes.Created;
            Updated = secretItem.Attributes.Updated;
            ContentType = secretItem.ContentType;
            Tags = (secretItem.Tags == null) ? null : secretItem.Tags.ConvertToHashtable();
        }

        internal SecretIdentityItem(Secret secret)
        {
            if (secret == null)
                throw new ArgumentNullException("secret");
            if (secret.Attributes == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidSecretAttributes);

            SetObjectIdentifier(secret);

            Enabled = secret.Attributes.Enabled;
            Expires = secret.Attributes.Expires;
            NotBefore = secret.Attributes.NotBefore;
            Created = secret.Attributes.Created;
            Updated = secret.Attributes.Updated;
            Tags = secret.Attributes.Tags;
        }
        public bool? Enabled { get; set; }

        public DateTime? Expires { get; set; }

        public DateTime? NotBefore { get; set; }

        public DateTime? Created { get; private set; }

        public DateTime? Updated { get; private set; }

        public string ContentType { get; set; }

        public Hashtable Tags { get; set; }
        public string TagsTable
        {
            get
            {
                return (Tags == null) ? null : Tags.ConvertToTagsTable();
            }
        }

    }
}
