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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.ServerCommunicationLink.Model;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ServerCommunicationLink.Services
{
    /// <summary>
    /// Adapter for Server communication link operations
    /// </summary>
    public class AzureSqlServerCommunicationLinkAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerCommunicationLinkCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private AzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs an adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlServerCommunicationLinkAdapter(AzureContext context)
        {
            _subscription = context.Subscription;
            Context = context;
            Communicator = new AzureSqlServerCommunicationLinkCommunicator(Context);
        }

        /// <summary>
        /// Gets a Azure Sql Server communication link by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="communicationLinkName">The name of the Azure Sql Server communication link</param>
        /// <returns>The Azure Sql server communication link object</returns>
        internal AzureSqlServerCommunicationLinkModel GetServerCommunicationLink(string resourceGroupName, string serverName, string communicationLinkName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, communicationLinkName, Util.GenerateTracingId());
            return CreateServerCommunicationLinkModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of Azure Sql Server communication links.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <returns>A list of server communication link objects</returns>
        internal ICollection<AzureSqlServerCommunicationLinkModel> ListServerCommunicationLinks(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName, Util.GenerateTracingId());

            return resp.Select((l) =>
            {
                return CreateServerCommunicationLinkModelFromResponse(resourceGroupName, serverName, l);
            }).ToList();
        }

        /// <summary>
        /// Creates or updates a Azure Sql Server communication link.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql server communication link</returns>
        internal AzureSqlServerCommunicationLinkModel UpsertServerCommunicationLink(AzureSqlServerCommunicationLinkModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.Name, Util.GenerateTracingId(), new ServerCommunicationLinkCreateOrUpdateParameters()
            {
                Location = model.Location,
                Properties = new ServerCommunicationLinkCreateOrUpdateProperties()
                {
                    PartnerServer = model.PartnerServer,
                }
            });

            return CreateServerCommunicationLinkModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Deletes a Server communication link
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="communicationLinkName">The name of the Azure Sql server communication link to delete</param>
        public void RemoveServerCommunicationLink(string resourceGroupName, string serverName, string communicationLinkName)
        {
            Communicator.Remove(resourceGroupName, serverName, communicationLinkName, Util.GenerateTracingId());
        }

        /// <summary>
        /// Gets the Location of the server.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns></returns>
        public string GetServerLocation(string resourceGroupName, string serverName)
        {
            AzureSqlServerAdapter serverAdapter = new AzureSqlServerAdapter(Context);
            var server = serverAdapter.GetServer(resourceGroupName, serverName);
            return server.Location;
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="link">The service response</param>
        /// <returns>The converted model</returns>
        private AzureSqlServerCommunicationLinkModel CreateServerCommunicationLinkModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.ServerCommunicationLink link)
        {
            AzureSqlServerCommunicationLinkModel model = new AzureSqlServerCommunicationLinkModel();

            model.ResourceGroupName = resourceGroup;
            model.ServerName = serverName;
            model.Name = link.Name;
            model.PartnerServer = link.Properties.PartnerServer;
            model.State = link.Properties.State;
            model.Location = link.Location;

            return model;
        }
    }
}
