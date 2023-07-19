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
using System.Management.Automation.Runspaces;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// Represents the current Azure PowerShell context.
    /// </summary>
    internal interface IAzContext
    {
        /// <summary>
        /// Gets the installation id that's associate with an Azure cli command.
        /// </summary>
        public string InstallationId { get; }

        /// <summary>
        /// Gets the hashed user account id. A empty string if the user doesn't log in.
        /// </summary>
        public string HashUserId { get; }

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
        /// Gets the group number of the cohort.
        /// </summary>
        public int Cohort { get; }

        /// <summary>
        /// Gets whether the user is an internal user.
        /// </summary>
        public bool IsInternal { get; }

        /// <summary>
        /// Gets the host environment where the module runs.
        /// </summary>
        public string HostEnvironment { get; }

        /// <summary>
        /// Gets the minimum PowerShell Runspace. This isn't the necessary the same one as the PowerShell environment that Az
        /// Predictor is running on.
        /// </summary>
        public Runspace DefaultRunspace { get;}

        /// <summary>
        /// Updates the Az context.
        /// </summary>
        public void UpdateContext();
    }
}
