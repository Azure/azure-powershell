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
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests
{
    /// <summary>
    /// Helper class that stores asyncronous exceptions to be thrown on the main thread.
    /// </summary>
    public class AsyncExceptionManager : IDisposable
    {
        /// <summary>
        /// Stores a list of exceptions that was caught during the execution.
        /// </summary>
        private List<Exception> exceptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncExceptionManager" /> class.
        /// </summary>
        public AsyncExceptionManager()
        {
            this.exceptions = new List<Exception>();
        }

        /// <summary>
        /// Execute the <paramref name="action"/> and stores any exception that occur.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        public void CatchExceptions(Action action)
        {
            this.CatchExceptions(action, null);
        }

        /// <summary>
        /// Execute the <paramref name="action"/> and stores any exception that occur.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        public void CatchExceptions(Action action, Action cleanup)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                this.exceptions.Add(ex);
                Console.Error.WriteLine(ex.ToString());

                // Try execute the cleanup action
                if (cleanup != null)
                {
                    try
                    {
                        cleanup();
                    }
                    catch (Exception cleanupEx)
                    {
                        this.exceptions.Add(cleanupEx);
                        Console.Error.WriteLine(cleanupEx.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Disposes the exception manager and throws the first exception if it occurred.
        /// </summary>
        public void Dispose()
        {
            if (this.exceptions.Count > 0)
            {
                throw this.exceptions.First();
            }
        }
    }
}
