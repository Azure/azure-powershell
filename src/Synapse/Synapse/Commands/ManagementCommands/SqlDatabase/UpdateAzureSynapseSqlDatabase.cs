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
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SqlDatabase,
        DefaultParameterSetName = UpdateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseSqlDatabase))]
    public class UpdateAzureSynapseSqlDatabase : SynapseManagementCmdletBase
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByParentObjectParameterSet = "UpdateByParentObjectParameterSet";
        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = HelpMessages.SqlDatabaseName)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByParentObjectParameterSet, HelpMessage = HelpMessages.SqlDatabaseName)]
        [ResourceNameCompleter(
            ResourceTypes.SqlDatabase,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet, Mandatory = true,
            HelpMessage = HelpMessages.SqlDatabaseObject)]
        [ValidateNotNull]
        public PSSynapseSqlDatabase InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SqlDatabaseResourceId)]
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

            SqlDatabase existingSqlDatabase = null;
            try
            {
                existingSqlDatabase = this.SynapseAnalyticsClient.GetSqlDatabase(this.ResourceGroupName, this.WorkspaceName, this.Name);
            }
            catch
            {
                existingSqlDatabase = null;
            }

            if (existingSqlDatabase == null)
            {
                throw new AzPSResourceNotFoundCloudException(string.Format(Resources.FailedToDiscoverSqlDatabase, this.Name, this.ResourceGroupName, this.WorkspaceName));
            }

            switch (this.ParameterSetName)
            {
                case UpdateByNameParameterSet:
                case UpdateByInputObjectParameterSet:
                case UpdateByParentObjectParameterSet:
                case UpdateByResourceIdParameterSet:
                    UpdateSqlDatabase(existingSqlDatabase);
                    break;

                default: throw new AzPSInvalidOperationException(string.Format(Resources.InvalidParameterSet, this.ParameterSetName));
            }
        }

        private void UpdateSqlDatabase(SqlDatabase existingSqlDatabase)
        {
            SqlDatabaseUpdate SqlDatabaseUpdate = new SqlDatabaseUpdate
            {
                Tags = this.IsParameterBound(c => c.Tag) ? TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true) : existingSqlDatabase.Tags,
            };

            if (this.ShouldProcess(this.Name, string.Format(Resources.UpdatingSynapseSqlDatabase, this.Name, this.ResourceGroupName, this.WorkspaceName)))
            {
                this.SynapseAnalyticsClient.UpdateSqlDatabase(this.ResourceGroupName, this.WorkspaceName, this.Name, SqlDatabaseUpdate);
                if (this.PassThru.IsPresent)
                {
                    var result = this.SynapseAnalyticsClient.GetSqlDatabase(this.ResourceGroupName, this.WorkspaceName, this.Name);
                    WriteObject(result);
                }
            }
        }
    }
}
