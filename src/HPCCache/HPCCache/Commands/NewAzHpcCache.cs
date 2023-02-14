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
namespace Microsoft.Azure.Commands.HPCCache
{
    using System;
    using System.Collections;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.HPCCache.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.StorageCache;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Creates a HPC Cache.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HpcCache", SupportsShouldProcess = true)]
    [OutputType(typeof(PSHPCCache))]
    public class NewAzHpcCache : HpcCacheBaseCmdlet
    {
        /// <summary>
        /// Gets or sets resource group name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which you want to create cache.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets cache name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of cache.")]
        [Alias(CacheNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Sku.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Sku.")]
        [ValidateNotNullOrEmpty]
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets subnetUri.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "SubnetURI.")]
        [ValidateNotNullOrEmpty]
        public string SubnetUri { get; set; }

        /// <summary>
        /// Gets or sets cache size.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "CacheSize.")]
        [ValidateNotNullOrEmpty]
        public int CacheSize { get; set; }

        /// <summary>
        /// Gets or sets location.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the tags to associate with HPC Cache.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The tags to associate with HPC Cache.")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets Job to run job in background.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Execution cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                var cacheExists = this.HpcCacheClient.Caches.Get(this.ResourceGroupName, this.Name);
                throw new CloudException(string.Format("Cache name {0} already exists", this.Name));
            }
            catch (CloudErrorException ex)
            {
                if (ex.Body.Error.Code != "ResourceNotFound")
                {
                    throw;
                }
            }

            Utility.ValidateResourceGroup(this.ResourceGroupName);
            var cacheSku = new CacheSku() { Name = this.Sku };
            var tag = this.Tag.ToDictionaryTags();
            var cacheParameters = new Cache() { CacheSizeGB = this.CacheSize, Location = this.Location, Sku = cacheSku, Subnet = this.SubnetUri, Tags = tag };
            if (this.ShouldProcess(this.Name, string.Format(Resources.CreateCache, this.ResourceGroupName, this.Name)))
            {
                try
                {
                    var cache = this.HpcCacheClient.Caches.CreateOrUpdate(this.ResourceGroupName, this.Name, cacheParameters);
                    this.WriteObject(new PSHPCCache(cache), enumerateCollection: true);
                }
                catch (CloudErrorException ex)
                {
                    throw new CloudException(string.Format("Exception: {0}", ex.Body.Error.Message));
                }
            }
        }
    }
}