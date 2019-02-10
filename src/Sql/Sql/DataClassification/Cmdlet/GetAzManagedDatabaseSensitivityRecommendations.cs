using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using Microsoft.Azure.Commands.Sql.DataClassification.Services;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Cmdlet
{
    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedDatabaseSensitivityRecommendations"),
        OutputType(typeof(ManagedDatabaseSensitivityClassificationModel))]
    public class GetAzManagedDatabaseSensitivityRecommendations : AzureSqlCmdletBase<ManagedDatabaseSensitivityClassificationModel, DataClassificationAdapter>
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
            HelpMessage = DefinitionsCommon.InstanceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.DatabaseParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = DefinitionsCommon.ManagedDatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.ParentResourceParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = DefinitionsCommon.ManagedDatabaseInputObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedDatabaseModel InputObject { get; set; }

        protected override ManagedDatabaseSensitivityClassificationModel GetEntity()
        {
            ManagedDatabaseSensitivityClassificationModel model = new ManagedDatabaseSensitivityClassificationModel()
            {
                ResourceGroupName = InputObject == null ? ResourceGroupName : InputObject.ResourceGroupName,
                InstanceName  = InputObject == null ? InstanceName : InputObject.ManagedInstanceName,
                DatabaseName = InputObject == null ? DatabaseName : InputObject.Name,
                SensitivityLabels = new List<SensitivityLabel>()
            };

            return model;
        }

        protected override DataClassificationAdapter InitModelAdapter()
        {
            throw new System.NotImplementedException();
        }
    }
}
