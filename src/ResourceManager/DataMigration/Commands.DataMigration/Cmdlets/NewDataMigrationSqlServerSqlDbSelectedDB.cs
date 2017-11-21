// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewDataMigrationSqlServerSqlDbSelectedTables.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Management.DataMigration.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AzureRmDataMigrationSqlServerSqlDbSelectedDB", SupportsShouldProcess = true), OutputType(typeof(MigrateSqlServerSqlDbDatabaseInput))]
    [Alias("New-AzureRmDmsSqlServerSqlDbSelectedDB")]
    public class NewDataMigrationSqlServerSqlDbSelectedDB : DataMigrationCmdlet
    {
        [Parameter(
                   Mandatory = false,
                   HelpMessage = "The name of the database."
               )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
                   Mandatory = false,
                   HelpMessage = "The name of the target Database."
               )]
        [ValidateNotNullOrEmpty]
        public string TargetDatabaseName { get; set; }

        [Parameter(
                   Mandatory = false,
                   HelpMessage = "Set Database to readonly before migration"
               )]
        [ValidateNotNullOrEmpty]
        public SwitchParameter MakeSourceDbReadOnly { get; set; }

        [Parameter(
                   Mandatory = false,
                   HelpMessage = "mapping of source to target tables"
               )]
        [ValidateNotNullOrEmpty]
        public IDictionary<string, string> TableMap { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Name, Resources.createSelectedDB))
            {
                MigrateSqlServerSqlDbDatabaseInput input = new MigrateSqlServerSqlDbDatabaseInput();
                input.Name = Name;
                input.MakeSourceDbReadOnly = MakeSourceDbReadOnly;
                input.TargetDatabaseName = TargetDatabaseName;
                input.TableMap = TableMap;

                WriteObject(input);
            }
        }
    }
}
