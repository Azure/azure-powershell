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
using System.Linq;
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
    public class NewAzureAutomationScheduleTest : TestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private NewAzureAutomationSchedule cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new NewAzureAutomationSchedule
                              {
                                  AutomationClient = this.mockAutomationClient.Object,
                                  CommandRuntime = this.mockCommandRuntime
                              };
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByOneTimeSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";

            this.mockAutomationClient.Setup(f => f.CreateSchedule(accountName, It.IsAny<OneTimeSchedule>()));

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTime.Now;
            this.cmdlet.OneTime = true;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.CreateSchedule(accountName, It.IsAny<OneTimeSchedule>()), Times.Once());
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByDailySuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";

            this.mockAutomationClient.Setup(f => f.CreateSchedule(accountName, It.IsAny<DailySchedule>()));

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTime.Now;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.CreateSchedule(accountName, It.IsAny<DailySchedule>()), Times.Once());
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByDailyWithDefaultExpiryTimeDayIntervalSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";

            this.mockAutomationClient.Setup(f => f.CreateSchedule(accountName, It.IsAny<DailySchedule>())).Returns((string a, DailySchedule s) => s);

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTime.Now;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.CreateSchedule(accountName, It.IsAny<DailySchedule>()), Times.Once());

            Assert.AreEqual<int>(1, ((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.Count);
            var schedule = (DailySchedule)((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.FirstOrDefault();
            Assert.IsNotNull(schedule);
            Assert.IsTrue(schedule.Name == scheduleName);

            // Test for default values
            Assert.IsTrue(schedule.ExpiryTime == Constants.DefaultScheduleExpiryTime);
            Assert.IsTrue(schedule.DayInterval == Constants.DefaultDailyScheduleDayInterval);
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByDailyWithUnspecificedDateTimeKindSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            var startTime = DateTime.Now;
            var expiryTime = new DateTime(2048, 4, 2);

            this.mockAutomationClient.Setup(f => f.CreateSchedule(accountName, It.IsAny<DailySchedule>())).Returns((string a, DailySchedule s) => s);

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.ExpiryTime = expiryTime;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.CreateSchedule(accountName, It.IsAny<DailySchedule>()), Times.Once());

            Assert.AreEqual<int>(1, ((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.Count);
            var schedule = (DailySchedule)((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.FirstOrDefault();
            Assert.IsNotNull(schedule);
            Assert.IsTrue(schedule.Name == scheduleName);

            // If startTime or expiryTime is unspecified DateTimeKind, we assume they are local time
            Assert.IsTrue(schedule.StartTime.Kind == DateTimeKind.Local);
            Assert.IsTrue(schedule.ExpiryTime.Kind == DateTimeKind.Local);
        }
    }
}
