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
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    /// <summary>
    /// Cmdlet to get information of specified sync group or list all the sync groups under a resource group, 
    /// server and database or list all the sync groups which is doing synchronization for this database 
    /// which is either as primary or member
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlSyncGroup",ConfirmImpact = ConfirmImpact.None), OutputType(typeof(AzureSqlSyncGroupModel))]
    public class GetAzureSqlSyncGroup : AzureSqlSyncGroupCmdletBase
    {
        /// <summary>
        /// Gets or sets the sync group name
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3,
            HelpMessage = "The sync group name.")]
        [Alias("SyncGroupName")]
        [SupportsWildcards]
        public string Name { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlSyncGroupModel> GetEntity()
        {
            ICollection<AzureSqlSyncGroupModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("Name") && !WildcardPattern.ContainsWildcardCharacters(Name))
            {
                results = new List<AzureSqlSyncGroupModel>();
                results.Add(ModelAdapter.GetSyncGroup(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.Name));
            }
            else
            {
                results = ModelAdapter.ListSyncGroups(this.ResourceGroupName, this.ServerName, this.DatabaseName);
            }

            return SubResourceWildcardFilter(Name, results);
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncGroupModel> PersistChanges(IEnumerable<AzureSqlSyncGroupModel> entity)
        {
            return entity;
        }
    }
}
