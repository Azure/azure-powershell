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
    /// Disable auditing on a database server, therefore all of the databases that use their server's auditing policy will not be audited, as well as 
    /// all new databases within this database server.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Disable, "AzureSqlServerAuditing"), OutputType(typeof(AuditingPolicy))]
    public class DisableSqlServerAuditing : SqlDatabaseSecurityCmdletBase
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
            policy.IsEnabled = false;
        }
        protected override void SendPolicy(AuditingPolicy policy)
        {
            this.PolicyHandler.IgnoreStorage = true;
            this.PolicyHandler.SetServerAuditingPolicy(policy, clientRequestId);
        }
    }
}
