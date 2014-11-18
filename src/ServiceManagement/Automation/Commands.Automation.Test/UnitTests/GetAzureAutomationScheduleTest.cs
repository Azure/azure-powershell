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
    public class GetAzureAutomationScheduleTest : TestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureAutomationSchedule cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new GetAzureAutomationSchedule
                              {
                                  AutomationClient = this.mockAutomationClient.Object,
                                  CommandRuntime = this.mockCommandRuntime
                              };
        }

        [TestMethod]
        public void GetAzureAutomationScheduleByIdSuccessfull()
        {
            // Setup
            string accountName = "automation";
            var scheduleId = new Guid();

            this.mockAutomationClient.Setup(f => f.GetSchedule(accountName, scheduleId));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Id = scheduleId;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetSchedule(accountName, scheduleId), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationScheduleByNameSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";

            this.mockAutomationClient.Setup(f => f.GetSchedule(accountName, scheduleName));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetSchedule(accountName, scheduleName), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationScheduleByAllSuccessfull()
        {
            // Setup
            string accountName = "automation";

            this.mockAutomationClient.Setup(f => f.ListSchedules(accountName)).Returns((string a) => new List<Schedule>());

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListSchedules(accountName), Times.Once());
        }
    }
}
