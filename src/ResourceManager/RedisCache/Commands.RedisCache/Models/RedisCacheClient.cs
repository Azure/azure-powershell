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

namespace Microsoft.Azure.Commands.RedisCache
{
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Common.Authentication.Models;
    using Microsoft.Azure.Management.Redis;
    using Microsoft.Azure.Management.Redis.Models;
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Commands.Common;
    using System.Collections;
    using System.Collections.Generic;

    public class RedisCacheClient
    {
        private RedisManagementClient _client;
        public RedisCacheClient(AzureContext context)
        {
            _client = AzureSession.ClientFactory.CreateClient<RedisManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }
        public RedisCacheClient() { }

        public RedisCreateOrUpdateResponse CreateOrUpdateCache(string resourceGroupName, string cacheName, string location, string skuFamily, int skuCapacity, string skuName,
                Hashtable redisConfiguration, bool? enableNonSslPort, Hashtable tenantSettings, int? shardCount, string virtualNetwork, string subnet, string staticIP)
        {
            RedisCreateOrUpdateParameters parameters = new RedisCreateOrUpdateParameters
                                                    {
                                                        Location = location,
                                                        Properties = new RedisProperties
                                                        {
                                                            Sku = new Sku() { 
                                                                Name = skuName,
                                                                Family = skuFamily,
                                                                Capacity = skuCapacity
                                                            }
                                                        }
                                                    };

            if (redisConfiguration != null)
            {
                parameters.Properties.RedisConfiguration = new Dictionary<string, string>();
                foreach (object key in redisConfiguration.Keys)
                {
                    parameters.Properties.RedisConfiguration.Add(key.ToString(), redisConfiguration[key].ToString());
                }
            }

            if (enableNonSslPort.HasValue)
            {
                parameters.Properties.EnableNonSslPort = enableNonSslPort.Value;
            }

            if (tenantSettings != null)
            {
                parameters.Properties.TenantSettings = new Dictionary<string, string>();
                foreach (object key in tenantSettings.Keys)
                {
                    parameters.Properties.TenantSettings.Add(key.ToString(), tenantSettings[key].ToString());
                }
            }

            parameters.Properties.ShardCount = shardCount;
            
            if (!string.IsNullOrWhiteSpace(virtualNetwork))
            {
                parameters.Properties.VirtualNetwork = virtualNetwork;
            }

            if (!string.IsNullOrWhiteSpace(subnet))
            {
                parameters.Properties.Subnet = subnet;
            }

            if (!string.IsNullOrWhiteSpace(staticIP))
            {
                parameters.Properties.StaticIP = staticIP;
            }

            RedisCreateOrUpdateResponse response = _client.Redis.CreateOrUpdate(resourceGroupName: resourceGroupName, name: cacheName, parameters: parameters);
            return response;
        }

        public AzureOperationResponse DeleteCache(string resourceGroupName, string cacheName)
        {
            return _client.Redis.Delete(resourceGroupName: resourceGroupName, name: cacheName);
        }

        public RedisGetResponse GetCache(string resourceGroupName, string cacheName)
        {
            return _client.Redis.Get(resourceGroupName: resourceGroupName, name: cacheName);
        }

        public RedisListResponse ListCaches(string resourceGroupName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                return _client.Redis.List(null);
            }
            else
            {
                return _client.Redis.List(resourceGroupName: resourceGroupName);
            }
        }

        public RedisListResponse ListCachesUsingNextLink(string nextLink)
        {
            return _client.Redis.ListNext(nextLink: nextLink);
        }
        
        public AzureOperationResponse RegenerateAccessKeys(string resourceGroupName, string cacheName, RedisKeyType keyType)
        {
            return _client.Redis.RegenerateKey(resourceGroupName: resourceGroupName, name: cacheName, parameters: new RedisRegenerateKeyParameters() { KeyType = keyType });
        }

        public RedisListKeysResponse GetAccessKeys(string resourceGroupName, string cacheName)
        {
            return _client.Redis.ListKeys(resourceGroupName: resourceGroupName, name: cacheName);
        }
    }
}
