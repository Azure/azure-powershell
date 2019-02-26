using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DefinitionsCommon.SqlDatabaseSensitivityClassification,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class SetAzSqlDatabaseSensitivityClassification : AzureSqlDatabaseCmdletBase<SqlDatabaseSensitivityClassificationModel, DataClassificationAdapter>
    {
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
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = DefinitionsCommon.ServerNameHelpMessage)]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string ServerName { get; set; }

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
            ParameterSetName = DefinitionsCommon.DatabaseObjectColumnParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = DefinitionsCommon.SqlDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public AzureSqlDatabaseModel DatabaseObject { get; set; }

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
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DefinitionsCommon.LabelNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseObjectColumnParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DefinitionsCommon.LabelNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string SensitivityLabel { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DefinitionsCommon.InformationTypeHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseObjectColumnParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DefinitionsCommon.InformationTypeHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string InformationType { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ClassificationObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = DefinitionsCommon.SqlDatabaseSensitivityClassificationObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SqlDatabaseSensitivityClassificationModel ClassificationObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = DefinitionsCommon.PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = DefinitionsCommon.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        protected override SqlDatabaseSensitivityClassificationModel GetEntity()
        {
            if (ClassificationObject != null)
            {
                ResourceGroupName = ClassificationObject.ResourceGroupName;
                ServerName = ClassificationObject.ServerName;
                DatabaseName = ClassificationObject.DatabaseName;
            }

            IList<SensitivityLabelModel> sensitivityLabels = null;
            try
            {
                sensitivityLabels = ParameterSetName == DefinitionsCommon.ColumnParameterSet ?
                    ModelAdapter.GetCurrentSensitivityLabel(ResourceGroupName, ServerName, DatabaseName, SchemaName, TableName, ColumnName) :
                    ModelAdapter.GetCurrentSensitivityLabels(ResourceGroupName, ServerName, DatabaseName);
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
                SensitivityLabels = sensitivityLabels
            };
        }

        protected override SqlDatabaseSensitivityClassificationModel ApplyUserInputToModel(SqlDatabaseSensitivityClassificationModel model)
        {
            if (model.SensitivityLabels == null)
            {
                model.SensitivityLabels = new List<SensitivityLabelModel>();
            }

            if (ParameterSetName == DefinitionsCommon.ColumnParameterSet)
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

                if (SensitivityLabel != null)
                {
                    sensitivityLabelModel.SensitivityLabel = SensitivityLabel;
                }

                if (InformationType != null)
                {
                    sensitivityLabelModel.InformationType = InformationType;
                }
            }
            else
            {

            }

            return model;
        }

        protected override DataClassificationAdapter InitModelAdapter()
        {
            return new DataClassificationAdapter(DefaultProfile.DefaultContext);
        }

        protected override bool WriteResult()
        {
            return PassThru;
        }
    }
}
