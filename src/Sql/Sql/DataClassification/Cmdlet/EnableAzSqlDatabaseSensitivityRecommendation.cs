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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Cmdlet
{
    [Cmdlet(
        VerbsLifecycle.Enable,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DataClassificationCommon.SqlDatabaseSensitivityRecommendation,
        DefaultParameterSetName = DataClassificationCommon.InputObjectParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class EnableAzSqlDatabaseSensitivityRecommendation : ModifyAzSqlDatabaseSensitivityRecommendationCmdlet
    {
        protected override SqlDatabaseSensitivityClassificationModel GetEntity()
        {
            if (InputObject != null)
            {
                return InputObject;
            }
            else if (DatabaseObject != null)
            {
                ResourceGroupName = DatabaseObject.ResourceGroupName;
                ServerName = DatabaseObject.ServerName;
                DatabaseName = DatabaseObject.DatabaseName;
            }

            return new SqlDatabaseSensitivityClassificationModel
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                DatabaseName = DatabaseName,
                SensitivityLabels = new List<SensitivityLabelModel>()
                {
                    new SensitivityLabelModel
                    {
                        SchemaName = SchemaName,
                        TableName = TableName,
                        ColumnName = ColumnName
                    }
                }
            };
        }

        protected override SqlDatabaseSensitivityClassificationModel PersistChanges(SqlDatabaseSensitivityClassificationModel entity)
        {
            ModelAdapter.EnableSensitivityRecommendations(entity);
            return null;
        }
    }
}