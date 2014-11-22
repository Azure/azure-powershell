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
    using Microsoft.Azure.Management.Redis;
    using Microsoft.Azure.Management.Redis.Models;
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.WindowsAzure.Commands.Common.Models;

    public class RedisCacheClient
    {
        private RedisManagementClient _client;
        public RedisCacheClient(AzureContext context)
        {
            _client = AzureSession.ClientFactory.CreateClient<RedisManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }
        public RedisCacheClient() { }

        public RedisCreateOrUpdateResponse CreateOrUpdateCache(string resourceGroupName, string cacheName, string location, string redisVersion, string skuFamily, int skuCapacity, string skuName, string maxMemoryPolicy, bool? enableNonSslPort)
        {
            RedisCreateOrUpdateParameters parameters = new RedisCreateOrUpdateParameters
                                                    {
                                                        Location = location,
                                                        Properties = new RedisProperties
                                                        {
                                                            RedisVersion = redisVersion,
                                                            Sku = new Sku() { 
                                                                Name = skuName,
                                                                Family = skuFamily,
                                                                Capacity = skuCapacity
                                                            }
                                                        }
                                                    };

            if (!string.IsNullOrEmpty(maxMemoryPolicy))
            {
                parameters.Properties.MaxMemoryPolicy = maxMemoryPolicy;
            }

            if (enableNonSslPort.HasValue)
            {
                parameters.Properties.EnableNonSslPort = enableNonSslPort.Value;
            }
            RedisCreateOrUpdateResponse response = _client.Redis.CreateOrUpdate(resourceGroupName: resourceGroupName, name: cacheName, parameters: parameters);
            return response;
        }

        public OperationResponse DeleteCache(string resourceGroupName, string cacheName)
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
        
        public OperationResponse RegenerateAccessKeys(string resourceGroupName, string cacheName, RedisKeyType keyType)
        {
            return _client.Redis.RegenerateKey(resourceGroupName: resourceGroupName, name: cacheName, parameters: new RedisRegenerateKeyParameters() { KeyType = keyType });
        }

        public RedisListKeysResponse GetAccessKeys(string resourceGroupName, string cacheName)
        {
            return _client.Redis.ListKeys(resourceGroupName: resourceGroupName, name: cacheName);
        }
    }
}
