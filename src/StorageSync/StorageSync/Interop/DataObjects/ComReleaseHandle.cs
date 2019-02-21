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
using System.Text;
using System.Threading.Tasks;

namespace Commands.StorageSync.Interop.DataObjects
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Class COMReleaseHandle. This class cannot be inherited.
    /// Implements the <see cref="System.Runtime.InteropServices.SafeHandle" />
    /// </summary>
    /// <seealso cref="System.Runtime.InteropServices.SafeHandle" />
    public sealed class COMReleaseHandle : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="COMReleaseHandle" /> class.
        /// </summary>
        public COMReleaseHandle() : base(IntPtr.Zero, true)
        {
        }

        /// <summary>
        /// When overridden in a derived class, gets a value indicating whether the handle value is invalid.
        /// </summary>
        /// <value><c>true</c> if this instance is invalid; otherwise, <c>false</c>.</value>
        public override bool IsInvalid
        {
            get
            {
                return handle == IntPtr.Zero;
            }
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it generates a <see cref="~/docs/framework/debug-trace-profile/releasehandlefailed-mda.md">releaseHandleFailed</see> Managed Debugging Assistant.</returns>
        protected override bool ReleaseHandle()
        {
            int newRefCount = Marshal.Release(handle);
            Debug.Write($"RefCount: {newRefCount}");
            return true;
        }

        /// <summary>
        /// Attaches the handle.
        /// </summary>
        /// <param name="assignedHandle">The assigned handle.</param>
        public void AttachHandle(IntPtr assignedHandle)
        {
            SetHandle(assignedHandle);
        }
    }
}
