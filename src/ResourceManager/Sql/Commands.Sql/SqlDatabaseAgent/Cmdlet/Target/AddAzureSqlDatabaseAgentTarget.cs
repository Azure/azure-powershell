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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    /// <summary>
    /// Defines the Add-AzureRmSqlDatabaseAgentTarget Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureRmSqlDatabaseAgentTarget", 
        SupportsShouldProcess = true,
        DefaultParameterSetName = SqlDatabaseSet), 
        OutputType(typeof(JobTarget))]
    public class AddAzureSqlDatabaseAgentTarget : AzureSqlDatabaseAgentTargetCmdletBase
    {
        /// <summary>
        /// Gets or sets the flag indicating that we want to exclude this target
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Excludes a target.")]
        [ValidateNotNullOrEmpty]
        public override SwitchParameter Exclude { get; set; }

        /// <summary>
        /// Updates list of existing targets during add target scenario
        /// There are 2 scenarios where we will need to send an update to server
        /// 1. If target wasn't in list and we need to add it
        /// 2. If target was in the list, but client wants to update it's membership type.
        /// If one of these scenarios occurs, we return true and send update to server.
        /// Otherwise, we return empty response to indicate that no changes were made.
        /// </summary>
        /// <returns>True if an update to server is required after updating list of existing targets</returns>
        protected override bool UpdateExistingTargets()
        {
            int? index = FindTarget();
            bool targetExists = index.HasValue;
            bool needsMembershipUpdate = targetExists ? this.ExistingTargets[index.Value].MembershipType != this.Target.MembershipType : false;
            bool needsUpdate = false;

            if (!targetExists)
            {
                this.ExistingTargets.Add(this.Target);
                needsUpdate = true;
            }

            // If the membership type needs updating then update.
            if (needsMembershipUpdate)
            {
                this.ExistingTargets[index.Value].MembershipType = this.Target.MembershipType;
                needsUpdate = true;
            }

            return needsUpdate;
        }
    }
}