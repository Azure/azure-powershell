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
    using Microsoft.Azure.Management.Redis.Models;
    using System.Collections;
    using System.Management.Automation;
    using SkuStrings = Microsoft.Azure.Management.Redis.Models.SkuName;
    using Hyak.Common;
    using System;
        
    [Cmdlet(VerbsCommon.Set, "AzureRmRedisCache", DefaultParameterSetName = MaxMemoryParameterSetName), OutputType(typeof(RedisCacheAttributesWithAccessKeys))]
    public class SetAzureRedisCache : RedisCacheCmdletBase
    {
        internal const string MaxMemoryParameterSetName = "Only MaxMemoryPolicy";

        [Parameter(ParameterSetName = MaxMemoryParameterSetName, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which you want to create cache.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = MaxMemoryParameterSetName, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Size of redis cache. Valid values: C0, C1, C2, C3, C4, C5, C6, 250MB, 1GB, 2.5GB, 6GB, 13GB, 26GB, 53GB")]
        [ValidateSet(SizeConverter.C0String, SizeConverter.C1String, SizeConverter.C2String, SizeConverter.C3String, SizeConverter.C4String, SizeConverter.C5String,
            SizeConverter.C6String, SizeConverter.C0, SizeConverter.C1, SizeConverter.C2, SizeConverter.C3, SizeConverter.C4, SizeConverter.C5, SizeConverter.C6, IgnoreCase = false)]
        public string Size { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Wheather want to create Basic (1 Node) or Standard (2 Node) cache.")]
        [ValidateSet(SkuStrings.Basic, SkuStrings.Standard, IgnoreCase = false)]
        public string Sku { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "MaxMemoryPolicy is deprecated. Please use RedisConfiguration instead.")]
        public string MaxMemoryPolicy { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "A hash table which represents redis configuration properties.")]
        public Hashtable RedisConfiguration { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "EnableNonSslPort property of redis cache.")]
        public bool? EnableNonSslPort { get; set; }

        protected override void ProcessRecord()
        {
            if (!string.IsNullOrEmpty(MaxMemoryPolicy))
            {
                throw new ArgumentException(Resources.MaxMemoryPolicyException);
            }

            RedisGetResponse response = CacheClient.GetCache(ResourceGroupName, Name);

            string skuName;
            string skuFamily;
            int skuCapacity;

            if (string.IsNullOrEmpty(Sku))
            {
                skuName = response.Resource.Properties.Sku.Name;
            }
            else
            {
                skuName = Sku;
            }

            if (string.IsNullOrEmpty(Size))
            {
                skuFamily = response.Resource.Properties.Sku.Family;
                skuCapacity = response.Resource.Properties.Sku.Capacity;
            }
            else
            {
                Size = SizeConverter.GetSizeInRedisSpecificFormat(Size);
                skuFamily = Size.Substring(0, 1);
                int.TryParse(Size.Substring(1), out skuCapacity);
            }
            
            
            WriteObject(new RedisCacheAttributesWithAccessKeys(
                CacheClient.CreateOrUpdateCache(ResourceGroupName, Name, response.Resource.Location, response.Resource.Properties.RedisVersion,
                    skuFamily, skuCapacity, skuName, RedisConfiguration, EnableNonSslPort), 
                ResourceGroupName));
        }
    }
}