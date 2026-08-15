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
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Sql;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.Server.Services
{
    /// <summary>
    /// Adapter for deleted server operations
    /// </summary>
    public class AzureSqlDeletedServerAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDeletedServerCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a deleted server adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlDeletedServerAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlDeletedServerCommunicator(Context);
        }

        /// <summary>
        /// Gets a deleted Azure SQL server by location and server name.
        /// </summary>
        /// <param name="location">The Azure region (location) where the deleted server resided.</param>
        /// <param name="serverName">The name of the deleted SQL server.</param>
        /// <param name="subscriptionId">Optional. The subscription ID associated with the server. If null, uses the current context.</param>
        /// <returns>The deleted server information if found; otherwise, null.</returns>
        public DeletedServer GetDeletedServer(string location, string serverName, string subscriptionId = null)
        {
            try
            {
                return Communicator.GetDeleted(location, serverName, subscriptionId);
            }
            catch (ErrorResponseException ex)
            {
                if (ex.Response?.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    var notFoundMessage = string.Format(Properties.Resources.DeletedServerNotFoundInLocation, serverName, location);
                    throw new AzPSResourceNotFoundCloudException(
                        notFoundMessage,
                        notFoundMessage,
                        ex);
                }

                throw ErrorResponseExceptionHelper.CreateFrom(ex);
            }
        }

        /// <summary>
        /// Gets all deleted Azure SQL servers in a subscription.
        /// </summary>
        /// <param name="subscriptionId">Optional. The subscription ID. If null, uses the current context.</param>
        /// <returns>List of all deleted servers in the subscription.</returns>
        public IEnumerable<DeletedServer> ListDeletedServers(string subscriptionId = null)
        {
            return Communicator.ListDeletedServers(subscriptionId);
        }

        /// <summary>
        /// Gets all deleted Azure SQL servers in a location.
        /// </summary>
        /// <param name="location">The Azure region (location) where the deleted servers resided.</param>
        /// <param name="subscriptionId">Optional. The subscription ID associated with the servers. If null, uses the current context.</param>
        /// <returns>List of deleted servers in the specified location.</returns>
        public IEnumerable<DeletedServer> ListDeletedServersByLocation(string location, string subscriptionId = null)
        {
            return Communicator.ListDeletedServersByLocation(location, subscriptionId);
        }

        /// <summary>
        /// Converts a deleted server model from the service to a deleted server model.
        /// </summary>
        /// <param name="deletedServer">The service model to convert</param>
        /// <returns>The converted model</returns>
        public AzureSqlDeletedServerModel CreateDeletedServerModelFromResponse(DeletedServer deletedServer)
        {
            if (deletedServer == null)
            {
                return null;
            }

            // Id format: /subscriptions/{sub}[2]/providers/Microsoft.Sql/locations/{location}[6]/deletedServers/{name}
            // Note: the subscription-level list endpoint embeds the location display name (e.g. "Central US")
            // while the location-scoped endpoints embed the normalized name (e.g. "centralus"). Strip spaces so
            // callers always get a consistent, normalized location value regardless of which endpoint was used.
            string[] idSegments = deletedServer.Id?.Split('/');
            string parsedSubscriptionId = idSegments?.Length > 2 ? idSegments[2] : null;
            string parsedLocation = idSegments?.Length > 6
                ? idSegments[6]?.Replace(" ", string.Empty).ToLowerInvariant()
                : null;

            AzureSqlDeletedServerModel model = new AzureSqlDeletedServerModel()
            {
                ServerName = deletedServer.Name,
                DeletionTime = deletedServer.DeletionTime,
                FullyQualifiedDomainName = deletedServer.FullyQualifiedDomainName,
                Version = deletedServer.Version,
                Id = deletedServer.Id,
                OriginalId = deletedServer.OriginalId,
                Location = parsedLocation,
                ScheduledPurgeTime = deletedServer.ScheduledPurgeTime,
                SubscriptionId = parsedSubscriptionId,
                ResourceGroupName = deletedServer.OriginalResourceGroup
            };

            return model;
        }

    }
}