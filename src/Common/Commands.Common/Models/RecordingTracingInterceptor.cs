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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Common.Models
{
    public class RecordingTracingInterceptor : ICloudTracingInterceptor
    {
        public RecordingTracingInterceptor()
        {
            MessageQueue = new ConcurrentQueue<string>();
        }
        
        public ConcurrentQueue<string> MessageQueue { get; private set; }

        private void Write(string message, params object[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                MessageQueue.Enqueue(message);
            }
            else
            {
                MessageQueue.Enqueue(string.Format(message, arguments));
            }
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
            Write(GeneralUtilities.GetLog(request));
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            Write(GeneralUtilities.GetLog(response));
        }

        public void Error(string invocationId, Exception ex)
        {
            // Ignore 
        }

        public void Exit(string invocationId, object result)
        {
            // Ignore 
        }

        public static void AddToContext(RecordingTracingInterceptor interceptor)
        {
            RemoveFromContext(interceptor);
            CloudContext.Configuration.Tracing.AddTracingInterceptor(interceptor);
        }

        public static void RemoveFromContext(RecordingTracingInterceptor interceptor)
        {
            try
            {
                CloudContext.Configuration.Tracing.RemoveTracingInterceptor(interceptor);
            }
            catch
            {
                // Ignore
            }
        }
    }
}

