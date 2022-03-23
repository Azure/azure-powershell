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

using System.Collections.Generic;
using System.Management.Automation.Runspaces;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities
{
    using PowerShell = System.Management.Automation.PowerShell;

    /// <summary>
    /// A PowerShell environment to run PowerShell cmdlets and scripts.
    /// </summary>
    internal interface IPowerShellRuntime
    {
        /// <summary>
        /// Gets the minimum PowerShell Runspace. This isn't the necessary the same one as the PowerShell environment that Az
        /// Predictor is running on.
        /// </summary>
        Runspace DefaultRunspace { get; }

        /// <summary>
        /// The PowerShell environment that the module is imported into.
        /// </summary>
        /// <remarks>
        /// The usage of <see cref="ConsoleRuntime"/> has to be in the context of the running PowerShell thread, for example,
        /// the callback of <see cref="PredictorInitializer.OnImport"/>.
        /// The callbacks of <see cref="AzPredictor"/> are on a thread pool and it must not be used there.
        /// </remarks>
        PowerShell ConsoleRuntime { get; }

        /// <summary>
        /// Gets the current PowerShell host name.
        /// </summary>
        public string HostName { get; }

        /// <summary>
        /// Executes the PowerShell cmdlet in the current powershell session.
        /// </summary>
        IList<T> ExecuteScript<T>(string contents);
    }
}
