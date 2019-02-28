using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DataClassificationCommon.SqlInstanceDatabaseSensitivityClassification,
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
