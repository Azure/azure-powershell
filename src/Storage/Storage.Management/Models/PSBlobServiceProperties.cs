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

using Track2 = Azure.ResourceManager.Storage;
using Track2Models = Azure.ResourceManager.Storage.Models;
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
        [Ps1Xml(Label = "ChangeFeed", Target = ViewControl.Table, ScriptBlock = "$_.ChangeFeed.Enabled", Position = 7)]
        public PSChangeFeed ChangeFeed { get; set; }
        [Ps1Xml(Label = "DeleteRetentionPolicy.Enabled", Target = ViewControl.Table, ScriptBlock = "$_.DeleteRetentionPolicy.Enabled", Position = 3)]
        [Ps1Xml(Label = "DeleteRetentionPolicy.Days", Target = ViewControl.Table, ScriptBlock = "$_.DeleteRetentionPolicy.Days", Position = 4)]
        public PSDeleteRetentionPolicy DeleteRetentionPolicy { get; set; }
        [Ps1Xml(Label = "RestorePolicy.Enabled", Target = ViewControl.Table, ScriptBlock = "$_.RestorePolicy.Enabled", Position = 5)]
        [Ps1Xml(Label = "RestorePolicy.Days", Target = ViewControl.Table, ScriptBlock = "$_.RestorePolicy.Days", Position = 6)]
        [Ps1Xml(Label = "RestorePolicy.MinRestoreTime", Target = ViewControl.Table, ScriptBlock = "$_.RestorePolicy.MinRestoreTime", Position = 7)]
        public PSRestorePolicy RestorePolicy { get; set; }
        [Ps1Xml(Label = "ContainerDeleteRetentionPolicy.Days", Target = ViewControl.Table, ScriptBlock = "$_.ContainerDeleteRetentionPolicy.Days", Position = 8)]
        public PSDeleteRetentionPolicy ContainerDeleteRetentionPolicy { get; set; }
        public PSCorsRules Cors { get; set; }
        public bool? IsVersioningEnabled { get; set; }
        public PSLastAccessTimeTrackingPolicy LastAccessTimeTrackingPolicy { get; set; }

        public PSBlobServiceProperties()
        { }

        public PSBlobServiceProperties(Track2.BlobServiceResource policyResource)
        {
            this.ResourceGroupName = (new ResourceIdentifier(policyResource.Id)).ResourceGroupName;
            this.StorageAccountName = GetStorageAccountNameFromResourceId(policyResource.Id);
            this.Id = policyResource.Id;
            this.Name = policyResource.Data.Name;
            this.Type = policyResource.Data.ResourceType;
            this.Cors = policyResource.Data.CorsRulesValue is null ? null : new PSCorsRules(policyResource.Data.CorsRulesValue);
            this.DefaultServiceVersion = policyResource.Data.DefaultServiceVersion;
            this.DeleteRetentionPolicy = policyResource.Data.DeleteRetentionPolicy is null ? null : new PSDeleteRetentionPolicy(policyResource.Data.DeleteRetentionPolicy);
            this.RestorePolicy = policyResource.Data.RestorePolicy is null ? null : new PSRestorePolicy(policyResource.Data.RestorePolicy);
            this.ChangeFeed = policyResource.Data.ChangeFeed is null ? null : new PSChangeFeed(policyResource.Data.ChangeFeed);
            this.IsVersioningEnabled = policyResource.Data.IsVersioningEnabled;
            this.ContainerDeleteRetentionPolicy = policyResource.Data.ContainerDeleteRetentionPolicy is null ? null : new PSDeleteRetentionPolicy(policyResource.Data.ContainerDeleteRetentionPolicy);
            this.LastAccessTimeTrackingPolicy = policyResource.Data.LastAccessTimeTrackingPolicy is null ? null : new PSLastAccessTimeTrackingPolicy(policyResource.Data.LastAccessTimeTrackingPolicy);
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
                // Storage Account name will be the first parent resource, This works for all cmdlets reference this function, e.g.:
                // Blob Service: "storageAccounts/[AccountName]/blobServices/default"
                // Blob Container: "storageAccounts/[AccountName]/blobServices/default/containers/[ContainerName]"
                // File Share: "storageAccounts/[AccountName]/fileServices/default/shares/[ShareName]"
                var parentResource = resource.ParentResource.Split(new[] { '/' });
                return parentResource[1];
            }
        }
    }

    /// <summary>
    /// Wrapper of SDK type ChangeFeed
    /// </summary>
    public class PSChangeFeed
    {
        public bool? Enabled { get; set; }
        public int? RetentionInDays { get; set; }

        public PSChangeFeed()
        {
        }

        public PSChangeFeed(Track2Models.ChangeFeed changeFeed)
        {
            this.Enabled = changeFeed.Enabled;
            this.RetentionInDays = changeFeed.RetentionInDays;
        }

        public Track2Models.ChangeFeed ParseChangeFeed()
        {
            Track2Models.ChangeFeed changeFeed = new Track2Models.ChangeFeed
            {
                Enabled = this.Enabled,
                RetentionInDays = this.RetentionInDays,
            };
            return changeFeed;
        }
    }

    /// <summary>
    /// Wrapper of SDK type DeleteRetentionPolicy
    /// </summary>
    public class PSDeleteRetentionPolicy
    {
        public bool? Enabled { get; set; }
        public int? Days { get; set; }

        // TODO: AllowPermanentDelete is not supported by Track2 SDK yet. Will add later. 

        public PSDeleteRetentionPolicy()
        {
        }

        public PSDeleteRetentionPolicy(Track2Models.DeleteRetentionPolicy policy)
        {
            this.Enabled = policy.Enabled;
            this.Days = policy.Days;
        }

        public Track2Models.DeleteRetentionPolicy ParseDeleteRetentionPolicy()
        {
            Track2Models.DeleteRetentionPolicy ret = new Track2Models.DeleteRetentionPolicy
            {
                Enabled = this.Enabled,
                Days = this.Days,
            };
            return ret;
        }
    }

    /// <summary>
    /// Wrapper of SDK type DeleteRetentionPolicy
    /// </summary>
    public class PSRestorePolicy
    {
        public bool? Enabled { get; set; }
        public int? Days { get; set; }
        public DateTimeOffset? MinRestoreTime { get; set; }

        public PSRestorePolicy()
        {
        }

        public PSRestorePolicy(Track2Models.RestorePolicyProperties policy)
        {
            this.Enabled = policy.Enabled;
            this.Days = policy.Days;
            this.MinRestoreTime = policy.MinRestoreOn;
        }

        public Track2Models.RestorePolicyProperties ParseRestorePolicy()
        {
            bool enabled = this.Enabled is null ? false : this.Enabled.Value;

            return new Track2Models.RestorePolicyProperties(enabled)
            {
                Days = this.Days,
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

        public PSCorsRules(IList<Track2Models.CorsRule> rules)
        {
            if (rules is null)
            {
                this.CorsRulesProperty = null;
            }
            else
            {
                List<PSCorsRule> ruleList = new List<PSCorsRule>();
                foreach(Track2Models.CorsRule rule in rules)
                {
                    ruleList.Add(new PSCorsRule(rule));
                }
                this.CorsRulesProperty = ruleList.ToArray();
            }
        }

        public IList<Track2Models.CorsRule> ParseCorsRules()
        {
            if (this.CorsRulesProperty is null)
            {
                return null;
            }
            else
            {
                List<Track2Models.CorsRule> corsRules = new List<Track2Models.CorsRule>();
                foreach(PSCorsRule rule in this.CorsRulesProperty)
                {
                    corsRules.Add(rule.ParseCorsRule());
                }
                return corsRules;
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

        public PSCorsRule(Track2Models.CorsRule rule)
        {
            this.AllowedOrigins = ListToArray(rule.AllowedOrigins);

            if (rule.AllowedMethods is null)
            {
                this.AllowedMethods = null;
            } else
            {
                List<string> allowedMethodsList = new List<string>();
                foreach (Track2Models.CorsRuleAllowedMethodsItem itm in rule.AllowedMethods)
                {
                    allowedMethodsList.Add(itm.ToString());
                }
                this.AllowedMethods = ListToArray(allowedMethodsList);
            }

            this.MaxAgeInSeconds = rule.MaxAgeInSeconds;
            this.ExposedHeaders = ListToArray(rule.ExposedHeaders);
            this.AllowedHeaders = ListToArray(rule.AllowedHeaders);
        }

        public Track2Models.CorsRule ParseCorsRule()
        {
            List<Track2Models.CorsRuleAllowedMethodsItem> allowedMethods = new List<Track2Models.CorsRuleAllowedMethodsItem>();
            if (this.AllowedMethods is null)
            {
                allowedMethods = null;   
            } else
            {
                foreach(string itm in this.AllowedMethods)
                {
                    allowedMethods.Add(new Track2Models.CorsRuleAllowedMethodsItem(itm));
                }
            }

            return new Track2Models.CorsRule(
                this.AllowedOrigins,
                allowedMethods,
                this.MaxAgeInSeconds,
                this.ExposedHeaders,
                this.AllowedHeaders
                );
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

    /// <summary>
    ///  Wrapper of SDK type LastAccessTimeTrackingPolicy
    /// </summary>
    public class PSLastAccessTimeTrackingPolicy
    {
        public bool Enable { get; set; }
        public string Name { get; set; }
        public int? TrackingGranularityInDays { get; set; }
        public string[] BlobType { get; set; }

        public PSLastAccessTimeTrackingPolicy(Track2Models.LastAccessTimeTrackingPolicy policy)
        {
            this.Name = policy.Name?.ToString();
            this.Enable = policy.Enable;
            this.TrackingGranularityInDays = policy.TrackingGranularityInDays;
            this.BlobType = policy.BlobType is null ? null : new List<string>(policy.BlobType).ToArray();
        }

        public Track2Models.LastAccessTimeTrackingPolicy ParseLastAccessTimeTrackingPolicy()
        {
            Track2Models.LastAccessTimeTrackingPolicy policy = new Track2Models.LastAccessTimeTrackingPolicy(this.Enable)
            {
                Name = new Track2Models.Name(this.Name),
                TrackingGranularityInDays = this.TrackingGranularityInDays,
            };

            if (this.BlobType != null)
            {
                foreach(string blobType in this.BlobType)
                {
                    policy.BlobType.Add(blobType);
                }
            }
            return policy;
        }
    }
}
