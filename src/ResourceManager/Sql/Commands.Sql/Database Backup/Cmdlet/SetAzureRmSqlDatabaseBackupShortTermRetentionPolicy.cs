using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Database_Backup.Model;

namespace Microsoft.Azure.Commands.Sql.Database_Backup.Cmdlet
{
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabaseBackupShortTermRetentionPolicy",
    DefaultParameterSetName = PolicyByResourceServerDatabaseSet,
    SupportsShouldProcess = true,
    ConfirmImpact = ConfirmImpact.Low),
    OutputType(typeof(AzureSqlDatabaseBackupShortTermRetentionPolicyModel))]
    public class SetAzureRmSqlDatabaseBackupShortTermRetentionPolicy : AzureSqlDatabaseBackupShortTermRetentionPolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets backup retention days.
        /// </summary>
        [Parameter(ParameterSetName = PolicyByResourceServerDatabaseSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The name of the Azure SQL Database to use.")]
        [ValidateNotNullOrEmpty]
        //[ValidateScript(new ScriptBlock()]
        [ValidateRetentionDays]
        public int RetentionDays{ get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> GetEntity()
        {
            ICollection<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> results = new List<AzureSqlDatabaseBackupShortTermRetentionPolicyModel>()
            {
                ModelAdapter.GetDatabaseBackupShortTermRetentionPolicy(
                    this.ResourceGroupName,
                    this.ServerName,
                    this.DatabaseName)
            };

            return results;
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> model)
        {
            return new List<AzureSqlDatabaseBackupShortTermRetentionPolicyModel>()
            {
                new AzureSqlDatabaseBackupShortTermRetentionPolicyModel(
                    ResourceGroupName,
                    ServerName,
                    DatabaseName,
                    new Management.Sql.Models.BackupShortTermRetentionPolicy(retentionDays: RetentionDays))
            };
        }

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> PersistChanges(IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> entity)
        {
            if (ShouldProcess(DatabaseName))
            {
                return new List<AzureSqlDatabaseBackupShortTermRetentionPolicyModel>() {
                    ModelAdapter.SetDatabaseBackupShortTermRetentionPolicy(this.ResourceGroupName, this.ServerName, this.DatabaseName, entity.First())
                };
            }
            else
            {
                return null;
            }
        }

        public override void ExecuteCmdlet()
        {
            if (this.RetentionDays % 7 != 0)
            {
                
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Custom validator for retention days.
        /// TODO: Remove when server-side enforcement has been deployed.
        /// </summary>
        class ValidateRetentionDaysAttribute : ValidateArgumentsAttribute
        {
            protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
            {
                // Retention is only accepted in week intervals.
                if ((int)arguments % 7 != 0)
                {
                    throw new PSArgumentException("Backup retention must be in 7-day intervals (7, 14, 21, etc.");
                }
            }
        }
    }
}

