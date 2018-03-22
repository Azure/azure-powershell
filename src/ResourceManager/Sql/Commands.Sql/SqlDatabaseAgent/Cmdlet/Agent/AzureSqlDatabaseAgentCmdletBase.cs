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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Services;
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    public abstract class AzureSqlDatabaseAgentCmdletBase : AzureSqlCmdletBase<AzureSqlDatabaseAgentModel, AzureSqlDatabaseAgentAdapter>
    {
        /// <summary>
        /// Parameter sets
        /// </summary>
        protected const string DefaultParameterSet = "Agent Default Parameter Set";
        protected const string InputObjectParameterSet = "Agent Input Object Parameter Set";
        protected const string ResourceIdParameterSet = "Agent Resource Id Parameter Set";

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The Agent Resource Group Name")]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the agent server name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The Agent Server Name")]
        [Alias("AgentServerName")]
        public virtual string ServerName { get; set; }

        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <param name="subscription">The subscription the cmdlets are operation under</param>
        /// <returns>The Azure SQL Database Agent adapter</returns>
        protected override AzureSqlDatabaseAgentAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new AzureSqlDatabaseAgentAdapter(DefaultContext);
        }
    }
}