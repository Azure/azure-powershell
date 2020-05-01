﻿using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
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
    public class UpdateAzureSynapseSqlPool : SynapseCmdletBase
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByParentObjectParameterSet = "UpdateByParentObjectParameterSet";
        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        private const string RenameByNameParameterSet = "RenameByNameParameterSet";
        private const string RenameByParentObjectParameterSet = "RenameByParentObjectParameterSet";
        private const string RenameByInputObjectParameterSet = "RenameByInputObjectParameterSet";
        private const string RenameByResourceIdParameterSet = "RenameByResourceIdParameterSet";

        private const string PauseByNameParameterSet = "PauseByNameParameterSet";
        private const string PauseByParentObjectParameterSet = "PauseByParentObjectParameterSet";
        private const string PauseByInputObjectParameterSet = "PauseByInputObjectParameterSet";
        private const string PauseByResourceIdParameterSet = "PauseByResourceIdParameterSet";

        private const string ResumeByNameParameterSet = "ResumeByNameParameterSet";
        private const string ResumeByParentObjectParameterSet = "ResumeByParentObjectParameterSet";
        private const string ResumeByInputObjectParameterSet = "ResumeByInputObjectParameterSet";
        private const string ResumeByResourceIdParameterSet = "ResumeByResourceIdParameterSet";

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(Mandatory = false, ParameterSetName = PauseByNameParameterSet, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(Mandatory = false, ParameterSetName = ResumeByNameParameterSet, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(Mandatory = true, ParameterSetName = PauseByNameParameterSet, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(Mandatory = true, ParameterSetName = ResumeByNameParameterSet, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByParentObjectParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [Parameter(Mandatory = true, ParameterSetName = PauseByNameParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [Parameter(Mandatory = true, ParameterSetName = PauseByParentObjectParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [Parameter(Mandatory = true, ParameterSetName = ResumeByNameParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [Parameter(Mandatory = true, ParameterSetName = ResumeByParentObjectParameterSet, HelpMessage = HelpMessages.SqlPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlPool,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = PauseByNameParameterSet, HelpMessage = HelpMessages.SuspendSqlPool)]
        [Parameter(Mandatory = true, ParameterSetName = PauseByInputObjectParameterSet, HelpMessage = HelpMessages.SuspendSqlPool)]
        [Parameter(Mandatory = true, ParameterSetName = PauseByParentObjectParameterSet, HelpMessage = HelpMessages.SuspendSqlPool)]
        [Parameter(Mandatory = true, ParameterSetName = PauseByResourceIdParameterSet, HelpMessage = HelpMessages.SuspendSqlPool)]
        public SwitchParameter Suspend { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResumeByNameParameterSet, HelpMessage = HelpMessages.ResumeSqlPool)]
        [Parameter(Mandatory = true, ParameterSetName = ResumeByInputObjectParameterSet, HelpMessage = HelpMessages.ResumeSqlPool)]
        [Parameter(Mandatory = true, ParameterSetName = ResumeByParentObjectParameterSet, HelpMessage = HelpMessages.ResumeSqlPool)]
        [Parameter(Mandatory = true, ParameterSetName = ResumeByResourceIdParameterSet, HelpMessage = HelpMessages.ResumeSqlPool)]
        public SwitchParameter Resume { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = PauseByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = ResumeByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet, Mandatory = true,
            HelpMessage = HelpMessages.SqlPoolObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = PauseByInputObjectParameterSet, Mandatory = true,
            HelpMessage = HelpMessages.SqlPoolObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = ResumeByInputObjectParameterSet, Mandatory = true,
            HelpMessage = HelpMessages.SqlPoolObject)]
        [ValidateNotNull]
        public PSSynapseSqlPool InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlPoolResourceId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = PauseByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlPoolResourceId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = ResumeByResourceIdParameterSet,
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

                case PauseByNameParameterSet:
                case PauseByInputObjectParameterSet:
                case PauseByParentObjectParameterSet:
                case PauseByResourceIdParameterSet:
                    PauseSqlPool();
                    break;

                case ResumeByNameParameterSet:
                case ResumeByInputObjectParameterSet:
                case ResumeByParentObjectParameterSet:
                case ResumeByResourceIdParameterSet:
                    ResumeSqlPool();
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

        private void PauseSqlPool()
        {
            if (this.ShouldProcess(this.Name, string.Format(Resources.SuspendingSynapseSqlPool, this.Name, this.ResourceGroupName, this.WorkspaceName)))
            {
                this.SynapseAnalyticsClient.PauseSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name);
                var result = new PSSynapseSqlPool(this.SynapseAnalyticsClient.GetSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name));
                WriteObject(result);
            }
        }

        private void ResumeSqlPool()
        {
            if (this.ShouldProcess(this.Name, string.Format(Resources.SuspendingSynapseSqlPool, this.Name, this.ResourceGroupName, this.WorkspaceName)))
            {
                this.SynapseAnalyticsClient.ResumeSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name);
                var result = new PSSynapseSqlPool(this.SynapseAnalyticsClient.GetSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name));
                WriteObject(result);
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
