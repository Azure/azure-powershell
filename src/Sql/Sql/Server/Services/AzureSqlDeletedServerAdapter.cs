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
using Microsoft.Azure.Commands.Sql;
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
                throw GetImprovedErrorResponseException(ex, location, serverName);
            }
        }

        /// <summary>
        /// Gets all deleted Azure SQL servers in a location.
        /// </summary>
        /// <param name="location">The Azure region (location) where the deleted servers resided.</param>
        /// <param name="subscriptionId">Optional. The subscription ID associated with the servers. If null, uses the current context.</param>
        /// <returns>List of deleted servers in the specified location.</returns>
        public IEnumerable<DeletedServer> ListDeletedServers(string location, string subscriptionId = null)
        {
            return Communicator.ListDeletedServers(location, subscriptionId);
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

            string[] segments = deletedServer.OriginalId.Split('/');

            // Parse servername and subscription from originalId if available
            string parsedServerName = segments[8];
            string parsedSubscriptionId = segments[2];
            string parsedResourceGroupName = segments[4];

            AzureSqlDeletedServerModel model = new AzureSqlDeletedServerModel()
            {
                ServerName = parsedServerName,
                DeletionTime = deletedServer.DeletionTime,
                FullyQualifiedDomainName = deletedServer.FullyQualifiedDomainName,
                Version = deletedServer.Version,
                Id = deletedServer.Id,
                Type = deletedServer.Type,
                OriginalId = deletedServer.OriginalId,
                SubscriptionId = parsedSubscriptionId,
                ResourceGroupName = parsedResourceGroupName
            };

            return model;
        }

        /// <summary>
        /// Creates an improved ErrorResponseException with a more descriptive error message for NotFound scenarios.
        /// </summary>
        /// <param name="originalException">The original exception from the SDK</param>
        /// <param name="location">The location where the server was being searched</param>
        /// <param name="serverName">The name of the server being searched for</param>
        /// <returns>An ErrorResponseException with an improved error message</returns>
        private ErrorResponseException GetImprovedErrorResponseException(ErrorResponseException originalException, string location, string serverName)
        {
            string improvedMessage = originalException.Body?.Error?.Message;
            
            // If it's a NotFound error, provide a more helpful message
            if (originalException.Response?.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                improvedMessage = string.Format(
                    Properties.Resources.DeletedServerNotFoundInLocation,
                    serverName, location);
            }

            ErrorResponseException improvedException = new ErrorResponseException(improvedMessage, originalException.InnerException);
            improvedException.Body = originalException.Body;
            improvedException.Request = originalException.Request;
            improvedException.Response = originalException.Response;

            return improvedException;
        }
    }
}