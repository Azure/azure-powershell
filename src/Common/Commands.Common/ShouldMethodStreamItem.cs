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
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Common
{
    /// <summary>
    /// Queued item tracking a deferred method execution
    /// </summary>
    internal class ShouldMethodStreamItem
    {
        /// <summary>
        /// Create a should method stream item with the given invoker
        /// </summary>
        /// <param name="invoker"></param>
        public ShouldMethodStreamItem(ShouldMethodInvoker invoker)
        {
            MethodInvoker = invoker;
        }

        /// <summary>
        /// Record of the ShouldMethod invocation to be deferred
        /// </summary>
        public ShouldMethodInvoker MethodInvoker { get;  private set; }

        /// <summary>
        /// Perform the method execution
        /// </summary>
        /// <param name="cmdlet"></param>
        public void ExecuteShouldMethod(Cmdlet cmdlet)
        {
            lock (MethodInvoker.SyncObject)
            {
                MethodInvoker.MethodResult = false;
            }

            if (cmdlet != null)
            {
                try
                {
                    bool result = MethodInvoker.ShouldMethod(cmdlet);
                    lock(MethodInvoker.SyncObject)
                    {
                        MethodInvoker.MethodResult = result;
                    }
                }
                catch (Exception exception)
                {
                    lock (MethodInvoker.SyncObject)
                    {
                        MethodInvoker.ThrownException = exception;
                    }

                    throw;
                }
            }
        }
    }
}
