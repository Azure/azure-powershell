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

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Microsoft.WindowsAzure.Commands.Common
{
#if NETSTANDARD1_6
    public class AdalLogger : IAdalLogCallback
    {
        TraceListener _listener;
        public static void Enable(DebugStreamTraceListener listener)
        {
            var logger = new AdalLogger();
            logger._listener = listener;
            Microsoft.IdentityModel.Clients.ActiveDirectory.LoggerCallbackHandler.Callback = logger;
        }

        public static void Disable()
        {
            Microsoft.IdentityModel.Clients.ActiveDirectory.LoggerCallbackHandler.Callback = null;
        }
        public void Log(LogLevel level, string message)
        {
            _listener.WriteLine($"[AdalTrace ({level}]: {message}");
        }
    }
#endif
    public class DebugStreamTraceListener : TraceListener
    {
        public DebugStreamTraceListener(ConcurrentQueue<string> queue)
        {
            Messages = queue;
        }

        public static void AddAdalTracing(DebugStreamTraceListener listener)
        {
#if !NETSTANDARD1_6
            AdalTrace.TraceSource.Listeners.Add(listener);
            AdalTrace.TraceSource.Switch.Level = SourceLevels.All;
#else
            AdalLogger.Enable(listener);
#endif
        }

        public ConcurrentQueue<string> Messages;
        public override void Write(string message)
        {
            Messages.CheckAndEnqueue(message);
        }

        public override void WriteLine(string message)
        {
            Write(message + "\n");
        }

        public static void RemoveAdalTracing(DebugStreamTraceListener listener)
        {
#if !NETSTANDARD1_6
            AdalTrace.TraceSource.Listeners.Remove(listener);
#else
            AdalLogger.Disable();
#endif
        }
    }
}
