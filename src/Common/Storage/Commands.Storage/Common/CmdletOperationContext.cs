﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    using System;
    using System.Threading;
    using Microsoft.WindowsAzure.Storage;

    internal class CmdletOperationContext
    {
        private static volatile bool inited;
        private static object syncRoot = new Object();

        public static DateTime StartTime
        {
            get;
            private set;
        }

        public static string ClientRequestId
        {
            get;
            private set;
        }

        /// <summary>
        /// started remote call counter
        /// </summary>
        private static int startedRemoteCallCounter = 0;

        public static int StartedRemoteCallCounter
        {
            get
            {
                return startedRemoteCallCounter;
            }
        }

        /// <summary>
        /// finished remote call counter
        /// </summary>
        private static int finishedRemoteCallCounter = 0;

        public static int FinishedRemoteCallCounter
        {
            get
            {
                return finishedRemoteCallCounter;
            }
        }

        private CmdletOperationContext() { }

        /// <summary>
        /// Init the cmdlet operation context
        /// </summary>
        public static void Init()
        {
            if (!inited) 
            {
                lock (syncRoot) 
                {
                    if (!inited)
                    {
                        StartTime = DateTime.Now;
                        ClientRequestId = GenClientRequestID();
                        inited = true;
                    }
                }
            }
        }

        /// <summary>
        /// Get an unique client request id
        /// </summary>
        /// <returns>A unique request id</returns>
        internal static string GenClientRequestID()
        {
            string uniqueId = System.Guid.NewGuid().ToString();
            return string.Format(Resources.ClientRequestIdFormat, uniqueId);
        }

        /// <summary>
        /// Get Storage Operation Context for rest calls
        /// </summary>
        /// <param name="outputWriter">Ouput writer for writing logs for each rest call</param>
        /// <returns>Storage operation context</returns>
        public static OperationContext GetStorageOperationContext(Action<string> outputWriter)
        {
            if (!inited)
            {
                CmdletOperationContext.Init();
            }

            OperationContext context = new OperationContext();
            context.ClientRequestID = ClientRequestId;

            context.SendingRequest += (s, e) =>
            {
                context.StartTime = DateTime.Now;

                Interlocked.Increment(ref startedRemoteCallCounter);

                string message = String.Format(Resources.StartRemoteCall,
                    startedRemoteCallCounter, e.Request.Method, e.Request.RequestUri.ToString());

                try
                {
                    if (outputWriter != null)
                    {
                        outputWriter(message);
                    }
                }
                catch
                {
                    //catch the exception. If so, the storage client won't sleep and retry
                }
            };

            context.ResponseReceived += (s, e) =>
            {
                context.EndTime = DateTime.Now;
                Interlocked.Increment(ref finishedRemoteCallCounter);
                
                double elapsedTime = (context.EndTime - context.StartTime).TotalMilliseconds;
                string message = String.Format(Resources.FinishRemoteCall,
                    e.Request.RequestUri.ToString(), (int)e.Response.StatusCode, e.Response.StatusCode, e.RequestInformation.ServiceRequestID, elapsedTime);

                try
                {
                    if (outputWriter != null)
                    {
                        outputWriter(message);
                    }
                }
                catch
                {
                    //catch the exception. If so, the storage client won't sleep and retry
                }
            };
            
            return context;
        }

        /// <summary>
        /// Get the running ms from when operationcontext started
        /// </summary>
        /// <returns>A time string in ms</returns>
        public static double GetRunningMilliseconds()
        {
            if (!inited)
            {
                return 0;
            }
            else
            {
                TimeSpan span = DateTime.Now - StartTime;
                return span.TotalMilliseconds;
            }
        }
    }
}
