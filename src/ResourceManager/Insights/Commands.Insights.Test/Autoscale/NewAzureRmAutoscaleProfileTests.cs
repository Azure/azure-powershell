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
using Microsoft.Azure.Management.Insights.Models;
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

        public NewAzureRmAutoscaleProfileTests()
        {
            commandRuntimeMock = new Mock<ICommandRuntime>();
            Cmdlet = new NewAzureRmAutoscaleProfileCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        public NewAzureRmAutoscaleProfileTests(Xunit.Abstractions.ITestOutputHelper output)
            : this()
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));

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

            Cmdlet.ScheduleDays = null;
            Cmdlet.ScheduleHours = null;
            Cmdlet.ScheduleMinutes = null;
            Cmdlet.ScheduleTimeZone = null;

            Cmdlet.ExecuteCmdlet();
        }

        private ScaleRule CreateAutoscaleRule(string metricName = null)
        {
            var autocaseRuleCmd = new NewAzureRmAutoscaleRuleCommand
            {
                MetricName = metricName ?? "Requests",
                MetricResourceId = "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo",
                Operator = ComparisonOperationType.GreaterThan,
                MetricStatistic = MetricStatisticType.Average,
                Threshold = 10,
                TimeGrain = TimeSpan.FromMinutes(1),
                ScaleActionCooldown = TimeSpan.FromMinutes(5),
                ScaleActionDirection = ScaleDirection.Increase,
                ScaleActionScaleType = ScaleType.ChangeCount,
                ScaleActionValue = "1"
            };

            return autocaseRuleCmd.CreateSettingRule();
        }

        public void InitializeAutoscaleProfile(List<ScaleRule> rules = null)
        {
            List<ScaleRule> autoscaleRules = rules ?? new List<ScaleRule> { this.CreateAutoscaleRule() };

            Cmdlet.Name = "profile1";
            Cmdlet.DefaultCapacity = "1";
            Cmdlet.MaximumCapacity = "10";
            Cmdlet.MinimumCapacity = "1";
            Cmdlet.Rules = autoscaleRules;
        }

        public void InitializeForRecurrentSchedule()
        {
            Cmdlet.RecurrenceFrequency = RecurrenceFrequency.Minute;
            Cmdlet.ScheduleDays = new List<string> { "1", "2", "3" };
            Cmdlet.ScheduleHours = new List<int> { 5, 10, 15 };
            Cmdlet.ScheduleMinutes = new List<int> { 15, 30, 45 };
            Cmdlet.ScheduleTimeZone = "GMT";
        }

        public void InitializeForFixedDate()
        {
            Cmdlet.StartTimeWindow = DateTime.Now;
            Cmdlet.EndTimeWindow = DateTime.Now.AddMinutes(1);
            Cmdlet.TimeWindowTimeZone = "GMT";
        }
    }
}
