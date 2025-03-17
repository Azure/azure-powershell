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

using Microsoft.Azure.Management.RedisCache.Models;

namespace Microsoft.Azure.Commands.RedisCache
{
    using Microsoft.Azure.Commands.RedisCache.Models;
    using Microsoft.Azure.Commands.RedisCache.Properties;
    using Microsoft.Rest.Azure;
    using ResourceManager.Common.ArgumentCompleters;
    using System;
    using System.Collections;
    using System.Management.Automation;
    using SkuStrings = SkuName;
    using TlsStrings = TlsVersion;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RedisCache", SupportsShouldProcess = true), OutputType(typeof(RedisCacheAttributesWithAccessKeys))]
    public class NewAzureRedisCache : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which you want to create cache.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of redis cache.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Location where want to create cache.")]
        [LocationCompleter("Microsoft.Cache/Redis")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Size of redis cache. Valid values: P1,P2, P3, P4, P5, C0, C1, C2, C3, C4, C5, C6, 250MB, 1GB, 2.5GB, 6GB, 13GB, 26GB, 53GB, 120GB")]
        [PSArgumentCompleter(SizeConverter.P1String, SizeConverter.P2String, SizeConverter.P3String, SizeConverter.P4String, SizeConverter.P5String,
            SizeConverter.C0String, SizeConverter.C1String, SizeConverter.C2String, SizeConverter.C3String, SizeConverter.C4String, SizeConverter.C5String, SizeConverter.C6String,
            SizeConverter.MB250, SizeConverter.GB1, SizeConverter.GB2_5, SizeConverter.GB6, SizeConverter.GB13, SizeConverter.GB26, SizeConverter.GB53, SizeConverter.GB120)]
        public string Size { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Choose to create a Basic, Standard, or Premium cache.")]
        [ValidateSet(SkuStrings.Basic, SkuStrings.Standard, SkuStrings.Premium, IgnoreCase = false)]
        public string Sku { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "A hash table which represents redis configuration properties.")]
        public Hashtable RedisConfiguration { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "EnableNonSslPort property of redis cache.")]
        public bool? EnableNonSslPort { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "A hash table which represents tenant settings.")]
        public Hashtable TenantSettings { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "The number of shards to create on a Premium Cluster Cache.")]
        public int? ShardCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Specify the TLS version required by clients to connect to cache.")]
        [PSArgumentCompleter(TlsStrings.One0, TlsStrings.One1, TlsStrings.One2)]
        public string MinimumTlsVersion { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Authentication to Redis through access keys is disabled when set as true")]
        public bool? DisableAccessKeyAuthentication { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "The full resource ID of a subnet in a virtual network to deploy the Azure Cache for Redis in. Example format: /subscriptions/{subid}/resourceGroups/{resourceGroupName}/Microsoft.{Network|ClassicNetwork}/VirtualNetworks/{vnetName}/subnets/{subnetName}")]
        public string SubnetId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Required when deploying a redis cache inside an existing Azure Virtual Network.")]
        public string StaticIP { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "A hash table which represents tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "List of Azure regions with Availability zones.")]
        public string[] Zone { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Redis version. This should be in the form 'major[.minor]' (only 'major' is required) or the value 'latest' which refers to the latest stable Redis version that is available. Supported versions: 4.0, 6.0 (latest). Default value is 'latest'.")]
        public string RedisVersion { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Optional: Specifies the update channel for the monthly Redis updates your Redis Cache will receive. Caches using 'Preview' update channel get latest Redis updates at least 4 weeks ahead of 'Stable' channel caches. Default value is 'Stable'. Possible values include: 'Stable', 'Preview'")]
        public string UpdateChannel { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Specifies the type of identity used for the Azure Cache for Redis. Valid values: \"SystemAssigned\" or \"UserAssigned\" or \"SystemAssignedUserAssigned\" or \"None\" ")]
        [PSArgumentCompleter("SystemAssigned", "UserAssigned", "SystemAssignedUserAssigned", "None")]
        public string IdentityType { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Specifies one or more comma seperated user identities to be associated with the Azure Cache for Redis. The user identity references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/identities/{identityName}'")]
        public string[] UserAssignedIdentity { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Optional: Specifies how availability zones are allocated to the Redis cache. 'Automatic' enables zone redundancy and Azure will automatically select zones based on regional availability and capacity. 'UserDefined' will select availability zones passed in by you using the 'zones' parameter. 'NoZones' will produce a non-zonal cache. If 'zonalAllocationPolicy' is not passed, it will be set to 'UserDefined' when zones are passed in, otherwise, it will be set to 'Automatic' in regions where zones are supported and 'NoZones' in regions where zones are not supported.")]
        public string ZonalAllocationPolicy { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(ResourceGroupName, Name);
            if (string.IsNullOrEmpty(Sku))
            {
                Sku = SkuStrings.Standard;
            }


            if (string.IsNullOrEmpty(Size))
            {
                if (SkuStrings.Premium.Equals(Sku, StringComparison.OrdinalIgnoreCase))
                {
                    Size = SizeConverter.P1String;
                }
                else
                {
                    Size = SizeConverter.C1String;
                }
            }
            else
            {
                Size = SizeConverter.GetSizeInRedisSpecificFormat(Size, SkuStrings.Premium.Equals(Sku));
                SizeConverter.ValidateSize(Size.ToUpper(), SkuStrings.Premium.Equals(Sku));
            }

            // Size to SkuFamily and SkuCapacity conversion
            string skuFamily = Size.Substring(0, 1);
            int.TryParse(Size.Substring(1), out int skuCapacity);


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
            catch (ErrorResponseException ex)
            {
                if (ex.Body.Error.Code == "ResourceNotFound" || ex.Message.Contains("ResourceNotFound"))
                {
                    // cache does not exists so go ahead and create one
                }
                else if (ex.Body.Error.Code == "ResourceGroupNotFound" || ex.Message.Contains("ResourceGroupNotFound"))
                {
                    // resource group not found, let create throw error don't throw from here
                }
                else
                {
                    // all other exceptions should be thrown
                    throw;
                }
            }

            ConfirmAction(
              string.Format(Resources.CreateRedisCache, Name),
              Name,
              () =>
              {
                  var redisResource = CacheClient.CreateCache(ResourceGroupName, Name, Location, skuFamily, skuCapacity, Sku,
                      RedisConfiguration, EnableNonSslPort, TenantSettings, ShardCount, MinimumTlsVersion, DisableAccessKeyAuthentication, SubnetId, StaticIP, Tag, Zone, RedisVersion, IdentityType, UserAssignedIdentity, UpdateChannel, ZonalAllocationPolicy);
                  var redisAccessKeys = CacheClient.GetAccessKeys(ResourceGroupName, Name);
                  WriteObject(new RedisCacheAttributesWithAccessKeys(redisResource, redisAccessKeys, ResourceGroupName));
              });
        }
    }
}
