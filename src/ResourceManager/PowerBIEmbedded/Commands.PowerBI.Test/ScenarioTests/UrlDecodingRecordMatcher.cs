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

            if (path.Contains("%3A"))
            {
                path = path.Replace("%3A", ":");
            }

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
    }
}
