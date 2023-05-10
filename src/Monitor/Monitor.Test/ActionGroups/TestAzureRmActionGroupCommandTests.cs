// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Insights.Test.ActionGroups
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Azure.Commands.Insights.ActionGroups;
    using Microsoft.Azure.Commands.Insights.OutputClasses;
    using Microsoft.Azure.Commands.ScenarioTest;
    using Microsoft.Azure.Management.Monitor;
    using Microsoft.Azure.Management.Monitor.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    using Moq;
    using Xunit;

    public class TestAzureRmActionGroupCommandTests
    {
        private readonly TestAzureRmActionGroupCommand cmdlet;
        private readonly Mock<MonitorManagementClient> insightsManagementClientMock;
        private readonly Mock<IActionGroupsOperations> insightsOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationHeaderResponse<ActionGroupsCreateNotificationsAtActionGroupResourceLevelHeaders> postResponse;
        private AzureOperationResponse<TestNotificationDetailsResponse> getResponse;
        private TestNotificationDetailsResponse expectedGetResponseResult = ActionGroupsUtilities.CreateTestNotificationDetailsResponse();

        public TestAzureRmActionGroupCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsOperationsMock = new Mock<IActionGroupsOperations>();
            insightsManagementClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new TestAzureRmActionGroupCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };

            postResponse = new AzureOperationHeaderResponse<ActionGroupsCreateNotificationsAtActionGroupResourceLevelHeaders>()
            {
                Headers = new ActionGroupsCreateNotificationsAtActionGroupResourceLevelHeaders()
                {
                    Location = "https://test.test.com/subscriptions/5def922a-3ed4-49c1-b9fd-05ec533819a3/resourceGroups/test-RG/providers/microsoft.insights/actionGroups/test-AG/notificationStatus/11000001469037?api-version=2022-06-01"
                }
            };

            insightsOperationsMock.Setup(f => f.BeginCreateNotificationsAtActionGroupResourceLevelWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<NotificationRequestBody>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(postResponse));

            getResponse = new AzureOperationResponse<TestNotificationDetailsResponse>()
            {
                Body = expectedGetResponseResult,
            };

            insightsOperationsMock.Setup(f => f.GetTestNotificationsAtActionGroupResourceLevelWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(getResponse));

            insightsManagementClientMock.SetupGet(f => f.ActionGroups).Returns(this.insightsOperationsMock.Object);

            // Setup Confirmation
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNotificationCommandParametersProcessing()
        {
            cmdlet.ActionGroupName = "Test-AG";
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.AlertType = "servicehealth";
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

            var expectedResult = ActionGroupsUtilities.CreateTestNotificationDetailsResponse();
            var actualResponse = this.getResponse.Body;
            Assert.NotNull(this.getResponse.Body);
            Assert.Equal(actualResponse.State, expectedResult.State);
            Assert.Equal(actualResponse.Context.ContextType, expectedResult.Context.ContextType);
            Assert.Equal(actualResponse.ActionDetails.Count, expectedResult.ActionDetails.Count);
            Assert.Equal(actualResponse.ActionDetails[0].Detail, expectedResult.ActionDetails[0].Detail);
            Assert.Equal(actualResponse.ActionDetails[0].MechanismType, expectedResult.ActionDetails[0].MechanismType);
            Assert.Equal(actualResponse.ActionDetails[0].Name, expectedResult.ActionDetails[0].Name);
            Assert.Equal(actualResponse.ActionDetails[0].Status, expectedResult.ActionDetails[0].Status);
            Assert.Equal(actualResponse.ActionDetails[0].SubState, expectedResult.ActionDetails[0].SubState);
        }
    }
}