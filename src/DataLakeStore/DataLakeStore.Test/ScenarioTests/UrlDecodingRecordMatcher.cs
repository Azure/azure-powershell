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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.DataLake.Test.ScenarioTests
{
    public class UrlDecodingRecordMatcher : PermissiveRecordMatcherWithApiExclusion
    {
        public UrlDecodingRecordMatcher(bool ignoreResourcesClient, Dictionary<string, string> providers) 
            : base(ignoreResourcesClient, providers)
        {
        }

        public UrlDecodingRecordMatcher(bool ignoreResourcesClient, Dictionary<string, string> providers, 
            Dictionary<string, string> userAgents) : base(ignoreResourcesClient, providers, userAgents)
        {
        }

        public override string GetMatchingKey(HttpRequestMessage request)
        {
            var path = request.RequestUri.PathAndQuery;
            Debugger.Break();
            if (path.Contains("?&"))
            {
                path = path.Replace("?&", "?");
            }
            path = RemoveOrReplaceLeaseIdOrFilessesionID(path);
            string version;
            if (ContainsIgnoredProvider(path, out version))
            {
                path = RemoveOrReplaceApiVersion(path, version);
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
                            path = RemoveOrReplaceApiVersion(path, userAgnet.Value);
                            break;
                        }
                    }
                }
            }

            var encodedPath = Convert.ToBase64String(Encoding.UTF8.GetBytes(path));
            return string.Format("{0} {1}", request.Method, encodedPath);
        }

        public override string GetMatchingKey(RecordEntry recordEntry)
        {
            var encodedPath = recordEntry.EncodedRequestUri;
            var path = recordEntry.RequestUri;
            var changed = false;
            if (path.Contains("?&"))
            {
                path = recordEntry.RequestUri.Replace("?&", "?");
                changed = true;
            }
            if (path.Contains("leaseid") || path.Contains("filesessionid"))
            {
                path = RemoveOrReplaceLeaseIdOrFilessesionID(path);
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
        protected string RemoveOrReplaceLeaseIdOrFilessesionID(string requestUri)
        {
            var removedLeaseid = Regex.Replace(requestUri, @"([\?&])leaseid=[^&]+", string.Format("$1leaseid={0}", "const"));
            return Regex.Replace(removedLeaseid, @"([\?&])filesessionid=[^&]+", string.Format("$1filesessionid={0}", "const"));
        }
    }
}
