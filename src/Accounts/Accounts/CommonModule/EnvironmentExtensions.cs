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
using System.IO;
using System.Text;

namespace Microsoft.Azure.Commands.Common
{
    internal static class EnvironmentExtensions
    {
        /// <summary>
        /// Translate the given Uri into the appropriate Uri for the current environment.
        /// </summary>
        /// <param name="environment">The current Azure Environment</param>
        /// <param name="baseEndpoint">The Uri to tranform</param>
        /// <returns>The Uri, with naseUri appropriately altered for the current Azure environment</returns>
        public static Uri GetEndpointFromBaseEndpoint(this IAzureEnvironment environment, Uri baseEndpoint)
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
                return string.IsNullOrWhiteSpace(environment.TrafficManagerDnsSuffix)
                    ? baseEndpoint
                    : baseEndpoint.PatchDnsSuffix(environment.TrafficManagerDnsSuffix);
            }

            if (environment.ExtendedProperties.ContainsKey(AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix) 
                && baseEnvironment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix].IsMatch(baseEndpoint))
            {
                return baseEndpoint.PatchDnsSuffix(environment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix]);
            }

            return baseEndpoint;
        }

        public static string GetAudienceFromBaseEndpoint(this IAzureEnvironment environment, Uri baseEndpoint)
        {
            if (null == environment)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            var baseEnvironment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            if (baseEnvironment.GraphUrl.IsMatch(baseEndpoint))
            {
                return environment.GraphEndpointResourceId;
            }

            if (baseEnvironment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint].IsMatch(baseEndpoint))
            {
                return environment.ExtendedProperties.ContainsKey(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId) 
                    ? environment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId]
                    : baseEnvironment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId];
            }

            if (baseEnvironment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix.IsMatch(baseEndpoint))
            {
                return environment.DataLakeEndpointResourceId ?? baseEnvironment.DataLakeEndpointResourceId;
            }

            if (baseEnvironment.AzureDataLakeStoreFileSystemEndpointSuffix.IsMatch(baseEndpoint))
            {
                return environment.DataLakeEndpointResourceId ?? baseEnvironment.DataLakeEndpointResourceId;
            }

            if (baseEnvironment.AzureKeyVaultDnsSuffix.IsMatch(baseEndpoint))
            {
                return environment.AzureKeyVaultServiceEndpointResourceId 
                    ?? baseEnvironment.AzureKeyVaultServiceEndpointResourceId;
            }

            if (baseEnvironment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointSuffix].IsMatch(baseEndpoint))
            {
                return environment.ExtendedProperties.ContainsKey(AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId) 
                    ? environment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId]
                    : baseEnvironment.ExtendedProperties[AzureEnvironment.ExtendedEndpoint.AnalysisServicesEndpointResourceId];
            }

            return environment.ActiveDirectoryServiceEndpointResourceId;
        }

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

        internal static bool IsMatch(this string baseProperty, Uri compare)
        {
            var matcher = baseProperty.GetMatcher();
            return matcher != null && matcher.IsMatch(compare.DnsSafeHost);
        }

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

        internal static Uri PatchHost(this Uri baseUri, string newBase)
        {
            if (string.IsNullOrWhiteSpace(newBase))
            {
                throw new ArgumentOutOfRangeException(nameof(newBase));
            }

            baseUri = baseUri ?? new Uri("/", UriKind.Relative);
            UriBuilder output = new UriBuilder(newBase);

            if (baseUri.IsAbsoluteUri)
            {
                output.Path = output.Uri.AppendPathRemoveDuplicates(baseUri.AbsolutePath);
                output.Query = baseUri.Query;
                output.Fragment = baseUri.Fragment;
                return output.Uri;
            }

            return new Uri(output.Uri, baseUri);
        }

        internal static string AppendPathRemoveDuplicates(this Uri start, string end)
        {
            var startPath = start.AbsolutePath;
            var startRegex = new Regex($"(^{Regex.Escape(startPath)})");
            return string.Concat(startPath, startRegex.Replace(end, string.Empty, 1));
        }

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
    }
}
