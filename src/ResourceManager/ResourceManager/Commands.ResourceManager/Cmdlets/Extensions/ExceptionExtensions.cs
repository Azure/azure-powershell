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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Threading;

    /// <summary>
    /// Exception extension methods
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Test if an exception is a fatal exception. 
        /// </summary>
        /// <param name="ex">Exception object.</param>
        public static bool IsFatal(this Exception ex)
        {
            if (ex is AggregateException)
            {
                return ex.Cast<AggregateException>().Flatten().InnerExceptions.Any(exception => exception.IsFatal());
            }

            if (ex.InnerException != null && ex.InnerException.IsFatal())
            {
                return true;
            }

            return
                ex is TypeInitializationException ||
                ex is AppDomainUnloadedException ||
                ex is ThreadInterruptedException ||
                ex is AccessViolationException ||
                ex is InvalidProgramException ||
                ex is BadImageFormatException ||
                ex is StackOverflowException ||
                ex is ThreadAbortException ||
                ex is OutOfMemoryException ||
                ex is SecurityException ||
                ex is SEHException;
        }
    }
}
