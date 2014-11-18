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
    using Microsoft.WindowsAzure;
    using System.Management.Automation;
    using SkuStrings = Microsoft.Azure.Management.Redis.Models.SkuName;
    using MaxMemoryPolicyStrings = Microsoft.Azure.Management.Redis.Models.MaxMemoryPolicy;

    [Cmdlet(VerbsCommon.New, "AzureRedisCache"), OutputType(typeof(RedisCacheAttributesWithAccessKeys))]
    public class NewAzureRedisCache : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which you want to create cache.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Location where want to create cache.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("North Central US", "South Central US", "Central US", "West Europe", "North Europe", "West US", "East US", 
            "East US 2", "Japan East", "Japan West", "Brazil South", "Southeast Asia", "East Asia", "Australia East", "Australia Southeast", IgnoreCase = false)]
        public string Location { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Redis version.")]
        public string RedisVersion { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Size of redis cache. Valid values: C0, C1, C2, C3, C4, C5, C6, 250MB, 1GB, 2.5GB, 6GB, 13GB, 26GB, 53GB")]
        [ValidateSet(SizeConverter.C0String, SizeConverter.C1String, SizeConverter.C2String, SizeConverter.C3String, SizeConverter.C4String, SizeConverter.C5String,
            SizeConverter.C6String, SizeConverter.C0, SizeConverter.C1, SizeConverter.C2, SizeConverter.C3, SizeConverter.C4, SizeConverter.C5, SizeConverter.C6, IgnoreCase = false)]
        public string Size { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Wheather want to create Basic (1 Node) or Standard (2 Node) cache.")]
        [ValidateSet(SkuStrings.Basic, SkuStrings.Standard, IgnoreCase = false)]
        public string Sku { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "MaxMemoryPolicy property of redis cache. Valid values: AllKeysLRU, AllKeysRandom, NoEviction, VolatileLRU, VolatileRandom, VolatileTTL")]
        [ValidateSet(MaxMemoryPolicyStrings.AllKeysLRU, MaxMemoryPolicyStrings.AllKeysRandom, MaxMemoryPolicyStrings.NoEviction, 
            MaxMemoryPolicyStrings.VolatileLRU, MaxMemoryPolicyStrings.VolatileRandom, MaxMemoryPolicyStrings.VolatileTTL, IgnoreCase = false)]
        public string MaxMemoryPolicy { get; set;}

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "EnableNonSslPort property of redis cache.")]
        public bool? EnableNonSslPort { get; set; }

        private const string redisDefaultVersion = "2.8";

        public override void ExecuteCmdlet()
        {
            string skuFamily;

            int skuCapacity = 1;

            if (string.IsNullOrEmpty(RedisVersion))
            {
                RedisVersion = redisDefaultVersion;
            }

            if (string.IsNullOrEmpty(Size))
            {
                Size = SizeConverter.C1String;
            }
            else
            {
                Size = SizeConverter.GetSizeInRedisSpecificFormat(Size);
            }

            // Size to SkuFamily and SkuCapacity conversion
            skuFamily = Size.Substring(0, 1);
            int.TryParse(Size.Substring(1), out skuCapacity);

            if (string.IsNullOrEmpty(Sku))
            {
                Sku = SkuStrings.Standard;
            }

            // If Force flag is not avaliable than check if cache is already available or not
            try
            {
                RedisGetResponse availableCache = CacheClient.GetCache(ResourceGroupName, Name);
                if (availableCache != null)
                {
                    throw new CloudException(string.Format(Resources.RedisCacheExists, Name));
                }
            }
            catch (CloudException ex)
            {
                if (ex.ErrorCode == "ResourceNotFound" || ex.Message.Contains("ResourceNotFound"))
                {
                    // cache does not exists so go ahead and create one
                }
                else if (ex.ErrorCode == "ResourceGroupNotFound" || ex.Message.Contains("ResourceGroupNotFound"))
                {
                    // resource group not found, let create throw error don't throw from here
                }
                else
                { 
                    // all other exceptions should be thrown
                    throw;
                }
            }
            WriteObject(new RedisCacheAttributesWithAccessKeys(CacheClient.CreateOrUpdateCache(ResourceGroupName, Name, Location, RedisVersion, skuFamily, skuCapacity, Sku, MaxMemoryPolicy, EnableNonSslPort), ResourceGroupName));
        }
    }
}