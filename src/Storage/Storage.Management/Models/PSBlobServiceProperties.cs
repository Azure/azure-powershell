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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    /// <summary>
    /// Wrapper of SDK type BlobServiceProperties
    /// </summary>
    public class PSBlobServiceProperties
    {
        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 0)]
        public string ResourceGroupName { get; set; }
        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.Table, Position = 1)]
        public string StorageAccountName { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        [Ps1Xml(Label = "DefaultServiceVersion", Target = ViewControl.Table, Position = 2)]
        public string DefaultServiceVersion { get; set; }
        [Ps1Xml(Label = "DeleteRetentionPolicy.Enabled", Target = ViewControl.Table, ScriptBlock = "$_.DeleteRetentionPolicy.Enabled", Position = 3)]
        [Ps1Xml(Label = "DeleteRetentionPolicy.Days", Target = ViewControl.Table, ScriptBlock = "$_.DeleteRetentionPolicy.Days", Position = 4)]
        public PSDeleteRetentionPolicy DeleteRetentionPolicy { get; set; }
        public PSCorsRules Cors { get; set; }

        public PSBlobServiceProperties()
        { }

        public PSBlobServiceProperties(BlobServiceProperties policy)
        {
            this.ResourceGroupName = (new ResourceIdentifier(policy.Id)).ResourceGroupName;
            this.StorageAccountName = GetStorageAccountNameFromResourceId(policy.Id);
            this.Id = policy.Id;
            this.Name = policy.Name;
            this.Type = policy.Type;
            this.Cors = policy.Cors is null ? null : new PSCorsRules(policy.Cors);
            this.DefaultServiceVersion = policy.DefaultServiceVersion;
            this.DeleteRetentionPolicy = policy.DeleteRetentionPolicy is null ? null : new PSDeleteRetentionPolicy(policy.DeleteRetentionPolicy);
        }
        public BlobServiceProperties ParseBlobServiceProperties()
        {
            return new BlobServiceProperties
            {
                Cors = this.Cors is null ? null : this.Cors.ParseCorsRules(),
                DefaultServiceVersion = this.DefaultServiceVersion,
                DeleteRetentionPolicy = this.DeleteRetentionPolicy is null ? null : this.DeleteRetentionPolicy.ParseDeleteRetentionPolicy()
            };
        }

        /// <summary>
        /// Get Storage Account Name from Storage Account Resource Id or a storage account child resource Id (e.g. BlobServiceProperties ResourceId)
        /// </summary>
        /// <param name="ResourceId">Storage Account Resource Id or a storage account child resource Id (e.g. BlobServiceProperties ResourceId)</param>
        /// <returns>Storage Account Name</returns>
        public static string GetStorageAccountNameFromResourceId(string ResourceId)
        {
            ResourceIdentifier resource = new ResourceIdentifier(ResourceId);
            if (resource.ResourceType.Equals(StorageBlobBaseCmdlet.StorageAccountResourceType))
            {
                //Storage Account Resource Id
                return resource.ResourceName;

            }
            else //child resource Id(e.g.BlobServiceProperties ResourceId)
            {
                var parentResource = resource.ParentResource.Split(new[] { '/' });
                return parentResource[parentResource.Length - 1];
            }
        }
    }

    /// <summary>
    /// Wrapper of SDK type DeleteRetentionPolicy
    /// </summary>
    public class PSDeleteRetentionPolicy
    {
        public bool? Enabled { get; set; }
        public int? Days { get; set; }

        public PSDeleteRetentionPolicy()
        {
        }

        public PSDeleteRetentionPolicy(DeleteRetentionPolicy policy)
        {
            this.Enabled = policy.Enabled;
            this.Days = policy.Days;
        }
        public DeleteRetentionPolicy ParseDeleteRetentionPolicy()
        {
            return new DeleteRetentionPolicy
            {
                Enabled = this.Enabled,
                Days = this.Days
            };
        }
    }

    /// <summary>
    /// Wrapper of SDK type CorsRules
    /// </summary>
    public class PSCorsRules
    {
        public PSCorsRule[] CorsRulesProperty { get; set; }

        public PSCorsRules()
        {
        }

        public PSCorsRules(CorsRules rules)
        {
            if (rules.CorsRulesProperty is null)
            {
                CorsRulesProperty = null;
            }
            else
            {
                List<PSCorsRule> ruleList = new List<PSCorsRule>();
                foreach (CorsRule rule in rules.CorsRulesProperty)
                {
                    ruleList.Add(new PSCorsRule(rule));
                }
                this.CorsRulesProperty = ruleList.ToArray();
            }
        }

        public CorsRules ParseCorsRules()
        {
            if (this.CorsRulesProperty is null)
            {
                return new CorsRules
                {
                    CorsRulesProperty = null
                };
            }
            else
            {
                CorsRules returnValue = new CorsRules
                {
                    CorsRulesProperty = new List<CorsRule>()
                };
                foreach (PSCorsRule rule in this.CorsRulesProperty)
                {
                    returnValue.CorsRulesProperty.Add(rule.ParseCorsRule());
                }
                return returnValue;
            }
        }
    }

    /// <summary>
    /// Wrapper of SDK type CorsRule
    /// </summary>
    public class PSCorsRule
    {
        public string[] AllowedOrigins { get; set; }
        public string[] AllowedMethods { get; set; }
        public int MaxAgeInSeconds { get; set; }
        public string[] ExposedHeaders { get; set; }
        public string[] AllowedHeaders { get; set; }

        public PSCorsRule()
        {
        }

        public PSCorsRule(CorsRule rule)
        {
            this.AllowedOrigins = ListToArray(rule.AllowedOrigins);
            this.AllowedMethods = ListToArray(rule.AllowedMethods);
            this.MaxAgeInSeconds = rule.MaxAgeInSeconds;
            this.ExposedHeaders = ListToArray(rule.ExposedHeaders);
            this.AllowedHeaders = ListToArray(rule.AllowedHeaders);
        }

        public CorsRule ParseCorsRule()
        {
            return new CorsRule
            {
                AllowedOrigins = this.AllowedOrigins,
                AllowedMethods = this.AllowedMethods,
                MaxAgeInSeconds = this.MaxAgeInSeconds,
                ExposedHeaders = this.ExposedHeaders,
                AllowedHeaders = this.AllowedHeaders
            };
        }

        /// <summary>
        /// Parse String list to String Array for parse CorsRule 
        /// </summary>
        /// <param name="stringList">String list</param>
        /// <returns>String Array</returns>
        private static string[] ListToArray(IList<string> stringList)
        {
            if (null == stringList)
            {
                return null;
            }

            string[] stringArray = new string[stringList.Count];
            stringList.CopyTo(stringArray, 0);
            return stringArray;
        }
    }
}
