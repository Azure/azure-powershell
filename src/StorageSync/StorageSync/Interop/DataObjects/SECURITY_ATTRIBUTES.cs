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
using System.Runtime.InteropServices;

namespace Commands.StorageSync.Interop.DataObjects
{
    /// <summary>
    /// Struct SECURITY_ATTRIBUTES
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_ATTRIBUTES
    {
        /// <summary>
        /// The n length
        /// </summary>
        public int nLength;
        /// <summary>
        /// The lp security descriptor
        /// </summary>
        public IntPtr lpSecurityDescriptor;
        /// <summary>
        /// The b inherit handle
        /// </summary>
        public int bInheritHandle;
    }
}
