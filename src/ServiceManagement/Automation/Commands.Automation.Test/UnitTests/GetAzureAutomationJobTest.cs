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
using Moq;

namespace Microsoft.Azure.Commands.Automation.Test.UnitTests
{
    [TestClass]
    public class GetAzureAutomationJobTest : SMTestBase
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
        public void GetAzureAutomationJobByRunbookNameSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookName = "runbook";
            string nextLink = string.Empty;

            this.mockAutomationClient.Setup(f => f.ListJobsByRunbookName(accountName, runbookName, null, null, null, ref nextLink));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RunbookName = runbookName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobsByRunbookName(accountName, runbookName, null, null, null, ref nextLink), Times.Once());
        }

        public void GetAzureAutomationJobByRunbookNamAndStartTimeEndTimeeSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookName = "runbook";
            string nextLink = string.Empty;

            DateTime startTime = new DateTime(2014, 12, 30, 17, 0, 0, 0);
            DateTime endTime = new DateTime(2014, 12, 30, 18, 0, 0, 0);

            this.mockAutomationClient.Setup(f => f.ListJobsByRunbookName(accountName, runbookName, startTime, endTime, null, ref nextLink));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RunbookName = runbookName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobsByRunbookName(accountName, runbookName, startTime, endTime, null, ref nextLink), Times.Once());
        }

        public void GetAzureAutomationCompletedJobByRunbookNamAndStartTimeEndTimeeSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookName = "runbook";
            string nextLink = string.Empty;

            DateTime startTime = new DateTime(2014, 12, 30, 17, 0, 0, 0);
            DateTime endTime = new DateTime(2014, 12, 30, 18, 0, 0, 0);
            string status = "Completed";

            this.mockAutomationClient.Setup(f => f.ListJobsByRunbookName(accountName, runbookName, startTime, endTime, status, ref nextLink));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RunbookName = runbookName;
            this.cmdlet.Status = status;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobsByRunbookName(accountName, runbookName, startTime, endTime, status, ref nextLink), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationAllJobsSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string nextLink = string.Empty;

            this.mockAutomationClient.Setup(f => f.ListJobs(accountName, null, null, null, ref nextLink));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobs(accountName, null, null, null, ref nextLink), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationAllJobsBetweenStartAndEndTimeSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string nextLink = string.Empty;

            DateTime startTime = new DateTime(2014, 12, 30, 17, 0, 0, 0);
            DateTime endTime = new DateTime(2014, 12, 30, 18, 0, 0, 0);

            // look for jobs between 5pm to 6pm on 30th december 2014 
            this.mockAutomationClient.Setup(f => f.ListJobs(accountName, startTime, endTime, null, ref nextLink));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.EndTime = endTime;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobs(accountName, startTime, endTime, null, ref nextLink), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationAllCompletedJobsBetweenStartAndEndTimeSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string nextLink = string.Empty;

            DateTime startTime = new DateTime(2014, 12, 30, 17, 0, 0, 0);
            DateTime endTime = new DateTime(2014, 12, 30, 18, 0, 0, 0);
            string status = "Completed";

            // look for jobs between 5pm to 6pm on 30th december 2014 
            this.mockAutomationClient.Setup(f => f.ListJobs(accountName, startTime, endTime, status, ref nextLink));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.EndTime = endTime;
            this.cmdlet.Status = status;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobs(accountName, startTime, endTime, status, ref nextLink), Times.Once());
        }

        public void GetAzureAutomationJobByIdSuccessfull()
        {
            // Setup
            string accountName = "automation";
            Guid jobId = Guid.NewGuid();

            // look for jobs between 5pm to 6pm on 30th december 2014 
            this.mockAutomationClient.Setup(f => f.GetJob(accountName, jobId));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Id = jobId;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetJob(accountName, jobId), Times.Once());
        }

    }
}
