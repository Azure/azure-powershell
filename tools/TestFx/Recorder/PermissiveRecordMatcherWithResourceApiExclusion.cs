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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.TestFx.Recorder
{
    // Excludes api version when matching mocked records.
    // If alternate api version is provided, uses that to match records else removes the api-version matching.
    public class PermissiveRecordMatcherWithResourceApiExclusion : IRecordMatcher
    {
        protected bool _ignoreGenericResource;
        protected Dictionary<string, string> _providersToIgnore;
        protected Dictionary<string, string> _userAgentsToIgnore;
        protected string[] _resourcesToIgnore;

        public PermissiveRecordMatcherWithResourceApiExclusion(bool ignoreResourcesClient, Dictionary<string, string> providers)
        {
            _ignoreGenericResource = ignoreResourcesClient;
            _providersToIgnore = providers;
        }

        public PermissiveRecordMatcherWithResourceApiExclusion(
            bool ignoreResourcesClient,
            Dictionary<string, string> providers,
            Dictionary<string, string> userAgents)
        {
            _ignoreGenericResource = ignoreResourcesClient;
            _providersToIgnore = providers;
            _userAgentsToIgnore = userAgents;
        }

        public PermissiveRecordMatcherWithResourceApiExclusion(
            bool ignoreResourcesClient,
            Dictionary<string, string> providers,
            Dictionary<string, string> userAgents,
            string[] resourcesToIgnore)
        {
            _ignoreGenericResource = ignoreResourcesClient;
            _providersToIgnore = providers;
            _userAgentsToIgnore = userAgents;
            _resourcesToIgnore = resourcesToIgnore;
        }

        public virtual string GetMatchingKey(System.Net.Http.HttpRequestMessage request)
        {
            var requestUri = request.RequestUri.PathAndQuery;
            if (requestUri.Contains("?&"))
            {
                requestUri = requestUri.Replace("?&", "?");
            }

            string version;
            if (ContainsIgnoredProvider(requestUri, out version))
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
            if (ContainsIgnoredProvider(requestUri, out version))
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

        public bool ContainsIgnoredProvider(string requestUri, out string version)
        {
            return ContainsIgnoredProvider(requestUri, _ignoreGenericResource, _providersToIgnore, _resourcesToIgnore, apiVersion: out version);
        }

        /// <summary>
        /// Helper method to determine whether or not this request api version should be ignored
        /// </summary>
        /// <param name="requestUri">The request uri</param>
        /// <param name="apiVersion">The api verison to use</paraam>
        /// <returns></returns>
        public static bool ContainsIgnoredProvider(
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

            if (resourcesToIgnore != null && resourcesToIgnore.Any())
            {
                // If we're looking at a specific provider and we have top level resource from this provider to ignore
                foreach (var resourceToIgnore in resourcesToIgnore)
                {
                    string[] segments = requestUri.Split(new char[] { '/' }, options: StringSplitOptions.RemoveEmptyEntries);

                    // /subscriptions/.../resourceGroups/.../providers/Microsoft.X/resourceType...?api-version=Y
                    var regex = new Regex(@"\/subscriptions\/[0-9A-Fa-f-]*\/resourceGroups\/[a-zA-Z0-9_-]*\/providers\/[a-zA-Z0-9_-]*.[a-zA-Z0-9_-]*\/.*[?api-version=[0-9-]*]?");
                    if (regex.IsMatch(requestUri))
                    {
                        if (segments.Length > 7)
                        {
                            var resourceIdentifier = new ResourceIdentifier(requestUri);
                            if (resourceIdentifier.ResourceType == resourceToIgnore)
                            {
                                apiVersion = String.Empty;
                                return true;
                            }
                        }
                        else if (segments.Length == 7)
                        {
                            var resourceType = $"{segments[5]}/{segments[6]}";
                            if (resourceType.Contains(resourceToIgnore))
                            {
                                apiVersion = String.Empty;
                                return true;
                            }
                        }
                    }

                    // /subscriptions/.../providers/Microsoft.Provider/resourceType
                    regex = new Regex(@"\/subscriptions\/[0-9A-Fa-f-]*\/providers\/[a-zA-Z0-9_-]*.[a-zA-Z0-9_-]*\/.*?[api-version=[0-9-]*]?");
                    if (regex.IsMatch(requestUri))
                    {
                        var resourceType = $"{segments[3]}/{segments[4]}";
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