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
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DataClassificationCommon.SqlInstanceDatabaseSensitivityClassification,
        DefaultParameterSetName = DataClassificationCommon.ClassificationObjectParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveAzSqlInstanceDatabaseSensitivityClassification : ModifyAzSqlInstanceDatabaseSensitivityClassificationCmdlet
    {
        protected override ManagedDatabaseSensitivityClassificationModel GetEntity()
        {
            if (ClassificationObject != null)
            {
                return ClassificationObject;
            }
            else if (DatabaseObject != null)
            {
                ResourceGroupName = DatabaseObject.ResourceGroupName;
                InstanceName = DatabaseObject.ManagedInstanceName;
                DatabaseName = DatabaseObject.Name;
            }

            return new ManagedDatabaseSensitivityClassificationModel
            {
                ResourceGroupName = ResourceGroupName,
                InstanceName = InstanceName,
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

        protected override ManagedDatabaseSensitivityClassificationModel PersistChanges(ManagedDatabaseSensitivityClassificationModel entity)
        {
            ModelAdapter.RemoveManagedDatabaseSensitivityLabels(entity);
            return null;
        }
    }
}
