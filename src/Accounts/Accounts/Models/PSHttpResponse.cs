﻿//
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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Profile.Models
{
    public class PSHttpResponse
    {
        public HttpResponseHeaders Headers { get; }

        public string Version { get; set; }

        public int StatusCode { get; set; }

        public string Method { get; set; }

        public string Content { get; set; }

        public PSHttpResponse(AzureOperationResponse<string> response)
        {         
            this.Headers = response.Response.Headers;
            this.Version = response.Response.Version.ToString();
            this.StatusCode = (int)response.Response.StatusCode;
            this.Method = response.Response.RequestMessage.Method.Method;
            this.Content = response.Body;
        }
    }
}
