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

using System;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// Represents the current Azure PowerShell context.
    /// </summary>
    internal interface IAzContext
    {
        /// <summary>
        /// Gets the hashed user account id. A empty string if the user doesn't log in.
        /// </summary>
        public string UserId { get; }

        /// <summary>
        /// Gets the hashed MAC address.
        /// </summary>
        public string MacAddress { get; }

        /// <summary>
        /// Gets the OS where it's running on.
        /// </summary>
        public string OSVersion { get; }

        /// <summary>
        /// Gets the PowerShell version it's running on.
        /// </summary>
        public Version PowerShellVersion { get; }

        /// <summary>
        /// Gets the version of this module.
        /// </summary>
        public Version ModuleVersion { get; }

        /// <summary>
        /// Gets the current Az module version.
        /// </summary>
        public Version AzVersion { get; }

        /// <summary>
        /// Gets whether the user is an internal user.
        /// </summary>
        public bool IsInternal { get; }

        /// <summary>
        /// Updates the Az context.
        /// </summary>
        public void UpdateContext();
    }
}
