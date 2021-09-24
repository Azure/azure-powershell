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

namespace Microsoft.WindowsAzure.Commands.Common.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        private const string HeaderNameClientRequestId = "x-ms-client-request-id";

        /// <summary>
        /// Add x-ms-client-request-id to headers of Http Request 
        /// </summary>
        /// <param name="request">Current Http Request</param>
        /// <param name="clientRequestId">value of client request id</param>
        public static void AddClientRequestId(this HttpRequestMessage request, string clientRequestId)
        {
            if (request.Headers.Contains(HeaderNameClientRequestId))
            {
                request.Headers.Remove(HeaderNameClientRequestId);
            }
            request.Headers.TryAddWithoutValidation(HeaderNameClientRequestId, clientRequestId);
        }

    }
}
