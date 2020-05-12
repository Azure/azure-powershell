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
    using Microsoft.Azure.Commands.Common.Strategies;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.StorageCache;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Get StorageTargets on Cache.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HpcCacheStorageTarget", DefaultParameterSetName = FieldsParameterSet)]
    [OutputType(typeof(PSHpcStorageTarget))]
    public class GetAzHpcCacheStorageTarget : HpcCacheBaseCmdlet
    {
        /// <summary>
        /// Gets or sets resource Group Name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group cache is in.", ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets cache Name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of cache.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.StorageCache/caches", nameof(ResourceGroupName))]
        public string CacheName { get; set; }

        /// <summary>
        /// Gets or sets resource id of the cache.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id of the Cache", ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string CacheId { get; set; }

        /// <summary>
        /// Gets or sets cache object.
        /// </summary>
        [Parameter(ParameterSetName = ObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The cache object to start.")]
        [ValidateNotNullOrEmpty]
        public PSHPCCache CacheObject { get; set; }

        /// <summary>
        /// Gets or sets storage target name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of storage target.", ParameterSetName = FieldsParameterSet)]
        [Alias(StoragTargetNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <inheritdoc/>
        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.CacheId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.CacheName = resourceIdentifier.ResourceName;
            }
            else if (this.ParameterSetName == ObjectParameterSet)
            {
                this.ResourceGroupName = this.CacheObject.ResourceGroupName;
                this.CacheName = this.CacheObject.CacheName;
            }

            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                if (!string.IsNullOrEmpty(this.CacheName))
                {
                    if (!string.IsNullOrEmpty(this.Name))
                    {
                        try
                        {
                            var singleST = this.HpcCacheClient.StorageTargets.Get(this.ResourceGroupName, this.CacheName, this.Name);
                            this.WriteObject(new PSHpcStorageTarget(singleST), true);
                        }
                        catch (CloudErrorException ex)
                        {
                            throw new CloudException(string.Format("Exception: {0}", ex.Body.Error.Message));
                        }
                    }
                    else
                    {
                        var storageTargets = this.HpcCacheClient.StorageTargets.ListByCache(this.ResourceGroupName, this.CacheName);
                        foreach (var target in storageTargets.Value)
                        {
                            this.WriteObject(new PSHpcStorageTarget(target), true);
                        }
                    }
                }
            }
        }
    }
}
