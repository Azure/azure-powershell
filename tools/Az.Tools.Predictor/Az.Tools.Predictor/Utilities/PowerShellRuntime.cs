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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities
{
    using PowerShell = System.Management.Automation.PowerShell;

    /// <summary>
    /// A PowerShell environment to run PowerShell cmdlets and scripts.
    /// </summary>
    internal class PowerShellRuntime : IDisposable
    {
        private PowerShell _runtime;
        private PowerShell Runtime
        {
            get
            {
                if (_runtime == null)
                {
                    _runtime = PowerShell.Create(DefaultRunspace);
                }

                return _runtime;
            }
        }

        private readonly Lazy<Runspace> _defaultRunspace = new(() =>
                {
                    // Create a mini runspace by remove the types and formats
                    InitialSessionState minimalState = InitialSessionState.CreateDefault2();
                    minimalState.Types.Clear();
                    minimalState.Formats.Clear();
                    var runspace = RunspaceFactory.CreateRunspace(minimalState);
                    runspace.Open();
                    return runspace;
                });

        /// <inheritdoc />
        /// <remarks>
        /// Creating the instance is at the first time this is called.
        /// It can be slow. So the first call must not be in the path of the user interaction.
        /// Loading too many modules can also impact user experience because that may add to much memory pressure at the same time.
        /// Ideally we should pre-load needed module such as Az.Accounts. But our module doesn't have Az.Accounts as required
        /// dependency so we cannot assume that module is always intalled.
        /// </remarks>
        public Runspace DefaultRunspace => _defaultRunspace.Value;

        public void Dispose()
        {
            if (_runtime != null)
            {
                _runtime.Dispose();
                _runtime = null;
            }

            if (_defaultRunspace.IsValueCreated)
            {
                _defaultRunspace.Value.Dispose();
            }
        }

        /// <summary>
        /// Executes the PowerShell cmdlet in the current powershell session.
        /// </summary>
        public IList<T> ExecuteScript<T>(string contents)
        {
            List<T> output = new List<T>();

            Runtime.Commands.Clear();
            Runtime.AddScript(contents);
            Collection<T> result = Runtime.Invoke<T>();

            if (result != null && result.Count > 0)
            {
                output.AddRange(result);
            }

            return output;
        }
    }
}
