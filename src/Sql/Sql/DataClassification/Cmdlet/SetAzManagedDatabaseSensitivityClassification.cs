using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using Microsoft.Azure.Commands.Sql.DataClassification.Services;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DefinitionsCommon.ManagedDatabaseSensitivityClassification,
        SupportsShouldProcess = true)]
    public class SetAzManagedDatabaseSensitivityClassification : AzureSqlCmdletBase<ManagedDatabaseSensitivityClassificationModel, DataClassificationAdapter>
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
            HelpMessage = DefinitionsCommon.InstanceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = DefinitionsCommon.ManagedDatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
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
        public string TableName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
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
        [ValidateNotNullOrEmpty]
        public string LabelName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ColumnParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DefinitionsCommon.InformationTypeHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string InformationType { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ParentResourceParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = DefinitionsCommon.ManagedDatabaseInputObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public ManagedDatabaseSensitivityClassificationModel InputObject { get; set; }

        protected override ManagedDatabaseSensitivityClassificationModel GetEntity()
        {
            return InputObject ?? new ManagedDatabaseSensitivityClassificationModel
            {
                ResourceGroupName = ResourceGroupName,
                InstanceName = InstanceName,
                DatabaseName = DatabaseName,
                SensitivityLabels = new List<SensitivityLabel>()
                    {
                        new SensitivityLabel
                        {
                            SchemaName  = SchemaName,
                            TableName = TableName,
                            ColumnName = ColumnName,
                            InformationType = InformationType,
                            LabelName = LabelName
                        }
                    }
            };
        }

        protected override DataClassificationAdapter InitModelAdapter()
        {
            throw new NotImplementedException();
        }
    }
}
