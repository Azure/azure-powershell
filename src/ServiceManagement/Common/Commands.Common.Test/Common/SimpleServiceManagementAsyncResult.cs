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
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Common
{
    /// <summary>
    /// Simple IAsyncResult implementation that can be used to cache all the
    /// parameters to the BeginFoo call and then passed to the FooThunk
    /// property that's invoked by EndFoo (thereby providing the test's
    /// implementation of FooThunk with as much of the state as it wants).
    /// </summary>
    public class SimpleServiceManagementAsyncResult : IAsyncResult
    {
        /// <summary>
        /// Gets a dictionary of state specific to a given call.
        /// </summary>
        public Dictionary<string, object> Values { get; private set; }

        /// <summary>
        /// Initializes a new instance of the
        /// SimpleServiceManagementAsyncResult class.
        /// </summary>
        public SimpleServiceManagementAsyncResult()
        {
            Values = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets the state specific to a given call.
        /// </summary>
        public object AsyncState
        {
            get { return Values; }
        }

        /// <summary>
        /// Gets an AsyncWaitHandle.  This is not implemented and will always
        /// throw.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations",
            Justification = "Tests should not access this property")]
        public WaitHandle AsyncWaitHandle
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a value indicating whether the async call completed
        /// synchronously.  It always returns true.
        /// </summary>
        public bool CompletedSynchronously
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the async call has completed.  It
        /// always returns true.
        /// </summary>
        public bool IsCompleted
        {
            get { return true; }
        }
    }
}
