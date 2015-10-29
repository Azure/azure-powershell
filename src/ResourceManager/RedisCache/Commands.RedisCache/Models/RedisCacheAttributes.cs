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

namespace Microsoft.Azure.Commands.RedisCache.Models
{
    using Microsoft.Azure.Management.Redis.Models;
    using System.Collections;
    using System.Collections.Generic;

    public class RedisCacheAttributes
    {
        public RedisCacheAttributes(RedisResource cache, string resourceGroupName)
        {
            Id = cache.Id;
            Location = cache.Location;
            Name = cache.Name;
            Type = cache.Type;
            HostName = cache.Properties.HostName;
            Port = cache.Properties.Port;
            ProvisioningState = cache.Properties.ProvisioningState;
            SslPort = cache.Properties.SslPort;
            RedisConfiguration = cache.Properties.RedisConfiguration;
            EnableNonSslPort = cache.Properties.EnableNonSslPort.Value;
            RedisVersion = cache.Properties.RedisVersion;
            Size = SizeConverter.GetSizeInUserSpecificFormat(cache.Properties.Sku.Family, cache.Properties.Sku.Capacity);
            Sku = cache.Properties.Sku.Name;
            ResourceGroupName = resourceGroupName; 
            VirtualNetwork = cache.Properties.VirtualNetwork;
            Subnet = cache.Properties.Subnet;
            StaticIP = cache.Properties.StaticIP;
            TenantSettings = cache.Properties.TenantSettings;
            ShardCount = cache.Properties.ShardCount;
        }

        public RedisCacheAttributes(RedisGetResponse cache, string resourceGroupName)
            : this(cache.Resource, resourceGroupName)
        {}

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

        public string VirtualNetwork { get; protected set; }

        public string Subnet { get; protected set; }

        public string StaticIP { get; protected set; }
    }
}