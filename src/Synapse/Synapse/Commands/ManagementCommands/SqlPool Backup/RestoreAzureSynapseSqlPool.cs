using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsData.Restore, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlPool,
        DefaultParameterSetName = RestoreFromBackupIdByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseSqlPool))]
    public class RestoreAzureSynapseSqlPool : SynapseManagementCmdletBase
    {
        // Restore from backup
        private const string RestoreFromBackupIdByNameParameterSet = "RestoreFromBackupIdByNameParameterSet";
        private const string RestoreFromBackupIdByParentObjectParameterSet = "RestoreFromBackupIdByParentObjectParameterSet";

        // Restore from restore point
        private const string RestoreFromRestorePointIdByNameParameterSet = "RestoreFromRestorePointIdByNameParameterSet";
        private const string RestoreFromRestorePointIdByParentObjectParameterSet = "RestoreFromRestorePointIdByParentObjectParameterSet";

        [Parameter(ParameterSetName = RestoreFromBackupIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromBackup)]
        [Parameter(ParameterSetName = RestoreFromBackupIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromBackup)]
        public SwitchParameter FromBackup { get; set; }

        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        public SwitchParameter FromRestorePoint { get; set; }

        [Parameter(ParameterSetName = RestoreFromBackupIdByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = RestoreFromBackupIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = RestoreFromBackupIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = RestoreFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessages.SqlPoolName)]
        [Alias(nameof(SynapseConstants.TargetSqlPoolName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PerformanceLevel)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PerformanceLevel)]
        [ValidateNotNullOrEmpty]
        public string PerformanceLevel { get; set; }

        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceDatabaseId)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceDatabaseId)]
        [Parameter(ParameterSetName = RestoreFromBackupIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceDatabaseId)]
        [Parameter(ParameterSetName = RestoreFromBackupIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceDatabaseId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RestorePoint)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RestorePoint)]
        [Alias(SynapseConstants.PointInTime)]
        public DateTime RestorePoint { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            var existingWorkspace = this.SynapseAnalyticsClient.GetWorkspaceOrDefault(this.ResourceGroupName, this.WorkspaceName);
            if (existingWorkspace == null)
            {
                throw new SynapseException(string.Format(Resources.WorkspaceDoesNotExist, this.WorkspaceName));
            }

            var createParams = new SqlPool
            {
                Location = existingWorkspace.Location
            };

            switch (this.ParameterSetName)
            {
                case RestoreFromBackupIdByNameParameterSet:
                case RestoreFromBackupIdByParentObjectParameterSet:
                    createParams.CreateMode = SynapseSqlPoolCreateMode.Recovery;
                    createParams.RecoverableDatabaseId = this.ResourceId;
                    break;

                case RestoreFromRestorePointIdByNameParameterSet:
                case RestoreFromRestorePointIdByParentObjectParameterSet:
                    createParams.CreateMode = SynapseSqlPoolCreateMode.PointInTimeRestore;
                    createParams.SourceDatabaseId = this.ResourceId;
                    createParams.RestorePointInTime = this.RestorePoint.ToUniversalTime().ToString("o");
                    createParams.Sku = new Sku
                    {
                        Name = this.PerformanceLevel
                    };

                    break;

                default: throw new SynapseException(string.Format(Resources.InvalidParameterSet, this.ParameterSetName));
            }

            if (this.ShouldProcess(this.Name, string.Format(Resources.RestoringSynapseSqlPool, this.ResourceId, this.ResourceGroupName, this.WorkspaceName, this.Name)))
            {
                var result = new PSSynapseSqlPool(this.ResourceGroupName, this.WorkspaceName, this.SynapseAnalyticsClient.CreateSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name, createParams));
                WriteObject(result);
            }
        }
    }
}
