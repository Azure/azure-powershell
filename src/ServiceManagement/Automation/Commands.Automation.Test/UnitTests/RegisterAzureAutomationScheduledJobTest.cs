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

using System;
using Microsoft.Azure.Commands.Automation.Cmdlet;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;

namespace Microsoft.Azure.Commands.Automation.Test.UnitTests
{
    [TestClass]
    public class RegisterAzureAutomationScheduledJobTest : TestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private RegisterAzureAutomationScheduledRunbook cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new RegisterAzureAutomationScheduledRunbook
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [TestMethod]
        public void RegisterAzureAutomationScheduledRunbookByRunbookIdSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            var runbookId = new Guid();

            this.mockAutomationClient.Setup(f => f.RegisterScheduledRunbook(accountName, runbookId, null, scheduleName));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Id = runbookId;
            this.cmdlet.ScheduleName = scheduleName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.RegisterScheduledRunbook(accountName, runbookId, null, scheduleName), Times.Once());
        }

        [TestMethod]
        public void RegisterAzureAutomationScheduledRunbookByRunbookNameSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookName = "runbook";
            string scheduleName = "schedule";

            this.mockAutomationClient.Setup(
                f => f.RegisterScheduledRunbook(accountName, runbookName, null, scheduleName));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = runbookName;
            this.cmdlet.ScheduleName = scheduleName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.RegisterScheduledRunbook(accountName, runbookName, null, scheduleName), Times.Once());
        }
    }
}
