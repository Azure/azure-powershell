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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;

namespace Microsoft.Azure.Commands.Automation.Test.UnitTests
{
    [TestClass]
    public class UnregisterAzureAutomationScheduledRunbookTest : SMTestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private UnregisterAzureAutomationScheduledRunbook cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new UnregisterAzureAutomationScheduledRunbook
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [TestMethod]
        public void UnregisterAzureAutomationScheduledRunbookByIdSuccessfull()
        {
            // Setup
            string accountName = "automation";
            var jobScheduleId = new Guid();

            this.mockAutomationClient.Setup(f => f.UnregisterScheduledRunbook(accountName, jobScheduleId));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.JobScheduleId = jobScheduleId;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByJobScheduleId);
            this.cmdlet.Force = true;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.UnregisterScheduledRunbook(accountName, jobScheduleId), Times.Once());
        }

        [TestMethod]
        public void UnregisterAzureAutomationScheduledRunbookByRunbookNameAndScheduleNameSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookName = "runbook";
            string scheduleName = "schedule";

            this.mockAutomationClient.Setup(f => f.UnregisterScheduledRunbook(accountName, runbookName, scheduleName));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RunbookName = runbookName;
            this.cmdlet.ScheduleName = scheduleName;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByRunbookNameAndScheduleName);
            this.cmdlet.Force = true;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.UnregisterScheduledRunbook(accountName, runbookName, scheduleName), Times.Once());
        }
    }
}
