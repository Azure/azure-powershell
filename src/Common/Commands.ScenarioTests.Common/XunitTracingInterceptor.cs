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
using Hyak.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;
using Xunit.Abstractions;
using System.IO;
using System.Reflection;

namespace Microsoft.WindowsAzure.ServiceManagemenet.Common.Models
{
    public class XunitTracingInterceptor : Hyak.Common.ICloudTracingInterceptor
    {
        private readonly string callingAssembly;

        public XunitTracingInterceptor(ITestOutputHelper output)
        {
            traceOutput = output;
            callingAssembly = Assembly.GetCallingAssembly().FullName.Split(new[] { ',' })[0];
        }

        public ITestOutputHelper traceOutput;

        private void Write(string message, params object[] arguments)
        {
            try
            {
                traceOutput.WriteLine(string.Format(message, arguments));
                using (StreamWriter file = new StreamWriter(string.Format("{0}.test.log", callingAssembly).AsAbsoluteLocation(), true))
                {
                    file.WriteLine(string.Format(message, arguments));
                }
            }
            catch {}
        }

        public void Information(string message)
        {
            Write(message);
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

        public static void AddToContext(XunitTracingInterceptor interceptor)
        {
            RemoveFromContext(interceptor);
            TracingAdapter.AddTracingInterceptor(interceptor);
        }

        public static void RemoveFromContext(XunitTracingInterceptor interceptor)
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
