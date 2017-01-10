// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using Microsoft.Azure.Commands.DataLakeStore.Properties;
using Microsoft.Rest;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    public enum LogLevel
    {
        Debug = 0,
        Information = 1,
        Error = 2,
        None = 3
    }

    public class DataLakeStoreTraceLogger
    {
        private const string MessagePrefixFormat = "ActivityId: [{0}] {1:yyyy-MM-dd HH:mm:ss.ffffff} T{2} {3}";

        public string LogFilePath { get; set; }

        public LogLevel LogLevel { get; set; }

        public readonly IServiceClientTracingInterceptor SdkTracingInterceptor;

        public DataLakeStoreTraceLogger(Cmdlet commandToLog, string logFilePath = null, LogLevel logLevel = LogLevel.Information)
        {
            LogFilePath = logFilePath;
            LogLevel = LogLevel;
            if (string.IsNullOrEmpty(LogFilePath))
            {
                LogFilePath = string.Format(@"{0}\ADLDataTransfer\ADLDataTransfer_{1}.log",
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    DateTime.Now.ToString("MM-dd-yyyy.HH.mm"));
            }

            FileStream traceStream = null;

            try
            {
                traceStream = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            }
            catch (Exception ex)
            {
                commandToLog.WriteWarning(string.Format(Resources.TraceStreamFailure, LogFilePath, ex.Message));
                return;
            }

            var defaultListener = new TextWriterTraceListener(traceStream);
            Trace.CorrelationManager.ActivityId = Guid.NewGuid();
            Trace.Listeners.Add(defaultListener);
            Trace.AutoFlush = true;

            SdkTracingInterceptor = new DataLakeStoreTracingInterceptor(this);
        }

        public void LogInformation(string message, params object[] args)
        {
            if (LogLevel == LogLevel.Debug || LogLevel == LogLevel.Information)
            {
                Trace.TraceInformation(BuildMessage("INFO", message, args));
            }
        }

        public void LogDebug(string message, params object[] args)
        {
            if (LogLevel == LogLevel.Debug)
            {
                Trace.TraceInformation(BuildMessage("DEBUG", message, args));
            }
        }

        public void LogError(string message, params object[] args)
        {
            if (LogLevel != LogLevel.None)
            {
                Trace.TraceError(BuildMessage("ERROR", message, args));
            }
        }

        public string BuildMessage(string logType, string message, params object[] args)
        {
            string messagePrefix = String.Format(MessagePrefixFormat,
                               Trace.CorrelationManager.ActivityId, DateTime.UtcNow, Thread.CurrentThread.ManagedThreadId, logType);
            var fullMessage = new StringBuilder();
            fullMessage.Append(messagePrefix);
            fullMessage.Append(" ");
            if (!args.Any())
            {
                fullMessage.Append(message);
            }
            else
            {
                fullMessage.AppendFormat(message, args);
            }
            return fullMessage.ToString();
        }

        public void Flush()
        {
            Trace.Flush();
        }
    }
}
