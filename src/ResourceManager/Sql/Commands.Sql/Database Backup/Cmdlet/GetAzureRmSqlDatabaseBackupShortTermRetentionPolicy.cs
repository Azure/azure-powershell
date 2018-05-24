using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Database_Backup.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.Database_Backup.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlDatabaseBackupShortTermRetentionPolicy")]
    public class GetAzureRmSqlDatabaseBackupShortTermRetentionPolicy : AzureSqlDatabaseBackupShortTermRetentionPolicyCmdletBase
    {
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> GetEntity()
        {
            if (InputObject != null)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                ServerName = InputObject.ServerName;
                DatabaseName = InputObject.DatabaseName;
            }
            else if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                ResourceIdentifier identifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = identifier.ResourceGroupName;
                DatabaseName = identifier.ResourceName;
                identifier = new ResourceIdentifier(identifier.ParentResource);
                ServerName = identifier.ResourceName;
            }

            ICollection<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> results = new List<AzureSqlDatabaseBackupShortTermRetentionPolicyModel>();

            results.Add(ModelAdapter.GetDatabaseBackupShortTermRetentionPolicy(
                ResourceGroupName,
                ServerName,
                DatabaseName));

            return results;
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> ApplyUserInputToModel(
            IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> PersistChanges(
            IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> entity)
        {
            return entity;
        }
    }
}
