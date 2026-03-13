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
    using System.Collections.Generic;

    /// <summary>
    /// Interface representing a WhatIf operation result.
    /// Implemented by RP-specific classes to provide operation result information.
    /// </summary>
    public interface IWhatIfOperationResult
    {
        /// <summary>
        /// The operation status.
        /// </summary>
        string Status { get; }

        /// <summary>
        /// The list of resource changes.
        /// </summary>
        IList<IWhatIfChange> Changes { get; }

        /// <summary>
        /// The list of potential resource changes (may or may not happen).
        /// </summary>
        IList<IWhatIfChange> PotentialChanges { get; }

        /// <summary>
        /// The list of diagnostics.
        /// </summary>
        IList<IWhatIfDiagnostic> Diagnostics { get; }

        /// <summary>
        /// Error information if the operation failed.
        /// </summary>
        IWhatIfError Error { get; }
    }
}
