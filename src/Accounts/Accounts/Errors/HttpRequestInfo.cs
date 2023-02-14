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

using Hyak.Common;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Profile.Errors
{
    public class HttpRequestInfo : HttpMessageInfo
    {
        public HttpRequestInfo(CloudHttpRequestErrorInfo request) : base(request)
        {
            Uri = request.RequestUri;
            Verb = request.Method.ToString();
        }

        public HttpRequestInfo(HttpRequestMessageWrapper request) : base(request)
        {
            Uri = request.RequestUri;
            Verb = request.Method.ToString();
        }

        public Uri Uri { get; set; }

        public string Verb { get; set; }

        public override string ToString()
        {
            return string.Format("{{{0} {1}}}", Verb, Uri);
        }
    }
}
