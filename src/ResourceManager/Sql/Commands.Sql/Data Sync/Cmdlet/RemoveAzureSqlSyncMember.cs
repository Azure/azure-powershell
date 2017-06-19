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
    /// Cmdlet to delete a sync member
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlSyncMember", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(AzureSqlSyncMemberModel))]
    public class RemoveAzureSqlSyncMember : AzureSqlSyncMemberCmdletBase
    {
        /// <summary>
        /// Gets or sets the sync member name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The sync member name.")]
        [Alias("SyncMemberName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Defines Whether return the removed sync member")]
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
        protected override IEnumerable<AzureSqlSyncMemberModel> GetEntity()
        {
            return new List<AzureSqlSyncMemberModel>() { 
               ModelAdapter.GetSyncMember(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName, this.Name)
            };
        }

        /// <summary>
        /// Remove the sync member
        /// </summary>
        /// <param name="entity">The sync member that this cmdlets operates on</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncMemberModel> PersistChanges(IEnumerable<AzureSqlSyncMemberModel> entity)
        {
            ModelAdapter.RemoveSyncMember(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName, this.Name);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Name))
            {
                if (Force || ShouldContinue(
                string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlSyncMemberWarning, this.Name, this.SyncGroupName), ""))
                {
                    base.ExecuteCmdlet();
                }
            }
        }
    }
}
