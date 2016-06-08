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
    public class RemoveAzureServiceScenarioTests : AzurePowerShellCertificateTest
    {
        public RemoveAzureServiceScenarioTests()
            : base("CloudService\\Common.ps1",
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
        public void TestRemoveAzureServiceWithInvalidCredentials()
        {
            RunPowerShellTest("Test-WithInvalidCredentials { Remove-AzureService $(Get-CloudServiceName) -Force }");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        public void TestRemoveAzureServiceWithNonExistingService()
        {
            RunPowerShellTest("Test-RemoveAzureServiceWithNonExistingService");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        public void TestRemoveAzureServiceWithProductionDeployment()
        {
            RunPowerShellTest("Test-RemoveAzureServiceWithProductionDeployment");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        public void TestRemoveAzureServiceWhatIf()
        {
            RunPowerShellTest("Test-RemoveAzureServiceWhatIf");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.BVT)]
        public void TestRemoveAzureServiceWhatIfWithInvalidName()
        {
            RunPowerShellTest("Test-RemoveAzureServiceWhatIfWithInvalidName");
        }
        
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.CloudService)]
        [TestCategory(Category.OneSDK)]
        [TestCategory(Category.CIT)]
        [TestCategory(Category.BVT)]
        public void TestRemoveAzureServicePipedFromGetAzureService()
        {
            RunPowerShellTest("Test-RemoveAzureServicePipedFromGetAzureService");
        }
    }
}
