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
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Exceptions;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.WAPackIaaS.FunctionalTest
{
    /// <summary>
    /// Provides a base for test classes which tests cmdlets.  It supplies a pre-created <see cref="PowerShell"/>
    /// object for every test method and handles the clean-up automatically.  Use the <value>this.PowerShell</value>
    /// property and add commands and parameters; exactly how you can invoke cmdlets from code.
    /// </summary>
    [TestClass]
    public class CmdletTestBase
    {
        private static string CmdletAssemblyPath = typeof(WAPackOperationException).Assembly.Location;
        private const string PowerShellObjectTag = "PowerShellObject";

        public TestContext TestContext { get; set; }
        public System.Management.Automation.PowerShell PowerShell
        {
            get
            {
                return this.TestContext.Properties[CmdletTestBase.PowerShellObjectTag] as System.Management.Automation.PowerShell;
            }
        }

        [TestInitialize]
        public void CmdletBaseInitialize()
        {
            // create PowerShell object and save in test context
            this.TestContext.Properties.Add(CmdletTestBase.PowerShellObjectTag, CmdletTestBase.CreatePipeline());
            InitializeWAPackConfiguration();
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            var ps = this.TestContext.Properties[CmdletTestBase.PowerShellObjectTag] as IDisposable;
            ps.Dispose();
        }

        private static System.Management.Automation.PowerShell CreatePipeline()
        {
            var iss = InitialSessionState.CreateDefault();
            iss.Types.Clear();
            iss.Formats.Clear();
            iss.ImportPSModule(new string[] { CmdletAssemblyPath });

            return System.Management.Automation.PowerShell.Create(iss);
        }

        private void InitializeWAPackConfiguration()
        {
            string directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(directoryPath, "..\\..\\..\\Package\\Debug\\ServiceManagement\\Azure\\Azure.psd1"));
            this.PowerShell.Commands.Clear();

            this.PowerShell.AddCommand("Import-Module").AddArgument(path).InvokeAndAssertForNoErrors();
            this.PowerShell.Commands.Clear();

            this.PowerShell.AddScript("Get-AzureSubscription | Remove-AzureSubscription -Force").InvokeAndAssertForNoErrors();
            this.PowerShell.Commands.Clear();

            var publishSettingsPath = Path.GetFullPath(Path.Combine(directoryPath, "..\\..\\..\\Common\\Commands.ScenarioTest\\Artifacts\\WAPackTestConfig.publishsettings"));
            this.PowerShell.AddCommand("Import-AzurePublishSettingsFile").AddArgument(publishSettingsPath).InvokeAndAssertForNoErrors();
            this.PowerShell.Commands.Clear();
        }

        public ICollection<PSObject> InvokeCmdlet(string cmdletName, IDictionary<string, object> parameters, string expectedErrorMsg = null)
        {
            var ps = this.PowerShell;
            ps.Commands.Clear();
            ps.Streams.ClearStreams();

            ps.AddCommand(cmdletName);

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    ps.Commands.AddParameter(item.Key, item.Value);
                }
            }

            return ps.InvokeAndAssertForErrors(expectedErrorMsg);
        }
    }

}
