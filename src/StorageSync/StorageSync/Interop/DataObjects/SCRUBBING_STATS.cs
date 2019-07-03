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
    /// Struct SCRUBBING_STATS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SCRUBBING_STATS
    {
        /// <summary>
        /// The file data access failures
        /// </summary>
        public UInt32 FileDataAccessFailures;
        /// <summary>
        /// The files automatic recovered
        /// </summary>
        public UInt32 FilesAutoRecovered;
        /// <summary>
        /// The files recovered
        /// </summary>
        public UInt32 FilesRecovered;
        /// <summary>
        /// The files failed to recover
        /// </summary>
        public UInt32 FilesFailedToRecover;
        /// <summary>
        /// The error files created
        /// </summary>
        public UInt32 ErrorFilesCreated;
        /// <summary>
        /// The files needing promotion
        /// </summary>
        public UInt32 FilesNeedingPromotion;
        /// <summary>
        /// The files promoted
        /// </summary>
        public UInt32 FilesPromoted;
    }
}
