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

using Microsoft.Azure.Commands.Sql.Security.Model;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet
{
    /// <summary>
    /// Returns the auditing policy of a specific database.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSqlDatabaseAuditingSetting"), OutputType(typeof(AuditingPolicy))]
    public class GetAzureSqlDatabaseAuditingSetting : SqlDatabaseSecurityCmdletBase
    {
         
        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory=true, HelpMessage = "SQL Database name.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

       /// <summary>
       /// Provides the auditing policy that this cmdlet operates on
       /// </summary>
       /// <returns>An auditingPolicy object</returns>
        protected override AuditingPolicy GetPolicy()
        {
            return this.PolicyHandler.GetDatabaseAuditingPolicy(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.clientRequestId);
        }

    }
}
