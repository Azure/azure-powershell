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
using Microsoft.Azure.Commands.Sql.Security.Services;
using Microsoft.Azure.Commands.Sql.Services;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet
{
    /// <summary>
    /// The base class for all Azure Sql Database security Management Cmdlets
    /// </summary>
   public abstract class SqlDatabaseSecurityCmdletBase : SqlDatabaseCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The PolicyHandler object mapped to this cmdlet
        /// </summary>
        public SqlClient PolicyHandler { get;  internal set; }

        /// <summary>
        /// Provides the auditing policy that this cmdlet operates on
        /// </summary>
        /// <returns>An auditingPolicy object</returns>
        protected abstract AuditingPolicy GetPolicy();
         
        /// <summary>
        /// Updates the given policy with the cmdlet specific operation 
        /// </summary>
        /// <param name="policy">An AuditingPolicy object representing the policy of the current resource</param>
        protected virtual void UpdatePolicy(AuditingPolicy policy) { }
        
        /// <summary>
        /// This method is responsible to call the right API that eventually send the information found in the given AuditingPolicy
        /// object to the backend
        /// </summary>
        /// <param name="policy">The AuditingPolicy object with the data to be sent to the backend</param>
        protected virtual void SendPolicy(AuditingPolicy policy) { }

        /// <summary>
        /// Returns true if the AuditingPolicy that was developed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the AuditingPolicy should be written out, False otherwise</returns>
        protected virtual bool writeResult() { return true; }
        
        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            PolicyHandler = new SqlClient(CurrentContext.Subscription);
            AuditingPolicy policy = this.GetPolicy();
            this.UpdatePolicy(policy);
            this.SendPolicy(policy);
            if (writeResult()) this.WriteObject(policy);
        }
    }
}
