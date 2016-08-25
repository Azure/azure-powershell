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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    [TestClass]
    public class DiagnosticsExtensionTests
    {
        private EnvironmentSetupHelper helper = new EnvironmentSetupHelper();

        protected void SetupManagementClients()
        {
            var rdfeTestFactory = new RDFETestEnvironmentFactory();
            var managementClient = TestBase.GetServiceClient<ManagementClient>(rdfeTestFactory);
            var computeClient = TestBase.GetServiceClient<ComputeManagementClient>(rdfeTestFactory);
            var networkClient = TestBase.GetServiceClient<NetworkManagementClient>(rdfeTestFactory);
            var storageClient = TestBase.GetServiceClient<StorageManagementClient>(rdfeTestFactory);

            helper.SetupSomeOfManagementClients(
                managementClient,
                computeClient,
                networkClient,
                storageClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(1), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                var modules = new List<string>
                {
                    @"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Compute\AzurePreview.psd1",
                    @"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Compute\PIR.psd1",
                    "Resources\\ServiceManagement\\Common.ps1",
                    "Resources\\DiagnosticsExtension\\DiagnosticsExtensionTests.ps1"
                };

                helper.SetupEnvironment(AzureModule.AzureServiceManagement);
                helper.SetupModules(AzureModule.AzureServiceManagement, modules.ToArray());

                var scriptEnvPath = new List<string>();
                scriptEnvPath.Add(
                    string.Format(
                    "$env:PSModulePath=\"{0};$env:PSModulePath\"",
                    @"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Compute".AsAbsoluteLocation()));

                helper.RunPowerShellTest(scriptEnvPath, scripts);
            }
        }

        [Fact]
        [Trait(Category.Service, Category.DiagnosticsExtension)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAzureServiceDiagnosticsExtensionBasic()
        {
            this.RunPowerShellTest("Test-AzureServiceDiagnosticsExtensionBasic");
        }

        [Fact]
        [Trait(Category.Service, Category.DiagnosticsExtension)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAzureServiceDiagnosticsExtensionConfigurationArray()
        {
            this.RunPowerShellTest("Test-AzureServiceDiagnosticsExtensionConfigurationArray");
        }

        [Fact]
        [Trait(Category.Service, Category.DiagnosticsExtension)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAzureServiceDiagnosticsExtensionWrongServiceName()
        {
            this.RunPowerShellTest("Test-AzureServiceDiagnosticsExtensionWrongServiceName");
        }
    }
}
