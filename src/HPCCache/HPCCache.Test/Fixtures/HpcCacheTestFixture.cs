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

namespace Microsoft.Azure.Commands.HPCCache.Test.Fixtures
{
    using System;
    using System.Text.RegularExpressions;
    using Microsoft.Azure.Commands.HPCCache.Test.Helper;
    using Microsoft.Azure.Commands.HPCCache.Test.Utilities;
    using Microsoft.Azure.Management.Internal.Resources.Models;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.StorageCache;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Test.HttpRecorder;

    /// <summary>
    /// Defines HPC cache test fixture.
    /// </summary>
    public class HpcCacheTestFixture : IDisposable
    {
        /// <summary>
        /// Defines the SubnetRegex.
        /// </summary>
        private static readonly Regex SubnetRegex = new Regex(@"^(/subscriptions/[-0-9a-f]{36}/resourcegroups/[-\w\._\(\)]+/providers/Microsoft.Network/virtualNetworks/(?<VNetName>[-\w\._\(\)]+))/subnets/(?<SubnetName>[-\w\._\(\)]+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Defines the resGroupName.
        /// </summary>
        private readonly string resGroupName;

        /// <summary>
        /// Defines the virNetworkName.
        /// </summary>
        private readonly string virNetworkName;

        /// <summary>
        /// Defines the subnetName.
        /// </summary>
        private readonly string subnetName;

        /// <summary>
        /// Defines the cacheName.
        /// </summary>
        private readonly string cacheName;

        /// <summary>
        /// Initializes a new instance of the <see cref="HpcCacheTestFixture"/> class.
        /// </summary>
        public HpcCacheTestFixture()
        {
            using (this.Context = new HpcCacheTestContext(this.GetType().Name))
            {
                try
                {
                    StorageCacheManagementClient storagecacheMgmtClient = this.Context.GetClient<StorageCacheManagementClient>();
                    storagecacheMgmtClient.ApiVersion = Constants.DefaultAPIVersion;

                    if (string.IsNullOrEmpty(HpcCacheTestEnvironmentUtilities.ResourceGroupName) &&
                        string.IsNullOrEmpty(HpcCacheTestEnvironmentUtilities.CacheName))
                    {
                        this.resGroupName = StorageCacheTestUtilities.GenerateName(HpcCacheTestEnvironmentUtilities.ResourcePrefix);
                        this.virNetworkName = "VNet-" + this.resGroupName;
                        this.subnetName = "Subnet-" + this.resGroupName;
                        this.cacheName = "Cache-" + this.resGroupName;
                    }
                    else
                    {
                        this.resGroupName = HpcCacheTestEnvironmentUtilities.ResourceGroupName;
                        this.cacheName = HpcCacheTestEnvironmentUtilities.CacheName;
                        this.ResourceGroup = this.Context.GetOrCreateResourceGroup(this.resGroupName, HpcCacheTestEnvironmentUtilities.Location);
                        this.Cache = this.Context.GetCacheIfExists(this.ResourceGroup, this.cacheName);

                        if (this.Cache != null)
                        {
                            Match subnetMatch = SubnetRegex.Match(this.Cache.Subnet);
                            this.virNetworkName = subnetMatch.Groups["VNetName"].Value;
                            this.subnetName = subnetMatch.Groups["SubnetName"].Value;
                        }
                        else
                        {
                            this.virNetworkName = "VNet-" + this.resGroupName;
                            this.subnetName = "Subnet-" + this.resGroupName;
                        }
                    }

                    if (this.ResourceGroup == null)
                    {
                        this.ResourceGroup = this.Context.GetOrCreateResourceGroup(this.resGroupName, HpcCacheTestEnvironmentUtilities.Location);
                    }

                    this.VirtualNetwork = this.Context.GetOrCreateVirtualNetwork(this.ResourceGroup, this.virNetworkName);
                    this.SubNet = this.Context.GetOrCreateSubnet(this.ResourceGroup, this.VirtualNetwork, this.subnetName);

                    this.SubscriptionID = HpcCacheTestEnvironmentUtilities.SubscriptionId();
                    this.CacheHelper = new CacheHelper(this.SubscriptionID, storagecacheMgmtClient, this.ResourceGroup, this.VirtualNetwork, this.SubNet);
                    var sku = HpcCacheTestEnvironmentUtilities.CacheSku;
                    var size = HpcCacheTestEnvironmentUtilities.CacheSize;
                    var int_size = int.Parse(size);
                    if (this.Cache == null)
                    {
                        this.Cache = null;
                        this.Cache = this.CacheHelper.Create(this.cacheName, sku, int_size);
                        if (HttpMockServer.Mode == HttpRecorderMode.Record)
                        {
                            this.CacheHelper.CheckCacheState(this.cacheName);
                        }
                    }
                }
                catch (Exception)
                {
                    this.Context.Dispose();
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets the subscriptionID.
        /// </summary>
        public string SubscriptionID { get; }

        /// <summary>
        /// Gets or sets the Context.
        /// </summary>
        public HpcCacheTestContext Context { get; set; }

        /// <summary>
        /// Gets or sets the ResourceGroup.
        /// </summary>
        public ResourceGroup ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the VirtualNetwork.
        /// </summary>
        public VirtualNetwork VirtualNetwork { get; set; }

        /// <summary>
        /// Gets or sets the SubNet.
        /// </summary>
        public Subnet SubNet { get; set; }

        /// <summary>
        /// Gets or sets the Hpc cache.
        /// </summary>
        public CacheHelper CacheHelper { get; set; }

        /// <summary>
        /// Gets or sets the Cache.
        /// </summary>
        public Cache Cache { get; set; }

        /// <summary>
        /// Dispose the object.
        /// </summary>
        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
