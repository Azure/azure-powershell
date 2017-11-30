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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Insights.Autoscale;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Monitor.Management.Models;
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
                ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
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
            Cmdlet.Rule = autoscaleRules;
        }

        public void InitializeForRecurrentSchedule()
        {
            Cmdlet.RecurrenceFrequency = RecurrenceFrequency.Minute;
            Cmdlet.ScheduleDay = new List<string> { "1", "2", "3" };
            Cmdlet.ScheduleHour = new List<int?> { 5, 10, 15 };
            Cmdlet.ScheduleMinute = new List<int?> { 15, 30, 45 };
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
