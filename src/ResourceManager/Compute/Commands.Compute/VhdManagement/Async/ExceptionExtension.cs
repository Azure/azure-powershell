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
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.Tools.Common.General
{
    public static class ExceptionExtensions
    {
        private static readonly MethodInfo methodPrepForRemoting = typeof(Exception).GetMethod("PrepForRemoting", BindingFlags.NonPublic | BindingFlags.Instance);

        public static bool IsCritical(
            this Exception exception
            )
        {
            Debug.Assert(null != exception);

            if (null == exception)
            {
                throw new ArgumentNullException("exception");
            }

            return (
                (exception is AccessViolationException) ||
                (exception is InsufficientMemoryException) ||
                (exception is OutOfMemoryException) ||
                (exception is SEHException) ||
                (exception is StackOverflowException) ||
                (exception is ThreadAbortException)
                );
        }

        public static Exception PrepareServerStackForRethrow(
            this Exception exception
            )
        {
            Debug.Assert(null != exception);

            methodPrepForRemoting.Invoke(exception, new object[0]);

            return exception;
        }
    }
}
