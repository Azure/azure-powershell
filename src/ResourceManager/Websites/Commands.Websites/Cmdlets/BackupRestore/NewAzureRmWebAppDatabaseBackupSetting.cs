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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.WebSites.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.BackupRestore
{
    /// <summary>
    /// Modifies the automatic backup configuration for an Azure Web App
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmWebAppDatabaseBackupSetting"), OutputType(typeof(DatabaseBackupSetting))]
    public class NewAzureRmWebAppDatabaseBackupSetting : AzureRMCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the database.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The type of database, e.g. SqlAzure or MySql.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string DatabaseType { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The database's connection string. If the restore should happen to a new database, the database name inside is the new one.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ConnectionString { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "Contains a connection string name that is linked to the SiteConfig.ConnectionStrings. This is used during restore with overwrite connection strings options.",
            ValueFromPipelineByPropertyName = true)]
        public string ConnectionStringName { get; set; }

        public override void ExecuteCmdlet()
        {
            DatabaseBackupSetting setting = new DatabaseBackupSetting()
            {
                Name = this.Name,
                DatabaseType = this.DatabaseType,
                ConnectionString = this.ConnectionString,
                ConnectionStringName = this.ConnectionStringName
            };
            WriteObject(setting);
        }
    }
}
