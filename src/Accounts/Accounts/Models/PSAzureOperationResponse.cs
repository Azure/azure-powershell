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
using System.Net.Http;
using System.Net;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Profile.Models
{
    public class PSAzureOperationResponse
    {
        public string CorrelationId { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public HttpMethod Method { get; set; }

        public bool IsSuccessStatusCode { get; set; }

        public string ReasonPhrase { get; set; }

    }

    public class PSAzureOperationResponse<T> : PSAzureOperationResponse
    {
        public T Body { get; set; }

        public PSAzureOperationResponse(AzureOperationResponse<T> response)
        {
            this.Body = response.Body;
            this.StatusCode = response.Response.StatusCode;
            this.Method = response.Request.Method;
            this.IsSuccessStatusCode = response.Response.IsSuccessStatusCode;
            this.ReasonPhrase = response.Response.ReasonPhrase;
            this.CorrelationId = response.RequestId;
        }

    }
}
