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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.DataClassification;
using Microsoft.Azure.Commands.Synaspe.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + DataClassificationCommon.SqlPoolSensitivityClassification,
        DefaultParameterSetName = DataClassificationCommon.SqlPoolObjectParameterSet),
        OutputType(typeof(SqlPoolSensitivityClassificationModel))]
    public class GetAzureSynapseSqlPoolSensitivityClassification : AzureSynapseSqlPoolManagementCmdletBase<SqlPoolSensitivityClassificationModel, DataClassificationAdapter>
    {
        [Parameter(
            ParameterSetName = DataClassificationCommon.SqlPoolParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = DataClassificationCommon.ResourceGroupNameHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = DataClassificationCommon.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.SqlPoolParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = DataClassificationCommon.WorkspaceNameHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = DataClassificationCommon.WorkspaceNameHelpMessage)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.SqlPoolParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = DataClassificationCommon.SqlPoolNameHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = DataClassificationCommon.SqlPoolNameHelpMessage)]
        [ResourceNameCompleter(ResourceTypes.SqlPool, nameof(ResourceGroupName), nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public override string SqlPoolName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.SqlPoolObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = DataClassificationCommon.SqlPoolObjectHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.SqlPoolObjectColumnParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = DataClassificationCommon.SqlPoolObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSSynapseSqlPool SqlPoolObject { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.SchemaNameHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.SqlPoolObjectColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.SchemaNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string SchemaName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.TableNameHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.SqlPoolObjectColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.TableNameHelpMessage)]
        public string TableName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.ColumnNameHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.SqlPoolObjectColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.ColumnNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ColumnName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = DataClassificationCommon.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        protected override SqlPoolSensitivityClassificationModel GetEntity()
        {
            if (SqlPoolObject != null)
            {
                var resourceIdentifier = new ResourceIdentifier(SqlPoolObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SqlPoolName = resourceIdentifier.ResourceName;
            }

            return new SqlPoolSensitivityClassificationModel()
            {
                ResourceGroupName = ResourceGroupName,
                WorkspaceName = WorkspaceName,
                SqlPoolName = SqlPoolName,
                SensitivityLabels = ParameterSetName == DataClassificationCommon.ColumnParameterSet ||
                    ParameterSetName == DataClassificationCommon.SqlPoolObjectColumnParameterSet
                    ? ModelAdapter.GetCurrentSensitivityLabel(
                        ResourceGroupName, WorkspaceName, SqlPoolName, SchemaName, TableName, ColumnName)
                    : ModelAdapter.GetCurrentSensitivityLabels(ResourceGroupName, WorkspaceName, SqlPoolName)
            };
        }

        protected override DataClassificationAdapter InitModelAdapter()
        {
            return new DataClassificationAdapter(DefaultProfile.DefaultContext);
        }
    }
}
