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
    /// Interface representing a WhatIf diagnostic message.
    /// Implemented by RP-specific classes to provide diagnostic information.
    /// </summary>
    public interface IWhatIfDiagnostic
    {
        /// <summary>
        /// Diagnostic code.
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Diagnostic message.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Diagnostic level (e.g., "Error", "Warning", "Info").
        /// </summary>
        string Level { get; }

        /// <summary>
        /// Target resource or component.
        /// </summary>
        string Target { get; }

        /// <summary>
        /// Additional details.
        /// </summary>
        string Details { get; }
    }
}
