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
    public class GetAzureAutomationJobTest : TestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureAutomationJob cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new GetAzureAutomationJob
                              {
                                  AutomationClient = this.mockAutomationClient.Object,
                                  CommandRuntime = this.mockCommandRuntime
                              };
        }

        [TestMethod]
        public void GetAzureAutomationJobByJobIdSuccessfull()
        {
            // Setup
            string accountName = "automation";
            var jobId = new Guid();

            this.mockAutomationClient.Setup(f => f.GetJob(accountName, jobId));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Id = jobId;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetJob(accountName, jobId), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationJobByRunbookIdSuccessfull()
        {
            // Setup
            string accountName = "automation";
            var runbookId = new Guid();

            this.mockAutomationClient.Setup(
                f => f.ListJobsByRunbookId(accountName, runbookId, It.IsAny<DateTime?>(), It.IsAny<DateTime?>()));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RunbookId = runbookId;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobsByRunbookId(accountName, runbookId, It.IsAny<DateTime?>(), It.IsAny<DateTime?>()), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationJobByRunbookNameSuccessfull()
        {
            // Setup
            string accountName = "automation";
            var runbookName = "runbook";

            this.mockAutomationClient.Setup(
                f => f.ListJobsByRunbookName(accountName, runbookName, It.IsAny<DateTime?>(), It.IsAny<DateTime?>()));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RunbookName = runbookName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobsByRunbookName(accountName, runbookName, It.IsAny<DateTime?>(), It.IsAny<DateTime?>()), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationJobByAllSuccessfull()
        {
            // Setup
            string accountName = "automation";

            this.mockAutomationClient.Setup(f => f.ListJobs(accountName, It.IsAny<DateTime?>(), It.IsAny<DateTime?>()));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobs(accountName, It.IsAny<DateTime?>(), It.IsAny<DateTime?>()), Times.Once());
        }
    }
}
