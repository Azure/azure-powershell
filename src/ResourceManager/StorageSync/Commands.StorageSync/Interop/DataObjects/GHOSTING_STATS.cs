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

    [StructLayout(LayoutKind.Sequential)]
    public struct GHOSTING_STATS
    {
        public UInt32 TieredCount;
        public UInt32 AlreadyTieredCount;
        public UInt32 SkippedForSizeCount;
        public UInt32 SkippedForAgeCount;
        public UInt32 SkippedForUnsupportedReparsePointCount;
        public UInt32 FailedToTierCount;
        public UInt64 ReclaimedSpaceBytes;
        public UInt64 SkippedForStableVersionFailure;
    }

}
