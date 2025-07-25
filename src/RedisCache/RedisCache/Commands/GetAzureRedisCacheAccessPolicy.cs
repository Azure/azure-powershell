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
    using Microsoft.Azure.Commands.RedisCache.Models;
    using Microsoft.Azure.Commands.RedisCache.Properties;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Rest.Azure;
    using ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.RedisCache.Models;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RedisCacheAccessPolicy", DefaultParameterSetName = NormalParameterSet), OutputType(typeof(PSRedisAccessPolicy))]
    public class GetAzureRedisCacheAccessPolicy : RedisCacheCmdletBase
    {
        private const string NormalParameterSet = "NormalParameterSet";
        private const string ParentObjectParameterSet = "CacheObjectParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group in which cache exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of Redis Cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "ARM Id of Redis Cache Access Policy")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParentObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Object of type RedisCacheAttributes")]
        [ValidateNotNull]
        public RedisCacheAttributes TopLevelResourceObject { get; set; }

        [Parameter(ParameterSetName = NormalParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of Access Policy.")]
        [Parameter(ParameterSetName = ParentObjectParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of Access Policy.")]
        public string AccessPolicyName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet))
            {
                FetchResourceGroupNameAndCacheNameFromParentObject();
            }
            else if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                FetchDetailsFromChildResourceId();
            }
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            ResourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(ResourceGroupName, Name);

            if (!string.IsNullOrEmpty(AccessPolicyName))
            {
                RedisCacheAccessPolicy redisAccessPolicy = CacheClient.GetAccessPolicy(
                    resourceGroupName: ResourceGroupName,
                    cacheName: Name,
                    accessPolicyName: AccessPolicyName);

                if (redisAccessPolicy == null)
                {
                    throw new CloudException(string.Format(Resources.AccessPolicyNotFound, Name, AccessPolicyName));
                }
                WriteObject(new PSRedisAccessPolicy(ResourceGroupName, Name, redisAccessPolicy));
            }
            else
            {
                IPage<RedisCacheAccessPolicy> response = CacheClient.ListAccessPolicies(ResourceGroupName, Name);
                List<PSRedisAccessPolicy> list = new List<PSRedisAccessPolicy>();
                foreach (RedisCacheAccessPolicy redisAccessPolicy in response)
                {
                    list.Add(new PSRedisAccessPolicy(ResourceGroupName, Name, redisAccessPolicy));
                }
                
                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    response = CacheClient.ListAccessPolicies(response.NextPageLink);
                    foreach (RedisCacheAccessPolicy redisAccessPolicy in response)
                    {
                        list.Add(new PSRedisAccessPolicy(ResourceGroupName, Name, redisAccessPolicy));
                    }
                }
                WriteObject(list, true);
            }
        }
        private void FetchDetailsFromChildResourceId()
        {
            (ResourceGroupName, Name, AccessPolicyName) = Utility.GetDetailsFromRedisCacheChildResourceId(ResourceId);
        }
        private void FetchResourceGroupNameAndCacheNameFromParentObject()
        {
            ResourceGroupName = TopLevelResourceObject.ResourceGroupName;
            Name = TopLevelResourceObject.Name;
        }
    }
}
