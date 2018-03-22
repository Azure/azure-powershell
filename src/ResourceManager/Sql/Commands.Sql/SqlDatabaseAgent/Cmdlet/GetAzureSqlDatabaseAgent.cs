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

using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlDatabaseAgent cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlDatabaseAgent", SupportsShouldProcess = true)]
    public class GetAzureSqlDatabaseAgent : AzureSqlDatabaseAgentCmdletBase
    {
        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "SQL Database Server Name")]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the agent name
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "SQL Database Agent Name")]
        public string AgentName { get; set; }
        
        /// <summary>
        /// Gets one or more Azure SQL Database Agents from the service.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<AzureSqlDatabaseAgentModel> GetEntity()
        {
            if (this.MyInvocation.BoundParameters.ContainsKey("AgentName"))
            {
                return new List<AzureSqlDatabaseAgentModel>
                {
                    ModelAdapter.GetSqlDatabaseAgent(this.ResourceGroupName, this.ServerName, this.AgentName)
                };
            }
            else
            {
                return ModelAdapter.GetSqlDatabaseAgent(this.ResourceGroupName, this.ServerName);
            }
        }
    }
}