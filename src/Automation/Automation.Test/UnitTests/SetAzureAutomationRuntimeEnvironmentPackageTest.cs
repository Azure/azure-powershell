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

using Microsoft.Azure.Commands.Automation.Cmdlet;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    [TestClass]
    public class SetAzureAutomationRuntimeEnvironmentPackageTest : RMTestBase
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private SetAzureAutomationRuntimeEnvironmentPackage cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new SetAzureAutomationRuntimeEnvironmentPackage
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [TestMethod]
        public void SetAzureAutomationRuntimeEnvironmentPackageSuccessful()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string runtimeEnvironmentName = "PowerShell-7.4";
            string packageName = "Pester";
            string contentUri = "https://www.powershellgallery.com/api/v2/package/Pester/5.6.0";
            string contentVersion = "5.6.0";

            this.mockAutomationClient.Setup(
                f => f.UpdateRuntimeEnvironmentPackage(resourceGroupName, accountName, runtimeEnvironmentName, packageName, contentUri, contentVersion))
                .Returns(new RuntimeEnvironmentPackage());

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RuntimeEnvironmentName = runtimeEnvironmentName;
            this.cmdlet.Name = packageName;
            this.cmdlet.ContentUri = contentUri;
            this.cmdlet.ContentVersion = contentVersion;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.UpdateRuntimeEnvironmentPackage(resourceGroupName, accountName, runtimeEnvironmentName, packageName, contentUri, contentVersion), Times.Once());
        }

        [TestMethod]
        public void SetAzureAutomationRuntimeEnvironmentPackageWithoutVersionSuccessful()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string runtimeEnvironmentName = "PowerShell-7.4";
            string packageName = "Az";
            string contentUri = "https://www.powershellgallery.com/api/v2/package/Az/15.4.0";

            this.mockAutomationClient.Setup(
                f => f.UpdateRuntimeEnvironmentPackage(resourceGroupName, accountName, runtimeEnvironmentName, packageName, contentUri, null))
                .Returns(new RuntimeEnvironmentPackage());

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RuntimeEnvironmentName = runtimeEnvironmentName;
            this.cmdlet.Name = packageName;
            this.cmdlet.ContentUri = contentUri;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.UpdateRuntimeEnvironmentPackage(resourceGroupName, accountName, runtimeEnvironmentName, packageName, contentUri, null), Times.Once());
        }

        [TestMethod]
        public void SetAzureAutomationRuntimeEnvironmentPackageOmitBothParametersSuccessful()
        {
            // Setup - omit both ContentUri and ContentVersion to verify they're passed as null
            // The implementation will fetch existing values and preserve them
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string runtimeEnvironmentName = "PowerShell-7.4";
            string packageName = "Pester";

            this.mockAutomationClient.Setup(
                f => f.UpdateRuntimeEnvironmentPackage(resourceGroupName, accountName, runtimeEnvironmentName, packageName, null, null))
                .Returns(new RuntimeEnvironmentPackage());

            // Test - don't set ContentUri or ContentVersion
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RuntimeEnvironmentName = runtimeEnvironmentName;
            this.cmdlet.Name = packageName;
            this.cmdlet.ExecuteCmdlet();

            // Assert - cmdlet passes null values, implementation handles preserving existing values
            this.mockAutomationClient.Verify(f => f.UpdateRuntimeEnvironmentPackage(resourceGroupName, accountName, runtimeEnvironmentName, packageName, null, null), Times.Once());
        }
    }
}
