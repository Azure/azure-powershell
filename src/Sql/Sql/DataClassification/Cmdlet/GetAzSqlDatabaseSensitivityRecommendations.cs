using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using Microsoft.Azure.Commands.Sql.DataClassification.Services;
using Microsoft.Azure.Commands.Sql.Database.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseSensitivityRecommendations"),
        OutputType(typeof(SqlDatabaseSensitivityClassificationModel))]
    public class GetAzSqlDatabaseSensitivityRecommendations : AzureSqlDatabaseCmdletBase<SqlDatabaseSensitivityClassificationModel, DataClassificationAdapter>
    {
        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseParameterSet,
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
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string ServerName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseParameterSet,
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
        [ValidateNotNullOrEmpty]
        public AzureSqlDatabaseModel InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = DefinitionsCommon.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        protected override SqlDatabaseSensitivityClassificationModel GetEntity()
        {
            SqlDatabaseSensitivityClassificationModel model = new SqlDatabaseSensitivityClassificationModel()
            {
                ResourceGroupName = InputObject == null ? ResourceGroupName : InputObject.ResourceGroupName,
                ServerName = InputObject == null ? ServerName : InputObject.ServerName,
                DatabaseName = InputObject == null ? DatabaseName : InputObject.DatabaseName,
                SensitivityLabels = new List<SensitivityLabel>()
                {
                    new SensitivityLabel
                    {
                        ColumnName = "column1",
                        TableName = "table1",
                        SchemaName = "schema1",
                        LabelName = "label1",
                        InformationType = "informationType1"
                    },
                    new SensitivityLabel
                    {
                        ColumnName = "column2",
                        TableName = "table2",
                        SchemaName = "schema2",
                        LabelName = "label2",
                        InformationType = null
                    },
                    new SensitivityLabel
                    {
                        ColumnName = "column2",
                        TableName = "table2",
                        SchemaName = "schema2",
                        LabelName = "label2",
                        InformationType = null
                    },
                }
            };

            return model;
        }

        protected override DataClassificationAdapter InitModelAdapter()
        {
            return new DataClassificationAdapter();
        }
    }
}
