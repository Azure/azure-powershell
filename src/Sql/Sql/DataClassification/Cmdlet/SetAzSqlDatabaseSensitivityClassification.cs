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
using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using Microsoft.Azure.Commands.Sql.DataClassification.Services;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DataClassificationCommon.SqlDatabaseSensitivityClassification,
        DefaultParameterSetName = DataClassificationCommon.ClassificationObjectParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class SetAzSqlDatabaseSensitivityClassification : ModifyAzSqlDatabaseSensitivityClassificationCmdlet
    {
        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.LabelNameHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseObjectColumnParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.LabelNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string SensitivityLabel { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.InformationTypeHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseObjectColumnParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.InformationTypeHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string InformationType { get; set; }

        protected override SqlDatabaseSensitivityClassificationModel GetEntity()
        {
            if (ClassificationObject != null)
            {
                ResourceGroupName = ClassificationObject.ResourceGroupName;
                ServerName = ClassificationObject.ServerName;
                DatabaseName = ClassificationObject.DatabaseName;
            }
            else if (DatabaseObject != null)
            {
                ResourceGroupName = DatabaseObject.ResourceGroupName;
                ServerName = DatabaseObject.ServerName;
                DatabaseName = DatabaseObject.DatabaseName;
            }

            List<SensitivityLabelModel> sensitivityLabels = null;
            try
            {
                sensitivityLabels = ParameterSetName == DataClassificationCommon.ColumnParameterSet
                    || ParameterSetName == DataClassificationCommon.DatabaseObjectColumnParameterSet
                    ? ModelAdapter.GetCurrentSensitivityLabel(ResourceGroupName, ServerName, DatabaseName, SchemaName, TableName, ColumnName)
                    : ModelAdapter.GetCurrentSensitivityLabels(ResourceGroupName, ServerName, DatabaseName);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != HttpStatusCode.NotFound || e.Message != "The specified sensitivity label could not be found")
                {
                    throw;
                }
            }

            return new SqlDatabaseSensitivityClassificationModel
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                DatabaseName = DatabaseName,
                SensitivityLabels = sensitivityLabels ?? new List<SensitivityLabelModel>()
            };
        }

        protected override SqlDatabaseSensitivityClassificationModel ApplyUserInputToModel(SqlDatabaseSensitivityClassificationModel model)
        {
            InformationProtectionPolicy informationProtectionPolicy = ModelAdapter.RetrieveInformationProtectionPolicyAsync().Result;
            if (ParameterSetName == DataClassificationCommon.ColumnParameterSet ||
                ParameterSetName == DataClassificationCommon.DatabaseObjectColumnParameterSet)
            {
                SensitivityLabelModel sensitivityLabelModel = model.SensitivityLabels.FirstOrDefault();
                if (sensitivityLabelModel == null)
                {
                    sensitivityLabelModel = new SensitivityLabelModel
                    {
                        SchemaName = SchemaName,
                        TableName = TableName,
                        ColumnName = ColumnName,
                    };

                    model.SensitivityLabels.Add(sensitivityLabelModel);
                }

                sensitivityLabelModel.ApplyInput(InformationType, SensitivityLabel, informationProtectionPolicy);
            }
            else
            {
                model.ApplyModel(ClassificationObject, informationProtectionPolicy);
            }

            return model;
        }

        protected override SqlDatabaseSensitivityClassificationModel PersistChanges(SqlDatabaseSensitivityClassificationModel entity)
        {
            ModelAdapter.SetSensitivityLabels(entity);
            return null;
        }
    }
}
