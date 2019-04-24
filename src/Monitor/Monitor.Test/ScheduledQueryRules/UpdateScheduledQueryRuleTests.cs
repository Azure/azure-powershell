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

using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Xunit;
using Microsoft.Azure.Commands.Insights.ScheduledQueryRules;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Microsoft.Azure.Management.Monitor.Models;
using ActivityLogAlertResource = Microsoft.Azure.Management.Monitor.Models.ActivityLogAlertResource;

namespace Microsoft.Azure.Commands.Insights.Test.ScheduledQueryRules
{
    public class UpdateScheduledQueryRuleTests
    {
        private readonly UpdateScheduledQueryRuleCommand cmdlet;
        private readonly Mock<MonitorManagementClient> monitorManagementClientMock;
        private readonly Mock<IScheduledQueryRulesOperations> sqrOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse<LogSearchRuleResource> response;
        private string resourceGroup;
        private string ruleName;
        private LogSearchRuleResourcePatch patchPrms;
        private LogSearchRuleResource updatePrms;

        public UpdateScheduledQueryRuleTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            sqrOperationsMock = new Mock<IScheduledQueryRulesOperations>();
            monitorManagementClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();

            //testing update of "enabled" field
            cmdlet = new UpdateScheduledQueryRuleCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = monitorManagementClientMock.Object,
                Enabled = true
            };

            response = new AzureOperationResponse<LogSearchRuleResource>()
            {
                Body = new LogSearchRuleResource()
            };

            sqrOperationsMock.Setup(f => f.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse<LogSearchRuleResource>>(response))
                .Callback((string resourceGrp, string name, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken) =>
                {
                    this.resourceGroup = resourceGrp;
                    this.ruleName = name;
                    this.updatePrms = response.Body;
                });

            sqrOperationsMock.Setup(f => f.UpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<LogSearchRuleResourcePatch>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse<LogSearchRuleResource>>(response))
                .Callback((string resourceGrp, string name, LogSearchRuleResourcePatch patchPrms, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    this.resourceGroup = resourceGrp;
                    this.ruleName = name;
                    this.patchPrms = patchPrms;
                    this.updatePrms = response.Body;
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

        public void UpdateScheduledQueryRuleCommandParametersProcessing()
        {
            //testing update of "enabled" field

            cmdlet.Name = "LogSearchAlertName";
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;

            cmdlet.Enabled = false;
            cmdlet.ExecuteCmdlet();

            Assert.Equal("LogSearchAlertName", this.ruleName);
            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);

            Assert.NotNull(this.updatePrms);
            Assert.NotNull(this.patchPrms);

            Assert.Equal("false", this.patchPrms.Enabled);

            Assert.Null(this.updatePrms.Id);

            cmdlet.Name = null;
            cmdlet.ResourceGroupName = null;

            ScheduledQueryRuleResource sqrResource= new ScheduledQueryRuleResource();
            cmdlet.InputObject = new PSScheduledQueryRuleResource(sqrResource);
            cmdlet.Enabled = true;

            cmdlet.ExecuteCmdlet();

            Assert.NotNull(this.patchPrms);
            Assert.NotNull(this.updatePrms);
            Assert.Equal("true", this.patchPrms.Enabled);

            cmdlet.InputObject = null;
            cmdlet.ResourceId = "/subscriptions/00000000-0000-0000-0000-0000000000000/resourceGroups/Default-Web-EastUS/providers/microsoft.insights/scheduledqueryrules/LogSearchAlertName";
            cmdlet.Enabled = false;

            cmdlet.ExecuteCmdlet();

            Assert.NotNull(this.patchPrms);
            Assert.NotNull(this.updatePrms);
            Assert.Equal("LogSearchAlertName", this.ruleName);
            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal("false", this.patchPrms.Enabled);
        }
    }
}
