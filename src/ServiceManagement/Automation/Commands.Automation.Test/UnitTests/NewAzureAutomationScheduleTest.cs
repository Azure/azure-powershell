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
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<OneTimeSchedule>()), Times.Once());
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByDailySuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            int dayInterval = 1;

            this.mockAutomationClient.Setup(f => f.CreateSchedule(accountName, It.IsAny<DailySchedule>()));

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTime.Now;
            this.cmdlet.DayInterval = dayInterval;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<DailySchedule>()), Times.Once());
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByHourlySuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            int hourInterval = 1;

            this.mockAutomationClient.Setup(f => f.CreateSchedule(accountName, It.IsAny<HourlySchedule>()));

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTime.Now;
            this.cmdlet.HourInterval = hourInterval;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<HourlySchedule>()), Times.Once());
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByDailyWithDefaultExpiryTimeDayIntervalSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            int dayInterval = 1;

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(accountName, It.IsAny<DailySchedule>()))
                .Returns((string a, DailySchedule s) => s);

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTime.Now;
            this.cmdlet.DayInterval = dayInterval;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<DailySchedule>()), Times.Once());

            Assert.AreEqual<int>(1, ((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.Count);
            var schedule = (DailySchedule)((MockCommandRuntime)this.cmdlet.CommandRuntime)
                .OutputPipeline
                .FirstOrDefault();
            Assert.IsNotNull(schedule);
            Assert.AreEqual(scheduleName, schedule.Name, "Schedule name is unexpectedly {0}", schedule.Name);

            // Test for default values
            Assert.AreEqual(
                Constants.DefaultScheduleExpiryTime, 
                schedule.ExpiryTime, 
                "Expiry time is unexpectedly {0}", 
                schedule.ExpiryTime);
            Assert.AreEqual(
                dayInterval, 
                schedule.DayInterval, 
                "Day Interval is unexpectedly {0}", 
                schedule.DayInterval);
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByHourlyWithDefaultExpiryTimeDayIntervalSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            int hourInterval = 1;

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(accountName, It.IsAny<HourlySchedule>()))
                .Returns((string a, HourlySchedule s) => s);

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTime.Now;
            this.cmdlet.HourInterval = hourInterval;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<HourlySchedule>()), Times.Once());

            Assert.AreEqual<int>(1, ((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.Count);
            var schedule = (HourlySchedule)((MockCommandRuntime)this.cmdlet.CommandRuntime)
                .OutputPipeline
                .FirstOrDefault();
            Assert.IsNotNull(schedule);
            Assert.AreEqual(scheduleName, schedule.Name, "Schedule name is unexpectedly {0}", schedule.Name);

            // Test for default values
            Assert.AreEqual(
                Constants.DefaultScheduleExpiryTime, 
                schedule.ExpiryTime, 
                "Expiry time is unexpectedly {0}", 
                schedule.ExpiryTime);
            Assert.AreEqual(
                hourInterval, 
                schedule.HourInterval, 
                "Hour Interval is unexpectedly {0}", 
                schedule.HourInterval);
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByDailyWithUnspecificedDateTimeKindSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            int dayInterval = 1;
            var startTime = DateTime.Now;
            var expiryTime = new DateTime(2048, 4, 2);

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(accountName, It.IsAny<DailySchedule>()))
                .Returns((string a, DailySchedule s) => s);

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.ExpiryTime = expiryTime;
            this.cmdlet.DayInterval = dayInterval;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<DailySchedule>()), Times.Once());

            Assert.AreEqual<int>(1, ((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.Count);
            var schedule = (DailySchedule)((MockCommandRuntime)this.cmdlet.CommandRuntime)
                .OutputPipeline
                .FirstOrDefault();
            Assert.IsNotNull(schedule);
            Assert.AreEqual(scheduleName, schedule.Name, "Schedule name is unexpectedly {0}", schedule.Name);

            // If startTime or expiryTime is unspecified DateTimeKind, we assume they are local time
            Assert.AreEqual(
                DateTimeKind.Local, 
                schedule.StartTime.Kind, 
                "DateTimeKind of start time is unexpectedly {0}", 
                schedule.StartTime.Kind);
            Assert.AreEqual(
                DateTimeKind.Local, 
                schedule.ExpiryTime.Kind, 
                "DateTimeKind of expiry time is unexpectedly {0}", 
                schedule.ExpiryTime.Kind);
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByHourlyWithUnspecificedDateTimeKindSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            int hourInterval = 1;
            var startTime = DateTime.Now;
            var expiryTime = new DateTime(2048, 4, 2);

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(accountName, It.IsAny<HourlySchedule>()))
                .Returns((string a, HourlySchedule s) => s);

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.ExpiryTime = expiryTime;
            this.cmdlet.HourInterval = hourInterval;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<HourlySchedule>()), Times.Once());

            Assert.AreEqual<int>(1, ((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.Count);
            var schedule = (HourlySchedule)((MockCommandRuntime)this.cmdlet.CommandRuntime)
                .OutputPipeline
                .FirstOrDefault();
            Assert.IsNotNull(schedule);
            Assert.AreEqual(scheduleName, schedule.Name, "Schedule name is unexpectedly {0}", schedule.Name);

            // If startTime or expiryTime is unspecified DateTimeKind, we assume they are local time
            Assert.AreEqual(
                DateTimeKind.Local, 
                schedule.StartTime.Kind, 
                "DateTimeKind of start time is unexpectedly {0}", 
                schedule.StartTime.Kind);
            Assert.AreEqual(
                DateTimeKind.Local, 
                schedule.ExpiryTime.Kind, 
                "DateTimeKind of expiry time is unexpectedly {0}", 
                schedule.ExpiryTime.Kind);
        }
    }
}
