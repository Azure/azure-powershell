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

    public class PSRedisAccessPolicyAssignment
    {
        public string ResourceGroupName { get; set; }
        public string Name { get; set; }
        public string AccessPolicyAssignmentId { get; }
        public string AccessPolicyAssignmentName { get; }
        public string AccessPolicyName { get; }
        public string ProvisioningState { get; }
        public string ObjectId { get; }
        public object ObjectIdAlias { get; }

        public PSRedisAccessPolicyAssignment() { }

        internal PSRedisAccessPolicyAssignment(string resourceGroupName, string cacheName, RedisCacheAccessPolicyAssignment redisAccessPolicyAssignment)
        {
            ResourceGroupName = resourceGroupName;
            Name = cacheName;

            AccessPolicyAssignmentId = redisAccessPolicyAssignment.Id;
            AccessPolicyAssignmentName = NormalizeAccessPolicyName(redisAccessPolicyAssignment.Name);
            AccessPolicyName = redisAccessPolicyAssignment.AccessPolicyName;
            ProvisioningState = redisAccessPolicyAssignment.ProvisioningState;
            ObjectId = redisAccessPolicyAssignment.ObjectId;
            ObjectIdAlias = redisAccessPolicyAssignment.ObjectIdAlias;
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