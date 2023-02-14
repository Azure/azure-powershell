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

namespace Microsoft.Azure.Commands.HPCCache.Test.Utilities
{
    /// <summary>
    /// Contains constants for tests.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Default region for resource group.
        /// </summary>
        public const string DefaultRegion = "eastus";

        /// <summary>
        /// Default API version of storage cache client.
        /// </summary>
        public const string DefaultAPIVersion = "2019-11-01";

        /// <summary>
        /// Default prefix for resource group name.
        /// </summary>
        public const string DefaultResourcePrefix = "hpc";

        /// <summary>
        /// Default size for cache.
        /// </summary>
        public const int DefaultCacheSize = 3072;

        /// <summary>
        /// Default SKU for cache.
        /// </summary>
        public const string DefaultCacheSku = "Standard_2G";

        /// <summary>
        /// Default PrincipalId for Storage Cache Resource Provider.
        /// </summary>
        public const string StorageCacheResourceProviderPrincipalId = "831d4223-7a3c-4121-a445-1e423591e57b";

        // If you want to use existing cache then uncomment below parameters and substitue proper values.

        /// <summary>
        /// Resouce group name.
        /// </summary>
        // public static readonly string ResourceGroupName = "test-rg";

        /// <summary>
        /// Cache name.
        /// </summary>
        // public static readonly string CacheName = "test-cache";

        /// <summary>
        /// Storage target name.
        /// </summary>
        // public static readonly string StorageTargetName = "msazure";
    }
}
