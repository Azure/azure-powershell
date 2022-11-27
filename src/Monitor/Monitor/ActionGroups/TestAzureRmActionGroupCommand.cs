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

namespace Microsoft.Azure.Commands.Insights.ActionGroups
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Management.Monitor;
    using Microsoft.Azure.Management.Monitor.Models;
    using Microsoft.Azure.Commands.Insights.OutputClasses;
    using Microsoft.Azure.Commands.Insights.TransitionalClasses;
    using Newtonsoft.Json;
    using ResourceManager.Common.ArgumentCompleters;

    /// <summary> Create new test notifications </summary>
    [Cmdlet("Test", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ActionGroup", DefaultParameterSetName = ByPropertyName, SupportsShouldProcess = true)]
    [OutputType(typeof(PSTestNotificationDetailsResponse))]
    public class TestAzureRmActionGroupCommand : ManagementCmdletBase
    {
        private const string ByPropertyName = "ByPropertyName";
        private const string CompleteState = "Complete";
        private readonly int MaxRetryCount = 30;
        private readonly int WaitDurationBetweenRetryInSeconds = 10;

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the action group name parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByPropertyName, Mandatory = true, HelpMessage = "The required alert type name")]
        [ValidateNotNullOrEmpty]
        public string AlertType { get; set; }

        /// <summary>
        /// Gets or sets the resource group parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByPropertyName, Mandatory = true, HelpMessage = "The optional resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the action group name parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByPropertyName, Mandatory = true, HelpMessage = "The optional action group name")]
        [ValidateNotNullOrEmpty]
        public string ActionGroupName { get; set; }

        /// <summary>
        /// Gets or sets the list of email receivers.
        /// </summary>
        [Parameter(ParameterSetName = ByPropertyName, Mandatory = true, HelpMessage = "The list of receivers")]
        public List<PSActionGroupReceiverBase> Receiver { get; set; }

        #endregion

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            if (string.IsNullOrWhiteSpace(AlertType))
            {
                throw new PSArgumentException("Alert type cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                throw new PSArgumentException("Resource group name cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(ActionGroupName))
            {
                throw new PSArgumentException("Action group name cannot be null or empty.");
            }

            IList<EmailReceiver> emailReceivers =
                this.Receiver.OfType<PSEmailReceiver>().
                    Select(o => new EmailReceiver(name: o.Name, emailAddress: o.EmailAddress, useCommonAlertSchema: o.UseCommonAlertSchema)).ToList();

            IList<SmsReceiver> smsReceivers =
                this.Receiver.OfType<PSSmsReceiver>().
                    Select(o => new SmsReceiver(name: o.Name, countryCode: o.CountryCode, phoneNumber: o.PhoneNumber, status: TransitionHelpers.ConvertNamespace(o.Status))).ToList();

            IList<WebhookReceiver> webhookReceivers =
                this.Receiver.OfType<PSWebhookReceiver>().
                    Select(o => new WebhookReceiver(
                                            name: o.Name,
                                            serviceUri: o.ServiceUri,
                                            useCommonAlertSchema: o.UseCommonAlertSchema,
                                            useAadAuth: o.UseAadAuth,
                                            objectId: o.ObjectId,
                                            identifierUri: o.IdentifierUri,
                                            tenantId: o.TenantId)).ToList();

            IList<ItsmReceiver> itsmReceivers =
                this.Receiver.OfType<PSItsmReceiver>().
                Select(o => new ItsmReceiver(name: o.Name, workspaceId: o.WorkspaceId, connectionId: o.ConnectionId, ticketConfiguration: o.TicketConfiguration, region: o.Region)).ToList();

            IList<VoiceReceiver> voiceReceivers =
                this.Receiver.OfType<PSVoiceReceiver>().
                    Select(o => new VoiceReceiver(name: o.Name, countryCode: o.CountryCode, phoneNumber: o.PhoneNumber)).ToList();

            IList<EventHubReceiver> eventHubReceivers =
                this.Receiver.OfType<PSEventHubReceiver>().
                    Select(o => new EventHubReceiver(name: o.Name, subscriptionId: o.SubscriptionId, eventHubNameSpace: o.EventHubNameSpace, eventHubName: o.EventHubName, useCommonAlertSchema: o.UseCommonAlertSchema)).ToList();

            IList<ArmRoleReceiver> armRoleReceivers =
                this.Receiver.OfType<PSArmRoleReceiver>().
                    Select(o => new ArmRoleReceiver(name: o.Name, roleId: o.RoleId, useCommonAlertSchema: o.UseCommonAlertSchema)).ToList();

            IList<AzureFunctionReceiver> azureFunctionReceivers =
                this.Receiver.OfType<PSAzureFunctionReceiver>().
                    Select(o => new AzureFunctionReceiver(
                                                    name: o.Name,
                                                    functionName: o.FunctionName,
                                                    functionAppResourceId: o.FunctionAppResourceId,
                                                    httpTriggerUrl: o.HttpTriggerUrl,
                                                    useCommonAlertSchema: o.UseCommonAlertSchema)).ToList();

            IList<LogicAppReceiver> logicAppReceivers =
                this.Receiver.OfType<PSLogicAppReceiver>().
                    Select(o => new LogicAppReceiver(
                                                    name: o.Name,
                                                    resourceId: o.ResourceId,
                                                    callbackUrl: o.CallbackUrl,
                                                    useCommonAlertSchema: o.UseCommonAlertSchema
                                                    )).ToList();

            IList<AutomationRunbookReceiver> automationRunbookReceivers =
                this.Receiver.OfType<PSAutomationRunbookReceiver>().
                    Select(o => new AutomationRunbookReceiver(
                                                    name: o.Name,
                                                    runbookName: o.RunbookName,
                                                    webhookResourceId: o.WebhookResourceId,
                                                    isGlobalRunbook: o.IsGlobalRunbook,
                                                    useCommonAlertSchema: o.UseCommonAlertSchema,
                                                    serviceUri: o.ServiceUri,
                                                    automationAccountId: o.AutomationAccountId
                                                    )).ToList();

            IList<AzureAppPushReceiver> azureAppPushReceivers =
              this.Receiver.OfType<PSAzureAppPushReceiver>().
                  Select(o => new AzureAppPushReceiver(
                                                  name: o.Name,
                                                  emailAddress: o.EmailAddress
                                                  )).ToList();

            NotificationRequestBody actionGroup = new NotificationRequestBody
            {
                AlertType = this.AlertType,
                EmailReceivers = emailReceivers,
                SmsReceivers = smsReceivers,
                WebhookReceivers = webhookReceivers,
                ItsmReceivers = itsmReceivers,
                VoiceReceivers = voiceReceivers,
                EventHubReceivers = eventHubReceivers,
                ArmRoleReceivers = armRoleReceivers,
                AzureFunctionReceivers = azureFunctionReceivers,
                LogicAppReceivers = logicAppReceivers,
                AutomationRunbookReceivers = automationRunbookReceivers,
                AzureAppPushReceivers = azureAppPushReceivers
            };

            var responseHeader = this.MonitorManagementClient.ActionGroups
                .BeginCreateNotificationsAtActionGroupResourceLevelAsync(
                ResourceGroupName,
                ActionGroupName,
                actionGroup).Result;

            WriteObject($"\nSending notifications for '{AlertType}' alert type to the following receivers:");
            WriteObject(actionGroup);

            if (responseHeader == null ||
                string.IsNullOrWhiteSpace(responseHeader.Location))
            {
                throw new Exception("The location header is null or empty.");
            }

            WriteObject($"\nGetting notification details for '{responseHeader.Location}'. \n\nPlease wait...\n");

            int retryCount = 0;
            bool completed = false;

            while (completed == false &&
                retryCount < MaxRetryCount)
            {
                retryCount++;

                int startIndex = responseHeader.Location.LastIndexOf("/") + 1;
                int endIndex = responseHeader.Location.LastIndexOf("?");
                string notificationId = responseHeader.Location.Substring(startIndex, endIndex - startIndex);

                TestNotificationDetailsResponse notificationDetail = null;

                try
                {
                    notificationDetail = this.MonitorManagementClient.ActionGroups.GetTestNotificationsAtActionGroupResourceLevel(
                        ResourceGroupName, ActionGroupName, notificationId);
                }
                catch (ErrorResponseException ex)
                {
                    if (ex.Response.StatusCode != System.Net.HttpStatusCode.Accepted)
                    {
                        throw;
                    }
                }

                if (notificationDetail != null &&
                    notificationDetail.State.Equals(CompleteState, StringComparison.OrdinalIgnoreCase))
                {
                    WriteObject("Notification Details:");

                    WriteObject(notificationDetail);

                    completed = true;
                }
                else
                {
                    Thread.Sleep(TimeSpan.FromSeconds(WaitDurationBetweenRetryInSeconds));
                }
            }
        }
    }
}
