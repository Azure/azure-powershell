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
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using Microsoft.Azure.Commands.Sql.DataClassification.Services;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseSensitivityRecommendation",
        DefaultParameterSetName = DataClassificationCommon.DatabaseObjectParameterSet),
        OutputType(typeof(ManagedDatabaseSensitivityClassificationModel))]
    public class GetAzSqlInstanceDatabaseSensitivityRecommendation : AzureSqlCmdletBase<ManagedDatabaseSensitivityClassificationModel, DataClassificationAdapter>
    {
        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = DataClassificationCommon.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = DataClassificationCommon.InstanceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = DataClassificationCommon.ManagedDatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = DataClassificationCommon.ManagedDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public AzureSqlManagedDatabaseModel DatabaseObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = DataClassificationCommon.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        protected override ManagedDatabaseSensitivityClassificationModel GetEntity()
        {
            if (DatabaseObject != null)
            {
                ResourceGroupName = DatabaseObject.ResourceGroupName;
                InstanceName = DatabaseObject.ManagedInstanceName;
                DatabaseName = DatabaseObject.Name;
            }

            return new ManagedDatabaseSensitivityClassificationModel()
            {
                ResourceGroupName = ResourceGroupName,
                InstanceName = InstanceName,
                DatabaseName = DatabaseName,
                SensitivityLabels = ModelAdapter.GetManagedDatabaseRecommendedSensitivityLabels(
                    ResourceGroupName, InstanceName, DatabaseName)
            };
        }

        protected override DataClassificationAdapter InitModelAdapter()
        {
            return new DataClassificationAdapter(DefaultProfile.DefaultContext);
        }
    }
}
