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

using Microsoft.Azure.Commands.Common.Authentication;
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

    public class DataLakeStoreTraceLogger : IDisposable
    {
        private const string MessagePrefixFormat = "ADLDataTransfer - ActivityId: [{0}] {1:yyyy-MM-dd HH:mm:ss.ffffff} T{2} {3}";

        internal string LogFilePath { get; set; }

        internal LogLevel LogLevel { get; set; }

        internal FileStream TraceStream { get; set; }

        internal TextWriterTraceListener TextListener { get; set; }

        private bool PreviousAutoFlush { get; set; }

        private SourceLevels PreviousAdalSourceLevel { get; set; }

        private TraceLevel PreviousAdalTraceLevel { get; set; }

        public readonly IServiceClientTracingInterceptor SdkTracingInterceptor;

        public DataLakeStoreTraceLogger(Cmdlet commandToLog, string logFilePath = null, LogLevel logLevel = LogLevel.Information)
        {
            LogFilePath = logFilePath;
            LogLevel = logLevel;
            if(Directory.Exists(LogFilePath)) // the user passed in a directory instead of a file
            {
                commandToLog.WriteWarning(string.Format(Resources.DiagnosticDirectoryAlreadyExists, LogFilePath));
                return;
            }

            try
            {
                // always create the directory, since it is a no-op if the path exists
                // we also do not do heavy validation here, since any exception will be caught and reported back as a warning.
                Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath));
                TraceStream = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            }
            catch (Exception ex)
            {
                commandToLog.WriteWarning(string.Format(Resources.TraceStreamFailure, LogFilePath, ex.Message));
                return;
            }

            TextListener = new TextWriterTraceListener(TraceStream);
            Trace.CorrelationManager.ActivityId = Guid.NewGuid();
            PreviousAutoFlush = Trace.AutoFlush;

            Trace.Listeners.Add(TextListener);
            Trace.AutoFlush = true;
            SdkTracingInterceptor = new DataLakeStoreTracingInterceptor(this);

            PreviousAdalSourceLevel = AzureSession.Instance.AuthenticationTraceSourceLevel;
            PreviousAdalTraceLevel = AzureSession.Instance.AuthenticationLegacyTraceLevel;

            // Ignore ADAL trace logs if debug logging isn't selected.
            if (LogLevel != LogLevel.Debug)
            {
                AzureSession.Instance.AuthenticationTraceSourceLevel = SourceLevels.Warning;
                AzureSession.Instance.AuthenticationLegacyTraceLevel = TraceLevel.Warning;
            }

            if (SdkTracingInterceptor != null)
            {
                ServiceClientTracing.AddTracingInterceptor(SdkTracingInterceptor);
            }
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
            string messagePrefix = string.Format(MessagePrefixFormat,
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

        public void Dispose()
        {
            if (SdkTracingInterceptor != null)
            {
                ServiceClientTracing.RemoveTracingInterceptor(SdkTracingInterceptor);
            }

            if (TextListener != null)
            {
                if (Trace.Listeners.Contains(TextListener))
                {
                    Trace.Listeners.Remove(TextListener);
                }

                TextListener.Dispose();
            }

            if(TraceStream != null)
            {
                TraceStream.Dispose();
            }

            Trace.AutoFlush = PreviousAutoFlush;
            AzureSession.Instance.AuthenticationTraceSourceLevel = PreviousAdalSourceLevel;
            AzureSession.Instance.AuthenticationLegacyTraceLevel = PreviousAdalTraceLevel;
        }
    }
}
