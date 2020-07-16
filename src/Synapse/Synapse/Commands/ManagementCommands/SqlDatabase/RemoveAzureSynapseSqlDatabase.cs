using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlDatabase, DefaultParameterSetName = DeleteByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureSynapseSqlDatabase : SynapseManagementCmdletBase
    {
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByParentObjectParameterSet = "DeleteByParentObjectParameterSet";
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        private const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";

        [Parameter(Mandatory = false, ParameterSetName = DeleteByNameParameterSet, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, HelpMessage = HelpMessages.SqlDatabaseName)]
        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet, HelpMessage = HelpMessages.SqlDatabaseName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlDatabase,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = DeleteByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = DeleteByInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlDatabaseObject)]
        [ValidateNotNull]
        public PSSynapseSqlDatabase InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = DeleteByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlDatabaseResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.Name = resourceIdentifier.ResourceName;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            if (this.ShouldProcess(this.Name, string.Format(Resources.RemovingSynapseSqlDatabase, this.Name, this.ResourceGroupName, this.WorkspaceName)))
            {
                this.SynapseAnalyticsClient.DeleteSqlDatabase(this.ResourceGroupName, this.WorkspaceName, this.Name);

                if (this.PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
