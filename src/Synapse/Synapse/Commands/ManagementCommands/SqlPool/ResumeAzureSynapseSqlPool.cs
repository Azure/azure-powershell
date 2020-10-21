using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Resume, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlPool,
        DefaultParameterSetName = ResumeByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseSqlPool))]
    public class ResumeAzureSynapseSqlPool : SynapseManagementCmdletBase
    {
        private const string ResumeByNameParameterSet = "ResumeByNameParameterSet";
        private const string ResumeByParentObjectParameterSet = "ResumeByParentObjectParameterSet";
        private const string ResumeByInputObjectParameterSet = "ResumeByInputObjectParameterSet";
        private const string ResumeByResourceIdParameterSet = "ResumeByResourceIdParameterSet";

        [Parameter(Mandatory = false, ParameterSetName = ResumeByNameParameterSet, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResumeByNameParameterSet, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResumeByNameParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [Parameter(Mandatory = true, ParameterSetName = ResumeByParentObjectParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlPool,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = ResumeByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = ResumeByInputObjectParameterSet, Mandatory = true,
            HelpMessage = HelpMessages.SqlPoolObject)]
        [ValidateNotNull]
        public PSSynapseSqlPool InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = ResumeByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlPoolResourceId)]
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

            SqlPool existingSqlPool = null;
            try
            {
                existingSqlPool = this.SynapseAnalyticsClient.GetSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name);
            }
            catch
            {
                existingSqlPool = null;
            }

            if (existingSqlPool == null)
            {
                throw new SynapseException(string.Format(Resources.FailedToDiscoverSqlPool, this.Name, this.ResourceGroupName, this.WorkspaceName));
            }

            if (this.ShouldProcess(this.Name, string.Format(Resources.ResumingSynapseSqlPool, this.Name, this.ResourceGroupName, this.WorkspaceName)))
            {
                this.SynapseAnalyticsClient.ResumeSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name);
                var result = new PSSynapseSqlPool(this.SynapseAnalyticsClient.GetSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name));
                WriteObject(result);
            }
        }
    }
}
