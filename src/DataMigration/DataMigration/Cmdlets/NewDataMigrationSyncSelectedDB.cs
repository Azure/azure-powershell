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

using System;
using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Commands.DataMigration.Models.OracleAzureDbPostgreSql;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationSyncSelectedDBObject"), OutputType(typeof(MigrateSqlServerSqlDbSyncTaskInput))]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsSyncSelectedDBObject", "New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsSyncSelectedDB", "New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationSyncSelectedDB")]
    public class NewDataMigrationSyncSelectedDBObject : DataMigrationCmdlet
    {
        private const string SqlServerSqlDbSyncParameterSet = "MigrateSqlServerSqlDbSync";
        private const string OracleAzureDbPostgreSqlSyncParameterSet = "MigrateOracleAzureDbPostgreSqlSync";
        private const string SourceDatabaseNameHelpMessage = "The name of the source database.";
        private const string TargetDatabaseNameHelpMessage = "The name of the target database.";
        private const string MigrationSettingHelpMessage = "Migration settings which tune the migration behavior.";
        private const string SourceSettingHelpMessage = "Source settings to tune source endpoint migration behavior.";
        private const string TargetSettingHelpMessage = "Target settings to tune target endpoint migration behavior.";

        [Parameter(
            Mandatory = true,
            HelpMessage = TargetDatabaseNameHelpMessage,
            ParameterSetName = OracleAzureDbPostgreSqlSyncParameterSet
        )]
        [Parameter(
            Mandatory = true,
            HelpMessage = TargetDatabaseNameHelpMessage,
            ParameterSetName = SqlServerSqlDbSyncParameterSet
        )]
        [ValidateNotNullOrEmpty]
        public string TargetDatabaseName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Copies all tables within this schema, preserving the casing of the source object names, " +
                "or using the value of 'CaseManipulation' if provided. " +
                "Not valid if providing 'TableMap'.",
            ParameterSetName = OracleAzureDbPostgreSqlSyncParameterSet
        )]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Schema name to be migrated",
            ParameterSetName = SqlServerSqlDbSyncParameterSet
        )]
        public string SchemaName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Mapping of source to target for schemas and tables." +
                "Not valid if providing 'SchemaName'.",
            ParameterSetName = OracleAzureDbPostgreSqlSyncParameterSet
        )]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Mapping of source to target tables",
            ParameterSetName = SqlServerSqlDbSyncParameterSet
        )]
        public Hashtable TableMap { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = MigrationSettingHelpMessage,
            ParameterSetName = OracleAzureDbPostgreSqlSyncParameterSet
        )]
        [Parameter(
            Mandatory = false,
            HelpMessage = MigrationSettingHelpMessage,
            ParameterSetName = SqlServerSqlDbSyncParameterSet
        )]
        [ValidateNotNullOrEmpty]
        public Hashtable MigrationSetting { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = SourceSettingHelpMessage,
            ParameterSetName = OracleAzureDbPostgreSqlSyncParameterSet
        )]
        [Parameter(
            Mandatory = false,
            HelpMessage = SourceSettingHelpMessage,
            ParameterSetName = SqlServerSqlDbSyncParameterSet
        )]
        [ValidateNotNullOrEmpty]
        public Hashtable SourceSetting { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = TargetSettingHelpMessage,
            ParameterSetName = OracleAzureDbPostgreSqlSyncParameterSet
        )]
        [Parameter(
            Mandatory = false,
            HelpMessage = TargetSettingHelpMessage,
            ParameterSetName = SqlServerSqlDbSyncParameterSet
        )]
        [ValidateNotNullOrEmpty]
        public Hashtable TargetSetting { get; set; }

        #region SQL Server to SQLDB Specific Parameters

        [Parameter(
            Mandatory = true,
            HelpMessage = SourceDatabaseNameHelpMessage,
            ParameterSetName = SqlServerSqlDbSyncParameterSet
        )]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        public string SourceDatabaseName { get; set; }

        [Parameter(
            ParameterSetName = SqlServerSqlDbSyncParameterSet,
            Mandatory = true,
            HelpMessage = "Set migration type to SQL Server to SQL DB Migration."
        )]
        public SwitchParameter MigrateSqlServerSqlDbSync { get; set; }

        # endregion SQL Server to SQLDB Specific Parameters

        #region Oracle to PostgreSql specific parameters

        [Parameter(
            ParameterSetName = OracleAzureDbPostgreSqlSyncParameterSet,
            Mandatory = true,
            HelpMessage = "Set migration type to Oracle to Azure DB for PostgreSql Migration."
        )]
        public SwitchParameter MigrateOracleAzureDbPostgreSql { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Whether to preserve the casing of source objects or force all target objects to be lower casing. " +
                "Not valid when providing a 'TableMap'.",
            ParameterSetName = OracleAzureDbPostgreSqlSyncParameterSet
        )]
        public CaseManipulationEnum? CaseManipulation { get; set; }

        #endregion Oracle to PostgreSql specific parameters

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case OracleAzureDbPostgreSqlSyncParameterSet:
                    MigrateOracleAzureDbPostgreSqlSyncDatabaseInput selectedOracle = ValidateAndCreateOracleAzureDbPostgreSql();
                    WriteObject(selectedOracle);
                    break;
                default:
                    if (string.IsNullOrEmpty(SchemaName) || (TableMap == null || TableMap.Count == 0))
                    {
                        throw new PSArgumentException("Both schemaName and tableMap must be provided.");
                    }

                    MigrateSqlServerSqlDbSyncDatabaseInput input = new MigrateSqlServerSqlDbSyncDatabaseInput
                    {
                        TargetDatabaseName = TargetDatabaseName,
                        SchemaName = SchemaName,
                        TableMap = Utils.HashtableToDictionary<string, string>(TableMap),
                        MigrationSetting = Utils.HashtableToDictionary<string, string>(MigrationSetting),
                        SourceSetting = Utils.HashtableToDictionary<string, string>(SourceSetting),
                        TargetSetting = Utils.HashtableToDictionary<string, string>(TargetSetting),
                        Name = SourceDatabaseName
                    };
                    WriteObject(input);
                    break;
            }
        }

        private MigrateOracleAzureDbPostgreSqlSyncDatabaseInput ValidateAndCreateOracleAzureDbPostgreSql()
        {
            if (string.IsNullOrEmpty(SchemaName) && (TableMap == null || TableMap.Count == 0))
            {
                throw new PSArgumentException("Either schemaName or tableMap must be provided.");
            }

            if (!string.IsNullOrEmpty(SchemaName) && TableMap != null)
            {
                throw new PSArgumentException("Only provide either schemaName or tableMap to define the scope of migration. Not both.");
            }

            if (CaseManipulation != null && TableMap != null)
            {
                throw new PSArgumentException("When providing tableMap, caseManipulation can not be defined.");
            }

            return new MigrateOracleAzureDbPostgreSqlSyncDatabaseInput()
            {
                CaseManipulation = CaseManipulation.HasValue ? Enum.GetName(typeof(CaseManipulationEnum), CaseManipulation) : null,
                MigrationSetting = Utils.HashtableToDictionary<string, string>(MigrationSetting),
                // If SchemaName is given, name the Attunity Pipeline that, otherwise name it the target database's name
                Name = string.IsNullOrEmpty(SchemaName) ? TargetDatabaseName : SchemaName,
                SchemaName = SchemaName,
                SourceSetting = Utils.HashtableToDictionary<string, string>(SourceSetting),
                // If not providing a TableMap, it's preferred to have null and not an empty dictionary
                TableMap = TableMap == null || TableMap.Keys.Count == 0 ? null : Utils.HashtableToDictionary<string, string>(TableMap),
                TargetDatabaseName = TargetDatabaseName,
                TargetSetting = Utils.HashtableToDictionary<string, string>(TargetSetting)
            };
        }
    }
}
