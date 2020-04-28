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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.StorageCache;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Get Cache / RG specific cache(s) / subscription wide caches.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HpcCache")]
    [OutputType(typeof(PSHPCCache))]
    public class GetAzHpcCache : HpcCacheBaseCmdlet
    {
        /// <summary>
        /// Gets or sets resource Group Name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group under which you want to list cache(s).")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets cache Name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of specific cache.")]
        [Alias(CacheNameAlias)]
        [ResourceNameCompleter("Microsoft.StorageCache/caches", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <inheritdoc/>
        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                if (!string.IsNullOrEmpty(this.Name))
                {
                    try
                    {
                        var singleCache = this.HpcCacheClient.Caches.Get(this.ResourceGroupName, this.Name);
                        this.WriteObject(new PSHPCCache(singleCache), true);
                    }
                    catch (CloudErrorException ex)
                    {
                        throw new CloudException(string.Format("Exception: {0}", ex.Body.Error.Message));
                    }
                }
                else
                {
                    var resourgeGroupCaches = this.HpcCacheClient.Caches.ListByResourceGroup(this.ResourceGroupName);
                    foreach (var cache in resourgeGroupCaches.Value)
                    {
                        this.WriteObject(new PSHPCCache(cache), true);
                    }
                }
            }
            else
            {
                var allCaches = this.HpcCacheClient.Caches.List();
                foreach (var cache in allCaches.Value)
                {
                    this.WriteObject(new PSHPCCache(cache), true);
                }
            }
        }
    }
}