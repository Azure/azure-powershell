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
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace Microsoft.Azure.Commands.Common
{
    using NextDelegate = Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>;
    using SignalDelegate = Func<string, CancellationToken, Func<EventArgs>, Task>;

    /// <summary>
    /// Pipeline step for adding x-ms-unique-id header
    /// </summary>
    public class UniqueId
    {
        private static UniqueId _instance;
        public static UniqueId Instance => UniqueId._instance ?? (UniqueId._instance = new UniqueId());

        private int count;

        /// <summary>
        /// Pipeline delegate to add a unique id header to an outgoing request
        /// </summary>
        /// <param name="request">The outgpoing request</param>
        /// <param name="token">The cancellation token</param>
        /// <param name="cancel">Additional cancellation action if the operation is cancelled</param>
        /// <param name="signal">Signal delegate for logging events</param>
        /// <param name="next">The next setp in the pipeline</param>
        /// <returns>Amended pipeline for retrieving a response</returns>
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token, Action cancel, SignalDelegate signal, NextDelegate next)
        {
            // add a header...
            request.Headers.Add("x-ms-unique-id", Interlocked.Increment(ref this.count).ToString());

            // continue with pipeline.
            return next(request, token, cancel, signal);
        }
    }

}
