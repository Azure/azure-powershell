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
using System.Linq;

using Track1Sdk = Microsoft.Azure.KeyVault.Models;
using Track2Sdk = Azure.Security.KeyVault.Keys;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    /// <summary>
    /// Key attributes from PSH perspective
    /// </summary>
    public class PSKeyVaultKeyAttributes
    {
        public PSKeyVaultKeyAttributes()
        { }

        internal PSKeyVaultKeyAttributes(Track1Sdk.KeyBundle keyBundle)
        {
            Enabled = keyBundle.Attributes.Enabled;
            Expires = keyBundle.Attributes.Expires;
            NotBefore = keyBundle.Attributes.NotBefore;
            KeyType = keyBundle.Key.Kty;
            KeyOps = keyBundle.Key.KeyOps.ToArray();
            Created = keyBundle.Attributes.Created;
            Updated = keyBundle.Attributes.Updated;
            RecoveryLevel = keyBundle.Attributes.RecoveryLevel;
            Tags = keyBundle.Tags?.ConvertToHashtable();
            Managed = Managed = keyBundle.Managed;
        }

        internal PSKeyVaultKeyAttributes(Track2Sdk.KeyVaultKey key)
        {
            Enabled = key.Properties.Enabled;
            // see https://docs.microsoft.com/en-us/dotnet/standard/datetime/converting-between-datetime-and-offset#conversions-from-datetimeoffset-to-datetime
            // time returned by key vault are UTC
            Expires = key.Properties.ExpiresOn?.UtcDateTime;
            NotBefore = key.Properties.NotBefore?.UtcDateTime;
            KeyType = key.KeyType.ToString();
            KeyOps = key.KeyOperations.Select(op => op.ToString()).ToArray();
            Created = key.Properties.CreatedOn?.UtcDateTime;
            Updated = key.Properties.UpdatedOn?.UtcDateTime;
            RecoveryLevel = key.Properties.RecoveryLevel;
            Tags = key.Properties.Tags?.ConvertToHashtable();
            Exportable = key.Properties.Exportable;
            ReleasePolicy = key.Properties.ReleasePolicy?.ToPSKeyReleasePolicy();
            RecoverableDays = key.Properties.RecoverableDays;
            Managed = key.Properties.Managed;
        }

        internal PSKeyVaultKeyAttributes(bool? enabled, DateTime? expires, DateTime? notBefore, string keyType, string[] keyOps, Hashtable tags) {
            this.Enabled = enabled;
            this.Expires = expires;
            this.NotBefore = notBefore;
            this.KeyType = keyType;
            this.KeyOps = keyOps;
            this.Tags = tags;
        }

        internal PSKeyVaultKeyAttributes(bool? enabled, DateTime? expires, DateTime? notBefore, string keyType,
            string[] keyOps, DateTime? created, DateTime? updated, string deletionRecoveryLevel, IDictionary<string, string> tags)
        {
            this.Enabled = enabled;
            this.Expires = expires;
            this.NotBefore = notBefore;
            this.KeyType = keyType;
            this.KeyOps = keyOps;
            this.Created = created;
            this.Updated = updated;
            this.RecoveryLevel = deletionRecoveryLevel;
            this.Tags = (tags == null) ? null : tags.ConvertToHashtable();
        }

        public bool? Enabled { get; set; }

        public DateTime? Expires { get; set; }

        public DateTime? NotBefore { get; set; }

        public string[] KeyOps { get; set; }

        public string KeyType { get; internal set; }

        public DateTime? Created { get; internal set; }

        public DateTime? Updated { get; internal set; }

        public string RecoveryLevel { get; internal set; }

        // Summary:
        //     Gets the number of days a key is retained before being deleted for a soft delete-enabled
        //     Key Vault.
        public int? RecoverableDays { get; internal set; }

        // Summary:
        //     Gets a value indicating whether the key's lifetime is managed by Key Vault. If
        //     this key is backing a Key Vault certificate, the value will be true.
        public bool? Managed { get; internal set; }

        public bool? Exportable { get; internal set; }

        public PSKeyReleasePolicy ReleasePolicy { get; internal set; }

        public Hashtable Tags { get; set; }

        public string TagsTable
        {
            get
            {
                return (Tags == null) ? null : Tags.ConvertToTagsTable();
            }
        }

        public Dictionary<string, string> TagsDirectionary
        {
            get
            {
                return (Tags == null) ? null : Tags.ConvertToDictionary();
            }
        }

        public static explicit operator Track1Sdk.KeyAttributes(PSKeyVaultKeyAttributes attr)
        {
            return new Track1Sdk.KeyAttributes()
            {
                Enabled = attr.Enabled,
                NotBefore = attr.NotBefore,
                Expires = attr.Expires
            };
        }

        public Track2Sdk.KeyProperties ToKeyProperties(string keyName, Track2Sdk.KeyProperties keyProperties = null) 
        {
            if(null == keyProperties)
            {
                keyProperties = new Track2Sdk.KeyProperties(keyName);
            }
            keyProperties.ExpiresOn = this.Expires;
            keyProperties.NotBefore = this.NotBefore;
            keyProperties.Exportable = this.Exportable;
            keyProperties.Enabled = this.Enabled;
            if (this.Tags != null)
            {
                keyProperties.Tags.Clear();
                foreach (KeyValuePair<string, string> entry in this.TagsDirectionary)
                {
                    keyProperties.Tags.Add(entry.Key, entry.Value);
                }
            }
            keyProperties.ReleasePolicy = this.ReleasePolicy?.ToKeyReleasePolicy();
            return keyProperties;            
        }
    }
}
