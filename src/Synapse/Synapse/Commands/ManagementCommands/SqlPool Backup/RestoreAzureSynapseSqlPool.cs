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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
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

        // Restore from restore point
        private const string RestoreFromRestorePointIdByNameParameterSet = "RestoreFromRestorePointIdByNameParameterSet";
        private const string RestoreFromRestorePointIdByParentObjectParameterSet = "RestoreFromRestorePointIdByParentObjectParameterSet";

        // Restore from dropped sql pool
        private const string RestoreFromDroppedSqlPoolByNameParameterSet = "RestoreFromDroppedSqlPoolByNameParameterSet";
        private const string RestoreFromDroppedSqlPoolByParentObjectParameterSet = "RestoreFromDroppedSqlPoolByParentObjectParameterSet";

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

        [Parameter(ParameterSetName = RestoreFromDroppedSqlPoolByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        [Parameter(ParameterSetName = RestoreFromDroppedSqlPoolByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.FromRestorePoint)]
        public SwitchParameter FromDroppedSqlPool { get; set; }

        [Parameter(ParameterSetName = RestoreFromBackupIdByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = RestoreFromDroppedSqlPoolByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = RestoreFromBackupIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = RestoreFromDroppedSqlPoolByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = RestoreFromBackupIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = RestoreFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = RestoreFromDroppedSqlPoolByParentObjectParameterSet,
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
        [Parameter(ParameterSetName = RestoreFromDroppedSqlPoolByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceDatabaseId)]
        [Parameter(ParameterSetName = RestoreFromDroppedSqlPoolByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SourceDatabaseId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = RestoreFromRestorePointIdByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RestorePoint)]
        [Parameter(ParameterSetName = RestoreFromRestorePointIdByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.RestorePoint)]
        [Alias(SynapseConstants.PointInTime)]
        public DateTime RestorePoint { get; set; }

        [Parameter(ParameterSetName = RestoreFromDroppedSqlPoolByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.DeletionDate)]
        [Parameter(ParameterSetName = RestoreFromDroppedSqlPoolByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.DeletionDate)]
        public DateTime DeletionDate { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.Tag)]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.StorageAccountType)]
        [ValidateSet(Management.Synapse.Models.StorageAccountType.GRS, Management.Synapse.Models.StorageAccountType.LRS, IgnoreCase = true)]
        [ValidateNotNull]
        public string StorageAccountType { get; set; }

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
                throw new AzPSResourceNotFoundCloudException(string.Format(Resources.WorkspaceDoesNotExist, this.WorkspaceName));
            }

            var createParams = new SqlPool
            {
                Location = existingWorkspace.Location,
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true),
                StorageAccountType = this.StorageAccountType
            };

            switch (this.ParameterSetName)
            {
                case RestoreFromBackupIdByNameParameterSet:
                case RestoreFromBackupIdByParentObjectParameterSet:
                    createParams.CreateMode = SynapseSqlPoolCreateMode.Recovery;
                    createParams.RecoverableDatabaseId = this.ResourceId;
                    break;

                case RestoreFromDroppedSqlPoolByNameParameterSet:
                case RestoreFromDroppedSqlPoolByParentObjectParameterSet:
                    createParams.CreateMode = SynapseSqlPoolCreateMode.Restore;
                    createParams.SourceDatabaseId = this.ResourceId;
                    createParams.SourceDatabaseDeletionDate = this.DeletionDate;
                    break;

                case RestoreFromRestorePointIdByNameParameterSet:
                case RestoreFromRestorePointIdByParentObjectParameterSet:
                    createParams.CreateMode = SynapseSqlPoolCreateMode.PointInTimeRestore;
                    createParams.SourceDatabaseId = this.ResourceId;
                    createParams.RestorePointInTime = this.RestorePoint;
                    createParams.Sku = new Sku
                    {
                        Name = this.PerformanceLevel
                    };

                    break;

                default: throw new AzPSInvalidOperationException(string.Format(Resources.InvalidParameterSet, this.ParameterSetName));
            }

            if (this.ShouldProcess(this.Name, string.Format(Resources.RestoringSynapseSqlPool, this.ResourceId, this.ResourceGroupName, this.WorkspaceName, this.Name)))
            {
                var result = new PSSynapseSqlPool(this.ResourceGroupName, this.WorkspaceName, this.SynapseAnalyticsClient.CreateSqlPool(this.ResourceGroupName, this.WorkspaceName, this.Name, createParams));
                WriteObject(result);
            }
        }
    }
}
