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

using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Management.DataMigration.Models;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationSyncSelectedDBObject"), OutputType(typeof(MigrateSqlServerSqlDbSyncTaskInput))]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsSyncSelectedDBObject", "New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsSyncSelectedDB", "New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationSyncSelectedDB")]
    public class NewDataMigrationSyncSelectedDBObject : DataMigrationCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the target database"
        )]
        [ValidateNotNullOrEmpty]
        public string TargetDatabaseName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Schema name to be migrated"
        )]
        [ValidateNotNullOrEmpty]
        public string SchemaName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Mapping of source to target tables"
        )]
        [ValidateNotNullOrEmpty]
        public Hashtable TableMap { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Migration settings which tune the migration behavior"
        )]
        [ValidateNotNullOrEmpty]
        public Hashtable MigrationSetting { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Source settings to tune source endpoint migration behavior"
        )]
        [ValidateNotNullOrEmpty]
        public Hashtable SourceSetting { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Target settings to tune target endpoint migration behavior"
        )]
        [ValidateNotNullOrEmpty]
        public Hashtable TargetSetting { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the source database."
        )]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        public string SourceDatabaseName { get; set; }

        public override void ExecuteCmdlet()
        {
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
        }
    }
}
