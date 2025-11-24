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

namespace Microsoft.Azure.PowerShell.Cmdlets.Shared.WhatIf.Models
{
    /// <summary>
    /// PowerShell representation of change types for display purposes.
    /// </summary>
    public enum PSChangeType
    {
        /// <summary>
        /// Create change type.
        /// </summary>
        Create,

        /// <summary>
        /// Delete change type.
        /// </summary>
        Delete,

        /// <summary>
        /// Deploy change type.
        /// </summary>
        Deploy,

        /// <summary>
        /// Ignore change type.
        /// </summary>
        Ignore,

        /// <summary>
        /// Modify change type.
        /// </summary>
        Modify,

        /// <summary>
        /// No change type.
        /// </summary>
        NoChange,

        /// <summary>
        /// No effect change type.
        /// </summary>
        NoEffect,

        /// <summary>
        /// Unsupported change type.
        /// </summary>
        Unsupported
    }
}
