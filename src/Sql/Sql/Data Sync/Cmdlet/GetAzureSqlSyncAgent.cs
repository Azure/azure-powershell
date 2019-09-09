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
using Microsoft.Azure.Commands.Sql.DataSync.Model;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    /// <summary>
    /// Cmdlet to get information of specified sync agent or list all the sync agents under a specified resource group
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlSyncAgent",ConfirmImpact = ConfirmImpact.None), OutputType(typeof(AzureSqlSyncAgentModel))]
    public class GetAzureSqlSyncAgent : AzureSqlSyncAgentCmdletBase
    {
        /// <summary>
        /// Gets or sets the sync agent name
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The sync agent name.")]
        [Alias("SyncAgentName")]
        [SupportsWildcards]
        public string Name { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlSyncAgentModel> GetEntity()
        {
            ICollection<AzureSqlSyncAgentModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("Name") && !WildcardPattern.ContainsWildcardCharacters(Name))
            {
                results = new List<AzureSqlSyncAgentModel>();
                results.Add(ModelAdapter.GetSyncAgent(this.ResourceGroupName, this.ServerName, this.Name));
            }
            else
            {
                results = ModelAdapter.ListSyncAgents(this.ResourceGroupName, this.ServerName);
            }
            return SubResourceWildcardFilter(Name, results);
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncAgentModel> PersistChanges(IEnumerable<AzureSqlSyncAgentModel> entity)
        {
            return entity;
        }
    }
}
