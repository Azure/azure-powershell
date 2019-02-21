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

using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.KeyVault.WebKey;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSDeletedKeyVaultKey : PSDeletedKeyVaultKeyIdentityItem
    {
        public PSDeletedKeyVaultKey()
        { }

        internal PSDeletedKeyVaultKey(Azure.KeyVault.Models.DeletedKeyBundle deletedKeyBundle, VaultUriHelper vaultUriHelper)
        {
            if (deletedKeyBundle == null)
                throw new ArgumentNullException("keyItem");
            if (deletedKeyBundle.Attributes == null)
                throw new ArgumentException(Resources.InvalidKeyAttributes);
            if (deletedKeyBundle.KeyIdentifier == null)
                throw new ArgumentException(Resources.InvalidKeyIdentifier);

            SetObjectIdentifier(vaultUriHelper, deletedKeyBundle.KeyIdentifier);

            Key = deletedKeyBundle.Key;
            Attributes = new PSKeyVaultKeyAttributes(
                deletedKeyBundle.Attributes.Enabled,
                deletedKeyBundle.Attributes.Expires,
                deletedKeyBundle.Attributes.NotBefore,
                deletedKeyBundle.Key.Kty,
                deletedKeyBundle.Key.KeyOps.ToArray(),
                deletedKeyBundle.Attributes.Created,
                deletedKeyBundle.Attributes.Updated,
                deletedKeyBundle.Attributes.RecoveryLevel,
                deletedKeyBundle.Tags);

            Enabled = deletedKeyBundle.Attributes.Enabled;
            Expires = deletedKeyBundle.Attributes.Expires;
            NotBefore = deletedKeyBundle.Attributes.NotBefore;
            Created = deletedKeyBundle.Attributes.Created;
            Updated = deletedKeyBundle.Attributes.Updated;
            RecoveryLevel = deletedKeyBundle.Attributes.RecoveryLevel;
            Tags = (deletedKeyBundle.Tags == null) ? null : deletedKeyBundle.Tags.ConvertToHashtable();

            ScheduledPurgeDate = deletedKeyBundle.ScheduledPurgeDate;
            DeletedDate = deletedKeyBundle.DeletedDate;
        }

        public PSKeyVaultKeyAttributes Attributes { get; set; }

        public JsonWebKey Key { get; set; }
    }
}
