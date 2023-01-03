using Microsoft.Azure.Commands.Sql.Database.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Database.Cmdlet
{
    /// <summary>
    /// Cmdlet for Revalidate Azure Sql Database encryption protector
    /// </summary>
    [Cmdlet("Revalidate", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseTransparentDataEncryptionProtector", SupportsShouldProcess = true)]
    public class RevalidateAzureSqlDatabaseTransparentDataEncryptionProtector : AzureSqlDatabaseCmdletBase<AzureSqlDatabaseModel>
    {
        /// <summary>
        /// Gets or sets the name of the database to create.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Azure SQL Database to revalidate.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the revalidate Transparent Data Encryption protector request confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

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
