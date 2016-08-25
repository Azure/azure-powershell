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
    using Microsoft.Azure.Management.Redis.Models;
    using Microsoft.Rest.Azure;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get, "AzureRmRedisCache", DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(List<RedisCacheAttributes>))]
    public class GetAzureRedisCache : RedisCacheCmdletBase
    {
        internal const string BaseParameterSetName = "All In Subscription";
        internal const string ResourceGroupParameterSetName = "All In Resource Group";
        internal const string RedisCacheParameterSetName = "Specific Redis Cache";

        [Parameter(ParameterSetName = ResourceGroupParameterSetName, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which want to create cache.")]
        [Parameter(ParameterSetName = RedisCacheParameterSetName, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which want to create cache.")]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = RedisCacheParameterSetName, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(Name))
            {
                // Get for single cache
                WriteObject(new RedisCacheAttributes(CacheClient.GetCache(ResourceGroupName, Name), ResourceGroupName));
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