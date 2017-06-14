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
    /// Secret attributes from PSH perspective
    /// </summary>
    public class SecretAttributes
    {
        public SecretAttributes()
        { }

        internal SecretAttributes(bool? enabled, DateTime? expires, DateTime? notBefore, string contentType, Hashtable tags)
        {
            this.Enabled = enabled;
            this.Expires = expires;
            this.NotBefore = notBefore;
            this.ContentType = contentType;
            this.Tags = tags;
        }

        internal SecretAttributes(bool? enabled, DateTime? expires, DateTime? notBefore, 
            DateTime? created, DateTime? updated, string contentType, IDictionary<string, string> tags)
        {
            this.Enabled = enabled;
            this.Expires = expires;
            this.NotBefore = notBefore;
            this.Created = created;
            this.Updated = updated;
            this.ContentType = contentType;
            this.Tags = (tags == null) ? null : tags.ConvertToHashtable();
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

        public Dictionary<string, string> TagsDictionary
        {
            get
            {
                return (Tags == null) ? null : Tags.ConvertToDictionary();
            }
        }

        public static explicit operator Azure.KeyVault.Models.SecretAttributes(SecretAttributes attr)
        {
            return new Azure.KeyVault.Models.SecretAttributes
            {
                Enabled = attr.Enabled,
                NotBefore = attr.NotBefore,
                Expires = attr.Expires
            };

        }
    }
}
