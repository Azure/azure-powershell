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

    public class PowerShellCommandRunner : IPowershellCommandRunner
    {
        #region Fields and Properties
        private readonly Runspace _runspace;
        private readonly PowerShell _powerShell;
        #endregion

        #region Constructors
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

            this._runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            this._runspace.Open();

            this._powerShell = PowerShell.Create();
            this._powerShell.Runspace = this._runspace;
        }

        ~PowerShellCommandRunner()
        {
            this._powerShell?.Dispose();
            this._runspace?.Close();
        }
        #endregion

        #region Public methods
        public void AddScript(string script)
        {
            this._powerShell.AddScript(script);
        }

        public Collection<PSObject> Invoke()
        {
            return this._powerShell.Invoke();
        }

        public PSDataCollection<ErrorRecord> Errors()
        {
            return this._powerShell.Streams.Error;
        }
        #endregion
    }
}