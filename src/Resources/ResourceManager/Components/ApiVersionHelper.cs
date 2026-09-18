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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components
{
    using Commands.Common.Authentication.Abstractions;
    using Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Extensions.Caching.Memory;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Helper class for determining the API version
    /// </summary>
    internal static class ApiVersionHelper
    {
        /// <summary>
        /// Determines the appropriate API version for a resource identified by its resource ID.
        /// </summary>
        /// <param name="context">The Azure context.</param>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="pre">When true, includes preview API versions in selection consideration.</param>
        /// <returns>The default API version for the specified resource type. Otherwise, fallback to the latest API version.</returns>
        internal static string DetermineApiVersion(IAzureContext context, string resourceId, bool pre)
        {
            var providerNamespace = ResourceIdUtility.GetExtensionProviderNamespace(resourceId) ?? ResourceIdUtility.GetProviderNamespace(resourceId);
            var resourceType = ResourceIdUtility.GetExtensionResourceType(resourceId, false) ?? ResourceIdUtility.GetResourceType(resourceId, false);

            return DetermineApiVersion(context, providerNamespace, resourceType, pre);
        }

        /// <summary>
        /// Determines the appropriate API version for a resource based on its provider namespace and resource type.
        /// </summary>
        /// <param name="context">The Azure context.</param>
        /// <param name="providerNamespace">The provider namespace.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <param name="pre">When true, includes preview API versions in selection consideration.</param>
        /// <returns>The default API version for the specified resource type. Otherwise, fallback to the latest API version.</returns>
        internal static string DetermineApiVersion(IAzureContext context, string providerNamespace, string resourceType, bool pre)
        {
            var cacheKey = ApiVersionCache.GetCacheKey(context.Environment.Name, providerNamespace, resourceType);
            var availableApiVersions = ApiVersionCache.Instance.AddOrGetExisting(cacheKey, () => GetAvailableApiVersionsForResourceType(context, providerNamespace, resourceType));
            return SelectApiVersion(availableApiVersions, pre);
        }

        /// <summary>
        /// Retrieves all available API versions for a specified resource type from the resource provider.
        /// </summary>
        /// <param name="context">The Azure context.</param>
        /// <param name="providerNamespace">The provider namespace.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <returns>
        /// An array of available API versions. If a default API version exists, returns an array containing only the default version.
        /// </returns>
        private static string[] GetAvailableApiVersionsForResourceType(IAzureContext context, string providerNamespace, string resourceType)
        {
            var providers = GetResourceProviders(context, providerNamespace);
            return GetAvailableApiVersions(providers, resourceType);
        }

        /// <summary>
        /// Retrieves the resource providers for a given namespace.
        /// </summary>
        /// <param name="context">The Azure context.</param>
        /// <param name="providerNamespace">The provider namespace.</param>
        /// <returns>The collection of the resource providers.</returns>
        private static IEnumerable<Provider> GetResourceProviders(IAzureContext context, string providerNamespace)
        {
            var resourceManagerSdkClient = new ResourceManagerSdkClient(context);
            return resourceManagerSdkClient.ListResourceProviders(providerNamespace).CoalesceEnumerable();
        }

        /// <summary>
        /// Extracts the available API versions from provider data for a specific resource type.
        /// </summary>
        /// <param name="providers">Collection of resource providers.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <returns>
        /// An array of available API versions. If a default API version exists, returns an array containing only the default version.
        /// </returns>
        private static string[] GetAvailableApiVersions(IEnumerable<Provider> providers, string resourceType)
        {
            var providerResourceTypes = providers.SelectMany(p => p.ResourceTypes.CoalesceEnumerable());

            var resourceTypeFilter = providerResourceTypes.Where(rt => rt.ResourceType.EqualsInsensitively(resourceType));
            if (!resourceTypeFilter.Any())
            {
                // If the specified resource type is not found, fallback to the top level resource type.
                var topLevelResourceType = ResourceTypeUtility.GetTopLevelResourceType(resourceType);
                resourceTypeFilter = providerResourceTypes.Where(rt => rt.ResourceType.EqualsInsensitively(topLevelResourceType));
            }
            var matchingResourceTypes = resourceTypeFilter.ToArray();

            var defaultApiVersion = matchingResourceTypes
                .Select(rt => rt.DefaultApiVersion)
                .Where(v => !string.IsNullOrWhiteSpace(v))
                .OrderByDescending(v => v)
                .FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(defaultApiVersion))
                return new[] { defaultApiVersion };

            // If the default API version is not found, fallback to the list of available API versions.
            return matchingResourceTypes
                .SelectMany(rt => rt.ApiVersions.CoalesceEnumerable())
                .Where(v => !string.IsNullOrWhiteSpace(v))
                .ToArray();
        }

        /// <summary>
        /// Selects the most appropriate API version from a collection of available versions.
        /// </summary>
        /// <param name="availableApiVersions">Collection of all available API versions.</param>
        /// <param name="pre">When true, includes preview API versions in selection consideration.</param>
        /// <returns>
        /// The API version to use, selected with the following priority:
        /// 1. Default API version if available
        /// 2. Latest stable API version if available and pre = false
        /// 3. Latest API version (including preview) if pre = true or no stable version exists
        /// 4. Fallback constant if no API versions found
        /// </returns>
        private static string SelectApiVersion(IEnumerable<string> availableApiVersions, bool pre)
        {
            if (!availableApiVersions.Any())
                return Constants.DefaultApiVersion;

            if (availableApiVersions.Count() == 1)
                return availableApiVersions.First();

            var matchingApiVersions = pre
                ? availableApiVersions
                : availableApiVersions.Where(v => v.IsDecimal(NumberStyles.AllowDecimalPoint) ||
                                                  v.IsDateTime("yyyy-mm-dd", DateTimeStyles.None));

            var latestApiVersion = matchingApiVersions.OrderByDescending(v => v).FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(latestApiVersion))
                return latestApiVersion;

            // If no stable API version is found, fallback to the latest preview API version.
            return availableApiVersions.OrderByDescending(v => v).First();
        }

        /// <summary>
        /// A singleton instance of the <see cref="ApiVersionCache"/>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Instances of this type are meant to be singletons.")]
        private class ApiVersionCache
        {
            private static readonly MemoryCache Cache;

            static ApiVersionCache()
            {
                Cache = new MemoryCache(new MemoryCacheOptions());
            }
            /// <summary>
            /// The API version cache
            /// </summary>
            internal static readonly ApiVersionCache Instance = new ApiVersionCache(TimeSpan.FromHours(1));

            /// <summary>
            /// The cache data expiration time
            /// </summary>
            internal TimeSpan CacheDataExpirationTime { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="ApiVersionCache" /> class.
            /// </summary>
            /// <param name="cacheDataExpirationTime">The polling interval.</param>
            private ApiVersionCache(TimeSpan cacheDataExpirationTime)
            {
                CacheDataExpirationTime = cacheDataExpirationTime;
            }

            /// <summary>
            /// Adds or gets existing data from cache.
            /// </summary>
            /// <param name="cacheKey">The cache key.</param>
            /// <param name="getFreshData">The delegate used to get data if cache is empty or stale.</param>
            internal string[] AddOrGetExisting(string cacheKey, Func<string[]> getFreshData)
            {
                cacheKey = cacheKey.ToUpperInvariant();

                var cacheItem = GetCacheItem(cacheKey);
                if (cacheItem != null) return cacheItem;

                var expirationTime = DateTime.UtcNow.Add(CacheDataExpirationTime);

                cacheItem = getFreshData();

                if (cacheItem != null)
                {
                    SetCacheItem(cacheKey, cacheItem, expirationTime);
                }

                return cacheItem;
            }

            /// <summary>
            /// Gets the cache entry.
            /// </summary>
            /// <param name="cacheKey">The cache key.</param>
            private static string[] GetCacheItem(string cacheKey)
            {
                return Cache.Get(cacheKey).Cast<string[]>();
            }

            /// <summary>
            /// Adds the cache entry.
            /// </summary>
            /// <param name="cacheKey">The cache key.</param>
            /// <param name="data">The data to add.</param>
            /// <param name="absoluteExpirationTime">The absolute expiration time.</param>
            private static void SetCacheItem(string cacheKey, string[] data, DateTimeOffset absoluteExpirationTime)
            {
                Cache.Set(cacheKey, data, absoluteExpirationTime);
            }

            /// <summary>
            /// Gets the cache key.
            /// </summary>
            /// <param name="environmentName">The environment name.</param>
            /// <param name="providerNamespace">The provider namespace.</param>
            /// <param name="resourceType">The resource type.</param>
            internal static string GetCacheKey(string environmentName, string providerNamespace, string resourceType)
            {
                return string.Format("{0}/{1}/{2}", environmentName.CoalesceString(), providerNamespace.CoalesceString(), resourceType.CoalesceString()).ToUpperInvariant();
            }
        }
    }
}
