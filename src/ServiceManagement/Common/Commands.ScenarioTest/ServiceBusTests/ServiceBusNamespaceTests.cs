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

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.ServiceBusTests
{
    [TestClass]
    public class ServiceBusNamespaceTests : AzurePowerShellCertificateTest
    {
        public ServiceBusNamespaceTests()
            : base("ServiceBus\\Common.ps1",
                   "ServiceBus\\NamespaceScenarioTests.ps1")
        {

        }

        #region Get-AzureSBLocation Scenario Tests

        /// <summary>
        /// Test Get-AzureSBLocation with valid credentials.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void ListAzureSBLocationWithValidCredentials()
        {
            RunPowerShellTest("Test-ListAzureSBLocation");
        }

        /// <summary>
        /// Tests using List-AzureSBLocation and piping it's output to New-AzureSBNamespace.
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestListAzureSBLocation1()
        {
            RunPowerShellTest("Test-ListAzureSBLocation1");
        }

        #endregion

        #region Get-AzureSBNamespace Scenario Tests

        /// <summary>
        /// Tests using Get-AzureSBNamespace cmdlet and expect to return empty collection
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestGetAzureSBNamespaceWithEmptyNamespaces()
        {
            RunPowerShellTest("Test-GetAzureSBNamespaceWithEmptyNamespaces");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestGetAzureSBNamespaceWithOneNamespace()
        {
            RunPowerShellTest("Test-GetAzureSBNamespaceWithOneNamespace");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestGetAzureSBNamespaceWithMultipleNamespaces()
        {
            RunPowerShellTest("Test-GetAzureSBNamespaceWithMultipleNamespaces");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestGetAzureSBNamespaceWithValidExisitingNamespace()
        {
            RunPowerShellTest("Test-GetAzureSBNamespaceWithValidExisitingNamespace");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [Ignore] // https://github.com/WindowsAzure/azure-sdk-tools/issues/1399
        public void TestGetAzureSBNamespaceWithValidNonExisitingNamespace()
        {
            RunPowerShellTest("Test-GetAzureSBNamespaceWithValidNonExisitingNamespace");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestGetAzureSBNamespacePipedToRemoveAzureSBNamespace()
        {
            RunPowerShellTest("Test-GetAzureSBNamespacePipedToRemoveAzureSBNamespace");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestGetAzureSBNamespaceWithWebsites()
        {
            RunPowerShellTest("Test-GetAzureSBNamespaceWithWebsites");
        }

        #endregion

        #region New-AzureSBNamespace Scenario Tests

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestNewAzureSBNamespaceWithValidNewNamespace()
        {
            RunPowerShellTest("Test-NewAzureSBNamespaceWithValidNewNamespace");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.WAPack)]
        [TestCategory(Category.BVT)]
        public void TestNewAzureSBNamespaceWithDefaultLocation()
        {
            RunPowerShellTest("Test-NewAzureSBNamespaceWithDefaultLocation");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.WAPack)]
        [Ignore] // https://github.com/WindowsAzure/azure-sdk-tools/issues/1400
        public void TestNewAzureSBNamespaceWithValidExistingNamespace()
        {
            RunPowerShellTest("Test-NewAzureSBNamespaceWithValidExistingNamespace");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        public void TestNewAzureSBNamespaceWithInvalidLocation()
        {
            RunPowerShellTest("Test-NewAzureSBNamespaceWithInvalidLocation");
        }

        /// <summary>
        /// This scenario test does the following:
        /// * Generates new name.
        /// * Uses Test-AzureName to make sure name is available
        /// * Runs Get-AzureSBLocation and pick default location object.
        /// * Creates new namespace.
        /// * Waits until it's status is Active
        /// * Setup website environment variable using Set-AzureWebsite -AppSettings
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestNewAzureSBNamespaceWithWebsite()
        {
            RunPowerShellTest("Test-NewAzureSBNamespaceWithWebsite");
        }

        #endregion

        #region Remove-AzureSBNamespace Scenario Tests

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        public void TestRemoveAzureSBNamespaceWithExistingNamespace()
        {
            RunPowerShellTest("Test-RemoveAzureSBNamespaceWithExistingNamespace");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [Ignore] // https://github.com/WindowsAzure/azure-sdk-tools/issues/1401
        public void TestRemoveAzureSBNamespaceWithNonExistingNamespace()
        {
            RunPowerShellTest("Test-RemoveAzureSBNamespaceWithNonExistingNamespace");
        }

        /// <summary>
        /// This test does the following:
        /// * Generate namespace name.
        /// * Uses Test-AzureName to make sure it's available
        /// * Waits for it's status to be 'Active'
        /// * Pipe it's value to Remove-AzureSBNamespace
        /// </summary>
        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestRemoveAzureSBNamespaceInputPiping()
        {
            RunPowerShellTest("Test-RemoveAzureSBNamespaceInputPiping");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestRemoveAzureSBNamespaceWhatIf()
        {
            RunPowerShellTest("Test-RemoveAzureSBNamespaceWhatIf");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        public void TestRemoveAzureSBNamespaceWhatIfError()
        {
            RunPowerShellTest("Test-RemoveAzureSBNamespaceWhatIfError");
        }

        #endregion

        #region General Service Bus Scenario Tests

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestGetAzureSBLocationWithInvalidCredentials()
        {
            RunPowerShellTest("Test-WithInvalidCredentials {Get-AzureSBLocation}");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestGetAzureSBNamespaceWithInvalidCredentials()
        {
            RunPowerShellTest("Test-WithInvalidCredentials {Get-AzureSBNamespace}");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestNewAzureSBNamespaceWithInvalidCredentials()
        {
            RunPowerShellTest("Test-WithInvalidCredentials {New-AzureSBNamespace $(Get-NamespaceName) $(Get-DefaultServiceBusLocation)}");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.ServiceBus)]
        [TestCategory(Category.BVT)]
        public void TestRemoveAzureSBNamespaceWithInvalidCredentials()
        {
            RunPowerShellTest("Test-WithInvalidCredentials {Remove-AzureSBNamespace \"AnyName\" -Force }");
        }

        #endregion
    }
}