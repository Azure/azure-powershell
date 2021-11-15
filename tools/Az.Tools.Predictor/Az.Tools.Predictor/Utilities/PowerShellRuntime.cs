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
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Threading;

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
                if (_runtime is null)
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
                    // Refer to the remarks for the property DefaultRunspace.
                    minimalState.Types.Clear();
                    minimalState.Formats.Clear();
                    var runspace = RunspaceFactory.CreateRunspace(minimalState);
                    runspace.Open();
                    return runspace;
                });

        /// <inheritdoc />
        /// <remarks>
        /// We don't pre-load Az service modules since they may not always be installed.
        /// Creating the instance is at the first time this is called.
        /// It can be slow. So the first call must not be in the path of the user interaction.
        /// Loading too many modules can also impact user experience because that may add to much memory pressure at the same
        /// time.
        /// </remarks>
        public Runspace DefaultRunspace => _defaultRunspace.Value;

        /// <summary>
        /// The PowerShell environment that the module is imported into.
        /// </summary>
        /// <remarks>
        /// The usage of <see cref="ConsoleRuntime"/> has to be in the context of the running PowerShell thread, for example,
        /// the callback of <see cref="PredictorInitializer.OnImport"/>.
        /// The callbacks of <see cref="AzPredictor"/> are on a thread pool and it must not be used there.
        /// </remarks>
        internal PowerShell ConsoleRuntime = PowerShell.Create(System.Management.Automation.RunspaceMode.CurrentRunspace);

        public void Dispose()
        {
            if (_runtime is not null)
            {
                _runtime.Dispose();
                _runtime = null;
            }

            if (_defaultRunspace.IsValueCreated)
            {
                _defaultRunspace.Value.Dispose();
            }

            if (ConsoleRuntime is not null)
            {
                ConsoleRuntime.Dispose();
            }
        }

        /// <summary>
        /// Executes the PowerShell cmdlet in the current powershell session.
        /// </summary>
        public IList<T> ExecuteScript<T>(string contents)
        {
            Runtime.Commands.Clear();
            Runtime.AddScript(contents);
            Collection<T> result = Runtime.Invoke<T>();

            return result?.ToList() ?? new List<T>();
        }
    }
}
