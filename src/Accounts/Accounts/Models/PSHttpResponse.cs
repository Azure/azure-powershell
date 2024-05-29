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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using Microsoft.Rest;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Profile.Models
{
    public class PSHttpResponse
    {

        [Ps1Xml(Target = ViewControl.List ,Label = "StatusCode", Position = 0)]
        public int StatusCode { get; set; }

        [Ps1Xml(Target = ViewControl.List, Label = "Content", Position = 1)]
        public string Content { get; set; }

        [Ps1Xml(Target = ViewControl.List, Label = "Headers", ScriptBlock = "[Microsoft.Rest.HttpExtensions]::ToJson($_.Headers).ToString()", Position = 2)]
        public HttpResponseHeaders Headers { get; }

        [Ps1Xml(Target = ViewControl.List, Label = "Method", Position = 3)]
        public string Method { get; set; }

        [Ps1Xml(Target = ViewControl.List, Label = "RequestUri", Position = 4)]
        public string RequestUri { get; set; }

        [Ps1Xml(Target = ViewControl.List, Label = "Version", Position = 5)]
        public string Version { get; set; }

        public PSHttpResponse(AzureOperationResponse<string> response)
        {         
            this.Headers = response.Response.Headers;
            this.Version = response.Response.Version.ToString();
            this.StatusCode = (int)response.Response.StatusCode;
            this.Method = response.Response.RequestMessage.Method.Method;
            try
            {
                this.Content = JObject.Parse(response.Body).ToString();
            }
            catch
            {
                this.Content = response.Body;
            }
            this.RequestUri = response.Request.RequestUri.ToString();
        }        
    }
}
