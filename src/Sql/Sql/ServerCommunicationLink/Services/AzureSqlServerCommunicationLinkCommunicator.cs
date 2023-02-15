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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ServerCommunicationLink.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the endpoints
    /// </summary>
    public class AzureSqlServerCommunicationLinkCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Elastic Pool
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlServerCommunicationLinkCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets a server communication link
        /// </summary>
        public Management.Sql.LegacySdk.Models.ServerCommunicationLink Get(string resourceGroupName, string serverName, string communicationLinkName)
        {
            return GetCurrentSqlClient().CommunicationLinks.Get(resourceGroupName, serverName, communicationLinkName).ServerCommunicationLink;
        }

        /// <summary>
        /// Lists server communication links
        /// </summary>
        public IList<Management.Sql.LegacySdk.Models.ServerCommunicationLink> List(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().CommunicationLinks.List(resourceGroupName, serverName).ServerCommunicationLinks;
        }

        /// <summary>
        /// Creates or updates a server communication link
        /// </summary>
        public Management.Sql.LegacySdk.Models.ServerCommunicationLink CreateOrUpdate(string resourceGroupName, string serverName, string communicationLinkName, ServerCommunicationLinkCreateOrUpdateParameters parameters)
        {
            var resp = GetCurrentSqlClient().CommunicationLinks.CreateOrUpdate(resourceGroupName, serverName, communicationLinkName, parameters);
            return resp.ServerCommunicationLink;
        }

        /// <summary>
        /// Deletes a server communication link
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string communicationLinkName)
        {
            GetCurrentSqlClient().CommunicationLinks.Delete(resourceGroupName, serverName, communicationLinkName);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return SqlClient;
        }
    }
}
