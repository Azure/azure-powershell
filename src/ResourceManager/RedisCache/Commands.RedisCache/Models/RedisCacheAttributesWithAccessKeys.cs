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

    public class RedisCacheAttributesWithAccessKeys : RedisCacheAttributes
    {
        public RedisCacheAttributesWithAccessKeys(RedisResourceWithAccessKey cache, string resourceGroupName)
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

            PrimaryKey = cache.AccessKeys.PrimaryKey;
            SecondaryKey = cache.AccessKeys.SecondaryKey;
            ResourceGroupName = resourceGroupName;

            SubnetId = cache.SubnetId;
            StaticIP = cache.StaticIP;
            TenantSettings = cache.TenantSettings;
            ShardCount = cache.ShardCount;
        }

        public string PrimaryKey { get; private set; }
        public string SecondaryKey { get; private set; }
    }
}