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
using Sku = Microsoft.Azure.Management.Synapse.Models.Sku;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlPool, DefaultParameterSetName = CreateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseSqlPool))]
    public class NewAzureSynapseSqlPool : SynapseManagementCmdletBase
    {
        // Default
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";

        // Create from backup
        private const string CreateFromBackupIdByNameParameterSet = "CreateFromBackupIdByNameParameterSet";
        private const string CreateFromBackupIdByParentObjectParameterSet = "CreateFromBackupIdByParentObjectParameterSet";
        private const string CreateFromBackupNameByNameParameterSet = "CreateFromBackupNameByNameParameterSet";
        private const string CreateFromBackupNameByParentObjectParameterSet = "CreateFromBackupNameByParentObjectParameterSet";
        private const string CreateFromBackupInputObjectByNameParameterSet = "CreateFromBackupInputObjectByNameParameterSet";

        // Create from restore point
        private const string CreateFromRestorePointIdByNameParameterSet = "CreateFromRestorePointIdByNameParameterSet";
        private const string CreateFromRestorePointIdByParentObjectParameterSet = "CreateFromRestorePointIdByParentObjectParameterSet";
        private const string CreateFromRestorePointNameByNameParameterSet = "CreateFromRestorePointNameByNameParameterSet";
        private const string CreateFromRestorePointNameByParentObjectParameterSet = "CreateFromRestorePointNameByParentObjectParameterSet";
        private const string CreateFromRestorePointInputObjectByNameParameterSet = "CreateFromRestorePointInputObjectByNameParameterSet";

        [Parameter(ParameterSetName = CreateFromBackupIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromBackup)]
        [Parameter(ParameterSetName = CreateFromBackupIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromBackup)]
        [Parameter(ParameterSetName = CreateFromBackupNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromBackup)]
        [Parameter(ParameterSetName = CreateFromBackupNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromBackup)]
        [Parameter(ParameterSetName = CreateFromBackupInputObjectByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromBackup)]
        public SwitchParameter FromBackup { get; set; }

        [Parameter(ParameterSetName = CreateFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        [Parameter(ParameterSetName = CreateFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        [Parameter(ParameterSetName = CreateFromRestorePointNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        [Parameter(ParameterSetName = CreateFromRestorePointNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        [Parameter(ParameterSetName = CreateFromRestorePointInputObjectByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        public SwitchParameter FromRestorePoint { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = CreateFromBackupIdByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = CreateFromBackupNameByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = CreateFromBackupInputObjectByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = CreateFromRestorePointIdByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = CreateFromRestorePointNameByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = CreateFromRestorePointInputObjectByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = CreateFromBackupIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = CreateFromBackupNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = CreateFromBackupInputObjectByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = CreateFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = CreateFromRestorePointNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = CreateFromRestorePointInputObjectByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateFromBackupNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateFromBackupIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateFromRestorePointNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = CreateFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessages.SqlPoolName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.SqlPoolVersion)]
        [ValidateNotNullOrEmpty]
        public int Version { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.Tag)]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PerformanceLevel)]
        [Parameter(ParameterSetName = CreateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PerformanceLevel)]
        [Parameter(ParameterSetName = CreateFromRestorePointNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PerformanceLevel)]
        [Parameter(ParameterSetName = CreateFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PerformanceLevel)]
        [Parameter(ParameterSetName = CreateFromRestorePointInputObjectByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.PerformanceLevel)]
        [Parameter(ParameterSetName = CreateFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.PerformanceLevel)]
        [ValidateNotNullOrEmpty]
        public string PerformanceLevel { get; set; }

        [Parameter(ParameterSetName = CreateByNameParameterSet, Mandatory = false, HelpMessage = HelpMessages.Collation)]
        [Parameter(ParameterSetName = CreateByParentObjectParameterSet, Mandatory = false, HelpMessage = HelpMessages.Collation)]
        [ValidateNotNullOrEmpty]
        public string Collation { get; set; }

        [Parameter(ParameterSetName = CreateFromBackupNameByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.BackupResourceGroupName)]
        [Parameter(ParameterSetName = CreateFromBackupNameByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.BackupResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string BackupResourceGroupName { get; set; }

        [Parameter(ParameterSetName = CreateFromBackupNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.BackupWorkspaceName)]
        [Parameter(ParameterSetName = CreateFromBackupNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.BackupWorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(BackupResourceGroupName))]
        [Alias("BackupServerName")]
        [ValidateNotNullOrEmpty]
        public string BackupWorkspaceName { get; set; }

        [Parameter(ParameterSetName = CreateFromBackupNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.BackupSqlPoolName)]
        [Parameter(ParameterSetName = CreateFromBackupNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.BackupSqlPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlPool,
            nameof(BackupResourceGroupName),
            nameof(BackupWorkspaceName))]
        [Alias("BackupDatabaseName")]
        [ValidateNotNullOrEmpty]
        public string BackupSqlPoolName { get; set; }

        [Parameter(ParameterSetName = CreateFromBackupInputObjectByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlPoolObject)]
        [ValidateNotNullOrEmpty]
        public PSSynapseSqlPool BackupSqlPoolObject { get; set; }

        [Parameter(ParameterSetName = CreateFromBackupIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.BackupSqlPoolResourceId)]
        [Parameter(ParameterSetName = CreateFromBackupIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.BackupSqlPoolResourceId)]
        [ValidateNotNullOrEmpty]
        public string BackupResourceId { get; set; }

        [Parameter(ParameterSetName = CreateFromRestorePointNameByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SourceResourceGroupName)]
        [Parameter(ParameterSetName = CreateFromRestorePointNameByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.SourceResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string SourceResourceGroupName { get { return BackupResourceGroupName; } set { this.BackupResourceGroupName = value; } }

        [Parameter(ParameterSetName = CreateFromRestorePointNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceWorkspaceName)]
        [Parameter(ParameterSetName = CreateFromRestorePointNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceWorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(SourceResourceGroupName))]
        [Alias("SourceServerName")]
        [ValidateNotNullOrEmpty]
        public string SourceWorkspaceName { get { return BackupWorkspaceName; } set { this.BackupWorkspaceName = value; } }

        [Parameter(ParameterSetName = CreateFromRestorePointNameByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceSqlPoolName)]
        [Parameter(ParameterSetName = CreateFromRestorePointNameByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceSqlPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlPool,
            nameof(SourceResourceGroupName),
            nameof(SourceWorkspaceName))]
        [Alias("SourceDatabaseName")]
        [ValidateNotNullOrEmpty]
        public string SourceSqlPoolName { get { return BackupSqlPoolName; } set { this.BackupSqlPoolName = value; } }

        [Parameter(ParameterSetName = CreateFromRestorePointInputObjectByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlPoolObject)]
        [ValidateNotNullOrEmpty]
        public PSSynapseSqlPool SourceSqlPoolObject { get { return BackupSqlPoolObject; } set { this.BackupSqlPoolObject = value; } }

        [Parameter(ParameterSetName = CreateFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceSqlPoolId)]
        [Parameter(ParameterSetName = CreateFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceSqlPoolId)]
        [ValidateNotNullOrEmpty]
        public string SourceResourceId { get { return BackupResourceId; } set { this.BackupResourceId = value; } }

        [Parameter(ParameterSetName = CreateFromRestorePointIdByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.RestorePoint)]
        [Parameter(ParameterSetName = CreateFromRestorePointIdByParentObjectParameterSet,
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

            if (this.Version == 3)
            {

                var existingSqlPool = this.SynapseAnalyticsClient.GetSqlPoolV3OrDefault(this.ResourceGroupName, this.WorkspaceName, this.Name);
                if (existingSqlPool != null)
                {
                    throw new SynapseException(string.Format(Resources.SynapseSqlPoolExists, this.Name, this.ResourceGroupName, this.WorkspaceName));
                }

                var createParams = new SqlPoolV3
                {
                    Location = existingWorkspace.Location,
                    Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true)
                };

                switch (this.ParameterSetName)
                {
                    case CreateByNameParameterSet:
                    case CreateByParentObjectParameterSet:
                        createParams.Sku = new Sku
                        {
                            Name = this.PerformanceLevel
                        };
                        break;
                    default: throw new SynapseException(string.Format(Resources.InvalidParameterSet, this.ParameterSetName));
                }

                if (this.ShouldProcess(this.Name, string.Format(Resources.CreatingSynapseSqlPool, this.ResourceGroupName, this.WorkspaceName, this.Name)))
                {
                    var result = new PSSynapseSqlPoolV3(this.SynapseAnalyticsClient.CreateSqlPoolV3(this.ResourceGroupName, this.WorkspaceName, this.Name, createParams));
                    WriteObject(result);
                }
            }
            else
            {
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
                    case CreateByNameParameterSet:
                    case CreateByParentObjectParameterSet:
                        createParams.CreateMode = SynapseSqlPoolCreateMode.Default;
                        createParams.Collation = this.IsParameterBound(c => c.Collation) ? this.Collation : SynapseConstants.DefaultCollation;
                        createParams.Sku = new Sku
                        {
                            Name = this.PerformanceLevel
                        };
                        break;

                    case CreateFromBackupNameByNameParameterSet:
                    case CreateFromBackupNameByParentObjectParameterSet:
                    case CreateFromBackupIdByNameParameterSet:
                    case CreateFromBackupIdByParentObjectParameterSet:
                    case CreateFromBackupInputObjectByNameParameterSet:
                        createParams.CreateMode = SynapseSqlPoolCreateMode.Recovery;
                        createParams.RecoverableDatabaseId = this.BackupResourceId;
                        break;

                    case CreateFromRestorePointNameByNameParameterSet:
                    case CreateFromRestorePointNameByParentObjectParameterSet:
                    case CreateFromRestorePointIdByNameParameterSet:
                    case CreateFromRestorePointIdByParentObjectParameterSet:
                    case CreateFromRestorePointInputObjectByNameParameterSet:
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

                if (this.ShouldProcess(this.Name, string.Format(Resources.CreatingSynapseSqlPool, this.ResourceGroupName, this.WorkspaceName, this.Name)))
                {
                    var result = new PSSynapseSqlPool(this.SynapseAnalyticsClient.CreateSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name, createParams));
                    WriteObject(result);
                }
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
