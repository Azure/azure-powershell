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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    /// <summary>
    /// Defines the Set-AzureRmSqlDatabaseAgent cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabaseAgent",
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium)]
    public class SetAzureSqlDatabaseAgent: AzureSqlDatabaseAgentCmdletBase
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
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "SQL Database Agent Name")]
        public string AgentName { get; set; }

        /// <summary>
        /// Gets or sets the agent's numbert of workers
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "SQL Database Agent Worker Count")]
        public int WorkerCount { get; set; }

        /// <summary>
        /// The tags to assocciate wit the Azure SQL Database Server
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure Sql Job Account")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Check to see if the job account already exists in this resource group.
        /// </summary>
        /// <returns>Null if the job account doesn't exist. Otherwise throws exception</returns>
        protected override IEnumerable<AzureSqlDatabaseAgentModel> GetEntity()
        {
            try
            {
                WriteDebugWithTimestamp("AgentName: {0}", AgentName);

                return new List<AzureSqlDatabaseAgentModel>() {
                    ModelAdapter.GetSqlDatabaseAgent(this.ResourceGroupName, this.ServerName, this.AgentName)
                };
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The sql database agent does not exist
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureSqlDatabaseAgentNotExists, this.AgentName, this.ServerName),
                        "AgentName");
                }

                // Unexpected exception encountered
                throw;
            }
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This exists because the agent should already exists</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlDatabaseAgentModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseAgentModel> model)
        {
            string location = ModelAdapter.GetServerLocationAndThrowIfAgentNotSupportedByServer(this.ResourceGroupName, this.ServerName);

            List<AzureSqlDatabaseAgentModel> updatedEntity = new List<AzureSqlDatabaseAgentModel>
            {
                new AzureSqlDatabaseAgentModel
                {
                    Location = location,
                    ResourceGroupName = this.ResourceGroupName,
                    ServerName = this.ServerName,
                    AgentName = this.AgentName,
                    WorkerCount = this.WorkerCount,
                    Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true),
                }
            };

            return updatedEntity;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the job account
        /// </summary>
        /// <param name="entity">The job account to create</param>
        /// <returns>The created job account</returns>
        protected override IEnumerable<AzureSqlDatabaseAgentModel> PersistChanges(IEnumerable<AzureSqlDatabaseAgentModel> entity)
        {
            return new List<AzureSqlDatabaseAgentModel>
            {
                ModelAdapter.UpsertSqlDatabaseAgent(entity.First())
            };
        }
    }
}