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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    [TestClass]
    public class GetAzureAutomationJobTest : RMTestBase
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
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string runbookName = "runbook";
            string nextLink = string.Empty;

            this.mockAutomationClient.Setup(f => f.ListJobsByRunbookName(resourceGroupName, accountName, runbookName, null, null, null, ref nextLink));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RunbookName = runbookName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobsByRunbookName(resourceGroupName, accountName, runbookName, null, null, null, ref nextLink), Times.Once());
        }

        public void GetAzureAutomationJobByRunbookNamAndStartTimeEndTimeeSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string runbookName = "runbook";
            string nextLink = string.Empty;

            DateTime startTime = new DateTime(2014, 12, 30, 17, 0, 0, 0);
            DateTime endTime = new DateTime(2014, 12, 30, 18, 0, 0, 0);

            this.mockAutomationClient.Setup(f => f.ListJobsByRunbookName(resourceGroupName, accountName, runbookName, startTime, endTime, null, ref nextLink));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RunbookName = runbookName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobsByRunbookName(resourceGroupName, accountName, runbookName, startTime, endTime, null, ref nextLink), Times.Once());
        }

        public void GetAzureAutomationCompletedJobByRunbookNamAndStartTimeEndTimeeSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string runbookName = "runbook";
            string nextLink = string.Empty;

            DateTime startTime = new DateTime(2014, 12, 30, 17, 0, 0, 0);
            DateTime endTime = new DateTime(2014, 12, 30, 18, 0, 0, 0);
            string status = "Completed";

            this.mockAutomationClient.Setup(f => f.ListJobsByRunbookName(resourceGroupName, accountName, runbookName, startTime, endTime, status, ref nextLink));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RunbookName = runbookName;
            this.cmdlet.Status = status;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobsByRunbookName(resourceGroupName, accountName, runbookName, startTime, endTime, status, ref nextLink), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationAllJobsSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string nextLink = string.Empty;

            this.mockAutomationClient.Setup(f => f.ListJobs(resourceGroupName, accountName, null, null, null, ref nextLink));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobs(resourceGroupName, accountName, null, null, null, ref nextLink), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationAllJobsBetweenStartAndEndTimeSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string nextLink = string.Empty;

            DateTime startTime = new DateTime(2014, 12, 30, 17, 0, 0, 0);
            DateTime endTime = new DateTime(2014, 12, 30, 18, 0, 0, 0);

            // look for jobs between 5pm to 6pm on 30th december 2014 
            this.mockAutomationClient.Setup(f => f.ListJobs(resourceGroupName, accountName, startTime, endTime, null, ref nextLink));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.EndTime = endTime;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobs(resourceGroupName, accountName, startTime, endTime, null, ref nextLink), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationAllCompletedJobsBetweenStartAndEndTimeSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string nextLink = string.Empty;

            DateTime startTime = new DateTime(2014, 12, 30, 17, 0, 0, 0);
            DateTime endTime = new DateTime(2014, 12, 30, 18, 0, 0, 0);
            string status = "Completed";

            // look for jobs between 5pm to 6pm on 30th december 2014 
            this.mockAutomationClient.Setup(f => f.ListJobs(resourceGroupName, accountName, startTime, endTime, status, ref nextLink));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.EndTime = endTime;
            this.cmdlet.Status = status;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobs(resourceGroupName, accountName, startTime, endTime, status, ref nextLink), Times.Once());
        }

        public void GetAzureAutomationJobByIdSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            Guid jobId = Guid.NewGuid();

            // look for jobs between 5pm to 6pm on 30th december 2014 
            this.mockAutomationClient.Setup(f => f.GetJob(resourceGroupName, accountName, jobId));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Id = jobId;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetJob(resourceGroupName, accountName, jobId), Times.Once());
        }

    }
}
