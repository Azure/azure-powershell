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
    /// Struct RecallStatistics
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RecallStatistics
    {
        /// <summary>
        /// The number of files processed
        /// </summary>
        public UInt32 NumberOfFilesProcessed;
        /// <summary>
        /// The number of files recalled
        /// </summary>
        public UInt32 NumberOfFilesRecalled;
        /// <summary>
        /// The number of files failed to recall
        /// </summary>
        public UInt32 NumberOfFilesFailedToRecall;
        /// <summary>
        /// The numberof files skipped
        /// </summary>
        public UInt32 NumberofFilesSkipped;
        /// <summary>
        /// The space claimed in bytes
        /// </summary>
        public UInt64 SpaceClaimedInBytes;
    }
}
