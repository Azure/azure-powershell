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
using System.IO;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Examples.Test
{
    public class EnvironmentTestContext : ITestContext
    {
        public EnvironmentTestContext(string _serviceDirectory)
        {
            ServiceDirectoryName = _serviceDirectory;
        }
        public string ServiceDirectoryName { get; private set; }
        public string ExecutionDirectory { get { return Directory.GetCurrentDirectory(); } }

        public AzureContext Context {
            get { return new AzureContext(
                new AzureAccount() {Id="user@contoso.org", Type=AzureAccount.AccountType.User},
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                new AzureTenant()); }
        }
        public string TestExecutableName { get {return "bash.exe";} }
        public string TestScriptSuffix { get { return ".sh"; } }
        public string TestScriptDirectory { get { return Path.Combine("..", "..", "..", "examples", ServiceDirectoryName);  } }
        public string Username { get { return ""; } }
        public string Password { get { return ""; } }

        public IEnumerable<IScriptEnvironmentHelper> EnvironmentHelpers
        {
            get
            {
                yield return new BasicAuthenticationEnvironmentHelper(Username, Password);
            }
        }
    }
}
