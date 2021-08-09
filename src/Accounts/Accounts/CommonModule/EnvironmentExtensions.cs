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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Text.RegularExpressions;
using System;
using System.Text;
using System.Collections.Concurrent;
using Microsoft.Azure.Commands.Profile.CommonModule;

namespace Microsoft.Azure.Commands.Common
{
    internal static class EnvironmentExtensions
    {
        /// <summary>
        /// Translate the given Uri into the appropriate Uri for the current environment.
        /// </summary>
        /// <param name="environment">The current Azure Environment</param>
        /// <param name="baseEndpoint">The Uri to transform</param>
        /// <returns>The Uri, with naseUri appropriately altered for the current Azure environment</returns>
        public static Uri GetUriFromBaseRequestUri(this IAzureEnvironment environment, Uri baseEndpoint)
        {
            if (null == environment)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            var baseEnvironment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            if (baseEnvironment.GraphUrl.IsMatch(baseEndpoint))
            {
                return baseEndpoint.PatchHost(environment.GraphUrl);
            }

            if (baseEnvironment.ResourceManagerUrl.IsMatch(baseEndpoint))
            {
                return baseEndpoint.PatchHost(environment.ResourceManagerUrl);
            }

            if (baseEnvironment.ServiceManagementUrl.IsMatch(baseEndpoint))
            {
                return baseEndpoint.PatchHost(environment.ServiceManagementUrl);
            }

            if (environment.ExtendedProperties.ContainsKey(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint) 
                && baseEnvironment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint].IsMatch(baseEndpoint))
            {
                return baseEndpoint.PatchHost(environment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint]);
            }

            if (!string.IsNullOrWhiteSpace(environment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix) 
                && baseEnvironment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix.IsMatch(baseEndpoint))
            {
                return baseEndpoint.PatchDnsSuffix(environment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix);
            }

            if (!string.IsNullOrWhiteSpace(environment.AzureDataLakeStoreFileSystemEndpointSuffix) 
                && baseEnvironment.AzureDataLakeStoreFileSystemEndpointSuffix.IsMatch(baseEndpoint))
            {
                return baseEndpoint.PatchDnsSuffix(environment.AzureDataLakeStoreFileSystemEndpointSuffix);
            }

            if (!string.IsNullOrWhiteSpace(environment.AzureKeyVaultDnsSuffix) && 
                baseEnvironment.AzureKeyVaultDnsSuffix.IsMatch(baseEndpoint))
            {
                return baseEndpoint.PatchDnsSuffix(environment.AzureKeyVaultDnsSuffix);
            }

            if (!string.IsNullOrWhiteSpace(environment.SqlDatabaseDnsSuffix) &&
                baseEnvironment.SqlDatabaseDnsSuffix.IsMatch(baseEndpoint))
            {
                return baseEndpoint.PatchDnsSuffix(environment.SqlDatabaseDnsSuffix);
            }

            if (!string.IsNullOrWhiteSpace(environment.StorageEndpointSuffix) 
                && baseEnvironment.StorageEndpointSuffix.IsMatch(baseEndpoint))
            {
                return baseEndpoint.PatchDnsSuffix(environment.StorageEndpointSuffix);
            }

            if (!string.IsNullOrWhiteSpace(environment.TrafficManagerDnsSuffix) 
                && baseEnvironment.TrafficManagerDnsSuffix.IsMatch(baseEndpoint))
            {
                return baseEndpoint.PatchDnsSuffix(environment.TrafficManagerDnsSuffix);
            }

            if (environment.ExtendedProperties.ContainsKey(AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix) 
                && baseEnvironment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix].IsMatch(baseEndpoint))
            {
                return baseEndpoint.PatchDnsSuffix(environment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix]);
            }

            return baseEndpoint;
        }

        ////TODO: Update to support all data plane audience
        /// <summary>
        /// Determien the inteneded audience of a request
        /// </summary>
        /// <param name="environment">The environment to use as a source of audiences</param>
        /// <param name="baseEndpoint">The Uri to try to find the audience for</param>
        /// <returns></returns>
        public static string GetAudienceFromRequestUri(this IAzureEnvironment environment, Uri baseEndpoint)
        {
            if (null == environment)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            var baseEnvironment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            if (baseEnvironment.GraphUrl.IsMatch(baseEndpoint) || environment.GraphUrl.IsMatch(baseEndpoint))
            {
                return environment.GraphEndpointResourceId;
            }

            if (baseEnvironment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint].IsMatch(baseEndpoint)
                || (environment.ExtendedProperties.ContainsKey(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint) 
                && environment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint].IsMatch(baseEndpoint)))
            {
                return environment.ExtendedProperties.ContainsKey(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId) 
                    ? environment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId]
                    : baseEnvironment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId];
            }

            if (baseEnvironment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix.IsMatch(baseEndpoint)
                || environment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix.IsMatch(baseEndpoint))
            {
                return environment.DataLakeEndpointResourceId ?? baseEnvironment.DataLakeEndpointResourceId;
            }

            if (baseEnvironment.AzureDataLakeStoreFileSystemEndpointSuffix.IsMatch(baseEndpoint) 
                || environment.AzureDataLakeStoreFileSystemEndpointSuffix.IsMatch(baseEndpoint))
            {
                return environment.DataLakeEndpointResourceId ?? baseEnvironment.DataLakeEndpointResourceId;
            }

            if (baseEnvironment.AzureKeyVaultDnsSuffix.IsMatch(baseEndpoint) || environment.AzureKeyVaultDnsSuffix.IsMatch(baseEndpoint))
            {
                return environment.AzureKeyVaultServiceEndpointResourceId 
                    ?? baseEnvironment.AzureKeyVaultServiceEndpointResourceId;
            }

            if (baseEnvironment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix].IsMatch(baseEndpoint)
                || ( environment.ExtendedProperties.ContainsKey(AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix) 
                && environment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix].IsMatch(baseEndpoint)))
            {
                return environment.ExtendedProperties.ContainsKey(AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId) 
                    ? environment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId]
                    : baseEnvironment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId];
            }

            //TODO: Add ExtendedProperties
            if("http://azconfig.io".IsMatch(baseEndpoint))
            {
                return baseEndpoint.GetLeftPart(UriPartial.Authority); //return https://{myname}.azconfig.io
            }

            return environment.ActiveDirectoryServiceEndpointResourceId;
        }

        /// <summary>
        /// Get a regular expression for a given Azure Environment endpoint or suffix.
        /// </summary>
        /// <param name="baseProperty">The string representation of the value to match</param>
        /// <returns>A regular expression that will appropriately match Uris that contain the given endpoint or suffix</returns>
        internal static Regex GetMatcher(this string baseProperty)
        {
            if (string.IsNullOrWhiteSpace(baseProperty))
            {
                return null;
            }

            if (baseProperty.Contains("//"))
            {
                return new Regex(Regex.Escape(new Uri(baseProperty).DnsSafeHost), RegexOptions.IgnoreCase);
            }

            return new Regex($"\\w+\\.?{Regex.Escape(baseProperty)}", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Determines if the given Uri contaisn the given endpoint or endpoint suffix
        /// </summary>
        /// <param name="endpointOrSuffix">The endpoint or suffix to match</param>
        /// <param name="compare">The Uri to compare to the given endpoint or suffix.</param>
        /// <returns>True if the Uri matches the given endpoint or siffix, otherwise false</returns>
        internal static bool IsMatch(this string endpointOrSuffix, Uri compare)
        {
            var matcher = endpointOrSuffix.GetMatcher();
            return matcher != null && matcher.IsMatch(compare.DnsSafeHost);
        }

        /// <summary>
        /// Adapt the given Uri to use the given Uri suffix
        /// </summary>
        /// <param name="baseUri">The Uri to change</param>
        /// <param name="suffix">The suffix to substitute for the dns suffix in the given Uri</param>
        /// <returns>A new Uri with the dns suffix altered to match the input suffix</returns>
        internal static Uri PatchDnsSuffix(this Uri baseUri, string suffix)
        {
            if (null == baseUri || !baseUri.IsAbsoluteUri)
            {
                throw new ArgumentOutOfRangeException(nameof(baseUri));
            }

            if (string.IsNullOrWhiteSpace(suffix))
            {
                throw new ArgumentOutOfRangeException(nameof(suffix));
            }

            var builder = new UriBuilder(baseUri);
            var dns = baseUri.Host;
            var newSuffix = suffix.RemoveAtStart('.');
            var dnsMatcher = new Regex("(?<=^[^\\.]+\\.)([^\\:]+)(?=\\:\\d+)?$");
            builder.Host = dnsMatcher.Replace(dns, newSuffix);
            return builder.Uri;
        }

        /// <summary>
        /// Change the given Uri to use the base endpoint provided
        /// </summary>
        /// <param name="baseUri">The Uri to change</param>
        /// <param name="newBase">The Uri or fragment to use as the new Uri base endpoint.</param>
        /// <returns>A transformed Uri using the given base.</returns>
        internal static Uri PatchHost(this Uri baseUri, string newBase)
        {
            if (string.IsNullOrWhiteSpace(newBase))
            {
                return baseUri;
            }

            baseUri = baseUri ?? new Uri("/", UriKind.Relative);
            UriBuilder output = new UriBuilder(newBase);
            if (baseUri.IsAbsoluteUri)
            {
                output.Path = output.Uri.AppendPathRemoveDuplicates(baseUri.AbsolutePath);
                output.Query = baseUri.Query?.TrimStart('?');
                output.Fragment = baseUri.Fragment?.TrimStart('#');
                return output.Uri;
            }

            return new Uri(output.Uri, baseUri);
        }

        /// <summary>
        /// Append two Uri paths, and remove any duplication of the first Uri path at the start of the new Uri
        /// </summary>
        /// <param name="start">The beginning of the path</param>
        /// <param name="end">The end of the path</param>
        /// <returns>A new absolute path that concatenates the teo paths</returns>
        internal static string AppendPathRemoveDuplicates(this Uri start, string end)
        {
            var startPath = start.AbsolutePath;
            var startRegex = new Regex($"(^{Regex.Escape(startPath)})");
            return string.Concat(startPath, startRegex.Replace(end, string.Empty, 1));
        }

        /// <summary>
        /// Remove the given characters from the start of a string
        /// </summary>
        /// <param name="target">The string to change</param>
        /// <param name="characters">The characters to remove from the start</param>
        /// <returns>The altered string</returns>
        internal static string RemoveAtStart(this string target, params char[] characters)
        {
            var builder = new StringBuilder("^([");
            foreach (var matchChar in characters)
            {
                builder.Append(Regex.Escape($"{matchChar}"));
            }

            builder.Append("]+)");
            var regex = new Regex(builder.ToString());
            return regex.Replace(target, string.Empty);
        }

        /// <summary>
        /// Determines
        /// </summary>
        /// <param name="target"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        internal static bool ContainsNotNull(this string target, string searchValue, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            if (string.IsNullOrWhiteSpace(target) || string.IsNullOrWhiteSpace(searchValue))
            {
                return false;
            }

            switch(comparison)
            {
                case StringComparison.CurrentCultureIgnoreCase:
                case StringComparison.OrdinalIgnoreCase:
                    target = target.ToLower();
                    searchValue = searchValue.ToLower();
                    break;
                case StringComparison.InvariantCultureIgnoreCase:
                    target = target.ToLowerInvariant();
                    searchValue = searchValue.ToLowerInvariant();
                    break;
            }

            return target.Contains(searchValue);
        }

        internal static void CheckAndEnqueue<T>(this ConcurrentQueue<T> queue,  T item) where T: class
        {
            const int capacity = 1000;
            if (null == item || null == queue)
            {
                return;
            }

            lock(queue)
            {
                while (queue.Count >= capacity)
                {
                    T result;
                    queue.TryDequeue(out result);
                }

                queue.Enqueue(item);
            }
        }

        internal static bool TryDequeueIfNotNull<T>(this ConcurrentQueue<T> queue, out T result)
        {
            result = default(T);
            if (null == queue)
            {
                return false;
            }

            return queue.TryDequeue(out result);
        }

        internal static Action<string> GetDebugLogger(this IEventStore store)
        {
            return ((message) => store.AddEvent(EventHelper.CreateDebugEvent(message)));
        }

        internal static Action<string> GetWarningLogger(this IEventStore store)
        {
            return ((message) => store.AddEvent(EventHelper.CreateWarningEvent(message)));
        }
    }
}
