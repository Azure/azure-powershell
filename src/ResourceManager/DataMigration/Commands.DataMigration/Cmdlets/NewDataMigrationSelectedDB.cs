// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AzureRmDataMigrationSelectedDB", DefaultParameterSetName = SqlServerSqlDbParameterSet), OutputType(typeof(MigrateSqlServerSqlDbDatabaseInput))]
    [Alias("New-AzureRmDmsSelectedDB")]
    public class NewDataMigrationSelectedDB : DataMigrationCmdlet
    {
        private const string SqlServerSqlDbParameterSet = "MigrateSqlServerSqlDb";
        private const string SqlServerSqlDbMiParameterSet = "MigrateSqlServerSqlDbMi";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the source database.",
            ParameterSetName = SqlServerSqlDbMiParameterSet
        )]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the source database.",
            ParameterSetName = SqlServerSqlDbParameterSet
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the target database.",
            ParameterSetName = SqlServerSqlDbMiParameterSet
        )]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the target database.",
            ParameterSetName = SqlServerSqlDbParameterSet
        )]
        [ValidateNotNullOrEmpty]
        public string TargetDatabaseName { get; set; }

        [Parameter(
            ParameterSetName = SqlServerSqlDbMiParameterSet,
            Mandatory = true,
            HelpMessage = "Set migration type to SQL Server to SQL DB MI Migration."
        )]
        public SwitchParameter MigrateSqlServerSqlDbMi { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "File share where the source server database files for this database should be backed up. " +
                "Use this setting to override file share information for each database. " +
                "Use fully qualified domain name for the server.",
            ValueFromPipeline = true,
            ParameterSetName = SqlServerSqlDbMiParameterSet
        )]
        public FileShare BackupFileShare { get; set; }

        [Parameter(
            ParameterSetName = SqlServerSqlDbParameterSet,
            Mandatory = true,
            HelpMessage = "Set migration type to SQL Server to SQL DB Migration."
        )]
        public SwitchParameter MigrateSqlServerSqlDb { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set Database to readonly before migration",
            ParameterSetName = SqlServerSqlDbParameterSet
        )]
        public SwitchParameter MakeSourceDbReadOnly { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "mapping of source to target tables",
            ParameterSetName = SqlServerSqlDbParameterSet
        )]
        [ValidateNotNullOrEmpty]
        public IDictionary<string, string> TableMap { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case SqlServerSqlDbMiParameterSet:
                    MigrateSqlServerSqlMIDatabaseInput selectedDbMI = new MigrateSqlServerSqlMIDatabaseInput
                    {
                        Name = Name,
                        RestoreDatabaseName = TargetDatabaseName,
                        BackupFileShare = BackupFileShare,
                    };
                    WriteObject(selectedDbMI);
                    break;
                default:
                    MigrateSqlServerSqlDbDatabaseInput selectedDbSqlDB = new MigrateSqlServerSqlDbDatabaseInput
                    {
                        Name = Name,
                        MakeSourceDbReadOnly = MakeSourceDbReadOnly,
                        TargetDatabaseName = TargetDatabaseName,
                        TableMap = TableMap
                    };
                    WriteObject(selectedDbSqlDB);
                    break;
            }
        }
    }
}
