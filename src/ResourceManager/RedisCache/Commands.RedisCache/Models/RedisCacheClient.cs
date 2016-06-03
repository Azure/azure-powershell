﻿// ----------------------------------------------------------------------------------
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
                Hashtable redisConfiguration, bool? enableNonSslPort, Hashtable tenantSettings, int? shardCount, string virtualNetwork, string subnet, string staticIP)
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

            if (!string.IsNullOrWhiteSpace(virtualNetwork))
            {
                parameters.VirtualNetwork = virtualNetwork;
            }

            if (!string.IsNullOrWhiteSpace(subnet))
            {
                parameters.Subnet = subnet;
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
    }
}
