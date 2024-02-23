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
    using System;
    using Microsoft.Azure.Management.RedisCache.Models;

    public class PSRedisAccessPolicy
    {
        public string ResourceGroupName { get; set; }
        public string Name { get; set; }

        public string AccessPolicyId { get; set; }
        public string AccessPolicyName { get; set; }
        public string AccessPolicyType { get; set; }
        public string ProvisioningState { get; set; }
        public string Permission { get; set; }

        public PSRedisAccessPolicy() { }

        internal PSRedisAccessPolicy(string resourceGroupName, string cacheName, RedisCacheAccessPolicy redisAccessPolicy)
        {
            ResourceGroupName = resourceGroupName;
            Name = cacheName;

            AccessPolicyId = redisAccessPolicy.Id;
            AccessPolicyName = NormalizeAccessPolicyName(redisAccessPolicy.Name);
            AccessPolicyType = redisAccessPolicy.PropertiesType;
            ProvisioningState = redisAccessPolicy.ProvisioningState;
            Permission = redisAccessPolicy.Permissions;
        }

        internal string NormalizeAccessPolicyName(string ruleName)
        {
            if (string.IsNullOrWhiteSpace(ruleName) || !ruleName.Contains("/"))
            {
                return ruleName;
            }
            return ruleName.Substring(ruleName.IndexOf("/") + 1);
        }
    }
}