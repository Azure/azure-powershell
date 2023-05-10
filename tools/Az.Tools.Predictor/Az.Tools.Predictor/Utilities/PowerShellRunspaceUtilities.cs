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

using Microsoft.PowerShell;
using System.Management.Automation.Runspaces;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities
{
    /// <summary>
    /// A provider to create runspace in PowerShell.
    /// </summary>
    internal class PowerShellRunspaceUtilities
    {
        /// <summary>
        /// Gets a new minimal runspace.
        /// </summary>
        public static Runspace GetMinimalRunspace() => GetRunspace(ExecutionPolicy.Default);

        /// <summary>
        /// Gets a new minimal runspace that's tweak for unit tests.
        /// </summary>
        /// <remarks>
        /// This returns the runspace with ExecutionPolicy.RemoteSigned. In the unit tests, we need to load
        /// the modules copied to the test folder. So RemoteSigned is required to be able to load them.
        /// Other than that, the settings should be the same as <see cref="GetMinimalRunspace"/>.
        /// </remarks>
        internal static Runspace GetTestRunspace() => GetRunspace(ExecutionPolicy.RemoteSigned);

        private static Runspace GetRunspace(ExecutionPolicy executionPolicy)
        {
            // Create a mini runspace by remove the types and formats
            InitialSessionState minimalState = InitialSessionState.CreateDefault2();
            if (executionPolicy != ExecutionPolicy.Default)
            {
                minimalState.ExecutionPolicy = executionPolicy;
            }
            // Refer to the remarks for the property DefaultRunspace.
            minimalState.Types.Clear();
            minimalState.Formats.Clear();
            var runspace = RunspaceFactory.CreateRunspace(minimalState);
            runspace.Open();
            return runspace;
        }
    }
}
