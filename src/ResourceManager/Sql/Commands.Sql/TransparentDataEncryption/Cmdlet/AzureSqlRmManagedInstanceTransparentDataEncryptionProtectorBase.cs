using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Adapter;
using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Cmdlet
{
    public abstract class AzureSqlRmManagedInstanceTransparentDataEncryptionProtectorBase : AzureSqlCmdletBase<IEnumerable<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel>, AzureSqlDatabaseTransparentDataEncryptionArmAdapter>
    {
        /// <summary>
        /// Parameter sets
        /// </summary>
        protected const string DefaultParameterSet = "AzureSqlRmManagedInstanceTransparentDataEncryptionProtectorDefaultParameterSet";
        
        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 0,
            HelpMessage = "The Resource Group Name")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the managed instance name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 1,
            HelpMessage = "The managed instance name")]
        [ValidateNotNullOrEmpty]
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <param name="subscription">The subscription the cmdlets are operation under</param>
        /// <returns>The server adapter</returns>
        protected override AzureSqlDatabaseTransparentDataEncryptionArmAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new AzureSqlDatabaseTransparentDataEncryptionArmAdapter(DefaultProfile.DefaultContext);
        }

        /// <summary>
        /// Returns null in default implementation
        /// </summary>
        /// <returns>null, since the certificate does not exist</returns>
        protected override IEnumerable<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> GetEntity()
        {
            return null;
        }

        /// <summary>
        /// Returns input model for default implementation
        /// </summary>
        /// <param name="model"> Model to send to the update API</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> 
            ApplyUserInputToModel(IEnumerable<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> model)
        {
            return model;
        }

        /// <summary>
        /// Returns input model for default implementation
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> 
            PersistChanges(IEnumerable<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> entity)
        {
            return entity;
        }
    }
}