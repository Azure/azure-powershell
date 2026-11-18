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

namespace Microsoft.Azure.PowerShell.Cmdlets.Resiliency
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The spec sends the operation ID of action POSTs (drills, drill runs, recovery-plan actions and
    /// recovery jobs) as the `operation-id` header, but the released service does not reliably bind that
    /// header to its operationId parameter: the workflow never starts, the POST stays in progress and later
    /// POSTs on the resource fail with 409 InvalidResourceOperation. Also send the same ID as the
    /// `operationId` query parameter. Remove once the service binds the header.
    /// </summary>
    public partial class Module
    {
        partial void AfterCreatePipeline(global::System.Management.Automation.InvocationInfo invocationInfo, ref Runtime.HttpPipeline pipeline)
        {
            pipeline.Append(MirrorOperationIdToQuery);
        }

        private static Task<HttpResponseMessage> MirrorOperationIdToQuery(
            HttpRequestMessage request,
            CancellationToken token,
            Action cancel,
            Func<string, CancellationToken, Func<EventArgs>, Task> signal,
            Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>> next)
        {
            if (request.Method == HttpMethod.Post
                && request.RequestUri != null
                && request.Headers.TryGetValues("operation-id", out var values))
            {
                var operationId = values.FirstOrDefault();
                var query = request.RequestUri.Query;
                if (!string.IsNullOrEmpty(operationId)
                    && query.IndexOf("operationId=", StringComparison.OrdinalIgnoreCase) < 0)
                {
                    var builder = new UriBuilder(request.RequestUri);
                    var parameter = "operationId=" + Uri.EscapeDataString(operationId);
                    builder.Query = string.IsNullOrEmpty(query) ? parameter : query.TrimStart('?') + "&" + parameter;
                    request.RequestUri = builder.Uri;
                }
            }
            return next(request, token, cancel, signal);
        }
    }
}
