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
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.DataSync.Model;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    /// <summary>
    /// Cmdlet to delete a sync agent
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlSyncAgent", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.High)]
    public class RemoveAzureSqlSyncAgent : AzureSqlSyncAgentCmdletBase
    {
        /// <summary>
        /// Gets or sets the sync agent name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The sync agent name.")]
        [Alias("SyncAgentName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Defines Whether return the removed sync agent")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected override bool WriteResult() { return PassThru; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlSyncAgentModel> GetEntity()
        {
            return new List<AzureSqlSyncAgentModel>() { 
                ModelAdapter.GetSyncAgent(this.ResourceGroupName, this.ServerName, this.Name) 
            };
        }

        /// <summary>
        /// Remove the sync agent
        /// </summary>
        /// <param name="entity">The sync agent that this cmdlet operates on</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncAgentModel> PersistChanges(IEnumerable<AzureSqlSyncAgentModel> entity)
        {
            ModelAdapter.RemoveSyncAgent(this.ResourceGroupName, this.ServerName, this.Name);
            return entity;
        }

        /// <summary>
        /// Get the confirmation message when users want to remove a sync agent
        /// </summary>
        /// <returns>The confirmation message</returns>
        protected override string GetConfirmActionProcessMessage()
        {
            return string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlSyncAgentDescription, this.Name);
        }

        /// <summary>
        /// Get resource id for confirmation message
        /// </summary>
        /// <param name="model">The sync agent that this cmdlet operates on</param>
        /// <returns>The resource id</returns>
        protected override string GetResourceId(IEnumerable<AzureSqlSyncAgentModel> model)
        {
            return this.ServerName;
        }
    }
}
