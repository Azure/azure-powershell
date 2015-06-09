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
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Common
{
    public class ComputeTracingInterceptor : ICloudTracingInterceptor
    {
        private PSCmdlet _cmdlet;
        private ConcurrentQueue<string> _messageQueue;

        public ComputeTracingInterceptor(PSCmdlet cmdlet, ConcurrentQueue<string> queue)
        {
            _cmdlet = cmdlet;
            _messageQueue = queue;
        }

        private void Write(HttpResponseMessage response)
        {
            const string xmlRequestHeaderStr = "x-ms-request-id";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Running Compute Cmdlet: '{0}'", _cmdlet.MyInvocation.MyCommand.Name).AppendLine();
            sb.AppendFormat("Parameter Set Name: '{0}'", _cmdlet.ParameterSetName).AppendLine();
            sb.AppendFormat("Method: '{0}'", response.RequestMessage.Method).AppendLine();
            sb.AppendFormat("Request Uri: '{0}'", response.RequestMessage.RequestUri).AppendLine();
            sb.AppendFormat("Status Code: '{0}'", response.StatusCode).AppendLine();
            sb.AppendFormat("Asynchronous Operation Id: '{0}'", response.Headers.GetValues(xmlRequestHeaderStr).FirstOrDefault()).AppendLine();

            string message = sb.ToString();
            _messageQueue.Enqueue(message);
            //_cmdlet.WriteVerbose(message);
        }

        private void Write(string message, params object[] arguments)
        {
            // Ignore
        }

        public void Information(string message)
        {
            // Ignore
        }

        public void Configuration(string source, string name, string value)
        {
            // Ignore
        }

        public void Enter(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            // Ignore
        }

        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
            // Ignore
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.Created)
            {
                Write(response);
            }
        }

        public void Error(string invocationId, Exception ex)
        {
            // Ignore
        }

        public void Exit(string invocationId, object result)
        {
            // Ignore
        }

        public static void AddToContext(ComputeTracingInterceptor interceptor)
        {
            RemoveFromContext(interceptor);
            TracingAdapter.AddTracingInterceptor(interceptor);
        }

        public static void RemoveFromContext(ComputeTracingInterceptor interceptor)
        {
            try
            {
                TracingAdapter.RemoveTracingInterceptor(interceptor);
            }
            catch
            {
                // Ignore
            }
        }
    }
}

