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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;

namespace Microsoft.Azure.Commands.Automation.Test.UnitTests
{
    [TestClass]
    public class NewAzureAutomationScheduleTest : SMTestBase
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

            this.mockAutomationClient.Setup(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()));

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTimeOffset.Now;
            this.cmdlet.OneTime = true;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByOneTime);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()), Times.Once());
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByDailySuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            byte dayInterval = 1;

            this.mockAutomationClient.Setup(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()));

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTimeOffset.Now;
            this.cmdlet.DayInterval = dayInterval;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByDaily);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()), Times.Once());
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByHourlySuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            byte hourInterval = 1;

            this.mockAutomationClient.Setup(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()));

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTimeOffset.Now;
            this.cmdlet.HourInterval = hourInterval;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByHourly);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()), Times.Once());
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByDailyWithDefaultExpiryTimeDayIntervalSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            byte dayInterval = 1;

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()))
                .Returns((string a, Schedule s) => s);

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTimeOffset.Now;
            this.cmdlet.DayInterval = dayInterval;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByDaily);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()), Times.Once());

            Assert.AreEqual<int>(1, ((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.Count);
            var schedule = (Schedule)((MockCommandRuntime)this.cmdlet.CommandRuntime)
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
                schedule.Interval,
                "Day Interval is unexpectedly {0}",
                schedule.Interval);
            Assert.AreEqual(
                ScheduleFrequency.Day,
                schedule.Frequency,
                "Day Frequency is unexpectedly {0}",
                schedule.Frequency);
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByHourlyWithDefaultExpiryTimeDayIntervalSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            byte hourInterval = 1;

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()))
                .Returns((string a, Schedule s) => s);

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTimeOffset.Now;
            this.cmdlet.HourInterval = hourInterval;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByHourly);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()), Times.Once());

            Assert.AreEqual<int>(1, ((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.Count);
            var schedule = (Schedule)((MockCommandRuntime)this.cmdlet.CommandRuntime)
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
                schedule.Interval,
                "Hour Interval is unexpectedly {0}",
                schedule.Interval);
            Assert.AreEqual(
                ScheduleFrequency.Hour,
                schedule.Frequency,
                "Hour Frequency is unexpectedly {0}",
                schedule.Frequency);
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByDailyWithExpiryTimeSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            byte dayInterval = 1;
            var startTime = DateTimeOffset.Now;
            var expiryTime = startTime.AddDays(10);

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()))
                .Returns((string a, Schedule s) => s);

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.ExpiryTime = expiryTime;
            this.cmdlet.DayInterval = dayInterval;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByDaily);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()), Times.Once());

            Assert.AreEqual<int>(1, ((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.Count);
            var schedule = (Schedule)((MockCommandRuntime)this.cmdlet.CommandRuntime)
                .OutputPipeline
                .FirstOrDefault();
            Assert.IsNotNull(schedule);
            Assert.AreEqual(scheduleName, schedule.Name, "Schedule name is unexpectedly {0}", schedule.Name);

            Assert.AreEqual(
                expiryTime,
                schedule.ExpiryTime,
                "Expiry time is unexpectedly {0}",
                schedule.ExpiryTime);
            Assert.AreEqual(
                dayInterval,
                schedule.Interval,
                "Day Interval is unexpectedly {0}",
                schedule.Interval);
            Assert.AreEqual(
                ScheduleFrequency.Day,
                schedule.Frequency,
                "Day Frequency is unexpectedly {0}",
                schedule.Frequency);
        }

        [TestMethod]
        public void NewAzureAutomationScheduleByHourlyWithExpiryTimeSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";
            byte hourInterval = 2;
            var startTime = DateTimeOffset.Now;
            var expiryTime = startTime.AddDays(10);

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()))
                .Returns((string a, Schedule s) => s);

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.ExpiryTime = expiryTime;
            this.cmdlet.HourInterval = hourInterval;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByHourly);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(accountName, It.IsAny<Schedule>()), Times.Once());

            Assert.AreEqual<int>(1, ((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.Count);
            var schedule = (Schedule)((MockCommandRuntime)this.cmdlet.CommandRuntime)
                .OutputPipeline
                .FirstOrDefault();
            Assert.IsNotNull(schedule);
            Assert.AreEqual(scheduleName, schedule.Name, "Schedule name is unexpectedly {0}", schedule.Name);

            // Test for default values
            Assert.AreEqual(
                expiryTime,
                schedule.ExpiryTime,
                "Expiry time is unexpectedly {0}",
                schedule.ExpiryTime);
            Assert.AreEqual(
                hourInterval,
                schedule.Interval,
                "Hour Interval is unexpectedly {0}",
                schedule.Interval);
            Assert.AreEqual(
                ScheduleFrequency.Hour,
                schedule.Frequency,
                "Hour Frequency is unexpectedly {0}",
                schedule.Frequency);
        }
    }
}
