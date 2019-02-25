using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using Microsoft.Azure.Commands.Sql.DataClassification.Services;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DefinitionsCommon.SqlInstanceDatabaseSensitivityClassification),
        OutputType(typeof(ManagedDatabaseSensitivityClassificationModel))]
    public class GetAzSqlInstanceDatabaseSensitivityClassification : AzureSqlCmdletBase<ManagedDatabaseSensitivityClassificationModel, DataClassificationAdapter>
    {
        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = DefinitionsCommon.ResourceGroupNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = DefinitionsCommon.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = DefinitionsCommon.InstanceNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = DefinitionsCommon.InstanceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = DefinitionsCommon.ManagedDatabaseNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = DefinitionsCommon.ManagedDatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = DefinitionsCommon.ManagedDatabaseObjectHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseObjectColumnParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = DefinitionsCommon.ManagedDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public AzureSqlManagedDatabaseModel DatabaseObject { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DefinitionsCommon.SchemaNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseObjectColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DefinitionsCommon.SchemaNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string SchemaName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DefinitionsCommon.TableNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseObjectColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DefinitionsCommon.TableNameHelpMessage)]
        public string TableName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DefinitionsCommon.ColumnNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseObjectColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DefinitionsCommon.ColumnNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ColumnName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = DefinitionsCommon.AsJobHelpMessage)]
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
                SensitivityLabels = ParameterSetName == DefinitionsCommon.ColumnParameterSet ||
                    ParameterSetName == DefinitionsCommon.DatabaseObjectColumnParameterSet
                    ? ModelAdapter.GetManagedDatabaseCurrentSensitivityLabel(
                        ResourceGroupName, InstanceName, DatabaseName, SchemaName, TableName, ColumnName)
                    : ModelAdapter.GetManagedDatabaseCurrentSensitivityLabels(ResourceGroupName, InstanceName, DatabaseName)
            };
        }

        protected override DataClassificationAdapter InitModelAdapter()
        {
            throw new NotImplementedException();
        }
    }
}
