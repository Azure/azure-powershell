using Microsoft.Azure.Commands.Sql.Database.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Database.Cmdlet
{
    /// <summary>
    /// Cmdlet for Revalidate Azure Sql Database encryption protector
    /// </summary>
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseTransparentDataEncryptionProtectorRevalidation", SupportsShouldProcess = true), OutputType(typeof(AzureSqlDatabaseModel))]
    public class InvokeAzureSqlDatabaseTransparentDataEncryptionProtectorRevalidation : AzureSqlDatabaseCmdletBase<AzureSqlDatabaseModel>
    {
        /// <summary>
        /// Gets or sets the name of the database to revalidate.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Azure SQL Database to revalidate.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        ///  Defines whether the Cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out.
        /// </summary>
        /// <returns>True if the model object should be written out; false otherwise.</returns>
        protected override bool WriteResult() { return PassThru.IsPresent; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>Database entity</returns>
        protected override AzureSqlDatabaseModel GetEntity()
        {
            return ModelAdapter.GetDatabase(this.ResourceGroupName, this.ServerName, this.DatabaseName);
        }

        /// <summary>
        /// Revalidate encryption protector
        /// </summary>
        /// <param name="entity">Database entity</param>
        /// <returns>Database model</returns>
        protected override AzureSqlDatabaseModel PersistChanges(AzureSqlDatabaseModel entity)
        {
            ModelAdapter.RevalidateDatabaseEncryptionProtector(entity.ResourceGroupName, entity.ServerName, entity.DatabaseName);
            return entity;
        }
    }
}
