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

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Specialized;
using System.Web;

namespace Microsoft.Azure.Commands.Blueprint.Common
{
    /// <summary>
    /// Delegating handler class to append $expand=versions to the URL. Needed to get blueprint versions.
    /// </summary>
    public class ApiExpandHandler : DelegatingHandler, ICloneable
    {
        private const string ExpandString = "versions";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uriString = request.RequestUri.ToString();
            UriBuilder uri = new UriBuilder(uriString);
            var expandQueryString = "&$expand=" + ExpandString;
            var apiString =  uri.ToString() + expandQueryString;
            request.RequestUri = new Uri(apiString);

            return base.SendAsync(request, cancellationToken);
        }
        public object Clone()
        {
            return new ApiExpandHandler();
        }
    }
}
