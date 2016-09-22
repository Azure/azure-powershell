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

using Microsoft.Azure.Commands.Sql.ServerCommunicationLink.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerCommunicationLink.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlServerCommunicationLink",
        ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true), 
        OutputType(typeof(AzureSqlServerCommunicationLinkModel))]
    public class GetAzureSqlServerCommunicationLink : AzureSqlServerCommunicationLinkCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the server communication link to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL server communication link to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string LinkName { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlServerCommunicationLinkModel> GetEntity()
        {
            ICollection<AzureSqlServerCommunicationLinkModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("LinkName"))
            {
                results = new List<AzureSqlServerCommunicationLinkModel>();
                results.Add(ModelAdapter.GetServerCommunicationLink(this.ResourceGroupName, this.ServerName, this.LinkName));
            }
            else
            {
                results = ModelAdapter.ListServerCommunicationLinks(this.ResourceGroupName, this.ServerName);
            }

            return results;
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlServerCommunicationLinkModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerCommunicationLinkModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlServerCommunicationLinkModel> PersistChanges(IEnumerable<AzureSqlServerCommunicationLinkModel> entity)
        {
            return entity;
        }
    }
}
