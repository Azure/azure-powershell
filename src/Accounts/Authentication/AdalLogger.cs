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

using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Implements logging callback for ADAL - since only a single logger is allowed, allow
    /// reporting logs to multiple logging mechanisms
    /// </summary>
    /// TODO: AdalLogger should be useless, will verify after engineering bits
    public class AdalLogger :  IDisposable
    {
        Action<string> _logger;

        public AdalLogger(Action<string> logger)
        {
            _logger = logger;
            AdalCompositeLogger.Enable(this);
        }

        /// <summary>
        /// Manually disable the logger
        /// </summary>
        public static void Disable()
        {
            AdalCompositeLogger.Disable();
        }

        /// <summary>
        /// Free resources associated with a logger and disable it
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Remove this logger from the logging delegate
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose( bool disposing)
        {
            if (disposing && _logger != null)
            {
                AdalCompositeLogger.Disable(this);
                _logger = null;
            }
        }

        /// <summary>
        /// Handle the given ADAL log message
        /// </summary>
        /// <param name="level">The log level</param>
        /// <param name="message">The log message</param>
        public void Log(LogLevel level, string message)
        {
            _logger($"[ADAL]: {level}: {message}");
        }

        /// <summary>
        /// Central logging mechanism - allows registering multiple logging callbacks
        /// </summary>
        class AdalCompositeLogger 
        {
            static object _lockObject = new object();
            IList<AdalLogger> _loggers = new List<AdalLogger>();
            private AdalCompositeLogger()
            {
            }

            /// <summary>
            /// singleton logger instance, since only one log callback delegate is allowed
            /// </summary>
            static AdalCompositeLogger Instance { get; } = new AdalCompositeLogger();

            /// <summary>
            /// Enable logging through the given logging delegate
            /// </summary>
            /// <param name="logger">The logger to send ADAL messages to</param>
            internal static void Enable(AdalLogger logger)
            {
                lock (_lockObject)
                {
                    Instance._loggers.Add(logger);
                    //LoggerCallbackHandler.LogCallback = Instance.Log;
                    //LoggerCallbackHandler.PiiLoggingEnabled = true;
                }
            }

            /// <summary>
            /// Disable all ADAL logging
            /// </summary>
            internal static void Disable()
            {
                lock (_lockObject)
                {
                    Instance._loggers.Clear();
                    //LoggerCallbackHandler.UseDefaultLogging = false;
                }
            }

            /// <summary>
            /// Disable the given logger by removing from the logger collection
            /// </summary>
            /// <param name="logger"></param>
            internal static void Disable(AdalLogger logger)
            {
                lock (_lockObject)
                {
                    Instance._loggers.Remove(logger);
                }
            }

            /// <summary>
            /// Log a message to all active loggers
            /// </summary>
            /// <param name="level">The log level</param>
            /// <param name="message">The log message</param>
            /// <param name="containsPII"></param>
            public void Log(LogLevel level, string message, bool containsPII)
            {
                foreach (var logger in _loggers)
                {
                    logger.Log(level, message);
                }
            }
        }
    }

    
}
