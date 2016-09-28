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
    using Microsoft.Rest.Azure;
    using System;
    using System.Collections;
    using System.Management.Automation;
    using SkuStrings = Microsoft.Azure.Management.Redis.Models.SkuName;

    [Cmdlet(VerbsCommon.New, "AzureRmRedisCache"), OutputType(typeof(RedisCacheAttributesWithAccessKeys))]
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
        public string Location { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Redis version.")]
        public string RedisVersion { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Size of redis cache. Valid values: P1,P2, P3, P4, C0, C1, C2, C3, C4, C5, C6, 250MB, 1GB, 2.5GB, 6GB, 13GB, 26GB, 53GB")]
        [ValidateSet(SizeConverter.P1String, SizeConverter.P2String, SizeConverter.P3String, SizeConverter.P4String,
            SizeConverter.C0String, SizeConverter.C1String, SizeConverter.C2String, SizeConverter.C3String, SizeConverter.C4String, SizeConverter.C5String, SizeConverter.C6String,
            SizeConverter.MB250, SizeConverter.GB1, SizeConverter.GB2_5, SizeConverter.GB6, SizeConverter.GB13, SizeConverter.GB26, SizeConverter.GB53, IgnoreCase = false)]
        public string Size { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Choose to create a Basic, Standard, or Premium cache.")]
        [ValidateSet(SkuStrings.Basic, SkuStrings.Standard, SkuStrings.Premium, IgnoreCase = false)]
        public string Sku { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "MaxMemoryPolicy is deprecated. Please use RedisConfiguration instead.")]
        public string MaxMemoryPolicy { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "A hash table which represents redis configuration properties.")]
        public Hashtable RedisConfiguration { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "EnableNonSslPort property of redis cache.")]
        public bool? EnableNonSslPort { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "A hash table which represents tenant settings.")]
        public Hashtable TenantSettings { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "The number of shards to create on a Premium Cluster Cache.")]
        public int? ShardCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "VirtualNetwork is deprecated. Please use SubnetId instead.")]
        public string VirtualNetwork { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Subnet is deprecated. Please use SubnetId instead.")]
        public string Subnet { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "The full resource ID of a subnet in a virtual network to deploy the redis cache in. Example format: /subscriptions/{subid}/resourceGroups/{resourceGroupName}/Microsoft.{Network|ClassicNetwork}/VirtualNetworks/vnet1/subnets/subnet1")]
        public string SubnetId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Required when deploying a redis cache inside an existing Azure Virtual Network.")]
        public string StaticIP { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            if (!string.IsNullOrEmpty(RedisVersion))
            {
                WriteWarning("The RedisVersion parameter has been deprecated.  As such, it is no longer necessary to provide this parameter and any value specified is ignored.");
            }

            if (!string.IsNullOrEmpty(VirtualNetwork) || !string.IsNullOrEmpty(Subnet))
            {
                WriteWarning("Parameters 'VirtualNetwork' and 'Subnet' are deprecated. Please use SubnetId instead.");
                if (string.IsNullOrEmpty(SubnetId))
                {
                    SubnetId = string.Format("{0}/subnets/{1}", VirtualNetwork, Subnet);
                }
            }

            if (!string.IsNullOrEmpty(MaxMemoryPolicy))
            {
                throw new ArgumentException(Resources.MaxMemoryPolicyException);
            }

            if (string.IsNullOrEmpty(Sku))
            {
                Sku = SkuStrings.Standard;
            }


            if (string.IsNullOrEmpty(Size))
            {
                Size = SizeConverter.C1String;
            }
            else
            {
                Size = SizeConverter.GetSizeInRedisSpecificFormat(Size, SkuStrings.Premium.Equals(Sku));
            }

            int skuCapacity = 1;
            // Size to SkuFamily and SkuCapacity conversion
            string skuFamily = Size.Substring(0, 1);
            int.TryParse(Size.Substring(1), out skuCapacity);


            // If Force flag is not avaliable than check if cache is already available or not
            try
            {
                RedisResource availableCache = CacheClient.GetCache(ResourceGroupName, Name);
                if (availableCache != null)
                {
                    throw new CloudException(string.Format(Resources.RedisCacheExists, Name));
                }
            }
            catch (CloudException ex)
            {
                if (ex.Body.Code == "ResourceNotFound" || ex.Message.Contains("ResourceNotFound"))
                {
                    // cache does not exists so go ahead and create one
                }
                else if (ex.Body.Code == "ResourceGroupNotFound" || ex.Message.Contains("ResourceGroupNotFound"))
                {
                    // resource group not found, let create throw error don't throw from here
                }
                else
                {
                    // all other exceptions should be thrown
                    throw;
                }
            }

            WriteObject(
                new RedisCacheAttributesWithAccessKeys(
                    CacheClient.CreateOrUpdateCache(ResourceGroupName, Name, Location, skuFamily, skuCapacity, Sku, RedisConfiguration, EnableNonSslPort, TenantSettings, ShardCount, SubnetId, StaticIP),
                    ResourceGroupName
                )
            );
        }
    }
}