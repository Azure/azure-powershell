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
    /// <summary>
    /// Key attributes from PSH perspective
    /// </summary>
    public class KeyAttributes
    {
        public KeyAttributes()
        { }

        internal KeyAttributes(bool? enabled, DateTime? expires, DateTime? notBefore, string keyType,
            string[] keyOps, Hashtable tags)
        {
            this.Enabled = enabled;
            this.Expires = expires;
            this.NotBefore = notBefore;
            this.KeyType = keyType;
            this.KeyOps = keyOps;
            this.Tags = tags;
        }

        internal KeyAttributes(bool? enabled, DateTime? expires, DateTime? notBefore, string keyType, 
            string[] keyOps, DateTime? created, DateTime? updated, IDictionary<string, string> tags)
        {
            this.Enabled = enabled;
            this.Expires = expires;
            this.NotBefore = notBefore;
            this.KeyType = keyType;
            this.KeyOps = keyOps;
            this.Created = created;
            this.Updated = updated;
            this.Tags = (tags == null) ? null : tags.ConvertToHashtable();
        }

        public bool? Enabled { get; set; }

        public DateTime? Expires { get; set; }

        public DateTime? NotBefore { get; set; }

        public string[] KeyOps { get; set; }

        public string KeyType { get; private set; }

        public DateTime? Created { get; private set; }

        public DateTime? Updated { get; private set; }

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

        public static explicit operator Azure.KeyVault.Models.KeyAttributes(KeyAttributes attr)
        {
            return new Azure.KeyVault.Models.KeyAttributes()
            {
                Enabled = attr.Enabled,
                NotBefore = attr.NotBefore,
                Expires = attr.Expires
            };
        }
    }
}
