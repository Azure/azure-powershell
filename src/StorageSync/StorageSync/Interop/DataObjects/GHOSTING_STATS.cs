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
    /// Struct GHOSTING_STATS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GHOSTING_STATS
    {
        /// <summary>
        /// The tiered count
        /// </summary>
        public UInt32 TieredCount;
        /// <summary>
        /// The already tiered count
        /// </summary>
        public UInt32 AlreadyTieredCount;
        /// <summary>
        /// The skipped for size count
        /// </summary>
        public UInt32 SkippedForSizeCount;
        /// <summary>
        /// The skipped for age count
        /// </summary>
        public UInt32 SkippedForAgeCount;
        /// <summary>
        /// The skipped for unsupported reparse point count
        /// </summary>
        public UInt32 SkippedForUnsupportedReparsePointCount;
        /// <summary>
        /// The failed to tier count
        /// </summary>
        public UInt32 FailedToTierCount;
        /// <summary>
        /// The reclaimed space bytes
        /// </summary>
        public UInt64 ReclaimedSpaceBytes;
        /// <summary>
        /// The skipped for stable version failure
        /// </summary>
        public UInt64 SkippedForStableVersionFailure;
    }

}
