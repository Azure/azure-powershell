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
