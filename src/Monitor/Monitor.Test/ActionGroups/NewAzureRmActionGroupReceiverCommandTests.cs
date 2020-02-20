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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using Xunit;
using Microsoft.Azure.Commands.Insights.ActionGroups;

namespace Microsoft.Azure.Commands.Insights.Test.ActionGroups
{
    using System;

    using Microsoft.Azure.Commands.Insights.OutputClasses;
    using Microsoft.Azure.Management.Monitor.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    public class NewAzureRmActionGroupReceiverTests
    {
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewAzureRmActionGroupReceiverCommand Cmdlet { get; set; }

        public NewAzureRmActionGroupReceiverTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            commandRuntimeMock = new Mock<ICommandRuntime>();
            Cmdlet = new NewAzureRmActionGroupReceiverCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandEmailParametersProcessing()
        {
            Cmdlet.SetParameterSet("NewEmailReceiver");
            Cmdlet.EmailReceiver = true;
            Cmdlet.Name = "email1";
            Cmdlet.EmailAddress = "foo@email.com";
            Cmdlet.ExecuteCmdlet();

            Func<PSEmailReceiver, bool> verify = r =>
            {
                Assert.Equal("foo@email.com", r.EmailAddress);
                Assert.Equal("email1", r.Name);
                // when not explicitly set . value will be false by default
                Assert.False(r.UseCommonAlertSchema);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSEmailReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandEmailParametersWithExplicitUseCommandAlertSchemaParameterProcessing()
        {
            Cmdlet.SetParameterSet("NewEmailReceiver");
            Cmdlet.EmailReceiver = true;
            Cmdlet.Name = "email1";
            Cmdlet.EmailAddress = "foo@email.com";
            Cmdlet.UseCommonAlertSchema = true;
            Cmdlet.ExecuteCmdlet();

            Func<PSEmailReceiver, bool> verify = r =>
            {
                Assert.Equal("foo@email.com", r.EmailAddress);
                Assert.Equal("email1", r.Name);
                Assert.True(r.UseCommonAlertSchema);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSEmailReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandSmsParametersProcessing()
        {
            Cmdlet.SetParameterSet("NewSmsReceiver");
            Cmdlet.SmsReceiver = true;
            Cmdlet.Name = "sms1";
            Cmdlet.CountryCode = "1";
            Cmdlet.PhoneNumber = "4254251234";
            Cmdlet.ExecuteCmdlet();

            Func<PSSmsReceiver, bool> verify = r =>
            {
                Assert.Equal("1", r.CountryCode);
                Assert.Equal("4254251234", r.PhoneNumber);
                Assert.Equal("sms1", r.Name);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSSmsReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandWebhookParametersProcessing()
        {
            Cmdlet.SetParameterSet("NewWebhookReceiver");
            Cmdlet.WebhookReceiver = true;
            Cmdlet.Name = "webhook1";
            Cmdlet.ServiceUri = "http://test.com";
            Cmdlet.ExecuteCmdlet();

            Func<PSWebhookReceiver, bool> verify = r =>
            {
                Assert.Equal("http://test.com", r.ServiceUri);
                Assert.Equal("webhook1", r.Name);
                Assert.False(r.UseCommonAlertSchema); // when not set , it is false by default
                Assert.False(r.UseAadAuth); // when not set, it is false by default
                Assert.Equal(string.Empty, r.ObjectId);
                Assert.Equal(string.Empty, r.IdentifierUri);
                Assert.Equal(string.Empty, r.TenantId);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSWebhookReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandWebhookParametersProcessingWithExplicitUseCommonAlertSchema()
        {
            Cmdlet.SetParameterSet("NewWebhookReceiver");
            Cmdlet.WebhookReceiver = true;
            Cmdlet.Name = "webhook1";
            Cmdlet.ServiceUri = "http://test.com";
            Cmdlet.UseCommonAlertSchema = true;
            Cmdlet.ExecuteCmdlet();

            Func<PSWebhookReceiver, bool> verify = r =>
            {
                Assert.Equal("http://test.com", r.ServiceUri);
                Assert.Equal("webhook1", r.Name);
                Assert.True(r.UseCommonAlertSchema);
                Assert.False(r.UseAadAuth); // when not set, it is false by default
                Assert.Equal(string.Empty, r.ObjectId);
                Assert.Equal(string.Empty, r.IdentifierUri);
                Assert.Equal(string.Empty, r.TenantId);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSWebhookReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandWebhookParametersProcessingWithAadAuth()
        {
            Cmdlet.SetParameterSet("NewWebhookReceiver");
            Cmdlet.WebhookReceiver = true;
            Cmdlet.Name = "webhook1";
            Cmdlet.ServiceUri = "http://test.com";
            Cmdlet.UseCommonAlertSchema = true;
            Cmdlet.UseAadAuth = true;
            Cmdlet.ObjectId = "someObjectId";
            Cmdlet.TenantId = "someTenantId";
            Cmdlet.IdentifierUri = "someIdentifierUri";

            Cmdlet.ExecuteCmdlet();

            Func<PSWebhookReceiver, bool> verify = r =>
            {
                Assert.Equal("http://test.com", r.ServiceUri);
                Assert.Equal("webhook1", r.Name);
                Assert.True(r.UseCommonAlertSchema);
                Assert.True(r.UseAadAuth); // when not set, it is false by default
                Assert.Equal("someObjectId", r.ObjectId);
                Assert.Equal("someIdentifierUri", r.IdentifierUri);
                Assert.Equal("someTenantId", r.TenantId);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSWebhookReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandItsmParametersProcessing()
        {
            Cmdlet.SetParameterSet("NewItsmReceiver");
            Cmdlet.ItsmReceiver = true;
            Cmdlet.Name = "itsm1";
            Cmdlet.WorkspaceId = "someworkSpaceid";
            Cmdlet.ConnectionId = "someConnectionId";
            Cmdlet.TicketConfiguration = "someTicketConfiguration";
            Cmdlet.Region = "someRegion";

            Cmdlet.ExecuteCmdlet();


            Func<PSItsmReceiver, bool> verify = r =>
            {
                Assert.Equal("itsm1", r.Name);
                Assert.Equal("someworkSpaceid", r.WorkspaceId);
                Assert.Equal("someConnectionId", r.ConnectionId);
                Assert.Equal("someTicketConfiguration", r.TicketConfiguration);
                Assert.Equal("someRegion", r.Region);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSItsmReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandVoiceParametersProcessing()
        {
            Cmdlet.SetParameterSet("NewVoiceReceiver");
            Cmdlet.VoiceReceiver = true;
            Cmdlet.Name = "voice";
            Cmdlet.VoicePhoneNumber = "somePhoneNumber";
            Cmdlet.VoiceCountryCode = "someCountryCode";

            Cmdlet.ExecuteCmdlet();


            Func<PSVoiceReceiver, bool> verify = r =>
            {
                Assert.Equal("voice", r.Name);
                Assert.Equal("somePhoneNumber", r.PhoneNumber);
                Assert.Equal("someCountryCode", r.CountryCode);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSVoiceReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandArmRoleParametersProcessing()
        {
            Cmdlet.SetParameterSet("NewArmRoleReceiver");
            Cmdlet.ArmRoleReceiver = true;
            Cmdlet.Name = "armRole";
            Cmdlet.RoleId = "someRoleId";
           
            Cmdlet.ExecuteCmdlet();


            Func<PSArmRoleReceiver, bool> verify = r =>
            {
                Assert.Equal("armRole", r.Name);
                Assert.Equal("someRoleId", r.RoleId);
                Assert.False(r.UseCommonAlertSchema); // by default when not set, it is false
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSArmRoleReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandArmRoleParametersProcessingWithExplicitUseCommonAlertSchema()
        {
            Cmdlet.SetParameterSet("NewArmRoleReceiver");
            Cmdlet.ArmRoleReceiver = true;
            Cmdlet.Name = "armRole";
            Cmdlet.RoleId = "someRoleId";
            Cmdlet.UseCommonAlertSchema = true;

            Cmdlet.ExecuteCmdlet();


            Func<PSArmRoleReceiver, bool> verify = r =>
            {
                Assert.Equal("armRole", r.Name);
                Assert.Equal("someRoleId", r.RoleId);
                Assert.True(r.UseCommonAlertSchema); 
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSArmRoleReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandAzureFunctionParametersProcessing()
        {
            Cmdlet.SetParameterSet("NewAzureFunctionReceiver");
            Cmdlet.AzureFunctionReceiver = true;
            Cmdlet.Name = "azurefunctions";
            Cmdlet.FunctionAppResourceId = "someFunctionAppResourceId";
            Cmdlet.FunctionName = "someFunctionName";
            Cmdlet.HttpTriggerUrl = "someHttpTriggerURi";

            Cmdlet.ExecuteCmdlet();


            Func<PSAzureFunctionReceiver, bool> verify = r =>
            {
                Assert.Equal("azurefunctions", r.Name);
                Assert.Equal("someFunctionAppResourceId", r.FunctionAppResourceId);
                Assert.Equal("someFunctionName", r.FunctionName);
                Assert.Equal("someHttpTriggerURi", r.HttpTriggerUrl);
                Assert.False(r.UseCommonAlertSchema);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSAzureFunctionReceiver>(r => verify(r))), Times.Once);
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandAzureFunctionParametersProcessingWithExplicitUseCommonAlertSchema()
        {
            Cmdlet.SetParameterSet("NewAzureFunctionReceiver");
            Cmdlet.AzureFunctionReceiver = true;
            Cmdlet.Name = "azurefunctions";
            Cmdlet.FunctionAppResourceId = "someFunctionAppResourceId";
            Cmdlet.FunctionName = "someFunctionName";
            Cmdlet.UseCommonAlertSchema = true;
            Cmdlet.HttpTriggerUrl = "someHttpTriggerURi";

            Cmdlet.ExecuteCmdlet();


            Func<PSAzureFunctionReceiver, bool> verify = r =>
            {
                Assert.Equal("azurefunctions", r.Name);
                Assert.Equal("someFunctionAppResourceId", r.FunctionAppResourceId);
                Assert.Equal("someFunctionName", r.FunctionName);
                Assert.Equal("someHttpTriggerURi", r.HttpTriggerUrl);
                Assert.True(r.UseCommonAlertSchema);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSAzureFunctionReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandLogicAppParametersProcessing()
        {
            Cmdlet.SetParameterSet("NewLogicAppReceiver");
            Cmdlet.ArmRoleReceiver = true;
            Cmdlet.Name = "logicapp";
            Cmdlet.ResourceId = "someResourceId";
            Cmdlet.CallbackUrl = "someCallbackUrl";

            Cmdlet.ExecuteCmdlet();


            Func<PSLogicAppReceiver, bool> verify = r =>
            {
                Assert.Equal("logicapp", r.Name);
                Assert.Equal("someResourceId", r.ResourceId);
                Assert.Equal("someCallbackUrl", r.CallbackUrl);
                Assert.False(r.UseCommonAlertSchema);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSLogicAppReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandLogicAppParametersProcessingWithExplicitUseCommonAlertSchema()
        {
            Cmdlet.SetParameterSet("NewLogicAppReceiver");
            Cmdlet.ArmRoleReceiver = true;
            Cmdlet.Name = "logicapp";
            Cmdlet.ResourceId = "someResourceId";
            Cmdlet.CallbackUrl = "someCallbackUrl";
            Cmdlet.UseCommonAlertSchema = true;

            Cmdlet.ExecuteCmdlet();


            Func<PSLogicAppReceiver, bool> verify = r =>
            {
                Assert.Equal("logicapp", r.Name);
                Assert.Equal("someResourceId", r.ResourceId);
                Assert.Equal("someCallbackUrl", r.CallbackUrl);
                Assert.True(r.UseCommonAlertSchema);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSLogicAppReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandAutomationRunBookParameters()
        {
            Cmdlet.SetParameterSet("NewAutomationRunbookReceiver");
            Cmdlet.AutomationRunbookReceiver = true;
            Cmdlet.Name = "runbook";
            Cmdlet.AutomationAccountId = "someaccountId";
            Cmdlet.RunbookName = "someRunbookName";
            Cmdlet.WebhookResourceId = "somewWebhookResourceId";
            Cmdlet.IsGlobalRunbook = true;
            Cmdlet.AutomationRunbookServiceUri = "someServiceURi";

            Cmdlet.ExecuteCmdlet();

            Func<PSAutomationRunbookReceiver, bool> verify = r =>
            {
                Assert.Equal("runbook", r.Name);
                Assert.Equal("someaccountId", r.AutomationAccountId);
                Assert.Equal("someRunbookName", r.RunbookName);
                Assert.Equal("somewWebhookResourceId", r.WebhookResourceId);
                Assert.Equal("someServiceURi", r.ServiceUri);
                Assert.True(r.IsGlobalRunbook);
                Assert.False(r.UseCommonAlertSchema);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSAutomationRunbookReceiver>(r => verify(r))), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandAutomationRunBookParametersProcessingWithExplicitUseCommonAlertSchema()
        {
            Cmdlet.SetParameterSet("NewAutomationRunbookReceiver");
            Cmdlet.AutomationRunbookReceiver = true;
            Cmdlet.Name = "runbook";
            Cmdlet.AutomationAccountId = "someaccountId";
            Cmdlet.RunbookName = "someRunbookName";
            Cmdlet.WebhookResourceId = "somewWebhookResourceId";
            Cmdlet.IsGlobalRunbook = true;
            Cmdlet.AutomationRunbookServiceUri = "someServiceURi";
            Cmdlet.UseCommonAlertSchema = true;

            Cmdlet.ExecuteCmdlet();

            Func<PSAutomationRunbookReceiver, bool> verify = r =>
            {
                Assert.Equal("runbook", r.Name);
                Assert.Equal("someaccountId", r.AutomationAccountId);
                Assert.Equal("someRunbookName", r.RunbookName);
                Assert.Equal("somewWebhookResourceId", r.WebhookResourceId);
                Assert.Equal("someServiceURi", r.ServiceUri);
                Assert.True(r.IsGlobalRunbook);
                Assert.True(r.UseCommonAlertSchema);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSAutomationRunbookReceiver>(r => verify(r))), Times.Once);
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandAzureAppPushParameters()
        {
            Cmdlet.SetParameterSet("NewAzureAppPushReceiver");
            Cmdlet.Name = "apppush";
            Cmdlet.AzureAppPushReceiver = true;
            Cmdlet.AzureAppPushEmailAddress = "someEmailAddress";

            Cmdlet.ExecuteCmdlet();

            Func<PSAzureAppPushReceiver, bool> verify = r =>
            {
                Assert.Equal("apppush", r.Name);
                Assert.Equal("someEmailAddress", r.EmailAddress);
                return true;
            };

            this.commandRuntimeMock.Verify(o => o.WriteObject(It.Is<PSAzureAppPushReceiver>(r => verify(r))), Times.Once);
        }
    }
}