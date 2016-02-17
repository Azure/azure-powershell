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
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Test;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.Common
{
    [TestClass]
    public class AzurePowerShellCertificateTest : PowerShellTest
    {
        protected TestCredentialHelper credentials;
        protected string credentialFile;
        protected string profileFile;

        // Location where test output will be written to e.g. C:\Temp
        private static string outputDirKey = "TEST_HTTPMOCK_OUTPUT";

        private bool runningMocked = false;

        private void OnClientCreated(object sender, ClientCreatedArgs e)
        {
            e.AddHandlerToClient(HttpMockServer.CreateInstance());
        }

        public AzurePowerShellCertificateTest(params string[] modules)
            : base(AzureModule.AzureServiceManagement, modules)
        {
            this.runningMocked = (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Playback);
            TestMockSupport.RunningMocked = this.runningMocked;
            if (this.runningMocked)
            {
                AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory();
                string dummyCredentialFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TestCredentialHelper.DefaultCredentialFile);
                if (!File.Exists(dummyCredentialFile))
                {
                    AzureSession.DataStore.WriteFile(dummyCredentialFile, Properties.Resources.RdfeTestDummy);
                }
                this.credentialFile = dummyCredentialFile;
            }
            else
            {
                this.credentials = new TestCredentialHelper(AppDomain.CurrentDomain.BaseDirectory);
                this.credentialFile = TestCredentialHelper.DefaultCredentialFile;
                this.profileFile = TestCredentialHelper.WindowsAzureProfileFile;
            }
            AzureSession.DataStore = new MemoryDataStore();

            if (Environment.GetEnvironmentVariable(outputDirKey) != null)
            {
                HttpMockServer.RecordsDirectory = Environment.GetEnvironmentVariable(outputDirKey);
            }
        }

        public override Collection<PSObject> RunPowerShellTest(params string[] scripts)
        {
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(2));
            return base.RunPowerShellTest(scripts);
        }

        [TestInitialize]
        public override void TestSetup()
        {
            base.TestSetup();
            if (this.runningMocked)
            {
                TestCredentialHelper.ImportCredentails(powershell, this.credentialFile);
            }
            else
            {
                this.credentials.SetupPowerShellEnvironment(powershell, this.credentialFile, this.profileFile);
                System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
                {
                    return true;
                };
            }
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
            if (!this.runningMocked && HttpMockServer.CallerIdentity != null)
            {
                HttpMockServer.Flush();
            }
        }
    }
}