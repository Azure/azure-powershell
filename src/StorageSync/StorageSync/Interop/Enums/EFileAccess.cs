﻿// ----------------------------------------------------------------------------------
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
    /// Enum EFileAccess
    /// </summary>
    [Flags]
    public enum EFileAccess : uint
    {
        /// <summary>
        /// The generic read
        /// </summary>
        GenericRead = 0x80000000,
        /// <summary>
        /// The generic write
        /// </summary>
        GenericWrite = 0x40000000,
        /// <summary>
        /// The generic execute
        /// </summary>
        GenericExecute = 0x20000000,
        /// <summary>
        /// The generic all
        /// </summary>
        GenericAll = 0x10000000,
    }

}
