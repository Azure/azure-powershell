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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.RedisCache
{
    using Microsoft.Azure.Management.Insights;
    using Microsoft.Azure.Management.Insights.Models;
    using Microsoft.Azure.Management.Redis;
    using Microsoft.Azure.Management.Redis.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Rest.Azure;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class RedisCacheClient
    {
        private RedisManagementClient _client;
        private InsightsManagementClient _insightsClient;
        private ResourceManagementClient _resourceManagementClient;

        public RedisCacheClient(AzureContext context)
        {
            _client = AzureSession.ClientFactory.CreateArmClient<RedisManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            _insightsClient = AzureSession.ClientFactory.CreateClient<InsightsManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            _resourceManagementClient = AzureSession.ClientFactory.CreateClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }
        public RedisCacheClient() { }

        public RedisResourceWithAccessKey CreateOrUpdateCache(string resourceGroupName, string cacheName, string location, string skuFamily, int skuCapacity, string skuName,
                Hashtable redisConfiguration, bool? enableNonSslPort, Hashtable tenantSettings, int? shardCount, string subnetId, string staticIP, IDictionary<string, string> tags = null)
        {
            _resourceManagementClient.Providers.Register("Microsoft.Cache");
            RedisCreateOrUpdateParameters parameters = new RedisCreateOrUpdateParameters
            {
                Location = location,
                Sku = new Microsoft.Azure.Management.Redis.Models.Sku
                {
                    Name = skuName,
                    Family = skuFamily,
                    Capacity = skuCapacity
                }
            };

            if (tags != null)
            {
                parameters.Tags = tags;
            }

            if (redisConfiguration != null)
            {
                parameters.RedisConfiguration = new Dictionary<string, string>();
                foreach (object key in redisConfiguration.Keys)
                {
                    parameters.RedisConfiguration.Add(key.ToString(), redisConfiguration[key].ToString());
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

            if (!string.IsNullOrWhiteSpace(subnetId))
            {
                parameters.SubnetId = subnetId;
            }

            if (!string.IsNullOrWhiteSpace(staticIP))
            {
                parameters.StaticIP = staticIP;
            }

            RedisResourceWithAccessKey response = _client.Redis.CreateOrUpdate(resourceGroupName: resourceGroupName, name: cacheName, parameters: parameters);
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

        public IPage<RedisResource> ListCaches(string resourceGroupName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                return _client.Redis.List();
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
                return _client.Redis.ListNext(nextPageLink: nextLink);
            }
            else
            {
                return _client.Redis.ListByResourceGroupNext(nextPageLink: nextLink);
            }
        }

        public RedisListKeysResult RegenerateAccessKeys(string resourceGroupName, string cacheName, RedisKeyType keyType)
        {
            return _client.Redis.RegenerateKey(resourceGroupName: resourceGroupName, name: cacheName, parameters: new RedisRegenerateKeyParameters() { KeyType = keyType });
        }

        public RedisListKeysResult GetAccessKeys(string resourceGroupName, string cacheName)
        {
            return _client.Redis.ListKeys(resourceGroupName: resourceGroupName, name: cacheName);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void SetDiagnostics(string cacheId, string storageAccountName)
        {
            _insightsClient.ServiceDiagnosticSettingsOperations.Put(
                resourceUri: cacheId,
                parameters: new ServiceDiagnosticSettingsPutParameters
                {
                    Properties = new ServiceDiagnosticSettings
                    {
                        StorageAccountName = storageAccountName
                    }
                }
            );
        }

        public void ImportToCache(string resourceGroupName, string cacheName, string[] blobUrisWithSasTokens, string format)
        {
            ImportRDBParameters parameters = new ImportRDBParameters();
            parameters.Files = blobUrisWithSasTokens;
            if (!string.IsNullOrWhiteSpace(format))
            {
                parameters.Format = format;
            }
            _client.Redis.Import(resourceGroupName: resourceGroupName, name: cacheName, parameters: parameters);
        }

        public void ExportToCache(string resourceGroupName, string cacheName, string containerUrisWithSasTokens, string prefix, string format)
        {
            ExportRDBParameters parameters = new ExportRDBParameters();
            parameters.Container = containerUrisWithSasTokens;
            parameters.Prefix = prefix;
            if (!string.IsNullOrWhiteSpace(format))
            {
                parameters.Format = format;
            }
            _client.Redis.Export(resourceGroupName: resourceGroupName, name: cacheName, parameters: parameters);
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

        public IList<ScheduleEntry> SetPatchSchedules(string resourceGroupName, string cacheName, List<ScheduleEntry> schedules)
        {
            var response = _client.PatchSchedules.CreateOrUpdate(resourceGroupName, cacheName, new RedisPatchSchedulesRequest { ScheduleEntries = schedules });
            return response.ScheduleEntries;
        }

        public IList<ScheduleEntry> GetPatchSchedules(string resourceGroupName, string cacheName)
        {
            var response = _client.PatchSchedules.Get(resourceGroupName, cacheName);
            return response.ScheduleEntries;
        }

        public void RemovePatchSchedules(string resourceGroupName, string cacheName)
        {
            _client.PatchSchedules.Delete(resourceGroupName, cacheName);
        }
    }
}
