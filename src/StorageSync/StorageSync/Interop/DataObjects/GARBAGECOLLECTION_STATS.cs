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

namespace Commands.StorageSync.Interop.DataObjects
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Struct GARBAGECOLLECTION_STATS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GARBAGECOLLECTION_STATS
    {
        /// <summary>
        /// The stable versions deleted
        /// </summary>
        public UInt32 StableVersionsDeleted;
        /// <summary>
        /// The stable versions already deleted
        /// </summary>
        public UInt32 StableVersionsAlreadyDeleted;
        /// <summary>
        /// The stable versions failed to delete
        /// </summary>
        public UInt32 StableVersionsFailedToDelete;
        /// <summary>
        /// The stable versions failed to delete exceeded maximum count
        /// </summary>
        public UInt32 StableVersionsFailedToDeleteExceededMaxCnt;
    }
}
