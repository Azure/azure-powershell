using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.KeyVault;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    /// <summary>
    /// Secret attributes from PSH perspective
    /// </summary>
    public class SecretAttributes
    {
        public SecretAttributes() 
        {}

        internal SecretAttributes(bool? enabled, DateTime? expires, DateTime? notBefore, string contentType, Hashtable tags)
        {
            this.Enabled = enabled;
            this.Expires = expires;
            this.NotBefore = notBefore;
            this.ContentType = contentType;
            this.Tags = tags;
        }

        internal SecretAttributes(bool? enabled, DateTime? expires, DateTime? notBefore, 
            DateTime? created, DateTime? updated, string contentType, Dictionary<string, string> tags)
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

        public Dictionary<string, string> TagsDirectionary
        {
            get
            {
                return (Tags == null) ? null : Tags.ConvertToDictionary();
            }
        }

        public static explicit operator Microsoft.Azure.KeyVault.SecretAttributes(SecretAttributes attr)
        {
            return new Microsoft.Azure.KeyVault.SecretAttributes()
            {
                Enabled = attr.Enabled,
                NotBefore = attr.NotBefore,
                Expires = attr.Expires               
            };

        }       
    }
}
