using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
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
        private const string RestoreFromBackupNameByNameParameterSet = "RestoreFromBackupNameByNameParameterSet";
        private const string RestoreFromBackupNameByParentObjectParameterSet = "RestoreFromBackupNameByParentObjectParameterSet";
        private const string RestoreFromBackupInputObjectByNameParameterSet = "RestoreFromBackupInputObjectByNameParameterSet";

        // Restore from restore point
        private const string RestoreFromRestorePointIdByNameParameterSet = "RestoreFromRestorePointIdByNameParameterSet";
        private const string RestoreFromRestorePointIdByParentObjectParameterSet = "RestoreFromRestorePointIdByParentObjectParameterSet";
        private const string RestoreFromRestorePointNameByNameParameterSet = "RestoreFromRestorePointNameByNameParameterSet";
        private const string RestoreFromRestorePointNameByParentObjectParameterSet = "RestoreFromRestorePointNameByParentObjectParameterSet";
        private const string RestoreFromRestorePointInputObjectByNameParameterSet = "RestoreFromRestorePointInputObjectByNameParameterSet";

        [Parameter(ParameterSetName = RestoreFromBackupIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromBackup)]
        [Parameter(ParameterSetName = RestoreFromBackupIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromBackup)]
        [Parameter(ParameterSetName = RestoreFromBackupNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromBackup)]
        [Parameter(ParameterSetName = RestoreFromBackupNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromBackup)]
        [Parameter(ParameterSetName = RestoreFromBackupInputObjectByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromBackup)]
        public SwitchParameter FromBackup { get; set; }

        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        [Parameter(ParameterSetName = RestoreFromRestorePointNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        [Parameter(ParameterSetName = RestoreFromRestorePointNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        [Parameter(ParameterSetName = RestoreFromRestorePointInputObjectByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        public SwitchParameter FromRestorePoint { get; set; }

        [Parameter(ParameterSetName = RestoreFromBackupIdByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = RestoreFromBackupNameByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = RestoreFromBackupInputObjectByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = RestoreFromRestorePointNameByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = RestoreFromRestorePointInputObjectByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = RestoreFromBackupIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = RestoreFromBackupNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = RestoreFromBackupInputObjectByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = RestoreFromRestorePointNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = RestoreFromRestorePointInputObjectByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = RestoreFromBackupNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = RestoreFromBackupIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = RestoreFromRestorePointNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = RestoreFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessages.SqlPoolName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.Tag)]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ParameterSetName = RestoreFromRestorePointNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PerformanceLevel)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PerformanceLevel)]
        [Parameter(ParameterSetName = RestoreFromRestorePointInputObjectByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.PerformanceLevel)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PerformanceLevel)]
        [ValidateNotNullOrEmpty]
        public string PerformanceLevel { get; set; }

        [Parameter(ParameterSetName = RestoreFromBackupNameByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.BackupResourceGroupName)]
        [Parameter(ParameterSetName = RestoreFromBackupNameByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.BackupResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string BackupResourceGroupName { get; set; }

        [Parameter(ParameterSetName = RestoreFromBackupNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.BackupWorkspaceName)]
        [Parameter(ParameterSetName = RestoreFromBackupNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.BackupWorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(BackupResourceGroupName))]
        [Alias("BackupServerName")]
        [ValidateNotNullOrEmpty]
        public string BackupWorkspaceName { get; set; }

        [Parameter(ParameterSetName = RestoreFromBackupNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.BackupSqlPoolName)]
        [Parameter(ParameterSetName = RestoreFromBackupNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.BackupSqlPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlPool,
            nameof(BackupResourceGroupName),
            nameof(BackupWorkspaceName))]
        [Alias("BackupDatabaseName")]
        [ValidateNotNullOrEmpty]
        public string BackupSqlPoolName { get; set; }

        [Parameter(ParameterSetName = RestoreFromBackupInputObjectByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlPoolObject)]
        [ValidateNotNullOrEmpty]
        public PSSynapseSqlPool BackupSqlPoolObject { get; set; }

        [Parameter(ParameterSetName = RestoreFromBackupIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.BackupSqlPoolResourceId)]
        [Parameter(ParameterSetName = RestoreFromBackupIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.BackupSqlPoolResourceId)]
        [ValidateNotNullOrEmpty]
        public string BackupResourceId { get; set; }

        [Parameter(ParameterSetName = RestoreFromRestorePointNameByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SourceResourceGroupName)]
        [Parameter(ParameterSetName = RestoreFromRestorePointNameByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SourceResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string SourceResourceGroupName { get { return BackupResourceGroupName; } set { this.BackupResourceGroupName = value; } }

        [Parameter(ParameterSetName = RestoreFromRestorePointNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceWorkspaceName)]
        [Parameter(ParameterSetName = RestoreFromRestorePointNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceWorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(SourceResourceGroupName))]
        [Alias("SourceServerName")]
        [ValidateNotNullOrEmpty]
        public string SourceWorkspaceName { get { return BackupWorkspaceName; } set { this.BackupWorkspaceName = value; } }

        [Parameter(ParameterSetName = RestoreFromRestorePointNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceSqlPoolName)]
        [Parameter(ParameterSetName = RestoreFromRestorePointNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceSqlPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlPool,
            nameof(SourceResourceGroupName),
            nameof(SourceWorkspaceName))]
        [Alias("SourceDatabaseName")]
        [ValidateNotNullOrEmpty]
        public string SourceSqlPoolName { get { return BackupSqlPoolName; } set { this.BackupSqlPoolName = value; } }

        [Parameter(ParameterSetName = RestoreFromRestorePointInputObjectByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlPoolObject)]
        [ValidateNotNullOrEmpty]
        public PSSynapseSqlPool SourceSqlPoolObject { get { return BackupSqlPoolObject; } set { this.BackupSqlPoolObject = value; } }

        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceSqlPoolId)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceSqlPoolId)]
        [ValidateNotNullOrEmpty]
        public string SourceResourceId { get { return BackupResourceId; } set { this.BackupResourceId = value; } }

        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RestorePoint)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RestorePoint)]
        public DateTime? RestorePoint { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.BackupResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.BackupResourceId);
                this.BackupWorkspaceName = resourceIdentifier.ParentResource;
                this.BackupWorkspaceName = this.BackupWorkspaceName.Substring(this.BackupWorkspaceName.LastIndexOf('/') + 1);
                this.BackupSqlPoolName = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.BackupSqlPoolObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.BackupSqlPoolObject.Id);
                this.BackupResourceId = this.BackupSqlPoolObject.Id;
                this.BackupWorkspaceName = resourceIdentifier.ParentResource;
                this.BackupWorkspaceName = this.BackupWorkspaceName.Substring(this.BackupWorkspaceName.LastIndexOf('/') + 1);
                this.BackupSqlPoolName = resourceIdentifier.ResourceName;
                this.PerformanceLevel = this.IsParameterBound(c => c.PerformanceLevel) ? this.PerformanceLevel : this.BackupSqlPoolObject.Sku?.Name;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            if (FromBackup.IsPresent || FromRestorePoint.IsPresent)
            {
                // Construct resource id from components.
                if (string.IsNullOrEmpty(this.BackupResourceId))
                {
                    if (string.IsNullOrEmpty(this.BackupResourceGroupName))
                    {
                        this.BackupResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.BackupWorkspaceName);
                    }

                    this.BackupResourceId = ConstructSqlDatabaseResourceId(
                        this.DefaultContext.Subscription.Id,
                        this.BackupResourceGroupName,
                        this.BackupWorkspaceName,
                        this.BackupSqlPoolName,
                        this.FromBackup.IsPresent);
                }
            }

            var existingWorkspace = this.SynapseAnalyticsClient.GetWorkspaceOrDefault(this.ResourceGroupName, this.WorkspaceName);
            if (existingWorkspace == null)
            {
                throw new SynapseException(string.Format(Resources.WorkspaceDoesNotExist, this.WorkspaceName));
            }

            var existingSqlPool = this.SynapseAnalyticsClient.GetSqlPoolOrDefault(this.ResourceGroupName, this.WorkspaceName, this.Name);
            if (existingSqlPool != null)
            {
                throw new SynapseException(string.Format(Resources.SynapseSqlPoolExists, this.Name, this.ResourceGroupName, this.WorkspaceName));
            }

            var createParams = new SqlPool
            {
                Location = existingWorkspace.Location,
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true)
            };

            switch (this.ParameterSetName)
            {
                case RestoreFromBackupNameByNameParameterSet:
                case RestoreFromBackupNameByParentObjectParameterSet:
                case RestoreFromBackupIdByNameParameterSet:
                case RestoreFromBackupIdByParentObjectParameterSet:
                case RestoreFromBackupInputObjectByNameParameterSet:
                    createParams.CreateMode = SynapseSqlPoolCreateMode.Recovery;
                    createParams.RecoverableDatabaseId = this.BackupResourceId;
                    break;

                case RestoreFromRestorePointNameByNameParameterSet:
                case RestoreFromRestorePointNameByParentObjectParameterSet:
                case RestoreFromRestorePointIdByNameParameterSet:
                case RestoreFromRestorePointIdByParentObjectParameterSet:
                case RestoreFromRestorePointInputObjectByNameParameterSet:
                    if (!this.IsParameterBound(c => c.RestorePoint))
                    {
                        this.RestorePoint = GetNewestRestorePoint();
                    }

                    createParams.CreateMode = SynapseSqlPoolCreateMode.PointInTimeRestore;
                    createParams.SourceDatabaseId = this.SourceResourceId;
                    createParams.RestorePointInTime = this.RestorePoint;
                    createParams.Sku = new Sku
                    {
                        Name = this.PerformanceLevel
                    };

                    break;

                default: throw new SynapseException(string.Format(Resources.InvalidParameterSet, this.ParameterSetName));
            }

            if (this.ShouldProcess(this.Name, string.Format(Resources.RestoringSynapseSqlPool, this.BackupSqlPoolName, this.ResourceGroupName, this.WorkspaceName, this.Name)))
            {
                var result = new PSSynapseSqlPool(this.SynapseAnalyticsClient.CreateSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name, createParams));
                WriteObject(result);
            }
        }

        private DateTime GetNewestRestorePoint()
        {
            string sourceResourceGroupName = this.SourceResourceGroupName;
            string sourceWorkspaceName = this.SourceWorkspaceName;
            sourceWorkspaceName = sourceWorkspaceName.Substring(sourceWorkspaceName.LastIndexOf('/') + 1);
            string sourceSqlPoolName = this.SourceSqlPoolName;

            var sourceSqlDatabase = this.SynapseAnalyticsClient.GetSqlPool(sourceResourceGroupName, sourceWorkspaceName, sourceSqlPoolName);
            if (sourceSqlDatabase == null)
            {
                throw new SynapseException(string.Format(Resources.SqlPoolDoesNotExist, sourceSqlPoolName));
            }

            var restorePoints = this.SynapseAnalyticsClient.ListSqlPoolRestorePoints(
                sourceResourceGroupName,
                sourceWorkspaceName,
                sourceSqlPoolName);

            var neweastRestorePoint = restorePoints.MaxOrDefault(rp => rp.RestorePointCreationDate, null);
            if (!neweastRestorePoint.HasValue)
            {
                throw new SynapseException(string.Format(Resources.FailedToDiscoverSqlPoolRestorePoints, sourceSqlPoolName, sourceResourceGroupName, sourceWorkspaceName));
            }
            else
            {
                return neweastRestorePoint.Value;
            }
        }

        private static string ConstructSqlDatabaseResourceId(
            string subscriptionId,
            string resourceGroupName,
            string serverName,
            string databaseName,
            bool isRecoverableDatabase)
        {
            return Utils.ConstructResourceId(
                subscriptionId,
                resourceGroupName,
                isRecoverableDatabase ? ResourceTypes.RecoverablSqlDatabase : ResourceTypes.SqlDatabase,
                databaseName,
                $"servers/{serverName}");
        }
    }
}
