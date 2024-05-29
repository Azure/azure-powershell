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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    [TestClass]
    public class GetAzureAutomationHybridWorkerGroupTest : RMTestBase
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureAutomationHybridRunbookWorkerGroup cmdlet;

        
        public GetAzureAutomationHybridWorkerGroupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new GetAzureAutomationHybridRunbookWorkerGroup
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureAutomationHybridWorkerGroupByNameSuccessfull()
        {
            //Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string hybridRunbookWorkerGroupName = "hybridRunbookWorkerGroup";

            var mockHWG = new Microsoft.Azure.Management.Automation.Models.HybridRunbookWorkerGroup(hybridRunbookWorkerGroupName)
            {
                GroupType = "User"
            };

            this.mockAutomationClient.Setup(f => f.GetHybridRunbookWorkerGroup(resourceGroupName, accountName, hybridRunbookWorkerGroupName)).Returns(mockHWG);

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = hybridRunbookWorkerGroupName;
            this.cmdlet.SetParameterSet("ByName");
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetHybridRunbookWorkerGroup(resourceGroupName, accountName, hybridRunbookWorkerGroupName), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureAutomationHybridWorkerGroupByAllSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string nextLink = string.Empty;

            this.mockAutomationClient.Setup(f => f.ListHybridRunbookWorkerGroups(resourceGroupName, accountName, ref nextLink)).Returns((string a, string b, string c) => new List<Microsoft.Azure.Management.Automation.Models.HybridRunbookWorkerGroup>()); ;

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.SetParameterSet("ByAll");
            this.cmdlet.ExecuteCmdlet();

            //Assert
            this.mockAutomationClient.Verify(f => f.ListHybridRunbookWorkerGroups(resourceGroupName, accountName, ref nextLink), Times.Once());
        }
    }
}
