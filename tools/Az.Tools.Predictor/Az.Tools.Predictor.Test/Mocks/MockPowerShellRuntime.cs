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

using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
using System;
using System.Collections.Generic;
using System.Management.Automation.Runspaces;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test.Mocks
{
    using PowerShell = System.Management.Automation.PowerShell;

    /// <summary>
    /// A Mock PowerShell environment to be used in test cases.
    /// </summary>
    internal sealed class MockPowerShellRuntime : IPowerShellRuntime, IDisposable
    {
        private Runspace _defaultRunspace;

        /// <inheritdoc />
        public Runspace DefaultRunspace
        {
            get
            {
                if (_defaultRunspace is null)
                {
                    _defaultRunspace = PowerShellRunspaceUtilities.GetTestRunspace();
                }

                return _defaultRunspace;
            }
        }

        /// <inheritdoc />
        public PowerShell ConsoleRuntime => throw new NotImplementedException("It's not implemented yet because there is no test case to set up powershell environment.");

        /// <inheritdoc />
        public string HostName => AzPredictorConstants.MockPSHostName;

        /// <inheritdoc />
        public IList<T> ExecuteScript<T>(string contents) => throw new NotImplementedException("It's not implemented yet because there is no test case to set up powershell environment.");

        public void Dispose()
        {
            if (_defaultRunspace is not null)
            {
                _defaultRunspace.Dispose();
                _defaultRunspace = null;
            }
        }
    }
}
