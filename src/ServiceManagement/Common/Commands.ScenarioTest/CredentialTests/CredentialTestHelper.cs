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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System.IO;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.CredentialTests
{
    internal class CredentialTestHelper
    {
        private List<string> modules;

        public CredentialTestHelper()
        {
            AzureSession.DataStore = new MemoryDataStore();
            // Ignore SSL errors
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => true;
        }

        public void SetupModules(AzureModule mode, params string[] testModules)
        {
            modules = new List<string>();
            switch (mode)
            {
                case AzureModule.AzureProfile:
                    modules.Add(@"ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1");
                    modules.Add(@"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1");
                    modules.Add(@"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Tags.psd1");
                    modules.Add(@"Storage\Azure.Storage\Azure.Storage.psd1");
                    modules.Add(@"ServiceManagement\Azure\Azure.psd1");
                    break;

                case AzureModule.AzureServiceManagement:
                    modules.Add(@"ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1");
                    modules.Add(@"Storage\Azure.Storage\Azure.Storage.psd1");
                    modules.Add(@"ServiceManagement\Azure\Azure.psd1");
                    break;

                case AzureModule.AzureResourceManager:
                    modules.Add(@"ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1");
                    modules.Add(@"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1");
                    modules.Add(@"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Tags.psd1");
                    break;

                default:
                   throw new ArgumentException("Unknown command type for testing");
            }
            modules.Add("Assert.ps1");
            modules.Add("Common.ps1");
            modules.AddRange(testModules);
        }

        public virtual Collection<PSObject> RunPowerShellTest(params string[] scripts)
        {
            using (var powershell = System.Management.Automation.PowerShell.Create())
            {
                SetupPowerShellModules(powershell);

                Collection<PSObject> output = null;
                for (int i = 0; i < scripts.Length; ++i)
                {
                    Console.WriteLine(scripts[i]);
                    powershell.AddScript(scripts[i]);
                }
                try
                {
                    output = powershell.Invoke();

                    if (powershell.Streams.Error.Count > 0)
                    {
                        throw new RuntimeException(
                            "Test failed due to a non-empty error stream, check the error stream in the test log for more details.");
                    }
                    return output;
                }
                catch (Exception psException)
                {
                    powershell.LogPowerShellException(psException, null);
                    throw;
                }
                finally
                {
                    powershell.LogPowerShellResults(output, null);
                }
            }
        }

        private void SetupPowerShellModules(System.Management.Automation.PowerShell powershell)
        {
            powershell.AddScript("$error.clear()");
            powershell.AddScript(string.Format("cd \"{0}\"", AppDomain.CurrentDomain.BaseDirectory));

            foreach (string moduleName in modules)
            {
                powershell.AddScript(string.Format("Import-Module \"{0}\"",
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, moduleName)));
            }

            powershell.AddScript(
                string.Format("set-location \"{0}\"", AppDomain.CurrentDomain.BaseDirectory));
            powershell.AddScript(string.Format(@"$TestOutputRoot='{0}'", AppDomain.CurrentDomain.BaseDirectory));
            powershell.AddScript("$VerbosePreference='Continue'");
            powershell.AddScript("$DebugPreference='Continue'");
            powershell.AddScript("$ErrorActionPreference='Stop'");
            powershell.AddScript("Write-Debug \"AZURE_TEST_MODE = $env:AZURE_TEST_MODE\"");
            powershell.AddScript("Write-Debug \"TEST_HTTPMOCK_OUTPUT = $env:TEST_HTTPMOCK_OUTPUT\"");
        }
    }
}
