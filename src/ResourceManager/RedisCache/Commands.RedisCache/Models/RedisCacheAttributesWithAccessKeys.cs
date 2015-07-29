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
        public RedisCacheAttributesWithAccessKeys(RedisCreateOrUpdateResponse cache, string resourceGroupName)
        {
            Id = cache.Resource.Id;
            Location = cache.Resource.Location;
            Name = cache.Resource.Name;
            Type = cache.Resource.Type;
            HostName = cache.Resource.Properties.HostName;
            Port = cache.Resource.Properties.Port;
            ProvisioningState = cache.Resource.Properties.ProvisioningState;
            SslPort = cache.Resource.Properties.SslPort;
            RedisConfiguration = cache.Resource.Properties.RedisConfiguration;
            EnableNonSslPort = cache.Resource.Properties.EnableNonSslPort.Value;
            RedisVersion = cache.Resource.Properties.RedisVersion;
            Size = SizeConverter.GetSizeInUserSpecificFormat(cache.Resource.Properties.Sku.Family, cache.Resource.Properties.Sku.Capacity);
            Sku = cache.Resource.Properties.Sku.Name;

            PrimaryKey = cache.Resource.Properties.AccessKeys.PrimaryKey;
            SecondaryKey = cache.Resource.Properties.AccessKeys.SecondaryKey;
            ResourceGroupName = resourceGroupName;
        }

        public string PrimaryKey { get; private set; }
        public string SecondaryKey { get; private set; }
    }
}