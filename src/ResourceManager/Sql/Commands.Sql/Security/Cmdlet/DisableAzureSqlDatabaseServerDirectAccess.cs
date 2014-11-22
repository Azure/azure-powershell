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
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Commands.Sql.Security.Model;

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet
{
    /// <summary>
    /// Disables direct access to all Azure Sql databases that use the audit policy of a Sql database server 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Disable, "AzureSqlDatabaseServerDirectAccess"), OutputType(typeof(AuditingPolicy))]
    public class DisableAzureSqlDatabaseServerDirectAccess : SqlDatabaseSecurityCmdletBase
    {

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Provides the auditing policy that this cmdlet operates on
        /// </summary>
        /// <returns>An auditingPolicy object</returns>
        protected override AuditingPolicy GetPolicy()
        {
            return this.PolicyHandler.GetServerAuditingPolicy(this.ResourceGroupName, this.ServerName, this.clientRequestId);
        }

        protected override bool writeResult() { return PassThru; }

        protected override void UpdatePolicy(AuditingPolicy policy) 
        {
            policy.DirectAccessEnabled = false;
        }

        protected override void SendPolicy(AuditingPolicy policy) 
        {
            this.PolicyHandler.SetServerAuditingPolicy(policy, clientRequestId);
        }
    }
}
