using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using Microsoft.Azure.Commands.Sql.DataClassification.Services;
using Microsoft.Azure.Commands.Sql.Database.Model;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DefinitionsCommon.SqlDatabaseSensitivityClassification),
        OutputType(typeof(SqlDatabaseSensitivityClassificationModel))]
    public class GetAzSqlDatabaseSensitivityClassification : AzureSqlDatabaseCmdletBase<SqlDatabaseSensitivityClassificationModel, DataClassificationAdapter>
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
            HelpMessage = DefinitionsCommon.ServerNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = DefinitionsCommon.ServerNameHelpMessage)]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string ServerName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = DefinitionsCommon.DatabaseNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = DefinitionsCommon.DatabaseNameHelpMessage)]
        [ResourceNameCompleter("Microsoft.Sql/servers/databases", "ResourceGroupName", "ServerName")]
        [ValidateNotNullOrEmpty]
        public override string DatabaseName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ParentResourceParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = DefinitionsCommon.SqlDatabaseInputObjectHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.ParentResourceColumnParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = DefinitionsCommon.SqlDatabaseInputObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public AzureSqlDatabaseModel InputObject { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DefinitionsCommon.SchemaNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.ParentResourceColumnParameterSet,
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
            ParameterSetName = DefinitionsCommon.ParentResourceColumnParameterSet,
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
            ParameterSetName = DefinitionsCommon.ParentResourceColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DefinitionsCommon.ColumnNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ColumnName { get; set; }

        protected override SqlDatabaseSensitivityClassificationModel GetEntity()
        {
            SqlDatabaseSensitivityClassificationModel model = new SqlDatabaseSensitivityClassificationModel()
            {
                ResourceGroupName = InputObject == null ? ResourceGroupName : InputObject.ResourceGroupName,
                ServerName = InputObject == null ? ServerName : InputObject.ServerName,
                DatabaseName = InputObject == null ? DatabaseName : InputObject.DatabaseName,
                SensitivityLabels = new List<SensitivityLabel>()
            };

            return model;
        }

        protected override DataClassificationAdapter InitModelAdapter()
        {
            throw new NotImplementedException();
        }
    }
}
