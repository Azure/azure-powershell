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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ScenarioTest.Common;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.CloudServiceTests
{
    [TestClass]
    public class TestAzureNameScenarioTests : AzurePowerShellCertificateTest
    {
        public TestAzureNameScenarioTests()
            : base("CloudService\\Common.ps1",
                   "ServiceBus\\Common.ps1",
                   "CloudService\\CloudServiceTests.ps1")
        {

        }

        [TestInitialize]
        public override void TestSetup()
        {
            base.TestSetup();
            powershell.AddScript("Initialize-CloudServiceTest");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        public void TestAzureNameWithInvalidCredentials()
        {
            RunPowerShellTest("Test-WithInvalidCredentials { Test-AzureName -Service $(Get-CloudServiceName) }");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        public void TestAzureNameWithNotExistingHostedService()
        {
            RunPowerShellTest("Test-AzureNameWithNotExistingHostedService");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        public void TestAzureNameWithExistingHostedService()
        {
            RunPowerShellTest("Test-AzureNameWithExistingHostedService");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        public void TestAzureNameWithInvalidHostedService()
        {
            RunPowerShellTest("Test-AzureNameWithInvalidHostedService");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        public void TestAzureNameWithNotExistingStorageService()
        {
            RunPowerShellTest("Test-AzureNameWithNotExistingStorageService");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        public void TestAzureNameWithExistingStorageService()
        {
            RunPowerShellTest("Test-AzureNameWithExistingStorageService");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        public void TestAzureNameWithInvalidStorageService()
        {
            RunPowerShellTest("Test-AzureNameWithInvalidStorageService");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        public void TestAzureNameWithNotExistingServiceBusNamespace()
        {
            RunPowerShellTest("Test-AzureNameWithNotExistingServiceBusNamespace");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        public void TestAzureNameWithExistingServiceBusNamespace()
        {
            RunPowerShellTest("Test-AzureNameWithExistingServiceBusNamespace");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        [Ignore] // https://github.com/WindowsAzure/azure-sdk-tools/issues/1185
        public void TestAzureNameWithInvalidServiceBusNamespace()
        {
            RunPowerShellTest("Test-AzureNameWithInvalidServiceBusNamespace");
        }
    }
}