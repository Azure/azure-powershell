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
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    /// <summary>
    /// Cmdlet to stop an Azure Sql Managed Database Log Replay
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseLogReplay",
        DefaultParameterSetName = LogReplayByNameAndResourceGroupParameterSet,
        SupportsShouldProcess = true),
    OutputType(typeof(AzureSqlManagedDatabaseModel))]
    public class StopAzureSqlInstanceDatabaseLogReplay : AzureSqlManagedDatabaseLogReplayCmdletBase
    {
        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        protected override AzureSqlManagedDatabaseModel PersistChanges(AzureSqlManagedDatabaseModel entity)
        {
            ModelAdapter.StopManagedDatabaseLogReplay(entity);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldContinue(
                string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.StopAzureSqlInstanceDatabaseLogReplayDescription, this.Name),
                Microsoft.Azure.Commands.Sql.Properties.Resources.StopAzureSqlInstanceDatabaseLogReplayWarning))
            {
                return;
            }

            base.ExecuteCmdlet();
        }
    }
}
