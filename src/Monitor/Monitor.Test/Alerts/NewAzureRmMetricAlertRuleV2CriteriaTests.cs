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

using Microsoft.Azure.Commands.Insights.Alerts;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;
namespace Microsoft.Azure.Commands.Insights.Test.Alerts
{
    public class NewAzureRmMetricAlertRuleV2CriteriaTests
    {
        private readonly NewAzureRmMetricAlertRuleV2CriteriaCommand cmdlet;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewAzureRmMetricAlertRuleV2CriteriaTests(ITestOutputHelper output)
        {
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewAzureRmMetricAlertRuleV2CriteriaCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewMetricAlertRuleV2CriteriaParametersProcessing()
        {
            // Setting required parameter
            cmdlet.MetricName = "PacketsInDDoS";
            cmdlet.Operator = "GreaterThan";
            cmdlet.Threshold = 2;
            cmdlet.TimeAggregation = "Total";
            cmdlet.ExecuteCmdlet();

            Func<PSMetricCriteria, bool> verify = r =>
            {
                Assert.Equal("PacketsInDDoS", r.MetricName);
                Assert.Equal("GreaterThan", r.OperatorProperty);
                Assert.Equal(2, r.Threshold);
                Assert.Equal("Total", r.TimeAggregation);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSMetricCriteria>(r => verify(r))), Times.Once);
        }
    }
}
