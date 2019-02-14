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


namespace Commands.StorageSync.Interop.Enums
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Enum EFileAttributes
    /// </summary>
    [Flags]
    public enum EFileAttributes : uint
    {
        /// <summary>
        /// The readonly
        /// </summary>
        Readonly = 0x00000001,
        /// <summary>
        /// The hidden
        /// </summary>
        Hidden = 0x00000002,
        /// <summary>
        /// The system
        /// </summary>
        System = 0x00000004,
        /// <summary>
        /// The directory
        /// </summary>
        Directory = 0x00000010,
        /// <summary>
        /// The archive
        /// </summary>
        Archive = 0x00000020,
        /// <summary>
        /// The device
        /// </summary>
        Device = 0x00000040,
        /// <summary>
        /// The normal
        /// </summary>
        Normal = 0x00000080,
        /// <summary>
        /// The temporary
        /// </summary>
        Temporary = 0x00000100,
        /// <summary>
        /// The sparse file
        /// </summary>
        SparseFile = 0x00000200,
        /// <summary>
        /// The reparse point
        /// </summary>
        ReparsePoint = 0x00000400,
        /// <summary>
        /// The compressed
        /// </summary>
        Compressed = 0x00000800,
        /// <summary>
        /// The offline
        /// </summary>
        Offline = 0x00001000,
        /// <summary>
        /// The not content indexed
        /// </summary>
        NotContentIndexed = 0x00002000,
        /// <summary>
        /// The encrypted
        /// </summary>
        Encrypted = 0x00004000,
        /// <summary>
        /// The write through
        /// </summary>
        Write_Through = 0x80000000,
        /// <summary>
        /// The overlapped
        /// </summary>
        Overlapped = 0x40000000,
        /// <summary>
        /// The no buffering
        /// </summary>
        NoBuffering = 0x20000000,
        /// <summary>
        /// The random access
        /// </summary>
        RandomAccess = 0x10000000,
        /// <summary>
        /// The sequential scan
        /// </summary>
        SequentialScan = 0x08000000,
        /// <summary>
        /// The delete on close
        /// </summary>
        DeleteOnClose = 0x04000000,
        /// <summary>
        /// The backup semantics
        /// </summary>
        BackupSemantics = 0x02000000,
        /// <summary>
        /// The posix semantics
        /// </summary>
        PosixSemantics = 0x01000000,
        /// <summary>
        /// The open reparse point
        /// </summary>
        OpenReparsePoint = 0x00200000,
        /// <summary>
        /// The open no recall
        /// </summary>
        OpenNoRecall = 0x00100000,
        /// <summary>
        /// The first pipe instance
        /// </summary>
        FirstPipeInstance = 0x00080000
    }

}
