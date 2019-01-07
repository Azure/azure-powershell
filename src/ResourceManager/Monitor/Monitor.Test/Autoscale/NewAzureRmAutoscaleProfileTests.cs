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

using Microsoft.Azure.Commands.Insights.Autoscale;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Autoscale
{
    public class NewAzureRmAutoscaleProfileTests
    {
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewAzureRmAutoscaleProfileCommand Cmdlet { get; set; }

        public NewAzureRmAutoscaleProfileTests(Xunit.Abstractions.ITestOutputHelper output = null)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            if (output != null)
            {
                ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            }

            commandRuntimeMock = new Mock<ICommandRuntime>();
            Cmdlet = new NewAzureRmAutoscaleProfileCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAutoscaleProfileCommandParametersProcessing()
        {
            this.InitializeAutoscaleProfile();
            this.InitializeForRecurrentSchedule();
            Cmdlet.ExecuteCmdlet();

            this.InitializeForFixedDate();
            Cmdlet.ExecuteCmdlet();

            Cmdlet.ScheduleDay = null;
            Cmdlet.ScheduleHour = null;
            Cmdlet.ScheduleMinute = null;
            Cmdlet.ScheduleTimeZone = null;

            Cmdlet.ExecuteCmdlet();
        }

        private Management.Monitor.Management.Models.ScaleRule CreateAutoscaleRule(string metricName = null)
        {
            var autocaseRuleCmd = new NewAzureRmAutoscaleRuleCommand
            {
                MetricName = metricName ?? "Requests",
                MetricResourceId = "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo",
                Operator = Management.Monitor.Management.Models.ComparisonOperationType.GreaterThan,
                MetricStatistic = Management.Monitor.Management.Models.MetricStatisticType.Average,
                Threshold = 10,
                TimeGrain = TimeSpan.FromMinutes(1),
                ScaleActionCooldown = TimeSpan.FromMinutes(5),
                ScaleActionDirection = Management.Monitor.Management.Models.ScaleDirection.Increase,
                ScaleActionValue = "1"
            };

            return autocaseRuleCmd.CreateSettingRule();
        }

        internal void InitializeAutoscaleProfile(List<Management.Monitor.Management.Models.ScaleRule> rules = null)
        {
            List<Management.Monitor.Management.Models.ScaleRule> autoscaleRules = rules ?? new List<Management.Monitor.Management.Models.ScaleRule> { this.CreateAutoscaleRule() };

            Cmdlet.Name = "profile1";
            Cmdlet.DefaultCapacity = "1";
            Cmdlet.MaximumCapacity = "10";
            Cmdlet.MinimumCapacity = "1";
            Cmdlet.Rule = autoscaleRules;
        }

        internal void InitializeForRecurrentSchedule()
        {
            Cmdlet.RecurrenceFrequency = Management.Monitor.Management.Models.RecurrenceFrequency.Minute;
            Cmdlet.ScheduleDay = new List<string> { "1", "2", "3" };
            Cmdlet.ScheduleHour = new List<int?> { 5, 10, 15 };
            Cmdlet.ScheduleMinute = new List<int?> { 15, 30, 45 };
            Cmdlet.ScheduleTimeZone = "GMT";
        }

        internal void InitializeForFixedDate()
        {
            Cmdlet.StartTimeWindow = DateTime.Now;
            Cmdlet.EndTimeWindow = DateTime.Now.AddMinutes(1);
            Cmdlet.TimeWindowTimeZone = "GMT";
        }
    }
}
