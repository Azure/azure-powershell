using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Sql + SynapseConstants.Audit,
        DefaultParameterSetName = SetByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(WorkspaceAuditModel))]
    public class SetAzureSynapseSqlAudit : SynapseManagementCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        [Parameter(ParameterSetName = SetByNameParameterSet, Mandatory = false,
            HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = SetByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AuditActionGroup)]
        public AuditActionGroups[] AuditActionGroup { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PredicateExpression)]
        [ValidateNotNull]
        public string PredicateExpression { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.BlobStorageTargetState)]
        [ValidateSet(SynapseConstants.Security.Enabled, SynapseConstants.Security.Disabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string BlobStorageTargetState { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AuditStorageAccountResourceId)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.StorageKeyType)]
        [ValidateSet(SynapseConstants.Security.Primary, SynapseConstants.Security.Secondary, IgnoreCase = false)]
        public string StorageKeyType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.RetentionInDays)]
        [ValidateNotNullOrEmpty]
        public uint? RetentionInDays { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.EventHubTargetState)]
        [ValidateSet(SynapseConstants.Security.Enabled, SynapseConstants.Security.Disabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string EventHubTargetState { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.EventHubName)]
        [ValidateNotNullOrEmpty]
        public string EventHubName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.EventHubAuthorizationRuleId)]
        [ValidateNotNullOrEmpty]
        public string EventHubAuthorizationRuleResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.LogAnalyticsTargetState)]
        [ValidateSet(SynapseConstants.Security.Enabled, SynapseConstants.Security.Disabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string LogAnalyticsTargetState { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.WorkspaceId)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ResourceName;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            if (this.ShouldProcess(this.WorkspaceName, string.Format(Resources.SettingSqlAudit, this.WorkspaceName)))
            {
                WorkspaceAuditModel model = new WorkspaceAuditModel
                {
                    ResourceGroupName = this.ResourceGroupName,
                    WorkspaceName = this.WorkspaceName
                };

                if (this.IsParameterBound(c => c.AuditActionGroup))
                {
                    model.AuditActionGroup = this.AuditActionGroup;
                }

                if (this.IsParameterBound(c => c.PredicateExpression))
                {
                    model.PredicateExpression = this.PredicateExpression;
                }

                if (this.IsParameterBound(c => c.BlobStorageTargetState))
                {
                    model.BlobStorageTargetState = this.BlobStorageTargetState == SynapseConstants.Security.Enabled ?
                        AuditStateType.Enabled : AuditStateType.Disabled;
                }

                if (this.IsParameterBound(c => c.StorageAccountResourceId))
                {
                    model.StorageAccountResourceId = this.StorageAccountResourceId;
                }

                if (this.IsParameterBound(c => c.StorageKeyType))
                {
                    model.StorageKeyType = (this.StorageKeyType == SynapseConstants.Security.Primary) ? StorageKeyKind.Primary : StorageKeyKind.Secondary;
                }

                if (this.IsParameterBound(c => c.RetentionInDays))
                {
                    model.RetentionInDays = this.RetentionInDays;
                }

                if (this.IsParameterBound(c => c.EventHubTargetState))
                {
                    model.EventHubTargetState = this.EventHubTargetState == SynapseConstants.Security.Enabled ?
                        AuditStateType.Enabled : AuditStateType.Disabled;
                }

                if (this.IsParameterBound(c => c.EventHubName))
                {
                    model.EventHubName = this.EventHubName;
                }

                if (this.IsParameterBound(c => c.EventHubAuthorizationRuleResourceId))
                {
                    model.EventHubAuthorizationRuleResourceId = this.EventHubAuthorizationRuleResourceId;
                }

                if (this.IsParameterBound(c => c.LogAnalyticsTargetState))
                {
                    model.LogAnalyticsTargetState = this.LogAnalyticsTargetState == SynapseConstants.Security.Enabled ?
                        AuditStateType.Enabled : AuditStateType.Disabled;
                }

                if (this.IsParameterBound(c => c.WorkspaceResourceId))
                {
                    model.WorkspaceResourceId = this.WorkspaceResourceId;
                }

                SynapseAnalyticsClient.CreateOrUpdateSqlAudit(model);
                if (PassThru)
                {
                    WriteObject(model);
                }
            }
        }
    }
}
