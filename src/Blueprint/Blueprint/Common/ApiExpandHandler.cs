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
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Blueprint.Common
{
    /// <summary>
    /// Delegating handler class to append $expand=versions to get blueprint versions in GET request.
    /// </summary>
    public class ApiExpandHandler : DelegatingHandler, ICloneable
    {
        private const string ExpandString = "versions";
        private const string BlueprintProviderName = "microsoft.blueprint";
        private const string BlueprintResourceTypeName = "blueprints";
        private const string ProvidersSegment = "/providers/";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Custom delegating handlers are per PS instance. We would like to make sure "&$expand" query
            // string is only applied if the request is GET(point GET and collection) operation for Blueprint service.
            if (request.Method == HttpMethod.Get)
            {
                var requestUri = request.RequestUri.GetLeftPart(UriPartial.Path);
                var lastProvidersSegmentIndex = requestUri.LastIndexOf(ProvidersSegment, StringComparison.InvariantCultureIgnoreCase);

                if (lastProvidersSegmentIndex >= 0)
                {
                    var segments = requestUri
                        .Substring(lastProvidersSegmentIndex)
                        .CoalesceString()
                        .Trim('/')
                        .SplitRemoveEmpty('/');

                    if (IsBlueprintListRequest(segments))
                    {
                        var uriString = request.RequestUri.ToString();
                        UriBuilder uri = new UriBuilder(uriString);
                        var expandQueryString = "&$expand=" + ExpandString;
                        var apiString = uri.ToString() + expandQueryString;
                        request.RequestUri = new Uri(apiString);
                    }
                }
            }

            return base.SendAsync(request, cancellationToken);
        }

        private bool IsBlueprintListRequest(string[] segments)
        {
            return segments.Any()
                && segments.Length >= 3
                && BlueprintProviderName.Equals(segments[1], StringComparison.InvariantCultureIgnoreCase)
                && BlueprintResourceTypeName.Equals(segments[2], StringComparison.InvariantCultureIgnoreCase);
        }

        public object Clone()
        {
            return new ApiExpandHandler();
        }
    }
}
