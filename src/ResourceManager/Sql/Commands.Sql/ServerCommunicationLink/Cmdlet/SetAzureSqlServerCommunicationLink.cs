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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.ServerCommunicationLink.Model;

namespace Microsoft.Azure.Commands.Sql.ServerCommunicationLink.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql Database server communication link
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlServerCommunicationLink",
        ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(AzureSqlServerCommunicationLinkModel))]
    public class SetAzureSqlServerCommunicationLink : AzureSqlServerCommunicationLinkCmdletBase
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
            return new List<AzureSqlServerCommunicationLinkModel>() { 
                ModelAdapter.GetServerCommunicationLink(this.ResourceGroupName, this.ServerName, this.LinkName) 
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlServerCommunicationLinkModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerCommunicationLinkModel> model)
        {
            string location = ModelAdapter.GetServerLocation(ResourceGroupName, ServerName);
            List<AzureSqlServerCommunicationLinkModel> newEntity = new List<AzureSqlServerCommunicationLinkModel>();
            newEntity.Add(new AzureSqlServerCommunicationLinkModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                Location = location,
                Name = LinkName,
                PartnerServer = MyInvocation.BoundParameters.ContainsKey("PartnerServer") ? PartnerServer : null,
            });

            return newEntity;
        }

        /// <summary>
        /// Update the server communication link
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
