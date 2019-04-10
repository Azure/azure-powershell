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
    /// Cmdlet to get a specified sync member or list all the sync members under a specified sync group  
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlSyncMember",ConfirmImpact = ConfirmImpact.None), OutputType(typeof(AzureSqlSyncMemberModel))]
    public class GetAzureSqlSyncMember : AzureSqlSyncMemberCmdletBase
    {
        /// <summary>
        /// Gets or sets the sync member name
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The sync member name.")]
        [Alias("SyncMemberName")]
        public string Name { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlSyncMemberModel> GetEntity()
        {
            ICollection<AzureSqlSyncMemberModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("Name") && !WildcardPattern.ContainsWildcardCharacters(Name))
            {
                results = new List<AzureSqlSyncMemberModel>();
                results.Add(ModelAdapter.GetSyncMember(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName, this.Name));
            }
            else
            {
                results = ModelAdapter.ListSyncMembers(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName);
            }

            return SubResourceWildcardFilter(Name, results);
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncMemberModel> PersistChanges(IEnumerable<AzureSqlSyncMemberModel> entity)
        {
            return entity;
        }
    }
}
