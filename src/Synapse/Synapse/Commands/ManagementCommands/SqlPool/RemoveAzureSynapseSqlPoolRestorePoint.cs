using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using System.Linq;
using Microsoft.Azure.Commands.Synapse.Properties;
using System;

namespace Microsoft.Azure.Commands.Synapse.Commands
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlPool+ SynapseConstants.RestorePoint, DefaultParameterSetName = DeleteByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureSynapseSqlPoolRestorePoint : SynapseManagementCmdletBase
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

        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [ResourceNameCompleter(ResourceTypes.SqlPool, nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public string SqlPoolName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet, HelpMessage = HelpMessages.SqlPoolRestorePointName)]
        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, HelpMessage = HelpMessages.SqlPoolRestorePointName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlPoolRestorePoint,
            nameof(ResourceGroupName),
            nameof(WorkspaceName),
            nameof(SqlPoolName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = DeleteByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlPoolObject)]
        [ValidateNotNull]
        public PSSynapseSqlPool SqlPoolObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = DeleteByInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlPoolRestorePointObject)]
        [ValidateNotNull]
        public PSRestorePoint InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = DeleteByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlPoolRestorePointResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.SqlPoolObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.SqlPoolObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SqlPoolName = resourceIdentifier.ResourceName;
            } 

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.Name = this.InputObject.Id.Substring(this.InputObject.Id.LastIndexOf('/') + 1);
                this.ResourceId = this.InputObject.Id.Substring(0, this.InputObject.Id.Substring(0, this.InputObject.Id.LastIndexOf("/")).LastIndexOf("/"));
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SqlPoolName = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                this.Name = this.ResourceId.Substring(this.ResourceId.LastIndexOf('/') + 1);
                this.ResourceId = this.ResourceId.Substring(0,this.ResourceId.Substring(0, this.ResourceId.LastIndexOf("/")).LastIndexOf("/"));
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SqlPoolName = resourceIdentifier.ResourceName;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            if (this.ShouldProcess(this.Name, string.Format("Resources.RemovingSynapseSqlPoolRestorePoint", this.Name, this.ResourceGroupName, this.WorkspaceName, this.SqlPoolName)))
            {
                this.SynapseAnalyticsClient.DeleteSqlPoolRestorePoint(this.ResourceGroupName, this.WorkspaceName, this.SqlPoolName, this.Name);

                if (this.PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
