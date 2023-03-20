using Microsoft.Azure.Commands.Sql.ExternalGovernance.Model;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ExternalGovernance.Cmdlet
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerExternalGovernanceStatusRefresh", SupportsShouldProcess = true), OutputType(typeof(RefreshExternalGovernanceModel))]
    public class InvokeAzSqlServerExternalGovernanceStatusRefresh : AzureSqlServerRefreshExternalGovernanceCmdletBase
    {
        /// <summary>
        /// Get the refresh external governance status.
        /// </summary>
        /// <returns>Refresh external governance status.</returns>
        protected override RefreshExternalGovernanceModel GetEntity()
        {
            Console.WriteLine("GetEntity");
            return new RefreshExternalGovernanceModel();
        }

        /// <summary>
        /// Apply user input to model.
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override RefreshExternalGovernanceModel ApplyUserInputToModel(RefreshExternalGovernanceModel model)
        {
            model.ResourceGroupName = ResourceGroupName;
            model.ServerName = ServerName;
            return model;
        }

        /// <summary>
        /// Sends the refresh external governance status to the service.
        /// </summary>
        /// <param name="entity">The refresh external governance entity.</param>
        /// <returns>The response object from the service</returns>
        protected override RefreshExternalGovernanceModel PersistChanges(RefreshExternalGovernanceModel entity)
        {
            return ModelAdapter.RefreshExternalGovernanceStatus(entity.ResourceGroupName, entity.ServerName);
        }
    }
}
