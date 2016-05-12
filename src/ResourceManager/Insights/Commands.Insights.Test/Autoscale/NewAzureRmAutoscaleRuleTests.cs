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
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Autoscale
{
    public class NewAzureRmAutoscaleRuleTests
    {
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewAzureRmAutoscaleRuleCommand Cmdlet { get; set; }

        public NewAzureRmAutoscaleRuleTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            Cmdlet = new NewAzureRmAutoscaleRuleCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAutoscaleRuleCommandParametersProcessing()
        {
            // New-AutoscaleRule -MetricName <String> -MetricResourceUri <String> -Operator <{Equals | NotEquals | GreaterThan | GreaterThanOrEqual | LessThan | LessThanOrEqual}> 
            //                   -MetricStatistic <{Average | Min | Max | Sum}> -Threshold <Double> [-TimeAggregationOperator <{Average | Minimum | Maximum | Last | Total | Count}>] 
            //                   -TimeGrain <TimeSpan> [-TimeWindow <TimeSpan>] -ScaleActionCooldown <TimeSpan> -ScaleActionDirection <{None | Increase | Decrease}> 
            //                   -ScaleActionScaleType <{ChangeSize | ChangeCount | PercentChangeCount | ExactCount}> -ScaleActionValue <String>
            Cmdlet.MetricName = "Requests";
            Cmdlet.MetricResourceId = "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo";
            Cmdlet.Operator = ComparisonOperationType.GreaterThan;
            Cmdlet.MetricStatistic = MetricStatisticType.Average;
            Cmdlet.Threshold = 10;
            Cmdlet.ScaleActionCooldown = TimeSpan.FromMinutes(5);
            Cmdlet.ScaleActionDirection = ScaleDirection.Increase;
            Cmdlet.ScaleActionScaleType = ScaleType.ChangeCount;
            Cmdlet.ScaleActionValue = "1";
            Assert.Throws<ArgumentOutOfRangeException>(() => Cmdlet.ExecuteCmdlet());

            Cmdlet.TimeGrain = TimeSpan.FromMinutes(1);
            Cmdlet.ExecuteCmdlet();

            Cmdlet.TimeWindow = TimeSpan.FromMinutes(4);
            Assert.Throws<ArgumentOutOfRangeException>(() => Cmdlet.ExecuteCmdlet());

            Cmdlet.TimeWindow = TimeSpan.FromMinutes(5);
            Cmdlet.ExecuteCmdlet();
        }
    }
}
