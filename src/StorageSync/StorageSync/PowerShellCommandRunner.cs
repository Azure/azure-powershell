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

namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using Interfaces;
    using System.Collections.ObjectModel;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;

    /// <summary>
    /// Class PowerShellCommandRunner.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IPowershellCommandRunner" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces.IPowershellCommandRunner" />
    public class PowerShellCommandRunner : IPowershellCommandRunner
    {
        #region Fields and Properties
        /// <summary>
        /// The runspace
        /// </summary>
        private readonly Runspace _runspace;
        /// <summary>
        /// The power shell
        /// </summary>
        private readonly PowerShell _powerShell;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PowerShellCommandRunner" /> class.
        /// </summary>
        /// <param name="computerName">Name of the computer.</param>
        /// <param name="credential">The credential.</param>
        public PowerShellCommandRunner(string computerName, PSCredential credential)
        {
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo();

            if (computerName != null && !computerName.Equals("localhost", System.StringComparison.OrdinalIgnoreCase))
            {
                connectionInfo.ComputerName = computerName;
            }

            if (credential != null)
            {
                connectionInfo.Credential = credential;
            }

            _runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            _runspace.Open();

            _powerShell = PowerShell.Create();
            _powerShell.Runspace = _runspace;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="PowerShellCommandRunner" /> class.
        /// </summary>
        ~PowerShellCommandRunner()
        {
            _powerShell?.Dispose();
            _runspace?.Close();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Adds the script.
        /// </summary>
        /// <param name="script">The script.</param>
        public void AddScript(string script)
        {
            _powerShell.AddScript(script);
        }

        /// <summary>
        /// Invokes this instance.
        /// </summary>
        /// <returns>Collection&lt;PSObject&gt;.</returns>
        public Collection<PSObject> Invoke()
        {
            return _powerShell.Invoke();
        }

        /// <summary>
        /// Errorses this instance.
        /// </summary>
        /// <returns>PSDataCollection&lt;ErrorRecord&gt;.</returns>
        public PSDataCollection<ErrorRecord> Errors()
        {
            return _powerShell.Streams.Error;
        }
        #endregion
    }
}