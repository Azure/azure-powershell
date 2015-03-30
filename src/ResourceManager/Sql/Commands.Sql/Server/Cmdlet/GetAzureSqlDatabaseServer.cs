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
using Microsoft.Azure.Commands.Sql.Server.Model;

namespace Microsoft.Azure.Commands.Sql.Server.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureSqlDatabaseServer cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSqlDatabaseServer", ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlDatabaseServer : AzureSqlDatabaseServerCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets a server from the service.
        /// </summary>
        /// <returns>A single server</returns>
        protected override IEnumerable<AzureSqlDatabaseServerModel> GetEntity()
        {
            ICollection<AzureSqlDatabaseServerModel> results = null;
            
            if (this.MyInvocation.BoundParameters.ContainsKey("ServerName"))
            {
                results = new List<AzureSqlDatabaseServerModel>();
                results.Add(ModelAdapter.GetServer(this.ResourceGroupName, this.ServerName));
            }
            else
            {
                results = ModelAdapter.GetServers(this.ResourceGroupName);
            }

            return results;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlDatabaseServerModel> PersistChanges(IEnumerable<AzureSqlDatabaseServerModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlDatabaseServerModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseServerModel> model)
        {
            return model;
        }
    }
}
