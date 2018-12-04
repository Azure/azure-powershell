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
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System;
using System.Linq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    public class NewAzureAutomationScheduleTest : RMTestBase
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private NewAzureAutomationSchedule cmdlet;

        public NewAzureAutomationScheduleTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new NewAzureAutomationSchedule
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureAutomationScheduleByOneTimeSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string scheduleName = "schedule";

            this.mockAutomationClient.Setup(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()));

            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTimeOffset.Now;
            this.cmdlet.OneTime = true;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByOneTime);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureAutomationScheduleByDailySuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string scheduleName = "schedule";
            byte dayInterval = 1;

            this.mockAutomationClient.Setup(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()));

            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTimeOffset.Now;
            this.cmdlet.DayInterval = dayInterval;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByDaily);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureAutomationScheduleByHourlySuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string scheduleName = "schedule";
            byte hourInterval = 1;

            this.mockAutomationClient.Setup(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()));

            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTimeOffset.Now;
            this.cmdlet.HourInterval = hourInterval;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByHourly);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureAutomationScheduleByDailyWithDefaultExpiryTimeDayIntervalSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string scheduleName = "schedule";
            byte dayInterval = 1;

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()))
                .Returns((string a, string b, Schedule s) => s);

            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTimeOffset.Now;
            this.cmdlet.DayInterval = dayInterval;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByDaily);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()), Times.Once());

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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureAutomationScheduleByHourlyWithDefaultExpiryTimeDayIntervalSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string scheduleName = "schedule";
            byte hourInterval = 1;

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()))
                .Returns((string a, string b, Schedule s) => s);

            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = DateTimeOffset.Now;
            this.cmdlet.HourInterval = hourInterval;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByHourly);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()), Times.Once());

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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureAutomationScheduleByDailyWithExpiryTimeSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string scheduleName = "schedule";
            byte dayInterval = 1;
            var startTime = DateTimeOffset.Now;
            var expiryTime = startTime.AddDays(10);

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()))
                .Returns((string a, string b, Schedule s) => s);

            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.ExpiryTime = expiryTime;
            this.cmdlet.DayInterval = dayInterval;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByDaily);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()), Times.Once());

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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureAutomationScheduleByHourlyWithExpiryTimeSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string scheduleName = "schedule";
            byte hourInterval = 2;
            var startTime = DateTimeOffset.Now;
            var expiryTime = startTime.AddDays(10);

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()))
                .Returns((string a, string b, Schedule s) => s);

            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.ExpiryTime = expiryTime;
            this.cmdlet.HourInterval = hourInterval;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByHourly);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()), Times.Once());

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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WeeklyWithTimeZoneSetsTheTimeZoneProperty()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string scheduleName = "schedule";
            byte weekInterval = 2;
            var startTime = DateTimeOffset.Now;
            var expiryTime = startTime.AddDays(10);
            var timeZone = "America/Los_Angeles";

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()))
                .Returns((string a, string b, Schedule s) => s);

            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.ExpiryTime = expiryTime;
            this.cmdlet.WeekInterval = weekInterval;
            this.cmdlet.TimeZone = timeZone;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByWeekly);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()), Times.Once());

            Assert.AreEqual(1, ((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.Count);
            var schedule = (Schedule)((MockCommandRuntime)this.cmdlet.CommandRuntime)
                .OutputPipeline
                .FirstOrDefault();
            Assert.IsNotNull(schedule);

            // Test for correct time zone value
            Assert.AreEqual(timeZone, schedule.TimeZone);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MonthlyDaysOfMonthWithTimeZoneSetsTheTimeZoneProperty()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string scheduleName = "schedule";
            byte monthInterval = 1;
            var startTime = DateTimeOffset.Now;
            var expiryTime = startTime.AddDays(10);
            var timeZone = "America/Los_Angeles";

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()))
                .Returns((string a, string b, Schedule s) => s);

            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.ExpiryTime = expiryTime;
            this.cmdlet.MonthInterval = monthInterval;
            this.cmdlet.TimeZone = timeZone;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByMonthlyDaysOfMonth);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()), Times.Once());

            Assert.AreEqual(1, ((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.Count);
            var schedule = (Schedule)((MockCommandRuntime)this.cmdlet.CommandRuntime)
                .OutputPipeline
                .FirstOrDefault();
            Assert.IsNotNull(schedule);

            // Test for correct time zone value
            Assert.AreEqual(timeZone, schedule.TimeZone);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MonthlyDayOfWeekWithTimeZoneSetsTheTimeZoneProperty()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string scheduleName = "schedule";
            byte monthInterval = 1;
            var startTime = DateTimeOffset.Now;
            var expiryTime = startTime.AddDays(10);
            var timeZone = "America/Los_Angeles";

            this.mockAutomationClient
                .Setup(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()))
                .Returns((string a, string b, Schedule s) => s);

            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.ExpiryTime = expiryTime;
            this.cmdlet.MonthInterval = monthInterval;
            this.cmdlet.TimeZone = timeZone;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByMonthlyDayOfWeek);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient
                .Verify(f => f.CreateSchedule(resourceGroupName, accountName, It.IsAny<Schedule>()), Times.Once());

            Assert.AreEqual(1, ((MockCommandRuntime)this.cmdlet.CommandRuntime).OutputPipeline.Count);
            var schedule = (Schedule)((MockCommandRuntime)this.cmdlet.CommandRuntime)
                .OutputPipeline
                .FirstOrDefault();
            Assert.IsNotNull(schedule);

            // Test for correct time zone value
            Assert.AreEqual(timeZone, schedule.TimeZone);
        }
    }
}
