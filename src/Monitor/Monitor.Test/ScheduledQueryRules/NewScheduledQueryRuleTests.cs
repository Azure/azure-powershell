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

using System.Collections;
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
    public class NewScheduledQueryRuleTests
    {
        private const string Location = "westus";
        private readonly NewScheduledQueryRuleCommand cmdlet;
        private readonly Mock<MonitorManagementClient> monitorManagementClientMock;
        private readonly Mock<IScheduledQueryRulesOperations> sqrOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse<LogSearchRuleResource> response;
        private string resourceGroup;
        private string ruleName;
        private LogSearchRuleResource createOrUpdatePrms;

        public NewScheduledQueryRuleTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            sqrOperationsMock = new Mock<IScheduledQueryRulesOperations>();
            monitorManagementClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewScheduledQueryRuleCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = monitorManagementClientMock.Object
            };

            response = new AzureOperationResponse<LogSearchRuleResource>()
            {
                Body = new LogSearchRuleResource()
            };

            sqrOperationsMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<LogSearchRuleResource>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse<LogSearchRuleResource>>(response))
                .Callback((string resourceGrp, string name, LogSearchRuleResource createOrUpdateParams, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    this.resourceGroup = resourceGrp;
                    this.ruleName = name;
                    this.createOrUpdatePrms = createOrUpdateParams;
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
        
        public void NewScheduledQueryRuleCommandParametersProcessing()
        {
            cmdlet.Name = "LogSearchAlertName";
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.Location = Location;
            cmdlet.Description = "A Log Search Alert";

            Hashtable tags = new Hashtable();
            cmdlet.Tag = tags;
            cmdlet.Enabled = true;

            ScheduledQueryRuleAznsAction aznsAction = new ScheduledQueryRuleAznsAction(new AzNsActionGroup(new string[]{"AG1", "AG2"}, "Email Subject for Log Search Alert", "custom webhook payload"));
            ScheduledQueryRuleLogMetricTrigger logMetricTrigger = new ScheduledQueryRuleLogMetricTrigger(new LogMetricTrigger("GreaterThan", 15, "Total"));
            ScheduledQueryRuleTriggerCondition triggerCondition = new ScheduledQueryRuleTriggerCondition(new TriggerCondition("GreaterThan", 15, logMetricTrigger));
            ScheduledQueryRuleAlertingAction alertingAction = new ScheduledQueryRuleAlertingAction(new AlertingAction("2", aznsAction, triggerCondition, 5));

            cmdlet.Action = new PSScheduledQueryRuleAlertingAction(alertingAction);

            ScheduledQueryRuleSchedule schedule = new ScheduledQueryRuleSchedule(new Schedule(5, 5));
            cmdlet.Schedule = new PSScheduledQueryRuleSchedule(schedule);

            ScheduledQueryRuleSource source= new ScheduledQueryRuleSource(new Source("union *", "dataSourceId", new string[]{"authResource1", "authResource2"}, "ResultCount"));
            cmdlet.Source = new PSScheduledQueryRuleSource(source);

            cmdlet.ExecuteCmdlet();

            Assert.Equal("LogSearchAlertName", this.ruleName);
            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);

            Assert.NotNull(this.createOrUpdatePrms);

            Assert.Equal("A Log Search Alert", this.createOrUpdatePrms.Description);
            Assert.Equal("true", this.createOrUpdatePrms.Enabled);
            //Assert.Equal(tags, this.createOrUpdatePrms.Tags);
            
            Assert.Null(this.createOrUpdatePrms.Id);
            Assert.Equal(Location, this.createOrUpdatePrms.Location);
            
            Assert.NotNull(this.createOrUpdatePrms.Action);

            Assert.NotNull(this.createOrUpdatePrms.Schedule);
            Assert.Equal(5, this.createOrUpdatePrms.Schedule.FrequencyInMinutes);
            Assert.Equal(5, this.createOrUpdatePrms.Schedule.TimeWindowInMinutes);

            Assert.NotNull(this.createOrUpdatePrms.Source);
            Assert.Equal("union *", this.createOrUpdatePrms.Source.Query);
            Assert.Equal("dataSourceId", this.createOrUpdatePrms.Source.DataSourceId);
            Assert.Equal(new string[]{ "authResource1", "authResource2" }, this.createOrUpdatePrms.Source.AuthorizedResources);
            Assert.Equal("ResultCount", this.createOrUpdatePrms.Source.QueryType);
        }
    }
}
