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

using System.Collections.Generic;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Commands.Insights.ScheduledQueryRules;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.Test.ScheduledQueryRules
{
    public class RemoveScheduledQueryRuleTests
    {
        private readonly RemoveScheduledQueryRuleCommand cmdlet;

        private readonly Mock<MonitorManagementClient> monitorManagementClientMock;

        private readonly Mock<IScheduledQueryRulesOperations> sqrOperationsMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroup;

        private string ruleName;

        public RemoveScheduledQueryRuleTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            sqrOperationsMock = new Mock<IScheduledQueryRulesOperations>();
            monitorManagementClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new RemoveScheduledQueryRuleCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = monitorManagementClientMock.Object
            };

            sqrOperationsMock.Setup(f => f.DeleteWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse>(new Microsoft.Rest.Azure.AzureOperationResponse()))
                .Callback((string r, string n, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    this.resourceGroup = r;
                    this.ruleName = n;
                });

            monitorManagementClientMock.SetupGet(f => f.ScheduledQueryRules).Returns(this.sqrOperationsMock.Object);

            // Setup Confirmation
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveScheduledQueryRuleCommandParametersProcessing()
        {
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.Name = "alert1";
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal("alert1", this.ruleName);

            cmdlet.Name = null;
            cmdlet.ResourceGroupName = null;

            Source source = new Source();
            Schedule schedule = new Schedule();
            Action action = new Action();
            
            var resource = new ScheduledQueryRuleResource(new LogSearchRuleResource(name: "alert2", location: "westus", source: source, schedule: schedule, action: action, id: "/subscriptions/00000000-0000-0000-0000-0000000000000/resourceGroups/Default-Web-EastUS/providers/microsoft.insights/scheduledqueryrules/alert2"));


            cmdlet.InputObject = new OutputClasses.PSScheduledQueryRuleResource(resource);
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal("alert2", this.ruleName);

            cmdlet.Name = null;
            cmdlet.ResourceGroupName = null;
            cmdlet.InputObject = null;
            cmdlet.ResourceId = "/subscriptions/00000000-0000-0000-0000-0000000000000/resourceGroups/Default-Web-EastUS/providers/microsoft.insights/scheduledqueryrules/alert3";
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal("alert3", this.ruleName);
        }
    }
}
