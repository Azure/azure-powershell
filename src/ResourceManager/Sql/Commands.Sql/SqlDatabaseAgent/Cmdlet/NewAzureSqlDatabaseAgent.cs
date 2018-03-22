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
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    /// <summary>
    /// Defines the New-AzureRmSqlDatabaseAgent Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlDatabaseAgent", SupportsShouldProcess = true)]
    public class NewAzureSqlDatabaseAgent : AzureSqlDatabaseAgentCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the server to use
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to use
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "SQL Database database name.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the agent to create
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "SQL Database Agent name.")]
        [ValidateNotNullOrEmpty]
        public string AgentName { get; set; }

        /// <summary>
        /// Gets or sets the agent's number of workers
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = "SQL Database Agent Worker Count")]
        public int? WorkerCount { get; set; }

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
                ModelAdapter.GetSqlDatabaseAgent(this.ResourceGroupName, this.ServerName, this.AgentName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no job account with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The job account already exists
            throw new PSArgumentException(
                string.Format(Properties.Resources.AzureSqlDatabaseAgentExists, this.AgentName, this.ServerName),
                "AgentName");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the server doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlDatabaseAgentModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseAgentModel> model)
        {
            string location = ModelAdapter.GetServerLocationAndThrowIfAgentNotSupportedByServer(this.ResourceGroupName, this.ServerName);

            List<AzureSqlDatabaseAgentModel> newEntity = new List<AzureSqlDatabaseAgentModel>
            {
                new AzureSqlDatabaseAgentModel
                {
                    Location = location,
                    ResourceGroupName = this.ResourceGroupName,
                    ServerName = this.ServerName,
                    AgentName = this.AgentName,
                    DatabaseName = this.DatabaseName,
                    WorkerCount = MyInvocation.BoundParameters.ContainsKey("WorkerCount") ? this.WorkerCount : null,
                    Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true),
                }
            };
            return newEntity;
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