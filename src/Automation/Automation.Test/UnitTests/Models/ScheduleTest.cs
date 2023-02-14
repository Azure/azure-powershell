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

namespace Microsoft.Azure.Commands.Automation.Test.UnitTests.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.Automation.Cmdlet;
    using Microsoft.Azure.Management.Automation.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class ScheduleTest
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void ScheduleConstructorHandlesMonthlyDayOfWeekSchedule()
        {
            const string expectedDayOfWeek = "Saturday";
            const int occurrence = 1;

            var sdkSchedule = new Schedule()
            {
                Frequency = "Month",
                AdvancedSchedule = new AdvancedSchedule()
                {
                    WeekDays = null,
                    MonthDays = null,
                    MonthlyOccurrences = new List<AdvancedScheduleMonthlyOccurrence>()
                    {
                        new AdvancedScheduleMonthlyOccurrence()
                        {
                            Day = expectedDayOfWeek,
                            Occurrence = occurrence,
                        },
                    },
                },
            };

            var schedule = new Model.Schedule("anyRg", "anyAccount", sdkSchedule);

            Assert.NotNull(schedule.MonthlyScheduleOptions);
            Assert.Null(schedule.WeeklyScheduleOptions);

            Assert.Null(schedule.MonthlyScheduleOptions.DaysOfMonth);
            Assert.NotNull(schedule.MonthlyScheduleOptions.DayOfWeek);

            Assert.Equal(expectedDayOfWeek, schedule.MonthlyScheduleOptions.DayOfWeek.Day);
            Assert.Equal(Enum.GetName(typeof(DayOfWeekOccurrence), occurrence), schedule.MonthlyScheduleOptions.DayOfWeek.Occurrence);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void ScheduleConstructorHandlesMonthlyDayOfMonthSchedule()
        {
            var sdkSchedule = new Schedule()
            {
                Frequency = "Month",
                AdvancedSchedule = new AdvancedSchedule()
                {
                    WeekDays = null,
                    MonthDays = new List<int>() { 1, 15, },
                    MonthlyOccurrences = null,
                },
            };

            var schedule = new Model.Schedule("anyRg", "anyAccount", sdkSchedule);

            Assert.NotNull(schedule.MonthlyScheduleOptions);
            Assert.Null(schedule.WeeklyScheduleOptions);

            Assert.NotNull(schedule.MonthlyScheduleOptions.DaysOfMonth);
            Assert.Null(schedule.MonthlyScheduleOptions.DayOfWeek);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void ScheduleConstructorHandlesWeeklySchedule()
        {
            var sdkSchedule = new Schedule()
            {
                Frequency = "Week",
                AdvancedSchedule = new AdvancedSchedule()
                {
                    WeekDays = new List<string>() { "Monday" },
                    MonthDays = null,
                    MonthlyOccurrences = null,
                },
            };

            var schedule = new Model.Schedule("anyRg", "anyAccount", sdkSchedule);

            Assert.Null(schedule.MonthlyScheduleOptions);
            Assert.NotNull(schedule.WeeklyScheduleOptions);

            Assert.NotNull(schedule.WeeklyScheduleOptions.DaysOfWeek);
        }
    }
}
