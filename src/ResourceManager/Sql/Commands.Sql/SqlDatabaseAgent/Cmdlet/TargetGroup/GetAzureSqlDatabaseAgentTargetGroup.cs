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
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlDatabaseAgentTargetGroup Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlDatabaseAgentTargetGroup", 
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlDatabaseAgentTargetGroupModel))]
    public class GetAzureSqlDatabaseAgentTargetGroup : AzureSqlDatabaseAgentTargetGroupCmdletBase
    {
        /// <summary>
        /// Gets or sets the agent input object model
        /// </summary>
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The SQL Database Agent Parent Object")]
        [ValidateNotNullOrEmpty]
        public AzureSqlDatabaseAgentModel InputObject { get; set; }

        /// <summary>
		/// Gets or sets the agent resource id
		/// </summary>
		[Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The resource id of the credential to remove")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the target group name
        /// </summary>
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The target group name")]
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The target group name")]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The target group name")]
        [ValidateNotNullOrEmpty]
        [Alias("TargetGroupName")]
        public string Name { get; set; }

        /// <summary>
        /// Execution starts here
        /// </summary>
        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case InputObjectParameterSet:
                    this.ResourceGroupName = InputObject.ResourceGroupName;
                    this.ServerName = InputObject.ServerName;
                    this.AgentName = InputObject.AgentName;
                    break;
                case ResourceIdParameterSet:
                    var resourceInfo = new ResourceIdentifier(ResourceId);
                    this.ResourceGroupName = resourceInfo.ResourceGroupName;
                    this.ServerName = ResourceIdentifier.GetTypeFromResourceType(resourceInfo.ParentResource);
                    this.AgentName = resourceInfo.ResourceName;
                    break;
                default:
                    break;
            }

            // Lets us return a list of target groups
            if (this.Name == null)
            {
                ModelAdapter = InitModelAdapter(DefaultProfile.DefaultContext.Subscription);
                WriteObject(ModelAdapter.GetTargetGroup(this.ResourceGroupName, this.ServerName, this.AgentName), true);
                return;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the target group exists
        /// </summary>
        /// <returns>Throws exception if the target group doesn't exist.<returns>
        protected override AzureSqlDatabaseAgentTargetGroupModel GetEntity()
        {
            try
            {
                return ModelAdapter.GetTargetGroup(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The target group does not exist
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureSqlDatabaseAgentTargetGroupNotExists, this.Name, this.AgentName),
                        "TargetGroupName");
                }

                // Unexpected exception encountered
                throw;
            }
        }
    }
}