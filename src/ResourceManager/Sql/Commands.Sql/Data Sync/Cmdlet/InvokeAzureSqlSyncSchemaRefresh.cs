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
    /// Cmdlet to refresh the schema of member database
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "AzureRmSqlSyncSchemaRefresh", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.None)]
    public class InvokeAzureSqlSyncSchemaRefresh : AzureSqlSyncGroupCmdletBase
    {
        /// <summary>
        /// Gets or sets the sync group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The sync group name.")]
        public string SyncGroupName { get; set; }

        /// <summary>
        /// Gets or sets the sync member name
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The sync member name.")]
        public string SyncMemberName { get; set; }

        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Defines Whether return the sync group this cmdlet works on")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Returns false so that the model is not written out
        /// </summary>
        /// <returns>Always false</returns>
        protected override bool WriteResult() { return PassThru; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlSyncGroupModel> GetEntity()
        {
            // Try to verify the specified sync member exists
            if (MyInvocation.BoundParameters.ContainsKey("SyncMemberName"))
            {
                ModelAdapter.GetSyncMember(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName, this.SyncMemberName);
            }

            return new List<AzureSqlSyncGroupModel>() {
                ModelAdapter.GetSyncGroup(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName)
            };
        }

        /// <summary>
        /// Start refreshing the member database schema of sync member.
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncGroupModel> PersistChanges(IEnumerable<AzureSqlSyncGroupModel> entity)
        {
            if (MyInvocation.BoundParameters.ContainsKey("SyncMemberName"))
            {
                ModelAdapter.InvokeSyncMemberSchemaRefresh(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName, this.SyncMemberName);
            }
            else
            {
                ModelAdapter.InvokeSyncHubSchemaRefresh(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName);
            }
            return null;
        }
    }
}
