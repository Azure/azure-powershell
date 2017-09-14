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
using Microsoft.Azure.Commands.Insights.ActionGroups;

namespace Microsoft.Azure.Commands.Insights.Test.ActionGroups
{
    using Microsoft.Azure.Commands.Insights.OutputClasses;

    public class AddAzureRmActionGroupTests
    {
        private const string Location = "Global";

        private const string ResourceId =
            "/subscriptions/7de05d20-f39f-44d8-83ca-e7d2f12118b0/resourceGroups/testResourceGroup/providers/microsoft.insights/actionGroups/ActionGroupName";

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
            insightsManagementClientMock = new Mock<MonitorManagementClient>();
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
                new PSEmailReceiver(ActionGroupsUtilities.CreateEmailReceiver(
                    name: "email",
                    emailAddress: "foo@email.com")),
                new PSSmsReceiver(ActionGroupsUtilities.CreateSmsReceiver(
                    name: "sms",
                    phoneNumber: "4254251234")),
                new PSWebhookReceiver(ActionGroupsUtilities.CreateWebhookReceiver(
                    name: "webhook",
                    serviceUri: "http://test.com")),
            };
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal("ActionGroupName", this.name);
            Assert.Null(this.createOrUpdatePrms.Id);
            Assert.Equal(Location, this.createOrUpdatePrms.Location);
            Assert.Equal("AgShortName", this.createOrUpdatePrms.GroupShortName);

            Assert.Equal(1, this.createOrUpdatePrms.EmailReceivers.Count);
            Assert.Equal(this.createOrUpdatePrms.EmailReceivers[0].Name, "email");
            Assert.Equal(this.createOrUpdatePrms.EmailReceivers[0].EmailAddress, "foo@email.com");

            Assert.Equal(1, this.createOrUpdatePrms.SmsReceivers.Count);
            Assert.Equal(this.createOrUpdatePrms.SmsReceivers[0].Name, "sms");
            Assert.Equal(this.createOrUpdatePrms.SmsReceivers[0].CountryCode, "1");
            Assert.Equal(this.createOrUpdatePrms.SmsReceivers[0].PhoneNumber, "4254251234");

            Assert.Equal(1, this.createOrUpdatePrms.WebhookReceivers.Count);
            Assert.Equal(this.createOrUpdatePrms.WebhookReceivers[0].Name, "webhook");
            Assert.Equal(this.createOrUpdatePrms.WebhookReceivers[0].ServiceUri, "http://test.com");

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