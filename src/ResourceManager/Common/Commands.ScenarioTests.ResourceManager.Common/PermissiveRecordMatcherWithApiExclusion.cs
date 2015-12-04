﻿// ---------------------------------------------------------------------------------- 
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    // Excludes api version when matching mocked records. 
    // If alternate api version is provided, uses that to match records else removes the api-version matching.
    public class PermissiveRecordMatcherWithApiExclusion : IRecordMatcher
    {
        private bool _ignoreGenericResource;
        private Dictionary<string, string> _providersToIgnore;

        public PermissiveRecordMatcherWithApiExclusion(bool ignoreResourcesClient, Dictionary<string, string> providers)
        {
            _ignoreGenericResource = ignoreResourcesClient;
            _providersToIgnore = providers;
        }

        public string GetMatchingKey(System.Net.Http.HttpRequestMessage request)
        {
            var path = request.RequestUri.PathAndQuery;
            if (path.Contains("?&"))
            {
                path = path.Replace("?&", "?");
            }

            string version;
            if (ContainsIgnoredProvider(path, out version))
            {
                path = RemoveOrReplaceApiVersion(path, version);
            }

            var encodedPath = Convert.ToBase64String(Encoding.UTF8.GetBytes(path));
            return string.Format("{0} {1}", request.Method, encodedPath);
        }

        public string GetMatchingKey(RecordEntry recordEntry)
        {
            var encodedPath = recordEntry.EncodedRequestUri;
            var path = recordEntry.RequestUri;
            var changed = false;
            if (path.Contains("?&"))
            {
                path = recordEntry.RequestUri.Replace("?&", "?");
                changed = true;
            }

            string version;
            if (ContainsIgnoredProvider(path, out version))
            {
                path = RemoveOrReplaceApiVersion(path, version);
                changed = true;
            }

            if (changed)
            {
                encodedPath = Convert.ToBase64String(Encoding.UTF8.GetBytes(path));
            }

            return string.Format("{0} {1}", recordEntry.RequestMethod, encodedPath);
        }

        private bool ContainsIgnoredProvider(string requestUri, out string version)
        {
            if (_ignoreGenericResource && !requestUri.Contains("providers"))
            {
                version = String.Empty;
                return true;
            }

            foreach (var provider in _providersToIgnore)
            {
                var providerString = string.Format("providers/{0}", provider.Key);
                if (requestUri.Contains(providerString))
                {
                    version = provider.Value;
                    return true;
                }
            }


            version = string.Empty;
            return false;
        }

        private string RemoveOrReplaceApiVersion(string requestUri, string version)
        {
            if (!string.IsNullOrWhiteSpace(version))
            {
                return Regex.Replace(requestUri, @"([\?&])api-version=[^&]+", string.Format("$1api-version={0}", version));
            }
            else
            {
                var result= Regex.Replace(requestUri, @"&api-version=[^&]+", string.Empty);
                return Regex.Replace(result, @"\?api-version=[^&]+[&]*", "?");
            }
        }
    }
}