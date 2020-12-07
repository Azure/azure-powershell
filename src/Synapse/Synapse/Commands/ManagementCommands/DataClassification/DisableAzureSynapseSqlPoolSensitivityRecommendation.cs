using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.DataClassification;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(
        VerbsLifecycle.Disable,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix  + SynapseConstants.SynapsePrefix + DataClassificationCommon.SqlPoolSensitivityRecommendation,
        DefaultParameterSetName = DataClassificationCommon.InputObjectParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class DisableAzureSynapseSqlPoolSensitivityRecommendation : ModifyAzureSynapseSqlPoolSensitivityRecommendationCmdlet
    {
        protected override SqlPoolSensitivityClassificationModel GetEntity()
        {
            if (InputObject != null)
            {
                return InputObject;
            }
            else if (SqlPoolObject != null)
            {
                var resourceIdentifier = new ResourceIdentifier(SqlPoolObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SqlPoolName = resourceIdentifier.ResourceName;
            }

            return new SqlPoolSensitivityClassificationModel
            {
                ResourceGroupName = ResourceGroupName,
                WorkspaceName = WorkspaceName,
                SqlPoolName = SqlPoolName,
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

        protected override SqlPoolSensitivityClassificationModel PersistChanges(SqlPoolSensitivityClassificationModel entity)
        {
            ModelAdapter.DisableSensitivityRecommendations(entity);
            return null;
        }
    }
}
