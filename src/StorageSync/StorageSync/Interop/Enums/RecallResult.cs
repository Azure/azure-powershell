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
    /// Enum RecallResult
    /// </summary>
    public enum RecallResult
    {
        /// <summary>
        /// The recall succeeded
        /// </summary>
        RECALL_SUCCEEDED = 1,
        /// <summary>
        /// The recall failed
        /// </summary>
        RECALL_FAILED = 2,
        /// <summary>
        /// The recall skipped
        /// </summary>
        RECALL_SKIPPED = 3
    }

}
