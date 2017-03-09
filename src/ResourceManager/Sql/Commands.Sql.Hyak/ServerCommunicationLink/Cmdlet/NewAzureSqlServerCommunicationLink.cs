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

using Hyak.Common;
using Microsoft.Azure.Commands.Sql.ServerCommunicationLink.Model;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerCommunicationLink.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql server communication link
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlServerCommunicationLink",
        ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true), OutputType(typeof(AzureSqlServerCommunicationLinkModel))]
    public class NewAzureSqlServerCommunicationLink : AzureSqlServerCommunicationLinkCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the server communication link to create.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Azure SQL server communication link to create.")]
        [ValidateNotNullOrEmpty]
        public string LinkName { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner server.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the partner server.")]
        [ValidateNotNullOrEmpty]
        public string PartnerServer { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlServerCommunicationLinkModel> GetEntity()
        {
            // We try to get the server communication link.  Since this is a create, we don't want it to exist
            try
            {
                ModelAdapter.GetServerCommunicationLink(this.ResourceGroupName, this.ServerName, this.LinkName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no server communication link with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The entity already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerCommunicationLinkNameExists, this.LinkName, this.ServerName),
                "LinkName");
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlServerCommunicationLinkModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerCommunicationLinkModel> model)
        {
            string location = ModelAdapter.GetServerLocation(ResourceGroupName, ServerName);

            if (!MyInvocation.BoundParameters.ContainsKey("PartnerServer"))
            {
                throw new CmdletInvocationException("'PartnerServer' must be specified in the invocation of this cmdlet.");
            }

            List<AzureSqlServerCommunicationLinkModel> newEntity = new List<AzureSqlServerCommunicationLinkModel>();
            newEntity.Add(new AzureSqlServerCommunicationLinkModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                Location = location,
                Name = LinkName,
                PartnerServer = PartnerServer,
            });
            return newEntity;
        }

        /// <summary>
        /// Create the new server communication link
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlServerCommunicationLinkModel> PersistChanges(IEnumerable<AzureSqlServerCommunicationLinkModel> entity)
        {
            return new List<AzureSqlServerCommunicationLinkModel>() {
                ModelAdapter.UpsertServerCommunicationLink(entity.First())
            };
        }
    }
}
