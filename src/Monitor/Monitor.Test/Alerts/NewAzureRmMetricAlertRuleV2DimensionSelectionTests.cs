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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Insights.Test.Alerts
{
    public class NewAzureRmMetricAlertRuleV2DimensionSelectionTests : RMTestBase
    {
        private readonly NewAzureRmMetricAlertRuleV2DimensionSelectionCommand cmdlet;
        private Mock<ICommandRuntime> commandRuntimeMock;
        public NewAzureRmMetricAlertRuleV2DimensionSelectionTests(ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewAzureRmMetricAlertRuleV2DimensionSelectionCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewMetricAlertRuleV2DimensionSelectionarametersProcessing()
        {
            // Setting required parameter
            cmdlet.DimensionName = "dimension1";
            cmdlet.ValuesToInclude = new string[] { "val1", "val2" };
            cmdlet.ExecuteCmdlet();

            Func<PSMetricDimension, bool> verify = r =>
            {
                Assert.Equal("dimension1", r.Dimension);
                Assert.Equal(new List<string>() { "val1", "val2" }, r.IncludeValues);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSMetricDimension>(r => verify(r))), Times.Once);
        }
    }
}
