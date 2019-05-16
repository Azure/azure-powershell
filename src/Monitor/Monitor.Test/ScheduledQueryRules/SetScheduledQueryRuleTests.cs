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

namespace Microsoft.Azure.Commands.Insights.Test.ScheduledQueryRules
{
    public class SetScheduledQueryRuleTests
    {
        private const string Location = "westus";
        private readonly SetScheduledQueryRuleCommand cmdlet;
        private readonly Mock<MonitorManagementClient> monitorManagementClientMock;
        private readonly Mock<IScheduledQueryRulesOperations> sqrOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse<LogSearchRuleResource> response;
        private string resourceGroup;
        private string ruleName;
        private LogSearchRuleResource updatePrms;

        public SetScheduledQueryRuleTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            sqrOperationsMock = new Mock<IScheduledQueryRulesOperations>();
            monitorManagementClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();

            ScheduledQueryRuleAznsAction aznsAction = new ScheduledQueryRuleAznsAction(new AzNsActionGroup());
            ScheduledQueryRuleTriggerCondition triggerCondition = new ScheduledQueryRuleTriggerCondition(new TriggerCondition("GreaterThan", 15));
            ScheduledQueryRuleAlertingAction alertingAction = new ScheduledQueryRuleAlertingAction(new AlertingAction("2", aznsAction, triggerCondition));

            ScheduledQueryRuleSchedule schedule = new ScheduledQueryRuleSchedule(new Schedule(5, 5));          

            ScheduledQueryRuleSource source = new ScheduledQueryRuleSource(new Source("union *", "dataSourceId", new string[]{ "authResource1", "authResource2" }, "ResultCount"));

            //testing update of "description" field
            cmdlet = new SetScheduledQueryRuleCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = monitorManagementClientMock.Object,
                Source = new PSScheduledQueryRuleSource(source),
                Schedule = new PSScheduledQueryRuleSchedule(schedule),
                Action = new PSScheduledQueryRuleAlertingAction(alertingAction),
                Description = "A Log Search Alert description"
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

            sqrOperationsMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<LogSearchRuleResource>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse<LogSearchRuleResource>>(response))
                .Callback((string resourceGrp, string name, LogSearchRuleResource updateParams, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    this.resourceGroup = resourceGrp;
                    this.ruleName = name;
                    this.updatePrms = updateParams;
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

        public void SetScheduledQueryRuleCommandParametersProcessing()
        {
            //testing update of description field
            
            cmdlet.Name = "LogSearchAlertName";
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.Location = Location;

            cmdlet.Description = "Updated Log Search Alert description";
            cmdlet.ExecuteCmdlet();

            Assert.Equal("LogSearchAlertName", this.ruleName);
            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);

            Assert.NotNull(this.updatePrms);

            Assert.Equal("Updated Log Search Alert description", this.updatePrms.Description);

            Assert.Null(this.updatePrms.Id);
            Assert.Equal(Location, this.updatePrms.Location);

            Assert.NotNull(this.updatePrms.Action);
            Assert.NotNull(this.updatePrms.Schedule);
            Assert.Equal(5, this.updatePrms.Schedule.FrequencyInMinutes);
            Assert.Equal(5, this.updatePrms.Schedule.TimeWindowInMinutes);

            Assert.NotNull(this.updatePrms.Source);
            Assert.Equal("union *", this.updatePrms.Source.Query);
            Assert.Equal("dataSourceId", this.updatePrms.Source.DataSourceId);
            Assert.Equal(new string[]{ "authResource1", "authResource2" }, this.updatePrms.Source.AuthorizedResources);
            Assert.Equal("ResultCount", this.updatePrms.Source.QueryType);
        }
    }
}
