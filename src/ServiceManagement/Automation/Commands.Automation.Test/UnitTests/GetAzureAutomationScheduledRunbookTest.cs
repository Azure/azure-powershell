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
using System.Collections.Generic;
using Microsoft.Azure.Commands.Automation.Cmdlet;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;

namespace Microsoft.Azure.Commands.Automation.Test.UnitTests
{
    [TestClass]
    public class GetAzureAutomationScheduledRunbookTest : SMTestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureAutomationScheduledRunbook cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new GetAzureAutomationScheduledRunbook
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [TestMethod]
        public void GetAzureAutomationScheduledRunbookByIdSuccessfull()
        {
            // Setup
            string accountName = "automation";
            var jobScheduleId = new Guid();

            this.mockAutomationClient.Setup(f => f.GetJobSchedule(accountName, jobScheduleId));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.JobScheduleId = jobScheduleId;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByJobScheduleId);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetJobSchedule(accountName, jobScheduleId), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationScheduledRunbookByrunbookNameAndScheduleNameSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookName = "runbook";
            string scheduleName = "schedule";

            this.mockAutomationClient.Setup(f => f.GetJobSchedule(accountName, runbookName, scheduleName));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RunbookName = runbookName;
            this.cmdlet.ScheduleName = scheduleName;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByRunbookNameAndScheduleName);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetJobSchedule(accountName, runbookName, scheduleName), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationScheduledRunbookByRunbookNameSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookName = "runbook";
            string nextLink = string.Empty;

            this.mockAutomationClient.Setup(f => f.ListJobSchedules(accountName, ref nextLink)).Returns((string a, string b) => new List<JobSchedule>());

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RunbookName = runbookName;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByRunbookName);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobSchedules(accountName, ref nextLink), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationScheduledRunbookByScheduleNameSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            string nextLink = string.Empty;

            this.mockAutomationClient.Setup(f => f.ListJobSchedules(accountName, ref nextLink)).Returns((string a, string b) => new List<JobSchedule>());

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.ScheduleName = scheduleName;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByScheduleName);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobSchedules(accountName, ref nextLink), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationScheduledRunbookByAllSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string nextLink = string.Empty;

            this.mockAutomationClient.Setup(f => f.ListJobSchedules(accountName, ref nextLink)).Returns((string a, string b) => new List<JobSchedule>());

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByAll);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobSchedules(accountName, ref nextLink), Times.Once());
        }
    }
}
