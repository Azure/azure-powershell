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

using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components
{
    using Entities.Providers;
    using Extensions;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Caching;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper class for determining the API version
    /// </summary>
    internal static class ApiVersionHelper
    {
        /// <summary>
        /// Determines the API version.
        /// </summary>
        /// <param name="context">The azure profile.</param>
        /// <param name="resourceId">The resource Id.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="pre">When specified, indicates if pre-release API versions should be considered.</param>
        internal static Task<string> DetermineApiVersion(AzureContext context, string resourceId, CancellationToken cancellationToken, bool? pre = null, Dictionary<string, string> cmdletHeaderValues = null)
        {
            var providerNamespace = ResourceIdUtility.GetExtensionProviderNamespace(resourceId)
                ?? ResourceIdUtility.GetProviderNamespace(resourceId);

            var resourceType = ResourceIdUtility.GetExtensionResourceType(resourceId: resourceId, includeProviderNamespace: false)
                ?? ResourceIdUtility.GetResourceType(resourceId: resourceId, includeProviderNamespace: false);

            return ApiVersionHelper.DetermineApiVersion(context: context, providerNamespace: providerNamespace, resourceType: resourceType, cancellationToken: cancellationToken, pre: pre, cmdletHeaderValues: cmdletHeaderValues);
        }

        /// <summary>
        /// Determines the API version.
        /// </summary>
        /// <param name="context">The azure profile.</param>
        /// <param name="providerNamespace">The provider namespace.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="pre">When specified, indicates if pre-release API versions should be considered.</param>
        internal static Task<string> DetermineApiVersion(AzureContext context, string providerNamespace, string resourceType, CancellationToken cancellationToken, bool? pre = null, Dictionary<string, string> cmdletHeaderValues = null)
        {
            var cacheKey = ApiVersionCache.GetCacheKey(context.Environment.Name, providerNamespace: providerNamespace, resourceType: resourceType);
            var apiVersions = ApiVersionCache.Instance
                .AddOrGetExisting(cacheKey: cacheKey, getFreshData: () => ApiVersionHelper.GetApiVersionsForResourceType(
                    context,
                    providerNamespace: providerNamespace,
                    resourceType: resourceType,
                    cancellationToken: cancellationToken,
                    cmdletHeaderValues: cmdletHeaderValues));

            apiVersions = apiVersions.CoalesceEnumerable().ToArray();
            var apiVersionsToSelectFrom = apiVersions;
            if (pre == null || pre == false)
            {
                apiVersionsToSelectFrom = apiVersions
                    .Where(apiVersion => apiVersion.IsDecimal(NumberStyles.AllowDecimalPoint) || apiVersion.IsDateTime("yyyy-mm-dd", DateTimeStyles.None))
                    .ToArray();
            }

            var selectedApiVersion = apiVersionsToSelectFrom.OrderByDescending(apiVersion => apiVersion).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(selectedApiVersion) && apiVersions.Any())
            {
                // fall back on pre-release APIs if they're the only ones available.
                selectedApiVersion = apiVersions.OrderByDescending(apiVersion => apiVersion).FirstOrDefault();
            }

            var result = string.IsNullOrWhiteSpace(selectedApiVersion)
                ? Constants.DefaultApiVersion
                : selectedApiVersion;

            return Task.FromResult(result);
        }

        /// <summary>
        /// Determines the list of api versions currently supported by the RP.
        /// </summary>
        /// <param name="context">The azure profile.</param>
        /// <param name="providerNamespace">The provider namespace.</param>
        /// <param name="resourceType">The resource type.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        private static string[] GetApiVersionsForResourceType(AzureContext context, string providerNamespace, string resourceType, CancellationToken cancellationToken, Dictionary<string, string> cmdletHeaderValues = null)
        {
            var resourceManagerClient = ResourceManagerClientHelper.GetResourceManagerClient(context, cmdletHeaderValues);

            var defaultSubscription = context.Subscription;

            var resourceCollectionId = defaultSubscription == null
                ? "/providers"
                : string.Format("/subscriptions/{0}/providers", defaultSubscription.Id);

            var providers = PaginatedResponseHelper.Enumerate(
                getFirstPage: () => resourceManagerClient
                    .ListObjectColleciton<ResourceProviderDefinition>(
                        resourceCollectionId: resourceCollectionId,
                        apiVersion: Constants.ProvidersApiVersion,
                        cancellationToken: cancellationToken),
                getNextPage: nextLink => resourceManagerClient
                    .ListNextBatch<ResourceProviderDefinition>(
                    nextLink: nextLink,
                    cancellationToken: cancellationToken),
                cancellationToken: cancellationToken);

            return providers
                .CoalesceEnumerable()
                .Where(provider => providerNamespace.EqualsInsensitively(provider.Namespace))
                .SelectMany(provider => provider.ResourceTypes)
                .Where(type => resourceType.EqualsInsensitively(type.ResourceType))
                .Select(type => type.ApiVersions)
                .FirstOrDefault();
        }

        /// <summary>
        /// A singleton instance of the <see cref="ApiVersionCache"/>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Instances of this type are meant to be singletons.")]
        private class ApiVersionCache
        {
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
                this.CacheDataExpirationTime = cacheDataExpirationTime;
            }

            /// <summary>
            /// Adds or gets existing data from cache.
            /// </summary>
            /// <param name="cacheKey">The cache key.</param>
            /// <param name="getFreshData">The delegate used to get data if cache is empty or stale.</param>
            internal string[] AddOrGetExisting(string cacheKey, Func<string[]> getFreshData)
            {
                cacheKey = cacheKey.ToUpperInvariant();

                var cacheItem = this.GetCacheItem(cacheKey: cacheKey);

                if (cacheItem == null)
                {
                    var expirationTime = DateTime.UtcNow.Add(this.CacheDataExpirationTime);

                    cacheItem = getFreshData();

                    if (cacheItem != null)
                    {
                        this.SetCacheItem(
                        cacheKey: cacheKey,
                        data: cacheItem,
                        absoluteExpirationTime: expirationTime);
                    }
                }

                return cacheItem;
            }

            /// <summary>
            /// Gets the cache entry.
            /// </summary>
            /// <param name="cacheKey">The cache key.</param>
            private string[] GetCacheItem(string cacheKey)
            {
                return MemoryCache.Default[cacheKey].Cast<string[]>();
            }

            /// <summary>
            /// Adds the cache entry.
            /// </summary>
            /// <param name="cacheKey">The cache key.</param>
            /// <param name="data">The data to add.</param>
            /// <param name="absoluteExpirationTime">The absolute expiration time.</param>
            private void SetCacheItem(string cacheKey, string[] data, DateTimeOffset absoluteExpirationTime)
            {
                MemoryCache.Default.Set(key: cacheKey, value: data, absoluteExpiration: absoluteExpirationTime);
            }

            /// <summary>
            /// Gets the cache key.
            /// </summary>
            /// <param name="environmentName">The environment name.</param>
            /// <param name="providerNamespace">The provider namespace.</param>
            /// <param name="resourceType">The resource type.</param>
            internal static string GetCacheKey(string environmentName, string providerNamespace, string resourceType)
            {
                return string.Format("{0}/{1}/{2}", environmentName.CoalesceEnumerable(), providerNamespace.CoalesceString(), resourceType.CoalesceString()).ToUpperInvariant();
            }
        }
    }
}
