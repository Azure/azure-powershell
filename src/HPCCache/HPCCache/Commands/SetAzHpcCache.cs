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
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.HPCCache.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.StorageCache;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;

    /// <summary>
    /// SetHPCCache commandlet.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HpcCache", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSHPCCache))]
    public class SetAzHpcCache : HpcCacheBaseCmdlet
    {
        /// <summary>
        /// Gets or sets resource Group Name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which you want to update cache.", ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets resource CacheName.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of cache.", ParameterSetName = FieldsParameterSet)]
        [Alias(CacheNameAlias)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.StorageCache/caches", nameof(ResourceGroupName))]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tags to associate with HPC Cache.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The tags to associate with HPC Cache.", ParameterSetName = FieldsParameterSet)]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets cache object.
        /// </summary>
        [Parameter(ParameterSetName = ObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The cache object to update.")]
        [ValidateNotNullOrEmpty]
        public PSHPCCache InputObject { get; set; }

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
            IDictionary<string, string> tagPairs = null;

            if (this.Tag != null)
            {
                tagPairs = this.Tag.ToDictionaryTags();
            }

            if (this.ParameterSetName == ObjectParameterSet)
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.CacheName;
                var tags = this.InputObject.Tags;
                var json = JsonConvert.SerializeObject(tags);
                var dictionaryOfTags = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                tagPairs = dictionaryOfTags;
            }

            if (this.ShouldProcess(this.Name, string.Format(Resources.SetCache, this.Name, this.ResourceGroupName)))
            {
                try
                {
                    var cacheExists = this.HpcCacheClient.Caches.Get(this.ResourceGroupName, this.Name);
                    if (cacheExists != null)
                    {
                        var location = cacheExists.Location;
                        var cacheSize = cacheExists.CacheSizeGB;
                        var sku = cacheExists.Sku;
                        var subnet = cacheExists.Subnet;
                        var tag = tagPairs;
                        var cacheParameters = new Cache() { CacheSizeGB = cacheSize, Location = location, Sku = sku, Subnet = subnet, Tags = tag };
                        var cache = this.HpcCacheClient.Caches.Update(this.ResourceGroupName, this.Name, cacheParameters);
                        this.WriteObject(new PSHPCCache(cache), enumerateCollection: true);
                    }
                }
                catch (CloudErrorException ex)
                {
                    throw new CloudException(string.Format("Exception: {0}", ex.Body.Error.Message));
                }
            }
        }
    }
}