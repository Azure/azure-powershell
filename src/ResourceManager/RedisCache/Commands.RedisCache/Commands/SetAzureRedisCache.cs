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
    using System.Management.Automation;
    using MaxMemoryPolicyStrings = Microsoft.Azure.Management.Redis.Models.MaxMemoryPolicy;

    [Cmdlet(VerbsCommon.Set, "AzureRedisCache", DefaultParameterSetName = MaxMemoryParameterSetName), OutputType(typeof(RedisCacheAttributesWithAccessKeys))]
    public class SetAzureRedisCache : RedisCacheCmdletBase
    {
        internal const string MaxMemoryParameterSetName = "Only MaxMemoryPolicy";

        [Parameter(ParameterSetName = MaxMemoryParameterSetName, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which you want to create cache.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = MaxMemoryParameterSetName, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = MaxMemoryParameterSetName, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "MaxMemoryPolicy property of redis cache. Valid values: AllKeysLRU, AllKeysRandom, NoEviction, VolatileLRU, VolatileRandom, VolatileTTL")]
        [ValidateSet(MaxMemoryPolicyStrings.AllKeysLRU, MaxMemoryPolicyStrings.AllKeysRandom, MaxMemoryPolicyStrings.NoEviction, 
            MaxMemoryPolicyStrings.VolatileLRU, MaxMemoryPolicyStrings.VolatileRandom, MaxMemoryPolicyStrings.VolatileTTL, IgnoreCase = false)]
        public string MaxMemoryPolicy { get; set;}

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "EnableNonSslPort property of redis cache.")]
        public bool? EnableNonSslPort { get; set; }

        public override void ExecuteCmdlet()
        {
            RedisGetResponse response = CacheClient.GetCache(ResourceGroupName, Name);
            WriteObject(new RedisCacheAttributesWithAccessKeys(
                CacheClient.CreateOrUpdateCache(ResourceGroupName, Name, response.Location, response.Properties.RedisVersion,
                    response.Properties.Sku.Family, response.Properties.Sku.Capacity, response.Properties.Sku.Name, MaxMemoryPolicy, EnableNonSslPort), 
                ResourceGroupName));
        }
    }
}