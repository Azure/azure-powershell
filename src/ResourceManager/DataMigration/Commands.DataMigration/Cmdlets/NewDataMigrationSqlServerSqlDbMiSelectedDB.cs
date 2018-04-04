// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewDataMigrationSqlServerSqlDbMiSelectedDB.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AzureRmDataMigrationSqlServerSqlDbMiSelectedDB", SupportsShouldProcess = true), OutputType(typeof(MigrateSqlServerSqlMIDatabaseInput))]
    [Alias("New-AzureRmDmsSqlServerSqlDbMiSelectedDB")]
    public class NewDataMigrationSqlServerSqlDbMiSelectedDB : DataMigrationCmdlet
    {
        [Parameter(
                   Mandatory = true,
                   HelpMessage = "The name of the source database."
               )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
                   Mandatory = true,
                   HelpMessage = "The name of the database to be restored."
               )]
        [ValidateNotNullOrEmpty]
        public string RestoreDatabaseName { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "File share where the source server database files for this database should be backed up. " +
                            "Use this setting to override file share information for each database. " +
                            "Use fully qualified domain name for the server."
           )]
        public FileShare BackupFileShare { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Name, Resources.createSelectedDB))
            {
                MigrateSqlServerSqlMIDatabaseInput input = new MigrateSqlServerSqlMIDatabaseInput
                {
                    Name = Name,
                    RestoreDatabaseName = RestoreDatabaseName,
                    BackupFileShare = BackupFileShare,
                };

                WriteObject(input);
            }
        }
    }
}
