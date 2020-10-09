using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlPool,
        DefaultParameterSetName = UpdateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseSqlPool))]
    public class UpdateAzureSynapseSqlPool : SynapseManagementCmdletBase
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByParentObjectParameterSet = "UpdateByParentObjectParameterSet";
        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        private const string RenameByNameParameterSet = "RenameByNameParameterSet";
        private const string RenameByParentObjectParameterSet = "RenameByParentObjectParameterSet";
        private const string RenameByInputObjectParameterSet = "RenameByInputObjectParameterSet";
        private const string RenameByResourceIdParameterSet = "RenameByResourceIdParameterSet";

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByParentObjectParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlPool,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.SqlPoolVersion)]
        [ValidateNotNullOrEmpty]
        public int Version { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet, Mandatory = true,
            HelpMessage = HelpMessages.SqlPoolObject)]
        [ValidateNotNull]
        public PSSynapseSqlPool InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlPoolResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.Tag)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.Tag)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByInputObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.Tag)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByResourceIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.Tag)]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.PerformanceLevel)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.PerformanceLevel)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByInputObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.PerformanceLevel)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByResourceIdParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.PerformanceLevel)]
        [ValidateNotNullOrEmpty]
        public string PerformanceLevel { get; set; }

        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

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

            if (this.Version == 3)
            {
                SqlPoolV3 existingSqlPool = null;
                try
                {
                    existingSqlPool = this.SynapseAnalyticsClient.GetSqlPoolV3(this.ResourceGroupName, this.WorkspaceName, this.Name);
                }
                catch
                {
                    existingSqlPool = null;
                }

                if (existingSqlPool == null)
                {
                    throw new SynapseException(string.Format(Resources.FailedToDiscoverSqlPool, this.Name, this.ResourceGroupName, this.WorkspaceName));
                }

                switch (this.ParameterSetName)
                {
                    case UpdateByNameParameterSet:
                    case UpdateByInputObjectParameterSet:
                    case UpdateByParentObjectParameterSet:
                    case UpdateByResourceIdParameterSet:
                        UpdateSqlPoolV3(existingSqlPool);
                        break;

                    default: throw new SynapseException(string.Format(Resources.InvalidParameterSet, this.ParameterSetName));
                }
            }
            else
            {
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

                switch (this.ParameterSetName)
                {
                    case UpdateByNameParameterSet:
                    case UpdateByInputObjectParameterSet:
                    case UpdateByParentObjectParameterSet:
                    case UpdateByResourceIdParameterSet:
                        UpdateSqlPool(existingSqlPool);
                        break;

                    case RenameByNameParameterSet:
                    case RenameByInputObjectParameterSet:
                    case RenameByParentObjectParameterSet:
                    case RenameByResourceIdParameterSet:
                        RenameSqlPool();
                        break;

                    default: throw new SynapseException(string.Format(Resources.InvalidParameterSet, this.ParameterSetName));
                }
            }
        }

        private void UpdateSqlPoolV3(SqlPoolV3 existingSqlPool)
        {
            SqlPoolUpdate sqlPoolPatchInfo = new SqlPoolUpdate
            {
                Tags = this.IsParameterBound(c => c.Tag) ? TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true) : existingSqlPool.Tags,
                Sku = !this.IsParameterBound(c => c.PerformanceLevel) ? existingSqlPool.Sku : new Sku
                {
                    Name = this.PerformanceLevel
                }
            };

            if (this.ShouldProcess(this.Name, string.Format(Resources.UpdatingSynapseSqlPool, this.Name, this.ResourceGroupName, this.WorkspaceName)))
            {
                this.SynapseAnalyticsClient.UpdateSqlPoolV3(this.ResourceGroupName, this.WorkspaceName, this.Name, sqlPoolPatchInfo);
                if (this.PassThru.IsPresent)
                {
                    var result = this.SynapseAnalyticsClient.GetSqlPoolV3(this.ResourceGroupName, this.WorkspaceName, this.Name);
                    WriteObject(result);
                }
            }
        }

        private void UpdateSqlPool(SqlPool existingSqlPool)
        {
            SqlPoolPatchInfo sqlPoolPatchInfo = new SqlPoolPatchInfo
            {
                Tags = this.IsParameterBound(c => c.Tag) ? TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true) : existingSqlPool.Tags,
                Sku = !this.IsParameterBound(c => c.PerformanceLevel) ? existingSqlPool.Sku : new Sku
                {
                    Name = this.PerformanceLevel
                }
            };

            if (this.ShouldProcess(this.Name, string.Format(Resources.UpdatingSynapseSqlPool, this.Name, this.ResourceGroupName, this.WorkspaceName)))
            {
                this.SynapseAnalyticsClient.UpdateSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name, sqlPoolPatchInfo);
                if (this.PassThru.IsPresent)
                {
                    var result = this.SynapseAnalyticsClient.GetSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name);
                    WriteObject(result);
                }
            }
        }

        private void RenameSqlPool()
        {
            if (this.ShouldProcess(this.Name, string.Format(Resources.UpdatingSynapseSqlPool, this.Name, this.ResourceGroupName, this.WorkspaceName)))
            {
                this.SynapseAnalyticsClient.RenameSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name, this.NewName);
                var result = new PSSynapseSqlPool(this.SynapseAnalyticsClient.GetSqlPool(this.ResourceGroupName, this.WorkspaceName, this.NewName));
                WriteObject(result);
            }
        }
    }
}
