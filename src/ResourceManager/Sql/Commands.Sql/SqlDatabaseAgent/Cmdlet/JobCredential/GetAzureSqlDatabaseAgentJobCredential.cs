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
using Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Sql.SqlDatabaseAgent.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlDatabaseAgentJobCredential Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlDatabaseAgentJobCredential", 
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureSqlDatabaseAgentJobCredentialModel))]
    [OutputType(typeof(IEnumerable<AzureSqlDatabaseAgentJobCredentialModel>))]
    public class GetAzureSqlDatabaseAgentJobCredential : AzureSqlDatabaseAgentJobCredentialCmdletBase
    {
        /// <summary>
        /// Gets or sets the agent model input object
        /// </summary>
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent input object model")]
        [ValidateNotNullOrEmpty]
        public AzureSqlDatabaseAgentModel InputObject { get; set; }

        /// <summary>
		/// Gets or sets the agent resource id
		/// </summary>
		[Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The agent resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the credential name
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The job credential name")]
        [Parameter(ParameterSetName = InputObjectParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The job credential name")]
        [Parameter(ParameterSetName = ResourceIdParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The job credential name")]
        [ValidateNotNullOrEmpty]
        [Alias("CredentialName")]
        public string Name { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
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

            // Returns a list of credentials
            if (this.Name == null)
            {
                ModelAdapter = InitModelAdapter(DefaultProfile.DefaultContext.Subscription);
                WriteObject(ModelAdapter.GetJobCredential(this.ResourceGroupName, this.ServerName, this.AgentName), true);
                return;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the credential already exists for the agent.
        /// </summary>
        /// <returns>Throws exception if the credential doesn't exist.<returns>
        protected override AzureSqlDatabaseAgentJobCredentialModel GetEntity()
        {
            try
            {
                return ModelAdapter.GetJobCredential(this.ResourceGroupName, this.ServerName, this.AgentName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The credential does not exist
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureSqlDatabaseAgentJobCredentialNotExists, this.Name, this.AgentName),
                        "CredentialName");
                }

                // Unexpected exception encountered
                throw;
            }
        }
    }
}