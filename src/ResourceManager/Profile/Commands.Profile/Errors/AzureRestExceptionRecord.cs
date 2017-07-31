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
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Profile.Errors
{
    public class AzureRestExceptionRecord : AzureExceptionRecord
    {
        public AzureRestExceptionRecord(Hyak.Common.CloudException exception, ErrorRecord record, bool inner = false) : base(exception, record, inner)
        {
            if (exception != null)
            {
                if (exception.Error != null)
                {
                    ServerMessage = string.Format($"{exception.Error.Code}: {exception.Error.Message} ({exception.Error.OriginalMessage})");
                }

                if (exception.Response != null)
                {
                    ServerResponse = new HttpResponseInfo(exception.Response);
                }

                if (exception.Request != null)
                {
                    RequestMessage = new HttpRequestInfo(exception.Request);
                }
            }
        }

        public AzureRestExceptionRecord(Microsoft.Rest.Azure.CloudException exception, ErrorRecord record, bool inner = false) : base(exception, record, inner)
        {
            if (exception != null)
            {
                if (exception.Body != null)
                {
                    ServerMessage = string.Format($"{exception.Body.Code}: {exception.Body.Message} ({exception.Body.Details})");
                }

                if (exception.Response != null)
                {
                    ServerResponse = new HttpResponseInfo(exception.Response);
                }

                if (exception.Request != null)
                {
                    RequestMessage = new HttpRequestInfo(exception.Request);
                }

                RequestId = exception.RequestId;
            }
        }
        public string ServerMessage { get; set; }

        public HttpResponseInfo ServerResponse { get; set; }

        public HttpRequestInfo RequestMessage { get; set; }

        public string RequestId { get; set; }
    }
}
