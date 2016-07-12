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

namespace Microsoft.Azure.Commands.RedisCache.Models
{
    using Microsoft.Azure.Management.Redis.Models;
    using System.Collections.Generic;

    public class RedisCacheAttributes
    {
        public RedisCacheAttributes(RedisResource cache, string resourceGroupName)
        {
            Id = cache.Id;
            Location = cache.Location;
            Name = cache.Name;
            Type = cache.Type;
            HostName = cache.HostName;
            Port = cache.Port.HasValue ? cache.Port.Value : 0;
            ProvisioningState = cache.ProvisioningState;
            SslPort = cache.SslPort.HasValue ? cache.SslPort.Value : 0;
            RedisConfiguration = cache.RedisConfiguration;
            EnableNonSslPort = cache.EnableNonSslPort.Value;
            RedisVersion = cache.RedisVersion;
            Size = SizeConverter.GetSizeInUserSpecificFormat(cache.Sku.Family, cache.Sku.Capacity);
            Sku = cache.Sku.Name;
            ResourceGroupName = resourceGroupName;
            SubnetId = cache.SubnetId;
            StaticIP = cache.StaticIP;
            TenantSettings = cache.TenantSettings;
            ShardCount = cache.ShardCount;
        }

        public RedisCacheAttributes() { }

        private string _resourceGroupName;
        public string ResourceGroupName
        {
            get
            {
                return _resourceGroupName;
            }

            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _resourceGroupName = value;
                }
                else
                {
                    // if resource group name is null (when try to get all cache in given subscription it will be null) we have to fetch it from Id.
                    _resourceGroupName = Id.Split('/')[4];
                }
            }
        }

        public string Id { get; protected set; }

        public string Location { get; protected set; }

        public string Name { get; protected set; }

        public string Type { get; protected set; }

        public string HostName { get; protected set; }

        public int Port { get; protected set; }

        public string ProvisioningState { get; protected set; }

        public int SslPort { get; protected set; }

        public IDictionary<string, string> RedisConfiguration { get; protected set; }

        public bool EnableNonSslPort { get; protected set; }

        public string RedisVersion { get; protected set; }

        public string Size { get; protected set; }

        public string Sku { get; protected set; }

        public IDictionary<string, string> TenantSettings { get; protected set; }

        public int? ShardCount { get; protected set; }

        public string SubnetId { get; protected set; }

        public string StaticIP { get; protected set; }
    }
}