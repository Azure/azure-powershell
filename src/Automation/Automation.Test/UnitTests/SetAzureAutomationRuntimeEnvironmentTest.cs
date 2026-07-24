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
    public class SetAzureAutomationRuntimeEnvironmentTest : RMTestBase
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private SetAzureAutomationRuntimeEnvironment cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new SetAzureAutomationRuntimeEnvironment
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [TestMethod]
        public void SetAzureAutomationRuntimeEnvironmentSuccessful()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string runtimeEnvironmentName = "PowerShell-7.4";
            string description = "Updated description";

            this.mockAutomationClient.Setup(f => f.UpdateRuntimeEnvironment(
                resourceGroupName, accountName, runtimeEnvironmentName, null, description, null))
                .Returns(new RuntimeEnvironment
                {
                    Name = runtimeEnvironmentName,
                    Description = description
                });

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = runtimeEnvironmentName;
            this.cmdlet.Description = description;
            this.cmdlet.SetParameterSet("ByName");
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.UpdateRuntimeEnvironment(
                resourceGroupName, accountName, runtimeEnvironmentName, null, description, null), Times.Once());
        }

        [TestMethod]
        public void SetAzureAutomationRuntimeEnvironmentWithPackagesSuccessful()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string runtimeEnvironmentName = "PowerShell-7.4";
            var packages = new System.Collections.Hashtable { { "Az", "12.3.0" } };

            this.mockAutomationClient.Setup(f => f.UpdateRuntimeEnvironment(
                resourceGroupName, accountName, runtimeEnvironmentName, 
                It.IsAny<IDictionary<string, string>>(), null, null))
                .Returns(new RuntimeEnvironment
                {
                    Name = runtimeEnvironmentName
                });

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = runtimeEnvironmentName;
            this.cmdlet.DefaultPackages = packages;
            this.cmdlet.SetParameterSet("ByName");
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.UpdateRuntimeEnvironment(
                resourceGroupName, accountName, runtimeEnvironmentName, 
                It.IsAny<IDictionary<string, string>>(), null, null), Times.Once());
        }
    }
}
