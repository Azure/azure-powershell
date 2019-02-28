using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DataClassificationCommon.SqlDatabaseSensitivityClassification,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveAzSqlDatabaseSensitivityClassification : ModifyAzSqlDatabaseSensitivityClassificationCmdlet
    {
        protected override SqlDatabaseSensitivityClassificationModel GetEntity()
        {
            if (ClassificationObject != null)
            {
                return ClassificationObject;
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
            ModelAdapter.RemoveSensitivityLabels(entity);
            return null;
        }
    }
}
