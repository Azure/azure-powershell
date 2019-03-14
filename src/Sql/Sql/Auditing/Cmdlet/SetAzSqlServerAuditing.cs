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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    [CmdletOutputBreakingChange(
        typeof(DatabaseBlobAuditingSettingsModel),
        ReplacementCmdletOutputTypeName = "bool")]
    [Cmdlet(
        VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerAuditing",
        DefaultParameterSetName = DefinitionsCommon.BlobStorageParameterSetName,
        SupportsShouldProcess = true),
        OutputType(typeof(ServerBlobAuditingSettingsModel))]
    public class SetAzSqlServerAuditing : SqlServerAuditingSettingsCmdletBase
    {
        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = AuditingHelpMessages.ResourceGroupNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.StorageAccountSubscriptionIdParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = AuditingHelpMessages.ResourceGroupNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.EventHubParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = AuditingHelpMessages.ResourceGroupNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.LogAnalyticsParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = AuditingHelpMessages.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = AuditingHelpMessages.ServerNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.StorageAccountSubscriptionIdParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = AuditingHelpMessages.ServerNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.EventHubParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = AuditingHelpMessages.ServerNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.LogAnalyticsParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = AuditingHelpMessages.ServerNameHelpMessage)]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string ServerName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageByParentResourceParameterSetName,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = AuditingHelpMessages.ServerInputObjectHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.StorageAccountSubscriptionIdByParentResourceParameterSetName,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = AuditingHelpMessages.ServerInputObjectHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.EventHubByParentResourceParameterSetName,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = AuditingHelpMessages.ServerInputObjectHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.LogAnalyticsByParentResourceParameterSetName,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = AuditingHelpMessages.ServerInputObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public override AzureSqlServerModel InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.StateHelpMessage)]
        [ValidateSet(SecurityConstants.Enabled, SecurityConstants.Disabled, IgnoreCase = false)]
        public string State { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.AuditActionGroupsHelpMessage)]
        public AuditActionGroups[] AuditActionGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.PredicateExpressionHelpMessage)]
        [ValidateNotNull]
        public string PredicateExpression { get; internal set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = AuditingHelpMessages.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.BlobStorageHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.StorageAccountSubscriptionIdParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.BlobStorageHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageByParentResourceParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.BlobStorageHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.StorageAccountSubscriptionIdByParentResourceParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.BlobStorageHelpMessage)]
        public override SwitchParameter BlobStorage { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.AuditStorageAccountNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.StorageAccountSubscriptionIdParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.AuditStorageAccountNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageByParentResourceParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.AuditStorageAccountNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.StorageAccountSubscriptionIdByParentResourceParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.AuditStorageAccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.StorageAccountSubscriptionIdParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.AuditStorageAccountSubscriptionIdHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.StorageAccountSubscriptionIdByParentResourceParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.AuditStorageAccountSubscriptionIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public Guid StorageAccountSubscriptionId { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.StorageKeyTypeHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.StorageAccountSubscriptionIdParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.StorageKeyTypeHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageByParentResourceParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.StorageKeyTypeHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.StorageAccountSubscriptionIdByParentResourceParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.StorageKeyTypeHelpMessage)]
        [ValidateSet(SecurityConstants.Primary, SecurityConstants.Secondary, IgnoreCase = false)]
        public string StorageKeyType { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.RetentionInDaysHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.StorageAccountSubscriptionIdParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.RetentionInDaysHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageByParentResourceParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.RetentionInDaysHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.StorageAccountSubscriptionIdByParentResourceParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.RetentionInDaysHelpMessage)]
        [ValidateNotNullOrEmpty]
        public uint? RetentionInDays { get; internal set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.EventHubParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.EventHubNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.EventHubByParentResourceParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.EventHubNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string EventHubName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.EventHubParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.EventHubAuthorizationRuleIdHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.EventHubByParentResourceParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.EventHubAuthorizationRuleIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string EventHubAuthorizationRuleResourceId { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.LogAnalyticsParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.WorkspaceIdHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.LogAnalyticsByParentResourceParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.WorkspaceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceResourceId { get; set; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected override bool WriteResult() { return PassThru; }

        /// <summary>
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">A model object</param>
        protected override ServerBlobAuditingSettingsModel ApplyUserInputToModel(ServerBlobAuditingSettingsModel model)
        {
            base.ApplyUserInputToModel(model);
            model.AuditState = State == SecurityConstants.Enabled ? AuditStateType.Enabled : AuditStateType.Disabled;

            if (AuditActionGroup != null && AuditActionGroup.Length != 0)
            {
                model.AuditActionGroup = AuditActionGroup;
            }

            if (PredicateExpression != null)
            {
                model.PredicateExpression = PredicateExpression = PredicateExpression;
            }

            if (ParameterSetName == DefinitionsCommon.BlobStorageParameterSetName ||
                ParameterSetName == DefinitionsCommon.StorageAccountSubscriptionIdParameterSetName ||
                ParameterSetName == DefinitionsCommon.BlobStorageByParentResourceParameterSetName ||
                ParameterSetName == DefinitionsCommon.StorageAccountSubscriptionIdByParentResourceParameterSetName)
            {
                if (RetentionInDays != null)
                {
                    model.RetentionInDays = RetentionInDays;
                }

                if (StorageAccountName != null)
                {
                    model.StorageAccountName = StorageAccountName;
                }

                if (MyInvocation.BoundParameters.ContainsKey(SecurityConstants.StorageKeyType)) // the user enter a key type - we use it (and running over the previously defined key type)
                {
                    model.StorageKeyType = (StorageKeyType == SecurityConstants.Primary) ? StorageKeyKind.Primary : StorageKeyKind.Secondary;
                }

                if (!StorageAccountSubscriptionId.Equals(Guid.Empty))
                {
                    model.StorageAccountSubscriptionId = StorageAccountSubscriptionId;
                }
                else if (StorageAccountName != null)
                {
                    model.StorageAccountSubscriptionId = Guid.Parse(DefaultProfile.DefaultContext.Subscription.Id);
                }
            }
            else if (ParameterSetName == DefinitionsCommon.EventHubParameterSetName ||
                ParameterSetName == DefinitionsCommon.EventHubByParentResourceParameterSetName)
            {
                ServerEventHubAuditingSettingsModel eventHubModel = model as ServerEventHubAuditingSettingsModel;
                if (EventHubName != null)
                {
                    eventHubModel.EventHubName = EventHubName;
                }

                if (EventHubAuthorizationRuleResourceId != null)
                {
                    eventHubModel.EventHubAuthorizationRuleResourceId = EventHubAuthorizationRuleResourceId;
                }

            }
            else if (ParameterSetName == DefinitionsCommon.LogAnalyticsParameterSetName ||
                ParameterSetName == DefinitionsCommon.LogAnalyticsByParentResourceParameterSetName)
            {
                ServerLogAnalyticsAuditingSettingsModel logAnalyticsModel = model as ServerLogAnalyticsAuditingSettingsModel;
                if (WorkspaceResourceId != null)
                {
                    logAnalyticsModel.WorkspaceResourceId = WorkspaceResourceId;
                }
            }

            return model;
        }

        protected override ServerBlobAuditingSettingsModel PersistChanges(ServerBlobAuditingSettingsModel model)
        {
            model.PersistChanges(ModelAdapter);
            return null;
        }
    }
}