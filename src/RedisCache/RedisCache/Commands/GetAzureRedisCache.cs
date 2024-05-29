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
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.RedisCache.Models;
    using Microsoft.Rest.Azure;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RedisCache"), OutputType(typeof(RedisCacheAttributes))]
    public class GetAzureRedisCache : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group under which want to create cache.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of redis cache.")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            if (!string.IsNullOrEmpty(Name))
            {
                if (!string.IsNullOrEmpty(ResourceGroupName))
                {
                    // Get single cache directly by RP call
                    WriteObject(new RedisCacheAttributes(CacheClient.GetCache(ResourceGroupName, Name), ResourceGroupName));
                }
                else
                {
                    // Get single cache from list of caches
                    RedisResource response = CacheClient.GetCache(Name);
                    WriteObject(new RedisCacheAttributes(response, Utility.GetResourceGroupNameFromRedisCacheId(response.Id)));
                }
            }
            else
            {
                // List all cache in given resource group if avaliable otherwise all cache in given subscription
                IPage<RedisResource> response = CacheClient.ListCaches(ResourceGroupName);
                List<RedisCacheAttributes> list = new List<RedisCacheAttributes>();
                foreach (RedisResource resource in response)
                {
                    list.Add(new RedisCacheAttributes(resource, ResourceGroupName));
                }
                WriteObject(list, true);

                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    // List using next link
                    response = CacheClient.ListCachesUsingNextLink(ResourceGroupName, response.NextPageLink);
                    list = new List<RedisCacheAttributes>();
                    foreach (RedisResource resource in response)
                    {
                        list.Add(new RedisCacheAttributes(resource, ResourceGroupName));
                    }
                    WriteObject(list, true);
                }
            }
        }
    }
}
