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
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Commands.Insights.ActivityLogAlert;

namespace Microsoft.Azure.Commands.Insights.Test.ActivityLogAlerts
{
    public class SetAzureRmActivityLogAlertTests
    {
        private const string Location = "westus";
        private readonly SetAzureRmActivityLogAlertCommand cmdlet;
        private readonly Mock<MonitorManagementClient> insightsManagementClientMock;
        private readonly Mock<IActivityLogAlertsOperations> insightsOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse<ActivityLogAlertResource> response;
        private string resourceGroup;
        private string name;
        private ActivityLogAlertResource createOrUpdatePrms;

        public SetAzureRmActivityLogAlertTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsOperationsMock = new Mock<IActivityLogAlertsOperations>();
            insightsManagementClientMock = new Mock<MonitorManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new SetAzureRmActivityLogAlertCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };

            response = new AzureOperationResponse<ActivityLogAlertResource>()
            {
                Body = new ActivityLogAlertResource()
            };

            insightsOperationsMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ActivityLogAlertResource>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse<ActivityLogAlertResource>>(response))
                .Callback((string resourceGrp, string name, ActivityLogAlertResource createOrUpdateParams, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    this.resourceGroup = resourceGrp;
                    this.name = name;
                    this.createOrUpdatePrms = createOrUpdateParams;
                });

            insightsManagementClientMock.SetupGet(f => f.ActivityLogAlerts).Returns(this.insightsOperationsMock.Object);

            // Setup Confirmation
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetActivityLogAlertCommandParametersProcessing()
        {
            cmdlet.Name = "ActivityLogAlertName";
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.Location = Location;
            cmdlet.Scope = new List<string> { "scope1" };
            cmdlet.Action = new List<ActivityLogAlertActionGroup>
            {
                ActivityLogAlertsUtilities.CreateActionGroup(
                    id: "ActGrpId", 
                    webhooks: new Dictionary<string, string> { { "key1", "value1" } })
            };
            cmdlet.Condition = new List<ActivityLogAlertLeafCondition>
            {
                ActivityLogAlertsUtilities.CreateLeafCondition(
                    field: "field",
                    equals: "equals")
            };
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal("ActivityLogAlertName", this.name);
            Assert.Null(this.createOrUpdatePrms.Id);
            Assert.Equal(Location, this.createOrUpdatePrms.Location);
            Assert.NotNull(this.createOrUpdatePrms);
            Assert.NotNull(this.createOrUpdatePrms.Actions);
            Assert.NotNull(this.createOrUpdatePrms.Actions.ActionGroups);
            Assert.Equal(1, this.createOrUpdatePrms.Actions.ActionGroups.Count);
            Assert.Equal(this.createOrUpdatePrms.Actions.ActionGroups[0].ActionGroupId, "ActGrpId");
            Assert.NotNull(this.createOrUpdatePrms.Actions.ActionGroups[0].WebhookProperties);
            Assert.True(this.createOrUpdatePrms.Actions.ActionGroups[0].WebhookProperties.ContainsKey("key1"));

            Assert.NotNull(this.createOrUpdatePrms.Condition);
            Assert.NotNull(this.createOrUpdatePrms.Condition.AllOf);
            Assert.Equal(1, this.createOrUpdatePrms.Condition.AllOf.Count);
            Assert.Equal(this.createOrUpdatePrms.Condition.AllOf[0].Field, "field");
            Assert.Equal(this.createOrUpdatePrms.Condition.AllOf[0].Equals, "equals");

            Assert.True(this.createOrUpdatePrms.Enabled);
            Assert.Null(this.createOrUpdatePrms.Description);
            Assert.Null(this.createOrUpdatePrms.Type);
            Assert.Null(this.createOrUpdatePrms.Tags);

            cmdlet.DisableAlert = SwitchParameter.Present;
            cmdlet.Description = "description";
            cmdlet.Tag = new Dictionary<string, string>();
            cmdlet.ExecuteCmdlet();

            Assert.False(this.createOrUpdatePrms.Enabled);
            Assert.Equal("description", this.createOrUpdatePrms.Description);
            Assert.Null(this.createOrUpdatePrms.Type);
            Assert.NotNull(this.createOrUpdatePrms.Tags);
        }
    }
}
