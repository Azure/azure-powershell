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
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Commands.Insights.ActionGroups;

namespace Microsoft.Azure.Commands.Insights.Test.ActionGroups
{
    using Microsoft.Azure.Commands.Insights.OutputClasses;

    public class AddAzureRmActionGroupTests
    {
        private const string Location = "Global";

        private const string ResourceId =
            "/subscriptions/7de05d20-f39f-44d8-83ca-e7d2f12118b0/resourceGroups/testResourceGroup/providers/Microsoft.Insights/actionGroups/ActionGroupName";

        private readonly SetAzureRmActionGroupCommand cmdlet;
        private readonly Mock<MonitorManagementClient> insightsManagementClientMock;
        private readonly Mock<IActionGroupsOperations> insightsOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse<ActionGroupResource> response;
        private string resourceGroup;
        private string name;
        private ActionGroupResource createOrUpdatePrms;

        public AddAzureRmActionGroupTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsOperationsMock = new Mock<IActionGroupsOperations>();
            insightsManagementClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new SetAzureRmActionGroupCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };

            response = new AzureOperationResponse<ActionGroupResource>()
                       {
                           Body =
                               ActionGroupsUtilities.CreateActionGroupResource(
                                   name: "ActionGroupName",
                                   shortName: "AgShortName")
                       };

            insightsOperationsMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ActionGroupResource>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response))
                .Callback((string resourceGrp, string name, ActionGroupResource createOrUpdateParams, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    this.resourceGroup = resourceGrp;
                    this.name = name;
                    this.createOrUpdatePrms = createOrUpdateParams;
                });

            insightsManagementClientMock.SetupGet(f => f.ActionGroups).Returns(this.insightsOperationsMock.Object);

            // Setup Confirmation
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetActionGroupCommandParametersProcessing()
        {
            cmdlet.Name = "ActionGroupName";
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.ShortName = "AgShortName";
            cmdlet.Receiver = new List<PSActionGroupReceiverBase>
            {
                new PSEmailReceiver(
                    ActionGroupsUtilities.CreateEmailReceiver(name: "email",emailAddress:"foo@email.com")),

                 new PSEmailReceiver(
                    ActionGroupsUtilities.CreateEmailReceiver("email1", "email1@email1.com", true)),

                 new PSEmailReceiver(
                    ActionGroupsUtilities.CreateEmailReceiver("email2", "email2@email2.com", false)),

                 new PSEventHubReceiver(
                    ActionGroupsUtilities.CreateEventHubReceiver(name: "eventhub", subscriptionId:"5def922a-3ed4-49c1-b9fd-05ec533819a3", eventHubNameSpace:"eventhub1NameSpace", eventHubName:"testEventHubName")),

                 new PSEventHubReceiver(
                    ActionGroupsUtilities.CreateEventHubReceiver("eventhub1", "5def922a-3ed4-49c1-b9fd-05ec533819a3", "eventhub1NameSpace1", "testEventHubName1", true)),

                 new PSEventHubReceiver(
                    ActionGroupsUtilities.CreateEventHubReceiver("eventhub2", "5def922a-3ed4-49c1-b9fd-05ec533819a3", "eventhub1NameSpace2", "testEventHubName2", false)),

                new PSSmsReceiver(
                    ActionGroupsUtilities.CreateSmsReceiver(name: "sms", phoneNumber: "4254251234")),

                new PSWebhookReceiver(
                    ActionGroupsUtilities.CreateWebhookReceiver(name: "webhook", serviceUri: "http://test.com")),

                new PSWebhookReceiver(
                    ActionGroupsUtilities.CreateWebhookReceiver("webhook1", "http://test1.com", true)),

                new PSWebhookReceiver(
                    ActionGroupsUtilities.CreateWebhookReceiver("webhook2", "http://test2.com", true,false)),

                new PSWebhookReceiver(
                    ActionGroupsUtilities.CreateWebhookReceiver("webhook3", "http://test3.com", true,true,"someObjectId","someIdentifierId", "someTenantId")),

                new PSItsmReceiver(
                    ActionGroupsUtilities.CreateItsmReceiver("itsm", "someWorkspaceId", "someConnectionId", "sometickerConfiguration", "someRegion")),

                new PSVoiceReceiver(
                    ActionGroupsUtilities.CreateVoiceReceiver("voice", "someCountryCode", "somePhoeNumber")),

                new PSArmRoleReceiver(
                    ActionGroupsUtilities.CreateArmRoleReceiver("armRole", "someRoleId")),

                new PSArmRoleReceiver(
                    ActionGroupsUtilities.CreateArmRoleReceiver("armRole1", "someRoleId1",true)),

                new PSAzureFunctionReceiver(
                    ActionGroupsUtilities.CreateAzureFunctionReceiver("azureFunctionReceiver","somefuncappresourceId","somefunctionName","some trigeerURl")),

                new PSAzureFunctionReceiver(
                 ActionGroupsUtilities.CreateAzureFunctionReceiver("azureFunctionReceiver1","somefuncappresourceId1","somefunctionName2","some trigeerURl2",true)),

                new PSLogicAppReceiver(
                    ActionGroupsUtilities.CreateLogicAppReceiver("logicAppReceveir","someresourceId","someCallback")),

                new PSLogicAppReceiver(
                    ActionGroupsUtilities.CreateLogicAppReceiver("logicAppReceveir1","someresourceId1","someCallback1",true)),

                new PSAutomationRunbookReceiver(
                    ActionGroupsUtilities.CreateAutomationRunbookReceiver("runbookReceiver","someAutomationId","someRunbook","somewebhookresourceId",false,"someServiceUri")),

                new PSAutomationRunbookReceiver(
                    ActionGroupsUtilities.CreateAutomationRunbookReceiver("runbookReceiver1","someAutomationId1","someRunbook1","somewebhookresourceId1",true,"someServiceUri1",true)),

                new PSAzureAppPushReceiver(
                    ActionGroupsUtilities.CreateAzureAppPushReceiver("apppushreceiver","someEmailAddress"))
            };



            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal("ActionGroupName", this.name);
            Assert.Null(this.createOrUpdatePrms.Id);
            Assert.Equal(Location, this.createOrUpdatePrms.Location);
            Assert.Equal("AgShortName", this.createOrUpdatePrms.GroupShortName);

            Assert.Equal(3, this.createOrUpdatePrms.EmailReceivers.Count);

            Assert.Equal("email", this.createOrUpdatePrms.EmailReceivers[0].Name);
            Assert.Equal("foo@email.com", this.createOrUpdatePrms.EmailReceivers[0].EmailAddress);
            Assert.False(this.createOrUpdatePrms.EmailReceivers[0].UseCommonAlertSchema);

            Assert.Equal("email1", this.createOrUpdatePrms.EmailReceivers[1].Name);
            Assert.Equal("email1@email1.com", this.createOrUpdatePrms.EmailReceivers[1].EmailAddress);
            Assert.True(this.createOrUpdatePrms.EmailReceivers[1].UseCommonAlertSchema);

            Assert.Equal("email2", this.createOrUpdatePrms.EmailReceivers[2].Name);
            Assert.Equal("email2@email2.com", this.createOrUpdatePrms.EmailReceivers[2].EmailAddress);
            Assert.False(this.createOrUpdatePrms.EmailReceivers[2].UseCommonAlertSchema);

            Assert.Equal(3, this.createOrUpdatePrms.EventHubReceivers.Count);

            Assert.Equal("eventhub", this.createOrUpdatePrms.EventHubReceivers[0].Name);
            Assert.Equal("5def922a-3ed4-49c1-b9fd-05ec533819a3", this.createOrUpdatePrms.EventHubReceivers[0].SubscriptionId);
            Assert.Equal("eventhub1NameSpace", this.createOrUpdatePrms.EventHubReceivers[0].EventHubNameSpace);
            Assert.Equal("testEventHubName", this.createOrUpdatePrms.EventHubReceivers[0].EventHubName);
            Assert.False(this.createOrUpdatePrms.EventHubReceivers[0].UseCommonAlertSchema);

            Assert.Equal("eventhub1", this.createOrUpdatePrms.EventHubReceivers[1].Name);
            Assert.Equal("5def922a-3ed4-49c1-b9fd-05ec533819a3", this.createOrUpdatePrms.EventHubReceivers[1].SubscriptionId);
            Assert.Equal("eventhub1NameSpace1", this.createOrUpdatePrms.EventHubReceivers[1].EventHubNameSpace);
            Assert.Equal("testEventHubName1", this.createOrUpdatePrms.EventHubReceivers[1].EventHubName);
            Assert.True(this.createOrUpdatePrms.EventHubReceivers[1].UseCommonAlertSchema);

            Assert.Equal("eventhub2", this.createOrUpdatePrms.EventHubReceivers[2].Name);
            Assert.Equal("5def922a-3ed4-49c1-b9fd-05ec533819a3", this.createOrUpdatePrms.EventHubReceivers[2].SubscriptionId);
            Assert.Equal("eventhub1NameSpace2", this.createOrUpdatePrms.EventHubReceivers[2].EventHubNameSpace);
            Assert.Equal("testEventHubName2", this.createOrUpdatePrms.EventHubReceivers[2].EventHubName);
            Assert.False(this.createOrUpdatePrms.EventHubReceivers[2].UseCommonAlertSchema);

            Assert.Equal(1, this.createOrUpdatePrms.SmsReceivers.Count);

            Assert.Equal("sms", this.createOrUpdatePrms.SmsReceivers[0].Name);
            Assert.Equal("1", this.createOrUpdatePrms.SmsReceivers[0].CountryCode);
            Assert.Equal("4254251234", this.createOrUpdatePrms.SmsReceivers[0].PhoneNumber);

            Assert.Equal(4, this.createOrUpdatePrms.WebhookReceivers.Count);

            Assert.Equal("webhook", this.createOrUpdatePrms.WebhookReceivers[0].Name);
            Assert.Equal("http://test.com", this.createOrUpdatePrms.WebhookReceivers[0].ServiceUri);
            Assert.False(this.createOrUpdatePrms.WebhookReceivers[0].UseCommonAlertSchema);
            Assert.False(this.createOrUpdatePrms.WebhookReceivers[0].UseAadAuth);
            Assert.Equal("",this.createOrUpdatePrms.WebhookReceivers[0].ObjectId);
            Assert.Equal("", this.createOrUpdatePrms.WebhookReceivers[0].IdentifierUri);
            Assert.Equal("", this.createOrUpdatePrms.WebhookReceivers[0].TenantId);

            Assert.Equal("webhook1", this.createOrUpdatePrms.WebhookReceivers[1].Name);
            Assert.Equal("http://test1.com", this.createOrUpdatePrms.WebhookReceivers[1].ServiceUri);
            Assert.True(this.createOrUpdatePrms.WebhookReceivers[1].UseCommonAlertSchema);
            Assert.False(this.createOrUpdatePrms.WebhookReceivers[1].UseAadAuth);
            Assert.Equal("", this.createOrUpdatePrms.WebhookReceivers[1].ObjectId);
            Assert.Equal("", this.createOrUpdatePrms.WebhookReceivers[1].IdentifierUri);
            Assert.Equal("", this.createOrUpdatePrms.WebhookReceivers[1].TenantId);

            Assert.Equal("webhook2", this.createOrUpdatePrms.WebhookReceivers[2].Name);
            Assert.Equal("http://test2.com", this.createOrUpdatePrms.WebhookReceivers[2].ServiceUri);
            Assert.True(this.createOrUpdatePrms.WebhookReceivers[2].UseCommonAlertSchema);
            Assert.False(this.createOrUpdatePrms.WebhookReceivers[2].UseAadAuth);
            Assert.Equal("", this.createOrUpdatePrms.WebhookReceivers[2].ObjectId);
            Assert.Equal("", this.createOrUpdatePrms.WebhookReceivers[2].IdentifierUri);
            Assert.Equal("", this.createOrUpdatePrms.WebhookReceivers[2].TenantId);

            Assert.Equal("webhook3", this.createOrUpdatePrms.WebhookReceivers[3].Name);
            Assert.Equal("http://test3.com", this.createOrUpdatePrms.WebhookReceivers[3].ServiceUri);
            Assert.True(this.createOrUpdatePrms.WebhookReceivers[3].UseCommonAlertSchema);
            Assert.True(this.createOrUpdatePrms.WebhookReceivers[3].UseAadAuth);
            Assert.Equal("someObjectId", this.createOrUpdatePrms.WebhookReceivers[3].ObjectId);
            Assert.Equal("someIdentifierId", this.createOrUpdatePrms.WebhookReceivers[3].IdentifierUri);
            Assert.Equal("someTenantId", this.createOrUpdatePrms.WebhookReceivers[3].TenantId);

            Assert.Equal(1, this.createOrUpdatePrms.ItsmReceivers.Count);

            Assert.Equal("itsm", this.createOrUpdatePrms.ItsmReceivers[0].Name);
            Assert.Equal("someWorkspaceId", this.createOrUpdatePrms.ItsmReceivers[0].WorkspaceId);
            Assert.Equal("someConnectionId", this.createOrUpdatePrms.ItsmReceivers[0].ConnectionId);
            Assert.Equal("sometickerConfiguration", this.createOrUpdatePrms.ItsmReceivers[0].TicketConfiguration);
            Assert.Equal("someRegion", this.createOrUpdatePrms.ItsmReceivers[0].Region);

            Assert.Equal(1, this.createOrUpdatePrms.VoiceReceivers.Count);
            Assert.Equal("voice", this.createOrUpdatePrms.VoiceReceivers[0].Name);
            Assert.Equal("someCountryCode", this.createOrUpdatePrms.VoiceReceivers[0].CountryCode);
            Assert.Equal("somePhoeNumber", this.createOrUpdatePrms.VoiceReceivers[0].PhoneNumber);

            Assert.Equal(2, this.createOrUpdatePrms.ArmRoleReceivers.Count);

            Assert.Equal("armRole", this.createOrUpdatePrms.ArmRoleReceivers[0].Name);
            Assert.Equal("someRoleId", this.createOrUpdatePrms.ArmRoleReceivers[0].RoleId);
            Assert.False(this.createOrUpdatePrms.ArmRoleReceivers[0].UseCommonAlertSchema);

            Assert.Equal("armRole1", this.createOrUpdatePrms.ArmRoleReceivers[1].Name);
            Assert.Equal("someRoleId1", this.createOrUpdatePrms.ArmRoleReceivers[1].RoleId);
            Assert.True(this.createOrUpdatePrms.ArmRoleReceivers[1].UseCommonAlertSchema);

            Assert.Equal(2, this.createOrUpdatePrms.AzureFunctionReceivers.Count);

            Assert.Equal("azureFunctionReceiver", this.createOrUpdatePrms.AzureFunctionReceivers[0].Name);
            Assert.Equal("somefuncappresourceId", this.createOrUpdatePrms.AzureFunctionReceivers[0].FunctionAppResourceId);
            Assert.Equal("somefunctionName", this.createOrUpdatePrms.AzureFunctionReceivers[0].FunctionName);
            Assert.Equal("some trigeerURl", this.createOrUpdatePrms.AzureFunctionReceivers[0].HttpTriggerUrl);
            Assert.False(this.createOrUpdatePrms.AzureFunctionReceivers[0].UseCommonAlertSchema);

            Assert.Equal("azureFunctionReceiver1", this.createOrUpdatePrms.AzureFunctionReceivers[1].Name);
            Assert.Equal("somefuncappresourceId1", this.createOrUpdatePrms.AzureFunctionReceivers[1].FunctionAppResourceId);
            Assert.Equal("somefunctionName2", this.createOrUpdatePrms.AzureFunctionReceivers[1].FunctionName);
            Assert.Equal("some trigeerURl2", this.createOrUpdatePrms.AzureFunctionReceivers[1].HttpTriggerUrl);
            Assert.True(this.createOrUpdatePrms.AzureFunctionReceivers[1].UseCommonAlertSchema);

            Assert.Equal(2, this.createOrUpdatePrms.LogicAppReceivers.Count);

            Assert.Equal("logicAppReceveir", this.createOrUpdatePrms.LogicAppReceivers[0].Name);
            Assert.Equal("someresourceId", this.createOrUpdatePrms.LogicAppReceivers[0].ResourceId);
            Assert.Equal("someCallback", this.createOrUpdatePrms.LogicAppReceivers[0].CallbackUrl);
            Assert.False(this.createOrUpdatePrms.LogicAppReceivers[0].UseCommonAlertSchema);

            Assert.Equal("logicAppReceveir1", this.createOrUpdatePrms.LogicAppReceivers[1].Name);
            Assert.Equal("someresourceId1", this.createOrUpdatePrms.LogicAppReceivers[1].ResourceId);
            Assert.Equal("someCallback1", this.createOrUpdatePrms.LogicAppReceivers[1].CallbackUrl);
            Assert.True(this.createOrUpdatePrms.LogicAppReceivers[1].UseCommonAlertSchema);

            Assert.Equal(2, this.createOrUpdatePrms.AutomationRunbookReceivers.Count);

            Assert.Equal("runbookReceiver", this.createOrUpdatePrms.AutomationRunbookReceivers[0].Name);
            Assert.Equal("someAutomationId", this.createOrUpdatePrms.AutomationRunbookReceivers[0].AutomationAccountId);
            Assert.Equal("someRunbook", this.createOrUpdatePrms.AutomationRunbookReceivers[0].RunbookName);
            Assert.Equal("somewebhookresourceId", this.createOrUpdatePrms.AutomationRunbookReceivers[0].WebhookResourceId);
            Assert.Equal("someServiceUri", this.createOrUpdatePrms.AutomationRunbookReceivers[0].ServiceUri);
            Assert.False(this.createOrUpdatePrms.AutomationRunbookReceivers[0].IsGlobalRunbook);
            Assert.False(this.createOrUpdatePrms.AutomationRunbookReceivers[0].UseCommonAlertSchema);

            Assert.Equal("runbookReceiver1", this.createOrUpdatePrms.AutomationRunbookReceivers[1].Name);
            Assert.Equal("someAutomationId1", this.createOrUpdatePrms.AutomationRunbookReceivers[1].AutomationAccountId);
            Assert.Equal("someRunbook1", this.createOrUpdatePrms.AutomationRunbookReceivers[1].RunbookName);
            Assert.Equal("somewebhookresourceId1", this.createOrUpdatePrms.AutomationRunbookReceivers[1].WebhookResourceId);
            Assert.Equal("someServiceUri1", this.createOrUpdatePrms.AutomationRunbookReceivers[1].ServiceUri);
            Assert.True(this.createOrUpdatePrms.AutomationRunbookReceivers[1].IsGlobalRunbook);
            Assert.True(this.createOrUpdatePrms.AutomationRunbookReceivers[1].UseCommonAlertSchema);

            Assert.Equal(1, this.createOrUpdatePrms.AzureAppPushReceivers.Count);

            Assert.Equal("apppushreceiver", this.createOrUpdatePrms.AzureAppPushReceivers[0].Name);
            Assert.Equal("someEmailAddress", this.createOrUpdatePrms.AzureAppPushReceivers[0].EmailAddress);

            Assert.True(this.createOrUpdatePrms.Enabled);
            Assert.Null(this.createOrUpdatePrms.Type);
            Assert.Null(this.createOrUpdatePrms.Tags);

            cmdlet.DisableGroup = true;
            cmdlet.Tag = new Dictionary<string, string>();
            cmdlet.ExecuteCmdlet();

            Assert.False(this.createOrUpdatePrms.Enabled);
            Assert.Null(this.createOrUpdatePrms.Type);
            Assert.NotNull(this.createOrUpdatePrms.Tags);
        }
    }
}