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

using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Extensions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class ServiceClientTracingInterceptor : IServiceClientTracingInterceptor
    {
        public ServiceClientTracingInterceptor(ConcurrentQueue<string> queue, IList<Regex> matchers = null, string clientRequestId = null)
        {
            MessageQueue = queue;
            Matchers = matchers;
            this.clientRequestId = clientRequestId;
        }

        public ConcurrentQueue<string> MessageQueue { get; private set; }

        private IList<Regex> Matchers { get; set; }

        private string clientRequestId;

        public void Configuration(string source, string name, string value)
        {
            // Ignore 
        }

        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            // Ignore 
        }

        public void ExitMethod(string invocationId, object returnValue)
        {
            // Ignore 
        }

        public void Information(string message)
        {
            MessageQueue.CheckAndEnqueue(message);
        }

        public void ReceiveResponse(string invocationId, System.Net.Http.HttpResponseMessage response)
        {
            string responseAsString = response == null ? string.Empty : GeneralUtilities.GetLog(response, Matchers);
            MessageQueue.CheckAndEnqueue(responseAsString);
        }

        public void SendRequest(string invocationId, System.Net.Http.HttpRequestMessage request)
        {
            // CmdletInfoHandler sets/updates x-ms-client-request-id during SendAsync() no matter if SDK sets x-ms-client-request-id.
            // Update request here to ensure its value consistent with real result.
            if (request != null && clientRequestId != null)
            {
                request.AddClientRequestId(clientRequestId);
            }
            MessageQueue.CheckAndEnqueue(GeneralUtilities.GetLog(request, Matchers));
        }

        public void TraceError(string invocationId, Exception exception)
        {
            // Ignore 
        }

        public static void RemoveTracingInterceptor(ServiceClientTracingInterceptor interceptor)
        {
            if (interceptor != null)
            {
                ServiceClientTracing.RemoveTracingInterceptor(interceptor);
            }
        }
    }
}
