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
using System;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    [TestClass]
    public class GetAzureAutomationHybridWorkerTest : RMTestBase
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureAutomationHybridRunbookWorker cmdlet;

        
        public GetAzureAutomationHybridWorkerTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new GetAzureAutomationHybridRunbookWorker
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureAutomationHybridWorkerByNameSuccessfull()
        {
            //Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string hybridRunbookWorkerGroupName = "hybridRunbookWorkerGroup";
            string hybridWorkerId = Guid.NewGuid().ToString();

            this.mockAutomationClient.Setup(f => f.GetHybridRunbookWorkers(resourceGroupName, accountName, hybridRunbookWorkerGroupName, hybridWorkerId));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = hybridWorkerId;
            this.cmdlet.HybridRunbookWorkerGroupName = hybridRunbookWorkerGroupName;
            this.cmdlet.SetParameterSet("ByName");
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetHybridRunbookWorkers(resourceGroupName, accountName, hybridRunbookWorkerGroupName, hybridWorkerId), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureAutomationHybridWorkerByAllSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string hybridRunbookWorkerGroupName = "hybridRunbookWorkerGroup";
            string hybridWorkerId = Guid.NewGuid().ToString();

            string nextLink = string.Empty;

            this.mockAutomationClient.Setup(f => f.ListHybridRunbookWorkers(resourceGroupName, accountName, hybridRunbookWorkerGroupName, ref nextLink)).Returns((string a, string b, string c, string d) => new List<Microsoft.Azure.Management.Automation.Models.HybridRunbookWorker>()); ;

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.HybridRunbookWorkerGroupName = hybridRunbookWorkerGroupName;
            this.cmdlet.SetParameterSet("ByAll");
            this.cmdlet.ExecuteCmdlet();

            //Assert
            this.mockAutomationClient.Verify(f => f.ListHybridRunbookWorkers(resourceGroupName, accountName, hybridRunbookWorkerGroupName, ref nextLink), Times.Once());
        }
    }
}
