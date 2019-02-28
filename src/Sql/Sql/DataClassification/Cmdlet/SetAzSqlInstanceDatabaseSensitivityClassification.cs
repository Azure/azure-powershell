using Hyak.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using Microsoft.Azure.Commands.Sql.DataClassification.Services;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DataClassificationCommon.SqlInstanceDatabaseSensitivityClassification,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class SetAzSqlInstanceDatabaseSensitivityClassification : ModifyAzSqlInstanceDatabaseSensitivityClassificationCmdlet
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

        protected override ManagedDatabaseSensitivityClassificationModel GetEntity()
        {
            if (ClassificationObject != null)
            {
                ResourceGroupName = ClassificationObject.ResourceGroupName;
                InstanceName = ClassificationObject.InstanceName;
                DatabaseName = ClassificationObject.DatabaseName;
            }
            else if (DatabaseObject != null)
            {
                ResourceGroupName = DatabaseObject.ResourceGroupName;
                InstanceName = DatabaseObject.ManagedInstanceName;
                DatabaseName = DatabaseObject.Name;
            }

            List<SensitivityLabelModel> sensitivityLabels = null;
            try
            {
                sensitivityLabels = ParameterSetName == DataClassificationCommon.ColumnParameterSet
                    || ParameterSetName == DataClassificationCommon.DatabaseObjectColumnParameterSet
                    ? ModelAdapter.GetCurrentSensitivityLabel(ResourceGroupName, InstanceName, DatabaseName, SchemaName, TableName, ColumnName)
                    : ModelAdapter.GetCurrentSensitivityLabels(ResourceGroupName, InstanceName, DatabaseName);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != HttpStatusCode.NotFound || e.Message != "The specified sensitivity label could not be found")
                {
                    throw;
                }
            }

            return new ManagedDatabaseSensitivityClassificationModel
            {
                ResourceGroupName = ResourceGroupName,
                InstanceName = InstanceName,
                DatabaseName = DatabaseName,
                SensitivityLabels = sensitivityLabels ?? new List<SensitivityLabelModel>()
            };
        }

        protected override ManagedDatabaseSensitivityClassificationModel ApplyUserInputToModel(ManagedDatabaseSensitivityClassificationModel model)
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

        protected override ManagedDatabaseSensitivityClassificationModel PersistChanges(ManagedDatabaseSensitivityClassificationModel entity)
        {
            ModelAdapter.SetSensitivityLabels(entity);
            return null;
        }
    }
}
