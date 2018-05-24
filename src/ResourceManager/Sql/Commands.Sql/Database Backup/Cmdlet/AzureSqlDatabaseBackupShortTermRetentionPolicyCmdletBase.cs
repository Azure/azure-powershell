using System.Collections.Generic;
using Microsoft.Azure.Commands.Sql.Backup.Services;
using Microsoft.Azure.Commands.Sql.Common;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Database_Backup.Model;
using Microsoft.Azure.Commands.Sql.Database.Model;

namespace Microsoft.Azure.Commands.Sql.Database_Backup.Cmdlet
{
    public abstract class AzureSqlDatabaseBackupShortTermRetentionPolicyCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel>, AzureSqlDatabaseBackupAdapter>
    {
        /// <summary>
        /// Parameter set with ResourceGroup name, Server name and Database name.
        /// </summary>
        protected const string PolicyByResourceServerDatabaseSet = "PolicyByResourceServerDatabase";

        /// <summary>
        /// Parameter set for using a Database Input Object.
        /// </summary>
        private const string PolicyByInputObjectSet = "PolicyByInputObject";

        /// <summary>
        /// Parameter set for using a Database Resource ID.
        /// </summary>
        private const string PolicyByResourceIdSet = "PolicyByResourceId";

        /// <summary>
        /// Gets or sets the Database object to get the policy for.
        /// </summary>
        [Parameter(ParameterSetName = PolicyByInputObjectSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The database object to get backups for.")]
        //[ValidateNotNullOrEmpty]
        public AzureSqlDatabaseModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the Database Resource ID to get backups for.
        /// </summary>
        [Parameter(ParameterSetName = PolicyByResourceIdSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The database Resource ID to get backups for.")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(ParameterSetName = PolicyByResourceServerDatabaseSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server the database is in.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(ParameterSetName = PolicyByResourceServerDatabaseSet,
                Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database to use.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <param name="subscription">The subscription to operate on</param>
        /// <returns></returns>
        protected override AzureSqlDatabaseBackupAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new AzureSqlDatabaseBackupAdapter(DefaultProfile.DefaultContext);
        }
    }
}
