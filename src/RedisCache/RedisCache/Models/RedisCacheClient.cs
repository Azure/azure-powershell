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

namespace Microsoft.Azure.Commands.RedisCache
{
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.RedisCache.Properties;
    using Microsoft.Azure.Management.Insights;
    using Microsoft.Azure.Management.Insights.Models;
    using Microsoft.Azure.Management.Internal.Resources;
    using Microsoft.Azure.Management.RedisCache;
    using Microsoft.Azure.Management.RedisCache.Models;
    using Microsoft.Rest.Azure;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class RedisCacheClient
    {
        private RedisManagementClient _client;
        private InsightsManagementClient _insightsClient;
        private ResourceManagementClient _resourceManagementClient;

        public RedisCacheClient(IAzureContext context)
        {
            _client = AzureSession.Instance.ClientFactory.CreateArmClient<RedisManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            _insightsClient = AzureSession.Instance.ClientFactory.CreateArmClient<InsightsManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            _resourceManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }
        public RedisCacheClient() { }

        public RedisResource CreateCache(string resourceGroupName, string cacheName, string location, string skuFamily, int skuCapacity, string skuName,
                Hashtable redisConfiguration, bool? enableNonSslPort, Hashtable tenantSettings, int? shardCount, string minimumTlsVersion, bool? disableAccessKeyAuthentication, string subnetId,
                string staticIP, Hashtable tags, IList<string> zones, string redisVersion, string identityType, string[] userAssignedIdentities, string updateChannel, string zonalAllocationPolicy)
        {
            try
            {
                _resourceManagementClient.Providers.Register("Microsoft.Cache");
            }
            catch
            {
            }
            var parameters = new RedisCreateParameters
            {
                Location = location,
                Sku = new Sku
                {
                    Name = skuName,
                    Family = skuFamily,
                    Capacity = skuCapacity
                },
                RedisVersion = redisVersion,
                UpdateChannel = updateChannel,
                ZonalAllocationPolicy = zonalAllocationPolicy
            };

            parameters.Identity = Utility.BuildManagedServiceIdentity(identityType, userAssignedIdentities);

            if (zones != null && zones.Count != 0)
            {
                parameters.Zones = zones;
            }

            if (tags != null)
            {
                parameters.Tags = new Dictionary<string, string>();
                foreach (object key in tags.Keys)
                {
                    parameters.Tags.Add(key.ToString(), tags[key].ToString());
                }
            }

            if (redisConfiguration != null)
            {
                parameters.RedisConfiguration = new RedisCommonPropertiesRedisConfiguration(additionalProperties: new Dictionary<string, object>());
                foreach (object key in redisConfiguration.Keys)
                {
                    parameters.RedisConfiguration.AdditionalProperties.Add(key.ToString(), redisConfiguration[key].ToString());
                }
            }

            if (enableNonSslPort.HasValue)
            {
                parameters.EnableNonSslPort = enableNonSslPort.Value;
            }

            if (tenantSettings != null)
            {
                parameters.TenantSettings = new Dictionary<string, string>();
                foreach (object key in tenantSettings.Keys)
                {
                    parameters.TenantSettings.Add(key.ToString(), tenantSettings[key].ToString());
                }
            }

            if (shardCount.HasValue)
            {
                parameters.ShardCount = shardCount.Value;
            }

            if (!string.IsNullOrEmpty(minimumTlsVersion))
            {
                parameters.MinimumTlsVersion = minimumTlsVersion;
            }

            if (disableAccessKeyAuthentication.HasValue)
            {
                parameters.DisableAccessKeyAuthentication = disableAccessKeyAuthentication.Value;
            }

            if (!string.IsNullOrWhiteSpace(subnetId))
            {
                parameters.SubnetId = subnetId;
            }

            if (!string.IsNullOrWhiteSpace(staticIP))
            {
                parameters.StaticIP = staticIP;
            }

            RedisResource response = _client.Redis.BeginCreate(resourceGroupName: resourceGroupName, name: cacheName, parameters: parameters);
            return response;
        }

        public RedisResource UpdateCache(string resourceGroupName, string cacheName, string skuFamily, int skuCapacity, string skuName,
                Hashtable redisConfiguration, bool? enableNonSslPort, Hashtable tenantSettings, int? shardCount, string MinimumTlsVersion, bool? disableAccessKeyAuthentication,
                string redisVersion, Hashtable tags, string identityType, string[] userAssignedIdentities, string updateChannel, string zonalAllocationPolicy)
        {
            try
            {
                _resourceManagementClient.Providers.Register("Microsoft.Cache");
            }
            catch
            {
            }
            var parameters = new RedisUpdateParameters
            {
                Sku = new Sku
                {
                    Name = skuName,
                    Family = skuFamily,
                    Capacity = skuCapacity
                }
            };

            if (tags != null)
            {
                parameters.Tags = new Dictionary<string, string>();
                foreach (object key in tags.Keys)
                {
                    parameters.Tags.Add(key.ToString(), tags[key].ToString());
                }
            }

            if (redisConfiguration != null)
            {
                parameters.RedisConfiguration = new RedisCommonPropertiesRedisConfiguration(additionalProperties: new Dictionary<string, object>());
                foreach (object key in redisConfiguration.Keys)
                {
                    parameters.RedisConfiguration.AdditionalProperties.Add(key.ToString(), redisConfiguration[key].ToString());
                }
            }

            parameters.Identity = Utility.BuildManagedServiceIdentity(identityType, userAssignedIdentities);

            parameters.EnableNonSslPort = enableNonSslPort;

            if (!string.IsNullOrEmpty(updateChannel))
            {
                parameters.UpdateChannel = updateChannel;
                parameters.RedisVersion = "latest";
            }

            if (!string.IsNullOrEmpty(zonalAllocationPolicy))
            {
                parameters.ZonalAllocationPolicy = zonalAllocationPolicy;
            }

            if (!string.IsNullOrEmpty(redisVersion))
            {
                parameters.RedisVersion = redisVersion;
            }

            if (tenantSettings != null)
            {
                parameters.TenantSettings = new Dictionary<string, string>();
                foreach (object key in tenantSettings.Keys)
                {
                    // RP should disregard "InternalDependencyList" passed from user (it happens because of piping scenario)
                    string stringKey = key.ToString();
                    if (stringKey.Equals("InternalDependencyList", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }
                    parameters.TenantSettings.Add(key.ToString(), tenantSettings[key].ToString());
                }
            }

            parameters.ShardCount = shardCount;

            if (!string.IsNullOrEmpty(MinimumTlsVersion))
            {
                parameters.MinimumTlsVersion = MinimumTlsVersion;
            }

            if (disableAccessKeyAuthentication.HasValue)
            {
                parameters.DisableAccessKeyAuthentication = disableAccessKeyAuthentication.Value;
            }

            RedisResource response = _client.Redis.BeginUpdate(resourceGroupName: resourceGroupName, name: cacheName, parameters: parameters);
            return response;
        }

        public void DeleteCache(string resourceGroupName, string cacheName)
        {
            _client.Redis.Delete(resourceGroupName: resourceGroupName, name: cacheName);
        }

        public RedisResource GetCache(string resourceGroupName, string cacheName)
        {
            return _client.Redis.Get(resourceGroupName: resourceGroupName, name: cacheName);
        }

        public RedisResource GetCache(string cacheName)
        {
            IPage<RedisResource> allInSub = ListCaches(null);
            foreach (var cache in allInSub)
            {
                if (cache.Name.Equals(cacheName, StringComparison.OrdinalIgnoreCase))
                {
                    return cache;
                }
            }
            throw new ArgumentException(string.Format(Resources.CacheNotFound, cacheName));
        }

        public string GetResourceGroupNameIfNotProvided(string resourceGroupName, string cacheName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                RedisResource response = GetCache(cacheName);
                return Utility.GetResourceGroupNameFromRedisCacheId(response.Id);
            }
            return resourceGroupName;
        }

        public IPage<RedisResource> ListCaches(string resourceGroupName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                return _client.Redis.ListBySubscription();
            }
            else
            {
                return _client.Redis.ListByResourceGroup(resourceGroupName: resourceGroupName);
            }
        }

        public IPage<RedisResource> ListCachesUsingNextLink(string resourceGroupName, string nextLink)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                return _client.Redis.ListBySubscriptionNext(nextPageLink: nextLink);
            }
            else
            {
                return _client.Redis.ListByResourceGroupNext(nextPageLink: nextLink);
            }
        }

        public RedisAccessKeys RegenerateAccessKeys(string resourceGroupName, string cacheName, RedisKeyType keyType)
        {
            return _client.Redis.RegenerateKey(resourceGroupName: resourceGroupName, name: cacheName, keyType);
        }

        public RedisAccessKeys GetAccessKeys(string resourceGroupName, string cacheName)
        {
            return _client.Redis.ListKeys(resourceGroupName: resourceGroupName, name: cacheName);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void SetDiagnostics(string cacheId, string storageAccountId)
        {
            _insightsClient.ServiceDiagnosticSettings.CreateOrUpdateWithHttpMessagesAsync(
                resourceUri: cacheId,
                parameters: new ServiceDiagnosticSettingsResource
                {
                    StorageAccountId = storageAccountId
                }
            );
        }

        public void ImportToCache(string resourceGroupName, string cacheName, string[] blobUrisWithSasTokens, string format, string preferredDataArchiveAuthMethod, string StorageSubscriptionId)
        {
            ImportRDBParameters parameters = new ImportRDBParameters();
            parameters.Files = blobUrisWithSasTokens;
            parameters.PreferredDataArchiveAuthMethod = preferredDataArchiveAuthMethod;
            parameters.StorageSubscriptionId = StorageSubscriptionId;
            if (!string.IsNullOrWhiteSpace(format))
            {
                parameters.Format = format;
            }
            _client.Redis.ImportData(resourceGroupName: resourceGroupName, name: cacheName, parameters: parameters);
        }

        public void ExportToCache(string resourceGroupName, string cacheName, string containerUrisWithSasTokens, string prefix, string format, string preferredDataArchiveAuthMethod, string StorageSubscriptionId)
        {
            ExportRDBParameters parameters = new ExportRDBParameters();
            parameters.Container = containerUrisWithSasTokens;
            parameters.Prefix = prefix;
            parameters.PreferredDataArchiveAuthMethod = preferredDataArchiveAuthMethod;
            parameters.StorageSubscriptionId = StorageSubscriptionId;
            if (!string.IsNullOrWhiteSpace(format))
            {
                parameters.Format = format;
            }
            _client.Redis.ExportData(resourceGroupName: resourceGroupName, name: cacheName, parameters: parameters);
        }

        public void RebootCache(string resourceGroupName, string cacheName, string rebootType, int? shardId)
        {
            RedisRebootParameters parameters = new RedisRebootParameters();
            parameters.RebootType = rebootType;
            if (shardId.HasValue)
            {
                parameters.ShardId = shardId;
            }
            _client.Redis.ForceReboot(resourceGroupName: resourceGroupName, name: cacheName, parameters: parameters);
        }

        public void FlushCache(string resourceGroupName, string cacheName)
        {
            _client.Redis.FlushCache(resourceGroupName: resourceGroupName, cacheName: cacheName);
        }

        public IList<ScheduleEntry> SetPatchSchedules(string resourceGroupName, string cacheName, List<ScheduleEntry> schedules)
        {
            var response = _client.PatchSchedules.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, cacheName, schedules).Result;
            return response.Body.ScheduleEntries;
        }

        public IList<ScheduleEntry> GetPatchSchedules(string resourceGroupName, string cacheName)
        {
            var response = _client.PatchSchedules.Get(resourceGroupName, cacheName);
            if (response == null)
            {
                return null;
            }
            return response.ScheduleEntries;
        }

        public void RemovePatchSchedules(string resourceGroupName, string cacheName)
        {
            _client.PatchSchedules.Delete(resourceGroupName, cacheName);
        }

        internal RedisFirewallRule SetFirewallRule(string resourceGroupName, string cacheName, string ruleName, string startIP, string endIP)
        {
            return _client.FirewallRules.CreateOrUpdate(resourceGroupName, cacheName, ruleName, startIP, endIP);
        }

        internal RedisFirewallRule GetFirewallRule(string resourceGroupName, string cacheName, string ruleName)
        {
            return _client.FirewallRules.Get(resourceGroupName, cacheName, ruleName);
        }

        internal IPage<RedisFirewallRule> ListFirewallRules(string resourceGroupName, string cacheName)
        {
            return _client.FirewallRules.List(resourceGroupName, cacheName);
        }

        internal IPage<RedisFirewallRule> ListFirewallRules(string nextLink)
        {
            return _client.FirewallRules.ListNext(nextLink);
        }

        internal void RemoveFirewallRule(string resourceGroupName, string cacheName, string ruleName)
        {
            _client.FirewallRules.Delete(resourceGroupName, cacheName, ruleName);
        }

        internal RedisLinkedServerWithProperties SetLinkedServer(string resourceGroupName, string cacheName,
            string linkedCacheName, string linkedCacheId, string linkedCacheLocation, ReplicationRole serverRole)
        {
            return _client.LinkedServer.BeginCreate(resourceGroupName, cacheName, linkedCacheName, new RedisLinkedServerCreateParameters
            {
                LinkedRedisCacheId = linkedCacheId,
                LinkedRedisCacheLocation = linkedCacheLocation,
                ServerRole = serverRole
            });
        }

        internal RedisLinkedServerWithProperties GetLinkedServer(string resourceGroupName, string cacheName, string linkedCacheName)
        {
            return _client.LinkedServer.Get(resourceGroupName, cacheName, linkedCacheName);
        }

        internal IPage<RedisLinkedServerWithProperties> ListLinkedServer(string resourceGroupName, string cacheName)
        {
            return _client.LinkedServer.List(resourceGroupName, cacheName);
        }

        internal IPage<RedisLinkedServerWithProperties> ListLinkedServer(string nextLink)
        {
            return _client.LinkedServer.ListNext(nextLink);
        }

        internal void RemoveLinkedServer(string resourceGroupName, string cacheName, string linkedCacheName)
        {
            _client.LinkedServer.BeginDelete(resourceGroupName, cacheName, linkedCacheName);
        }

        internal RedisCacheAccessPolicy SetAccessPolicy(string resourceGroupName, string cacheName, string accessPolicyName, string permissions)
        {
            return _client.AccessPolicy.CreateUpdate(resourceGroupName, cacheName, accessPolicyName, permissions);
        }

        internal RedisCacheAccessPolicy GetAccessPolicy(string resourceGroupName, string cacheName, string accessPolicyName)
        {
            return _client.AccessPolicy.Get(resourceGroupName, cacheName, accessPolicyName);
        }

        internal IPage<RedisCacheAccessPolicy> ListAccessPolicies(string resourceGroupName, string cacheName)
        {
            return _client.AccessPolicy.List(resourceGroupName, cacheName);
        }

        internal IPage<RedisCacheAccessPolicy> ListAccessPolicies(string nextLink)
        {
            return _client.AccessPolicy.ListNext(nextLink);
        }

        internal void RemoveAccessPolicy(string resourceGroupName, string cacheName, string accessPolicyName)
        {
            _client.AccessPolicy.Delete(resourceGroupName, cacheName, accessPolicyName);
        }

        internal RedisCacheAccessPolicyAssignment SetAccessPolicyAssignment(string resourceGroupName, string cacheName, string accessPolicyAssignmentName, string accessPolicyName, string objectId, string objectIdAlias)
        {
            RedisCacheAccessPolicyAssignment parameters = new RedisCacheAccessPolicyAssignment
            {
                AccessPolicyName = accessPolicyName,
                ObjectId = objectId,
                ObjectIdAlias = objectIdAlias
            };
            return _client.AccessPolicyAssignment.CreateUpdate(resourceGroupName, cacheName, accessPolicyAssignmentName, parameters);
        }

        internal RedisCacheAccessPolicyAssignment GetAccessPolicyAssignment(string resourceGroupName, string cacheName, string accessPolicyAssignmentName)
        {
            return _client.AccessPolicyAssignment.Get(resourceGroupName, cacheName, accessPolicyAssignmentName);
        }

        internal IPage<RedisCacheAccessPolicyAssignment> ListAccessPolicyAssignments(string resourceGroupName, string cacheName)
        {
            return _client.AccessPolicyAssignment.List(resourceGroupName, cacheName);
        }

        internal IPage<RedisCacheAccessPolicyAssignment> ListAccessPolicyAssignments(string nextLink)
        {
            return _client.AccessPolicyAssignment.ListNext(nextLink);
        }

        internal void RemoveAccessPolicyAssignment(string resourceGroupName, string cacheName, string accessPolicyAssignmentName)
        {
            _client.AccessPolicyAssignment.Delete(resourceGroupName, cacheName, accessPolicyAssignmentName);
        }
    }
}
