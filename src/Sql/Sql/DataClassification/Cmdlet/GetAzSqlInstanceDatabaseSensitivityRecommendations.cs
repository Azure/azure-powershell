using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using Microsoft.Azure.Commands.Sql.DataClassification.Services;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseSensitivityRecommendations"),
        OutputType(typeof(ManagedDatabaseSensitivityClassificationModel))]
    public class GetAzSqlInstanceDatabaseSensitivityRecommendations : AzureSqlCmdletBase<ManagedDatabaseSensitivityClassificationModel, DataClassificationAdapter>
    {
        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = DataClassificationCommon.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = DataClassificationCommon.InstanceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = DataClassificationCommon.ManagedDatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.DatabaseObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = DataClassificationCommon.ManagedDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public AzureSqlManagedDatabaseModel DatabaseObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = DataClassificationCommon.AsJobHelpMessage)]
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
                SensitivityLabels = ModelAdapter.GetManagedDatabaseRecommendedSensitivityLabels(
                    ResourceGroupName, InstanceName, DatabaseName)
            };
        }

        protected override DataClassificationAdapter InitModelAdapter()
        {
            return new DataClassificationAdapter(DefaultProfile.DefaultContext);
        }
    }
}
