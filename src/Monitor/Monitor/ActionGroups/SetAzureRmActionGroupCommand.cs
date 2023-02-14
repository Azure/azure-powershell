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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.ActionGroups
{
    using System.Linq;

    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Monitor;
    using ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.Insights.TransitionalClasses;

    /// <summary>
    /// Gets an Azure Action Group.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ActionGroup", DefaultParameterSetName = ByPropertyName, SupportsShouldProcess = true)]
    [OutputType(typeof(PSActionGroupResource))]
    public class SetAzureRmActionGroupCommand : ManagementCmdletBase
    {
        private const string ByPropertyName = "ByPropertyName";

        private const string ByResourceId = "ByResourceId";

        private const string ByInputObject = "ByInputObject";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the resource group parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByPropertyName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the action group name parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByPropertyName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The action group name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the action group short name parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByPropertyName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The action group short name")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The action group short name")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, HelpMessage = "The action group short name")]
        [ValidateNotNullOrEmpty]
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the list of email receivers.
        /// </summary>
        [Parameter(ParameterSetName = ByPropertyName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of receivers")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of receivers")]
        public List<PSActionGroupReceiverBase> Receiver { get; set; }

        /// <summary>
        /// Gets or sets the DisableGroup flag.
        /// </summary>
        [Parameter(ParameterSetName = ByPropertyName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Whether or not the action group should be enabled")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Whether or not the action group should be enabled")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, HelpMessage = "Whether or not the action group should be enabled")]
        public SwitchParameter DisableGroup { get; set; }

        /// <summary>
        /// Gets or sets the Tags of the action group resource
        /// </summary>
        [Parameter(ParameterSetName = ByPropertyName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The tags of the action group resource")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The tags of the action group resource")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = "The tags of the action group resource")]
        [ValidateNotNullOrEmpty]
        public IDictionary<string, string> Tag { get; set; }

        /// <summary>
        /// Gets or sets the location of the action group resource
        /// </summary>
        [Parameter(ParameterSetName = ByPropertyName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The location of the action group resource")]
        [Parameter(ParameterSetName = ByResourceId, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The location of the action group resource")]
        [Parameter(ParameterSetName = ByInputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = "The location of the action group resource")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the resource id parameter.
        /// </summary>
        [Parameter(ParameterSetName = ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The action group resource")]
        public PSActionGroupResource InputObject { get; set; }

        #endregion

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            if (
                ShouldProcess(
                    target: string.Format("Add/update action group: {0} from resource group: {1}", this.Name, this.ResourceGroupName),
                    action: "Add/update action group"))
            {
                if (ParameterSetName == ByInputObject)
                {
                    this.ResourceGroupName = this.InputObject.ResourceGroupName;
                    if (this.Name == null)
                    {
                        this.Name = this.InputObject.Name;
                    }
                    if (this.ShortName == null)
                    {
                        this.ShortName = this.InputObject.GroupShortName;
                    }
                    if (!this.DisableGroup.IsPresent)
                    {
                        this.DisableGroup = !this.InputObject.Enabled;
                    }
                    if (this.Tag == null)
                    {
                        this.Tag = this.InputObject.Tags;
                    }
                    if (this.Location == null)
                    {
                        this.Location = this.InputObject.Location;
                    }
                    this.Receiver = new List<PSActionGroupReceiverBase>();
                    this.Receiver.AddRange(this.InputObject.EmailReceivers);
                    this.Receiver.AddRange(this.InputObject.SmsReceivers);
                    this.Receiver.AddRange(this.InputObject.WebhookReceivers);
                    this.Receiver.AddRange(this.InputObject.ItsmReceivers);
                    this.Receiver.AddRange(this.InputObject.VoiceReceivers);
                    this.Receiver.AddRange(this.InputObject.ArmRoleReceivers);
                    this.Receiver.AddRange(this.InputObject.AzureFunctionReceivers);
                    this.Receiver.AddRange(this.InputObject.LogicAppReceivers);
                    this.Receiver.AddRange(this.InputObject.AutomationRunbookReceivers);
                    this.Receiver.AddRange(this.InputObject.AzureAppPushReceivers);
                    this.Receiver.AddRange(this.InputObject.EventHubReceivers);
                }
                else if (ParameterSetName == ByResourceId)
                {
                    ResourceIdentifier resourceId = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = resourceId.ResourceGroupName;
                    this.Name = resourceId.ResourceName;
                }

                IList<EmailReceiver> emailReceivers =
                    this.Receiver.OfType<PSEmailReceiver>().
                        Select(o => new EmailReceiver(name: o.Name, emailAddress: o.EmailAddress, status: TransitionHelpers.ConvertNamespace(o.Status),useCommonAlertSchema : o.UseCommonAlertSchema)).ToList();

                IList<SmsReceiver> smsReceivers =
                    this.Receiver.OfType<PSSmsReceiver>().
                        Select(o => new SmsReceiver(name: o.Name, countryCode: o.CountryCode, phoneNumber: o.PhoneNumber, status: TransitionHelpers.ConvertNamespace(o.Status))).ToList();

                IList<WebhookReceiver> webhookReceivers =
                    this.Receiver.OfType<PSWebhookReceiver>().
                        Select(o => new WebhookReceiver(
                                                name: o.Name, 
                                                serviceUri: o.ServiceUri, 
                                                useCommonAlertSchema : o.UseCommonAlertSchema,
                                                useAadAuth :o.UseAadAuth,
                                                objectId : o.ObjectId,
                                                identifierUri: o.IdentifierUri,
                                                tenantId :o.TenantId)).ToList();

                IList<ItsmReceiver> itsmReceivers =
                    this.Receiver.OfType<PSItsmReceiver>().
                    Select(o => new ItsmReceiver(name: o.Name, workspaceId: o.WorkspaceId, connectionId: o.ConnectionId, ticketConfiguration: o.TicketConfiguration, region: o.Region)).ToList();

                IList <VoiceReceiver> voiceReceivers =
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
                                                        automationAccountId :o.AutomationAccountId
                                                        )).ToList();

                IList<AzureAppPushReceiver> azureAppPushReceivers =
                  this.Receiver.OfType<PSAzureAppPushReceiver>().
                      Select(o => new AzureAppPushReceiver(
                                                      name: o.Name,
                                                      emailAddress: o.EmailAddress
                                                      )).ToList();

                ActionGroupResource actionGroup = new ActionGroupResource
                                                  {
                                                      Location = this.Location ?? "Global",
                                                      GroupShortName = this.ShortName,
                                                      Enabled = !this.DisableGroup.IsPresent || !this.DisableGroup,
                                                      Tags = this.Tag,
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

                WriteObject(
                    new PSActionGroupResource(
                        this.MonitorManagementClient.ActionGroups.CreateOrUpdate(
                            resourceGroupName: this.ResourceGroupName,
                            actionGroupName: this.Name,
                            actionGroup: actionGroup)));
            }
        }
    }
}
