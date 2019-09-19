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

using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationSsisMigrationInfo"), OutputType(typeof(MigrateSqlServerSqlDbDatabaseInput))]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsSsisMigrationInfo")]
    public class NewSsisMigrationInfo : DataMigrationCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "Overwrite option for SSIS projects.")]
        [Alias("Project")]
        [PSArgumentCompleter("Ignore", "Overwrite")]
        public SsisMigrationOverwriteOptionEnum ProjectOverwriteOption { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Overwrite option for SSIS environment.")]
        [Alias("Environment")]
        [PSArgumentCompleter("Ignore", "Overwrite")]
        public SsisMigrationOverwriteOptionEnum EnvironmentOverwriteOption { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var ssisMigrationInfo = new SsisMigrationInfo
            {
                SsisStoreType = SsisStoreType.SsisCatalog,
                ProjectOverwriteOption = MyInvocation.BoundParameters.ContainsKey("ProjectOverwriteOption") ?
                    this.ProjectOverwriteOption.ToString() : SsisMigrationOverwriteOption.Ignore.ToString(),
                EnvironmentOverwriteOption = MyInvocation.BoundParameters.ContainsKey("EnvironmentOverwriteOption") ?
                    this.EnvironmentOverwriteOption.ToString() : SsisMigrationOverwriteOption.Ignore.ToString()
            };

            WriteObject(ssisMigrationInfo);
        }
    }
}
