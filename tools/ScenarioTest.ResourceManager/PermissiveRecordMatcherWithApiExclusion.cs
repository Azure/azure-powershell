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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    // Excludes api version when matching mocked records.
    // If alternate api version is provided, uses that to match records else removes the api-version matching.
    public class PermissiveRecordMatcherWithApiExclusion : IRecordMatcher
    {
        protected bool _shouldIgnoreGenericResource;
        protected Dictionary<string, string> _providersToIgnore;
        protected Dictionary<string, string> _userAgentsToIgnore;
        protected string[] _resourcesToIgnore;

        public PermissiveRecordMatcherWithApiExclusion(
            bool ignoreResourcesClient,
            Dictionary<string, string> providers,
            Dictionary<string, string> userAgents,
            string[] resourcesToIgnore = null)
        {
            _shouldIgnoreGenericResource = ignoreResourcesClient;
            _providersToIgnore = providers;
            _userAgentsToIgnore = userAgents;
            _resourcesToIgnore = resourcesToIgnore ?? new string[]{};
        }

        public virtual string GetMatchingKey(System.Net.Http.HttpRequestMessage request)
        {
            var requestUri = request.RequestUri.PathAndQuery;
            if (requestUri.Contains("?&"))
            {
                requestUri = requestUri.Replace("?&", "?");
            }

            string version;
            if (ShouldIgnoreApiVersion(requestUri, _shouldIgnoreGenericResource, _providersToIgnore, _resourcesToIgnore, out version))
            {
                requestUri = RemoveOrReplaceApiVersion(requestUri, version);
            }
            else if (_userAgentsToIgnore != null && _userAgentsToIgnore.Any())
            {
                var agent = request.Headers.FirstOrDefault(h => h.Key.Equals("User-Agent"));
                if (agent.Key != null)
                {
                    foreach (var userAgnet in _userAgentsToIgnore)
                    {
                        if (agent.Value.Any(v => v.StartsWith(userAgnet.Key, StringComparison.OrdinalIgnoreCase)))
                        {
                            requestUri = RemoveOrReplaceApiVersion(requestUri, userAgnet.Value);
                            break;
                        }
                    }
                }
            }

            var encodedPath = Convert.ToBase64String(Encoding.UTF8.GetBytes(requestUri));
            return string.Format("{0} {1}", request.Method, encodedPath);
        }

        public virtual string GetMatchingKey(RecordEntry recordEntry)
        {
            var encodedPath = recordEntry.EncodedRequestUri;
            var requestUri = recordEntry.RequestUri;
            var changed = false;
            if (requestUri.Contains("?&"))
            {
                requestUri = recordEntry.RequestUri.Replace("?&", "?");
                changed = true;
            }

            string version;
            if (ShouldIgnoreApiVersion(requestUri, _shouldIgnoreGenericResource, _providersToIgnore, _resourcesToIgnore, out version))
            {
                requestUri = RemoveOrReplaceApiVersion(requestUri, version);
                changed = true;
            }

            if (changed)
            {
                encodedPath = Convert.ToBase64String(Encoding.UTF8.GetBytes(requestUri));
            }

            return string.Format("{0} {1}", recordEntry.RequestMethod, encodedPath);
        }

        /// <summary>
        /// Helper method to determine whether or not this request api version should be ignored
        /// </summary>
        /// <param name="requestUri">The request uri</param>
        /// <param name="apiVersion">The api verison to use</paraam>
        /// <returns></returns>
        public static bool ShouldIgnoreApiVersion(
            string requestUri,
            bool shouldIgnoreGenericResource,
            Dictionary<string, string> providersToIgnore,
            string[] resourcesToIgnore,
            out string apiVersion)
        {
            if (shouldIgnoreGenericResource &&
                !requestUri.Contains("providers/") &&
                !requestUri.StartsWith("/certificates?", StringComparison.InvariantCultureIgnoreCase) &&
                !requestUri.StartsWith("/pools", StringComparison.InvariantCultureIgnoreCase) &&
                !requestUri.StartsWith("/jobs", StringComparison.InvariantCultureIgnoreCase) &&
                !requestUri.StartsWith("/jobschedules", StringComparison.InvariantCultureIgnoreCase) &&
                !requestUri.Contains("/applications?") &&
                !requestUri.Contains("/servicePrincipals?") &&
                !requestUri.StartsWith("/webhdfs/v1/?aclspec", StringComparison.InvariantCultureIgnoreCase))
            {
                apiVersion = String.Empty;
                return true;
            }

            // Ignore resource providers
            foreach (var provider in providersToIgnore)
            {
                var providerString = string.Format("providers/{0}", provider.Key);
                if (requestUri.Contains(providerString))
                {
                    apiVersion = provider.Value;
                    return true;
                }
            }

            // If we're looking at a specific provider and we have top level resource from this provider to ignore
            foreach (var resourceToIgnore in resourcesToIgnore)
            {
                var segments = requestUri.Split('/');

                // /subscriptions/.../resourceGroups/.../providers/Microsoft.X/resourceType...?api-version=Y
                if (requestUri.Contains("resourceGroups/") && requestUri.Contains("providers/"))
                {
                    if (segments.Length > 8)
                    {
                        var resourceIdentifier = new ResourceIdentifier(requestUri);
                        if (resourceIdentifier.ResourceType == resourceToIgnore)
                        {
                            apiVersion = String.Empty;
                            return true;
                        }
                    }
                    else if (segments.Length == 8)
                    {
                        var resourceType = $"{segments[6]}/{segments[7]}";
                        if (resourceType.Contains(resourceToIgnore))
                        {
                            apiVersion = String.Empty;
                            return true;
                        }
                    }
                }

                // /subscriptions/.../providers/Microsoft.Provider/resourceType
                if (requestUri.Contains("providers/"))
                {
                    if (segments.Length == 6)
                    {
                        var resourceType = $"{segments[4]}/{segments[5]}";
                        if (resourceType.Contains(resourceToIgnore))
                        {
                            apiVersion = String.Empty;
                            return true;
                        }
                    }
                }
            }

            apiVersion = string.Empty;
            return false;
        }

        protected string RemoveOrReplaceApiVersion(string requestUri, string version)
        {
            if (!string.IsNullOrWhiteSpace(version))
            {
                return Regex.Replace(requestUri, @"([\?&])api-version=[^&]+", string.Format("$1api-version={0}", version));
            }
            else
            {
                var result = Regex.Replace(requestUri, @"&api-version=[^&]+", string.Empty);
                return Regex.Replace(result, @"\?api-version=[^&]+[&]*", "?");
            }
        }
    }
}