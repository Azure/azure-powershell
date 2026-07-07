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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    [TestClass]
    public class NewAzureAutomationRuntimeEnvironmentTest : RMTestBase
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private NewAzureAutomationRuntimeEnvironment cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new NewAzureAutomationRuntimeEnvironment
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [TestMethod]
        public void NewAzureAutomationRuntimeEnvironmentSuccessful()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string runtimeEnvironmentName = "PowerShell-7.4";
            string location = "East US 2";
            string language = "PowerShell";
            string version = "7.4";

            this.mockAutomationClient.Setup(f => f.CreateRuntimeEnvironment(
                resourceGroupName, accountName, runtimeEnvironmentName, location, language, version, null, null))
                .Returns(new RuntimeEnvironment
                {
                    Name = runtimeEnvironmentName,
                    Location = location,
                    Language = language,
                    Version = version
                });

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = runtimeEnvironmentName;
            this.cmdlet.Location = location;
            this.cmdlet.Language = language;
            this.cmdlet.Version = version;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.CreateRuntimeEnvironment(
                resourceGroupName, accountName, runtimeEnvironmentName, location, language, version, null, null), Times.Once());
        }

        [TestMethod]
        public void NewAzureAutomationRuntimeEnvironmentWithPackagesSuccessful()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string runtimeEnvironmentName = "Python-3.10";
            string location = "West US";
            string language = "Python";
            string version = "3.10";
            var packages = new System.Collections.Hashtable { { "requests", "2.28.0" } };

            this.mockAutomationClient.Setup(f => f.CreateRuntimeEnvironment(
                resourceGroupName, accountName, runtimeEnvironmentName, location, language, version, 
                It.IsAny<IDictionary<string, string>>(), null))
                .Returns(new RuntimeEnvironment
                {
                    Name = runtimeEnvironmentName,
                    Location = location,
                    Language = language,
                    Version = version
                });

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = runtimeEnvironmentName;
            this.cmdlet.Location = location;
            this.cmdlet.Language = language;
            this.cmdlet.Version = version;
            this.cmdlet.DefaultPackages = packages;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.CreateRuntimeEnvironment(
                resourceGroupName, accountName, runtimeEnvironmentName, location, language, version, 
                It.IsAny<IDictionary<string, string>>(), null), Times.Once());
        }
    }
}
