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

using Microsoft.Azure.Commands.Insights.Metrics;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Metrics
{
    public class NewAzureRmMetricFilterTests : RMTestBase
    {
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewAzureRmMetricFilterCommand Cmdlet { get; set; }

        public NewAzureRmMetricFilterTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            commandRuntimeMock = new Mock<ICommandRuntime>();
            Cmdlet = new NewAzureRmMetricFilterCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmMetricFilterCommandParametersProcessing()
        {
            Cmdlet.Dimension = "City";
            Cmdlet.Operator = "eq";
            Cmdlet.Value = new string[] { "Seattle", "New York" };
            Cmdlet.ExecuteCmdlet();
            string expectedOutput = "City eq 'Seattle' or City eq 'New York'";

            Func<string, bool> verify = r =>
            {
                Assert.Equal(expectedOutput, r);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<string>(r => verify(r))), Times.Once);
        }
    }
}
