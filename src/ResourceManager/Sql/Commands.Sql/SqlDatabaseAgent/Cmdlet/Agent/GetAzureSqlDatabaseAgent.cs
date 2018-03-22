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

using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlDatabaseAgent cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlDatabaseAgent", 
        SupportsShouldProcess = true, 
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlDatabaseAgentModel))]
    [OutputType(typeof(IEnumerable<AzureSqlDatabaseAgentModel>))]
    public class GetAzureSqlDatabaseAgent : AzureSqlDatabaseAgentCmdletBase
    {
        /// <summary>
        /// Gets or sets the Agent Server Object
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent's server input object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlServerModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the Agent Server Resource Id
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The agent's server resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the agent name
        /// </summary>
        [Parameter(
            Mandatory = false,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The agent name")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The agent name")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The agent name")]
        [Alias("AgentName")]
        public string Name { get; set; }

        /// <summary>
        /// Cmdlet execution starts here
        /// </summary>
        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case InputObjectParameterSet:
                    this.ResourceGroupName = InputObject.ResourceGroupName;
                    this.ServerName = InputObject.ServerName;
                    break;
                case ResourceIdParameterSet:
                    var resourceInfo = new ResourceIdentifier(ResourceId);
                    this.ResourceGroupName = resourceInfo.ResourceGroupName;
                    this.ServerName = resourceInfo.ResourceName;
                    break;
                default:
                    break;
            }

            // Lets us return a list of agents
            if (this.Name == null)
            {
                ModelAdapter = InitModelAdapter(DefaultProfile.DefaultContext.Subscription);
                WriteObject(ModelAdapter.GetSqlDatabaseAgent(this.ResourceGroupName, this.ServerName), true);
                return;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Gets one or more Azure SQL Database Agents from the service.
        /// </summary>
        /// <returns></returns>
        protected override AzureSqlDatabaseAgentModel GetEntity()
        {
            return ModelAdapter.GetSqlDatabaseAgent(this.ResourceGroupName, this.ServerName, this.Name);
        }
    }
}