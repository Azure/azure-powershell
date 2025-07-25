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
    public class GetAzureAutomationPython3PackageTest : RMTestBase
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureAutomationPython3Package cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new GetAzureAutomationPython3Package
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [TestMethod]
        public void GetAzureAutomationRunbookByNameSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string packageName = "py3Package";

            this.mockAutomationClient.Setup(f => f.GetRunbook(resourceGroupName, accountName, packageName));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = packageName;
            this.cmdlet.SetParameterSet("ByRunbookName");
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetPython3Package(resourceGroupName, accountName, packageName), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationRunbookByAllSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string nextLink = string.Empty;

            this.mockAutomationClient.Setup(f => f.ListPython3Package(resourceGroupName, accountName, ref nextLink)).Returns((string a, string b, string c) => new List<Module>()); ;

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.SetParameterSet("ByAll");
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListPython3Package(resourceGroupName, accountName, ref nextLink), Times.Once());
        }
    }
}
