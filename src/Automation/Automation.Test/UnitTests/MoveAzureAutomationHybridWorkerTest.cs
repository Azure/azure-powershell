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
using Moq;
using System;
using Xunit;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    [TestClass]
    public class MoveAzureAutomationHybridWorkerTest : RMTestBase
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private MoveAzureAutomationHybridRunbookWorker cmdlet;

        
        public MoveAzureAutomationHybridWorkerTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new MoveAzureAutomationHybridRunbookWorker
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MoveAzureAutomationHybridWorkerSuccessfull()
        {
            //Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string hybridRunbookWorkerGroupName = "hybridRunbookWorkerGroup";
            string hybridWorkerId = Guid.NewGuid().ToString();
            string targetHybridWorkerGroupName = "targetHybridRunbookWorkerGroupName";

            this.mockAutomationClient.Setup(f => f.MoveRunbookWorker(resourceGroupName, accountName, hybridRunbookWorkerGroupName, targetHybridWorkerGroupName, hybridWorkerId));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = hybridWorkerId;
            this.cmdlet.HybridRunbookWorkerGroupName = hybridRunbookWorkerGroupName;
            this.cmdlet.TargetHybridRunbookWorkerGroupName = targetHybridWorkerGroupName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.MoveRunbookWorker(resourceGroupName, accountName, hybridRunbookWorkerGroupName, targetHybridWorkerGroupName, hybridWorkerId), Times.Once());
        }
    }
}
