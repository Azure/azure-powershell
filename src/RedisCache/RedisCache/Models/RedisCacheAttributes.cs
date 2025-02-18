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
    using Microsoft.Azure.Management.RedisCache.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Reflection;

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

            EnableNonSslPort = cache.EnableNonSslPort.Value;
            RedisVersion = cache.RedisVersion;
            UpdateChannel = cache.UpdateChannel;
            Size = SizeConverter.GetSizeInUserSpecificFormat(cache.Sku.Family, cache.Sku.Capacity);
            Sku = cache.Sku.Name;
            ResourceGroupName = resourceGroupName;
            SubnetId = cache.SubnetId;
            StaticIP = cache.StaticIP;
            TenantSettings = cache.TenantSettings;
            ShardCount = cache.ShardCount;
            MinimumTlsVersion = cache.MinimumTlsVersion;
            DisableAccessKeyAuthentication = cache.DisableAccessKeyAuthentication;
            ZonalAllocationPolicy = cache.ZonalAllocationPolicy;

            Tag = cache.Tags;
            Zone = cache.Zones;
            RedisConfiguration = new Dictionary<string, string>();

            // Converting cache.RedisConfiguration Object into a readable dictionary using the json attributes
            if (cache.RedisConfiguration != null)
            {
                foreach (PropertyInfo property in cache.RedisConfiguration.GetType().GetProperties())
                {
                    System.Attribute attr = property.GetCustomAttribute(typeof(JsonPropertyAttribute));
                    if (property.GetValue(cache.RedisConfiguration) != null && attr != null)
                    {
                        JsonPropertyAttribute jsonAttr = (JsonPropertyAttribute)attr;
                        RedisConfiguration[jsonAttr.PropertyName] = (string)property.GetValue(cache.RedisConfiguration);
                    }

                }
                if (cache.RedisConfiguration.AdditionalProperties != null)
                {
                    foreach (KeyValuePair<string, object> kvPair in cache.RedisConfiguration.AdditionalProperties)
                    {
                        RedisConfiguration[kvPair.Key] = (string)kvPair.Value;
                    }
                }
            }

            // Converting cache.Identity Object into a readable SystemAssignedIdenty dictionary and UserAssignedIdentities list
            if (cache.Identity != null)
            {
                IdentityType = "";
                if (cache.Identity.PrincipalId != null)
                {
                    SystemAssignedIdentity = new Dictionary<string, string>
                    {
                        { nameof(cache.Identity.PrincipalId), cache.Identity.PrincipalId.ToString() },
                        { nameof(cache.Identity.TenantId), cache.Identity.TenantId.ToString() }
                    };
                    IdentityType = nameof(ManagedServiceIdentityType.SystemAssigned);
                }
                if (cache.Identity.UserAssignedIdentities?.Count > 0)
                {
                    UserAssignedIdentity = new List<string>();
                    foreach (var identity in cache.Identity.UserAssignedIdentities)
                    {
                        UserAssignedIdentity.Add(identity.Key);
                    }
                    if (nameof(ManagedServiceIdentityType.SystemAssigned).Equals(IdentityType))
                    {
                        IdentityType = nameof(ManagedServiceIdentityType.SystemAssignedUserAssigned);
                    }
                    else
                    {
                        IdentityType = nameof(ManagedServiceIdentityType.UserAssigned);
                    }

                }
            }
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
                    _resourceGroupName = Utility.GetResourceGroupNameFromRedisCacheId(Id);
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

        public string UpdateChannel { get; protected set; }

        public string ZonalAllocationPolicy { get; protected set; }

        public string Size { get; protected set; }

        public string Sku { get; protected set; }

        public IDictionary<string, string> TenantSettings { get; protected set; }

        public int? ShardCount { get; protected set; }

        public string MinimumTlsVersion { get; protected set; }

        public bool? DisableAccessKeyAuthentication { get; protected set; }

        public string SubnetId { get; protected set; }

        public string StaticIP { get; protected set; }

        public IDictionary<string, string> Tag { get; protected set; }

        public IList<string> Zone { get; protected set; }

        public string IdentityType { get; protected set; }

        public IDictionary<string, string> SystemAssignedIdentity { get; protected set; }

        public IList<string> UserAssignedIdentity { get; protected set; }

    }
}