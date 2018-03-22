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
    public abstract class AzureSqlDatabaseAgentTargetGroupCmdletBase : AzureSqlCmdletBase<AzureSqlDatabaseAgentTargetGroupModel, AzureSqlDatabaseAgentTargetGroupAdapter>
    {
        /// <summary>
        /// Parameter sets
        /// </summary>
        protected const string DefaultParameterSet = "Target Group Default Parameter Set";
        protected const string InputObjectParameterSet = "Target Group Input Object Parameter Set";
        protected const string ResourceIdParameterSet = "Target Group Resource Id Parameter Set";

        /// <summary>
        /// Gets or sets the name of the resource group name to use
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The resource group name")]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server to use
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, 
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The agent server name")]
        [ValidateNotNullOrEmpty]
        [Alias("AgentServerName")]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the agent
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet, 
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The agent name")]
        [ValidateNotNullOrEmpty]
        public string AgentName { get; set; }

        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <param name="subscription">The subscription the cmdlets are operation under</param>
        /// <returns>The Azure SQL Database Agent adapter</returns>
        protected override AzureSqlDatabaseAgentTargetGroupAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new AzureSqlDatabaseAgentTargetGroupAdapter(DefaultContext);
        }
    }
}