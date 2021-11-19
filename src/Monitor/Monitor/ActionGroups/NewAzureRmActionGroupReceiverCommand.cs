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

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.ActionGroups
{
    /// <summary>
    /// Create an ActionGroup receiver
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ActionGroupReceiver", DefaultParameterSetName = NewEmailReceiver)]
    [OutputType(typeof(PSActionGroupReceiverBase))]
    public class NewAzureRmActionGroupReceiverCommand : AzureRMCmdlet
    {
        private const string NewEmailReceiver = "NewEmailReceiver";

        private const string NewSmsReceiver = "NewSmsReceiver";

        private const string NewWebhookReceiver = "NewWebhookReceiver";

        private const string NewItsmReceiver = "NewItsmReceiver";

        private const string NewVoiceReceiver = "NewVoiceReceiver";

        private const string NewArmRoleReceiver = "NewArmRoleReceiver";

        private const string NewAzureFunctionReceiver = "NewAzureFunctionReceiver";

        private const string NewLogicAppReceiver = "NewLogicAppReceiver";

        private const string NewAutomationRunbookReceiver = "NewAutomationRunbookReceiver";

        private const string NewAzureAppPushReceiver = "NewAzureAppPushReceiver";

        private const string NewEventHubReceiver = "NewEventHubReceiver";
        #region

        /// <summary>
        /// Gets or sets the Name parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the receiver")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the UseCommonAlertSchema parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The flag whether to use common alert schema . This value will be neglected" +
            "for SMS, Azure App push , ITSM and Voice recievers.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter UseCommonAlertSchema { get; set; }

        /// <summary>
        /// Gets or sets email receiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewEmailReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a email receiver")]
        public SwitchParameter EmailReceiver { get; set; }

        /// <summary>
        /// Gets or sets the EmailAddress parameter
        /// </summary>
        [Parameter(ParameterSetName = NewEmailReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The address of the email receiver")]
        [ValidateNotNullOrEmpty]
        public string EmailAddress { get; set; }


        /// <summary>
        /// Gets or sets event hub receiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewEventHubReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a event hub receiver")]
        public SwitchParameter EventHubReceiver { get; set; }

        /// <summary>
        /// Gets or sets the EventHubNameSpace parameter
        /// </summary>
        [Parameter(ParameterSetName = NewEventHubReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name space of the event hub receiver")]
        [ValidateNotNullOrEmpty]
        public string EventHubNameSpace { get; set; }

        /// <summary>
        /// Gets or sets the EventHubName parameter
        /// </summary>
        [Parameter(ParameterSetName = NewEventHubReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The EventHubName of the event hub receiver")]
        [ValidateNotNullOrEmpty]
        public string EventHubName { get; set; }

        /// <summary>
        /// Gets or sets the SubscriptionId parameter
        /// </summary>
        [Parameter(ParameterSetName = NewEventHubReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The subscription id of the event hub receiver")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets sms receiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewSmsReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a sms receiver")]
        public SwitchParameter SmsReceiver { get; set; }

        /// <summary>
        /// Gets or sets the SmsCountryCode parameter
        /// </summary>
        [Parameter(ParameterSetName = NewSmsReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The country code of the sms receiver")]
        [ValidateNotNullOrEmpty]
        public string CountryCode { get; set; } = "1";

        /// <summary>
        /// Gets or sets the CountryCode parameter
        /// </summary>
        [Parameter(ParameterSetName = NewSmsReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The phone number of the sms receiver")]
        [ValidateNotNullOrEmpty]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets webhook receiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewWebhookReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a webhook receiver")]
        public SwitchParameter WebhookReceiver { get; set; }

        /// <summary>
        /// Gets or sets the ServiceUri parameter
        /// </summary>
        [Parameter(ParameterSetName = NewWebhookReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The address of the webhook receiver")]
        [ValidateNotNullOrEmpty]
        public string ServiceUri { get; set; }

        /// <summary>
        /// Gets or sets the UseAadAuth SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewWebhookReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "the flag to use add auth")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter UseAadAuth { get; set; }

        /// <summary>
        /// Gets or sets the ObjectId parameter
        /// </summary>
        [Parameter(ParameterSetName = NewWebhookReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "the webhook app object Id for aad auth")]
        [ValidateNotNull]
        public string ObjectId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the IdentifierUri parameter
        /// </summary>
        [Parameter(ParameterSetName = NewWebhookReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "the Identifier uri for aad auth")]
        [ValidateNotNull]
        public string IdentifierUri { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the TenantId parameter
        /// </summary>
        [Parameter(ParameterSetName = NewWebhookReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "the tenant id for aad auth")]
        [ValidateNotNull]
        public string TenantId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets ItsmReceiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewItsmReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a ItsmReceiver")]
        public SwitchParameter ItsmReceiver { get; set; }

        /// <summary>
        /// Gets or sets the WorkspaceId parameter
        /// </summary>
        [Parameter(ParameterSetName = NewItsmReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "the itsm workspace id of this receiver")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceId { get; set; }

        /// <summary>
        /// Gets or sets the ConnectionId parameter
        /// </summary>
        [Parameter(ParameterSetName = NewItsmReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "the itsm connection id of this receiver")]
        [ValidateNotNullOrEmpty]
        public string ConnectionId { get; set; }

        /// <summary>
        /// Gets or sets the TicketConfiguration parameter
        /// </summary>
        [Parameter(ParameterSetName = NewItsmReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "the itsm TicketConfiguration of this receiver")]
        [ValidateNotNullOrEmpty]
        public string TicketConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the Region parameter
        /// </summary>
        [Parameter(ParameterSetName = NewItsmReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "the itsm Region of this receiver")]
        [ValidateNotNullOrEmpty]
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets VoiceReceiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewVoiceReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a voice receiver")]
        public SwitchParameter VoiceReceiver { get; set; }

        /// <summary>
        /// Gets or sets the VoiceCountryCode parameter
        /// </summary>
        [Parameter(ParameterSetName = NewVoiceReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The country code of the voice receiver")]
        [ValidateNotNullOrEmpty]
        public string VoiceCountryCode { get; set; } = "1";

        /// <summary>
        /// Gets or sets the VoicePhoneNumber parameter
        /// </summary>
        [Parameter(ParameterSetName = NewVoiceReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The phone number of the voice receiver")]
        [ValidateNotNullOrEmpty]
        public string VoicePhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets ArmRoleReceiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewArmRoleReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a ArmRoleReceiver")]
        public SwitchParameter ArmRoleReceiver { get; set; }

        /// <summary>
        /// Gets or sets the RoleId parameter
        /// </summary>
        [Parameter(ParameterSetName = NewArmRoleReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The arm role id of the receiver")]
        [ValidateNotNullOrEmpty]
        public string RoleId { get; set; }

        /// <summary>
        /// Gets or sets AzureFunctionReceiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewAzureFunctionReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a ArmRoleReceiver")]
        public SwitchParameter AzureFunctionReceiver { get; set; }

        /// <summary>
        /// Gets or sets the FunctionAppResourceId parameter
        /// </summary>
        [Parameter(ParameterSetName = NewAzureFunctionReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "the function app resourceId")]
        [ValidateNotNullOrEmpty]
        public string FunctionAppResourceId { get; set; }

        /// <summary>
        /// Gets or sets the HttpTriggerUrl parameter
        /// </summary>
        [Parameter(ParameterSetName = NewAzureFunctionReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "the httpTriggerUrl")]
        [ValidateNotNullOrEmpty]
        public string HttpTriggerUrl { get; set; }

        /// <summary>
        /// Gets or sets the FunctionName parameter
        /// </summary>
        [Parameter(ParameterSetName = NewAzureFunctionReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "the functionName")]
        [ValidateNotNullOrEmpty]
        public string FunctionName { get; set; }

        /// <summary>
        /// Gets or sets LogicAppReceiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewLogicAppReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a LogicAppReceiver")]
        public SwitchParameter LogicAppReceiver { get; set; }

        /// <summary>
        /// Gets or sets the ResourceId parameter
        /// </summary>
        [Parameter(ParameterSetName = NewLogicAppReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "the ResourceId")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the CallbackUrl parameter
        /// </summary>
        [Parameter(ParameterSetName = NewLogicAppReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "the CallbackUrl")]
        [ValidateNotNullOrEmpty]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Gets or sets AutomationRunbookReceiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewAutomationRunbookReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a AutomationRunbookReceiver")]
        public SwitchParameter AutomationRunbookReceiver { get; set; }

        /// <summary>
        /// Gets or sets the AutomationAccountId parameter
        /// </summary>
        [Parameter(ParameterSetName = NewAutomationRunbookReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "the AutomationAccountId")]
        [ValidateNotNullOrEmpty]
        public string AutomationAccountId { get; set; }

        /// <summary>
        /// Gets or sets the RunbookName parameter
        /// </summary>
        [Parameter(ParameterSetName = NewAutomationRunbookReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "the RunbookName")]
        [ValidateNotNullOrEmpty]
        public string RunbookName { get; set; }

        /// <summary>
        /// Gets or sets the IsGlobalRunbook parameter
        /// </summary>
        [Parameter(ParameterSetName = NewAutomationRunbookReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = " indicating whether this instance is global runbook")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IsGlobalRunbook { get; set; }

        /// <summary>
        /// Gets or sets the IsGlobalRunbook parameter
        /// </summary>
        [Parameter(ParameterSetName = NewAutomationRunbookReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = " the URI where webhooks should be sent")]
        [ValidateNotNullOrEmpty]
        public string AutomationRunbookServiceUri { get; set; }

        /// <summary>
        /// Gets or sets the WebhookResourceId parameter
        /// </summary>
        [Parameter(ParameterSetName = NewAutomationRunbookReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = " the WebhookResourceId")]
        [ValidateNotNullOrEmpty]
        public string WebhookResourceId { get; set; }

        /// <summary>
        /// Gets or sets AzureAppPushReceiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewAzureAppPushReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a AzureAppPushReceiver")]
        public SwitchParameter AzureAppPushReceiver { get; set; }

        /// <summary>
        /// Gets or sets the AzureAppPushEmailAddress parameter
        /// </summary>
        [Parameter(ParameterSetName = NewAzureAppPushReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = " the AzureAppPushEmailAddress")]
        [ValidateNotNullOrEmpty]
        public string AzureAppPushEmailAddress { get; set; }

        #endregion

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            PSActionGroupReceiverBase receiverBase = null;

            if (this.ParameterSetName == NewEmailReceiver)
            {
                receiverBase = new PSEmailReceiver { Name = Name, EmailAddress = EmailAddress , UseCommonAlertSchema = UseCommonAlertSchema};
            }
            else if (this.ParameterSetName == NewSmsReceiver)
            {
                receiverBase = new PSSmsReceiver { Name = Name, CountryCode = CountryCode, PhoneNumber = PhoneNumber };
            }
            else if (this.ParameterSetName == NewWebhookReceiver)
            {
                receiverBase = 
                    new PSWebhookReceiver
                    {
                        Name = Name,
                        ServiceUri = ServiceUri ,
                        UseCommonAlertSchema = UseCommonAlertSchema,
                        UseAadAuth = UseAadAuth,
                        ObjectId = ObjectId,
                        IdentifierUri = IdentifierUri,
                        TenantId = TenantId
                    };
            }
            else if(this.ParameterSetName == NewEventHubReceiver)
            {
                receiverBase = new PSEventHubReceiver
                {
                    Name = Name,
                    SubscriptionId = SubscriptionId,
                    EventHubNameSpace = EventHubNameSpace,
                    EventHubName = EventHubName,
                    UseCommonAlertSchema = UseCommonAlertSchema
                };
            }
            else if(this.ParameterSetName == NewItsmReceiver)
            {
                receiverBase = new PSItsmReceiver
                {
                    Name = Name,
                    WorkspaceId = WorkspaceId,
                    ConnectionId = ConnectionId,
                    TicketConfiguration = TicketConfiguration,
                    Region = Region
                };
            }
            else if (this.ParameterSetName == NewVoiceReceiver)
            {
                receiverBase = new PSVoiceReceiver
                {
                    Name = Name,
                    CountryCode = VoiceCountryCode,
                    PhoneNumber = VoicePhoneNumber
                };
            }
            else if (this.ParameterSetName == NewArmRoleReceiver)
            {
                receiverBase = new PSArmRoleReceiver
                {
                    Name = Name,
                    RoleId = RoleId,
                    UseCommonAlertSchema = UseCommonAlertSchema
                };
            }
            else if (this.ParameterSetName == NewAzureFunctionReceiver)
            {
                receiverBase = new PSAzureFunctionReceiver
                {
                    Name = Name,
                    FunctionAppResourceId = FunctionAppResourceId,
                    FunctionName = FunctionName,
                    HttpTriggerUrl = HttpTriggerUrl,
                    UseCommonAlertSchema = UseCommonAlertSchema
                };
            }
            else if (this.ParameterSetName == NewLogicAppReceiver)
            {
                receiverBase = new PSLogicAppReceiver
                {
                    Name = Name,
                    ResourceId = ResourceId,
                    CallbackUrl = CallbackUrl,
                    UseCommonAlertSchema = UseCommonAlertSchema
                };
            }
            else if (this.ParameterSetName == NewAutomationRunbookReceiver)
            {
                receiverBase = new PSAutomationRunbookReceiver
                {
                    Name = Name,
                    AutomationAccountId = AutomationAccountId,
                    RunbookName = RunbookName,
                    WebhookResourceId = WebhookResourceId,
                    IsGlobalRunbook = IsGlobalRunbook,
                    UseCommonAlertSchema = UseCommonAlertSchema,
                    ServiceUri = AutomationRunbookServiceUri
                };
            }
            else if (this.ParameterSetName == NewAzureAppPushReceiver)
            {
                receiverBase = new PSAzureAppPushReceiver
                {
                    Name = Name,
                    EmailAddress = AzureAppPushEmailAddress
                };
            }

            WriteObject(receiverBase);
        }
    }
}
