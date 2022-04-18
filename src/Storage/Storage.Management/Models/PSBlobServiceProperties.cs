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
            this.RestorePolicy = policy.RestorePolicy is null ? null : new PSRestorePolicy(policy.RestorePolicy);
            this.ChangeFeed = policy.ChangeFeed is null ? null : new PSChangeFeed(policy.ChangeFeed);
            this.IsVersioningEnabled = policy.IsVersioningEnabled;
            this.ContainerDeleteRetentionPolicy = policy.ContainerDeleteRetentionPolicy is null ? null : new PSDeleteRetentionPolicy(policy.ContainerDeleteRetentionPolicy);
            this.LastAccessTimeTrackingPolicy = policy.LastAccessTimeTrackingPolicy is null? null : new PSLastAccessTimeTrackingPolicy(policy.LastAccessTimeTrackingPolicy);
        }
        public BlobServiceProperties ParseBlobServiceProperties()
        {
            return new BlobServiceProperties
            {
                Cors = this.Cors is null ? null : this.Cors.ParseCorsRules(),
                DefaultServiceVersion = this.DefaultServiceVersion,
                DeleteRetentionPolicy = this.DeleteRetentionPolicy is null ? null : this.DeleteRetentionPolicy.ParseDeleteRetentionPolicy(),
                RestorePolicy = this.RestorePolicy is null ? null : this.RestorePolicy.ParseRestorePolicy(),
                ChangeFeed = this.ChangeFeed is null ? null : this.ChangeFeed.ParseChangeFeed(),
                IsVersioningEnabled = this.IsVersioningEnabled,
                ContainerDeleteRetentionPolicy = this.ContainerDeleteRetentionPolicy is null ? null : this.ContainerDeleteRetentionPolicy.ParseDeleteRetentionPolicy(),
                LastAccessTimeTrackingPolicy = this.LastAccessTimeTrackingPolicy is null ? null : this.LastAccessTimeTrackingPolicy.ParseLastAccessTimeTrackingPolicy()
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

        public PSChangeFeed(ChangeFeed changeFeed)
        {
            this.Enabled = changeFeed.Enabled;
            this.RetentionInDays = changeFeed.RetentionInDays;
        }

        public ChangeFeed ParseChangeFeed()
        {
            return new ChangeFeed
            {
                Enabled = this.Enabled,
                RetentionInDays = this.RetentionInDays
            };
        }
    }

    /// <summary>
    /// Wrapper of SDK type DeleteRetentionPolicy
    /// </summary>
    public class PSDeleteRetentionPolicy
    {
        public bool? Enabled { get; set; }
        public int? Days { get; set; }
        public bool? AllowPermanentDelete { get; set; }

        public PSDeleteRetentionPolicy()
        {
        }

        public PSDeleteRetentionPolicy(DeleteRetentionPolicy policy)
        {
            this.Enabled = policy.Enabled;
            this.Days = policy.Days;
            this.AllowPermanentDelete = policy.AllowPermanentDelete;
        }
        public DeleteRetentionPolicy ParseDeleteRetentionPolicy()
        {
            return new DeleteRetentionPolicy
            {
                Enabled = this.Enabled,
                Days = this.Days,
                AllowPermanentDelete = this.AllowPermanentDelete
            };
        }
    }

    /// <summary>
    /// Wrapper of SDK type DeleteRetentionPolicy
    /// </summary>
    public class PSRestorePolicy
    {
        public bool? Enabled { get; set; }
        public int? Days { get; set; }
        public DateTime? MinRestoreTime { get; set; }

        public PSRestorePolicy()
        {
        }

        public PSRestorePolicy(RestorePolicyProperties policy)
        {
            this.Enabled = policy.Enabled;
            this.Days = policy.Days;
            this.MinRestoreTime = policy.MinRestoreTime;

        }
        public RestorePolicyProperties ParseRestorePolicy()
        {
            return new RestorePolicyProperties
            {
                Enabled = this.Enabled is null ? false : this.Enabled.Value,
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

    /// <summary>
    ///  Wrapper of SDK type LastAccessTimeTrackingPolicy
    /// </summary>
    public class PSLastAccessTimeTrackingPolicy
    {
        public bool Enable { get; set; }
        public string Name { get; set; }
        public int? TrackingGranularityInDays { get; set; }
        public string[] BlobType { get; set; }


        public PSLastAccessTimeTrackingPolicy(LastAccessTimeTrackingPolicy policy)
        {
            this.Name = policy.Name;
            this.Enable = policy.Enable;
            this.TrackingGranularityInDays = policy.TrackingGranularityInDays;
            this.BlobType = policy.BlobType is null ? null : new List<string>(policy.BlobType).ToArray();
        }

        public LastAccessTimeTrackingPolicy ParseLastAccessTimeTrackingPolicy()
        {
            return new LastAccessTimeTrackingPolicy()
            {

                Name = this.Name,
                Enable = this.Enable,
                TrackingGranularityInDays = this.TrackingGranularityInDays,
                BlobType = this.BlobType is null ? null : new List<string>(this.BlobType)
            };
        }
    }
}
