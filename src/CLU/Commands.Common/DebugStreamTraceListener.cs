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
using System.Diagnostics;
using System.Net.Http;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Utilities.Common;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.Common
{
    public class DebugStreamTraceListener : TraceListener, IServiceClientTracingInterceptor
    {
        public DebugStreamTraceListener(ConcurrentQueue<string> queue)
        {
            Messages = queue;
        }

        public static void AddAdalTracing(DebugStreamTraceListener listener)
        {
            //AdalTrace.TraceSource.Listeners.Add(listener);
            //AdalTrace.TraceSource.Switch.Level = SourceLevels.All;
        }

        public ConcurrentQueue<string> Messages; 
        public override void Write(string message)
        {
            Messages.Enqueue(message);
        }

        public override void WriteLine(string message)
        {
            Write(message +  "\n");
        }

        public static void RemoveAdalTracing(DebugStreamTraceListener listener)
        {
            //AdalTrace.TraceSource.Listeners.Remove(listener);
        }

        public void Configuration(string source, string name, string value)
        {
        }

        public void ExitMethod(string invocationId, object returnValue)
        {
            WriteLine($"{invocationId}: End method with return value {returnValue}");
        }

        public void Information(string message)
        {
        }

        public void TraceError(string invocationId, Exception exception)
        {
            WriteLine($"{invocationId}: Exception {exception}");
        }

        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
            WriteLine($"{invocationId} REQUEST:");
            WriteLine($"{GeneralUtilities.GetLog(request)}");
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            WriteLine($"{invocationId} RESPONSE:");
            WriteLine($"{GeneralUtilities.GetLog(response)}");
        }

        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            WriteLine($"{invocationId}: Start method {method} with return value");
        }
    }
}
