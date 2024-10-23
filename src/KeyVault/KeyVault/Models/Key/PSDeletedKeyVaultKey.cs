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

using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Properties;

using System;
using System.Linq;

using JsonWebKey = Microsoft.Azure.KeyVault.WebKey.JsonWebKey;

using Track1Sdk = Microsoft.Azure.KeyVault.Models;
using Track2Sdk = Azure.Security.KeyVault.Keys;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSDeletedKeyVaultKey : PSDeletedKeyVaultKeyIdentityItem
    {
        public PSDeletedKeyVaultKey()
        { }

        internal PSDeletedKeyVaultKey(Track1Sdk.DeletedKeyBundle deletedKeyBundle, VaultUriHelper vaultUriHelper, bool isHsm = false)
        {
            if (deletedKeyBundle == null)
                throw new ArgumentNullException("keyItem");
            if (deletedKeyBundle.Attributes == null)
                throw new ArgumentException(Resources.InvalidKeyAttributes);
            if (deletedKeyBundle.KeyIdentifier == null)
                throw new ArgumentException(Resources.InvalidKeyIdentifier);

            SetObjectIdentifier(vaultUriHelper, deletedKeyBundle.KeyIdentifier);

            Key = deletedKeyBundle.Key;

            KeySize = JwkHelper.ConvertToRSAKey(Key)?.KeySize;

            Attributes = new PSKeyVaultKeyAttributes(
                deletedKeyBundle.Attributes.Enabled,
                deletedKeyBundle.Attributes.Expires,
                deletedKeyBundle.Attributes.NotBefore,
                deletedKeyBundle.Key?.Kty,
                deletedKeyBundle.Key.KeyOps?.ToArray(),
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
            IsHsm = isHsm;
        }

        internal PSDeletedKeyVaultKey(Track2Sdk.DeletedKey deletedKey, VaultUriHelper vaultUriHelper, bool isHsm = false)
        {
            if (deletedKey == null)
                throw new ArgumentNullException("deletedKey");
            if (deletedKey.Properties == null)
                throw new ArgumentException(Resources.InvalidKeyBundle);
            if (null == deletedKey.Id || string.IsNullOrEmpty(deletedKey.Id.ToString()))
                throw new ArgumentException(Resources.InvalidKeyIdentifier);

            SetObjectIdentifier(vaultUriHelper, new Microsoft.Azure.KeyVault.KeyIdentifier(deletedKey.Id.ToString()));
            if(null != deletedKey.Key)
            {
                Key = deletedKey.Key.ToTrack1JsonWebKey();
                KeySize = JwkHelper.ConvertToRSAKey(Key)?.KeySize;
            }
            Attributes = new PSKeyVaultKeyAttributes()
            {
                Enabled = deletedKey.Properties.Enabled,
                // see https://learn.microsoft.com/en-us/dotnet/standard/datetime/converting-between-datetime-and-offset#conversions-from-datetimeoffset-to-datetime
                Expires = deletedKey.Properties.ExpiresOn?.UtcDateTime, // time returned by key vault are UTC
                NotBefore = deletedKey.Properties.NotBefore?.UtcDateTime,
                Created = deletedKey.Properties.CreatedOn?.UtcDateTime,
                Updated = deletedKey.Properties.UpdatedOn?.UtcDateTime,
                RecoveryLevel = deletedKey.Properties.RecoveryLevel,
                Tags = deletedKey.Properties.Tags?.ConvertToHashtable(),
                HsmPlatform = deletedKey.Properties.HsmPlatform
            };

            Enabled = deletedKey.Properties.Enabled;
            Expires = deletedKey.Properties.ExpiresOn?.UtcDateTime;
            NotBefore = deletedKey.Properties.NotBefore?.UtcDateTime;
            Created = deletedKey.Properties.CreatedOn?.UtcDateTime;
            Updated = deletedKey.Properties.UpdatedOn?.UtcDateTime;
            RecoveryLevel = deletedKey.Properties.RecoveryLevel;
            Tags = deletedKey.Properties.Tags?.ConvertToHashtable();
            ScheduledPurgeDate = deletedKey.ScheduledPurgeDate?.UtcDateTime;
            DeletedDate = deletedKey.DeletedOn?.UtcDateTime;
            IsHsm = isHsm;
        }

        public PSKeyVaultKeyAttributes Attributes { get; set; }

        public JsonWebKey Key { get; set; }

        public string KeyType
        {
            get { return Key?.Kty; }
        }

        public string CurveName
        {
            get { return Key?.CurveName; }
        }

        public int? KeySize;
    }
}
