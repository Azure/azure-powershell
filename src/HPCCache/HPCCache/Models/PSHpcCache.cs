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

namespace Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using StorageCacheModels = Microsoft.Azure.Management.StorageCache.Models;

    /// <summary>
    /// Wrapper that wraps the response from .NET SDK.
    /// </summary>
    public class PSHPCCache
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSHPCCache"/> class.
        /// </summary>
        /// <param name="cache">cache object.</param>
        public PSHPCCache(StorageCacheModels.Cache cache)
        {
            this.ResourceGroupName = new ResourceIdentifier(cache.Id).ResourceGroupName;
            this.CacheName = cache.Name;
            this.Id = cache.Id;
            this.Location = cache.Location;
            this.Sku = new PSHpcCacheSku(cache.Sku);
            this.CacheSize = cache.CacheSizeGB;
            this.Health = new PSHpcCacheHealth(cache.Health);
            this.MountAddresses = cache.MountAddresses;
            this.ProvisioningState = cache.ProvisioningState;
            this.Subnet = cache.Subnet;
            this.UpgradeStatus = new PSHpcCacheUpgradeStatus(cache.UpgradeStatus);
            this.Tags = cache.Tags;
        }

        /// <summary>
        /// Gets or Sets ResourceGroupName.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or Sets CacheName.
        /// </summary>
        public string CacheName { get; set; }

        /// <summary>
        /// Gets or Sets Cache ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or Sets Sku.
        /// </summary>
        public PSHpcCacheSku Sku { get; set; }

        /// <summary>
        /// Gets or Sets Health.
        /// </summary>
        public PSHpcCacheHealth Health { get; set; }

        /// <summary>
        /// Gets or Sets MountAddresses.
        /// </summary>
        public IList<string> MountAddresses { get; set; }

        /// <summary>
        /// Gets or Sets Cache ProvisioningState.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or Sets Subnet.
        /// </summary>
        public string Subnet { get; set; }

        /// <summary>
        /// Gets or Sets UpgradeStatus.
        /// </summary>
        public PSHpcCacheUpgradeStatus UpgradeStatus { get; set; }

        /// <summary>
        /// Gets or Sets CacheSize.
        /// </summary>
        public int? CacheSize { get; set; }

        /// <summary>
        /// Gets or Sets Tags.
        /// </summary>
        public object Tags { get; set; }
    }
}