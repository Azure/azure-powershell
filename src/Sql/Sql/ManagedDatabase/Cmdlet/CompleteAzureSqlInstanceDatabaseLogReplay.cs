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
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    /// <summary>
    /// Cmdlet to complete an Azure Sql Managed Database Log Replay
    /// </summary>
    [Cmdlet(VerbsLifecycle.Complete, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseLogReplay",
         DefaultParameterSetName = LogReplayByNameAndResourceGroupParameterSet,
        SupportsShouldProcess = true),
    OutputType(typeof(bool))]
    public class CompleteAzureSqlInstanceDatabaseLogReplay : AzureSqlManagedDatabaseLogReplayCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the last backup.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string LastBackupName { get; set; }

        protected override AzureSqlManagedDatabaseModel PersistChanges(AzureSqlManagedDatabaseModel entity)
        {
            entity.LastBackupName = LastBackupName;

            ModelAdapter.CompleteManagedDatabaseLogReplay(entity);
            return entity;
        }
    }
}
