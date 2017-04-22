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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using Microsoft.WindowsAzure.Management.Storage;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlDatabaseTransparentDataEncryptionCommunicator
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
        /// Creates a communicator for Azure Sql Databases TransparentDataEncryption
        /// </summary>
        /// <param name="context">Azure context</param>
        public AzureSqlDatabaseTransparentDataEncryptionCommunicator(IAzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Database Transparent Data Encryption
        /// </summary>
        public Management.Sql.LegacySdk.Models.TransparentDataEncryption Get(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).TransparentDataEncryption.Get(resourceGroupName, serverName, databaseName).TransparentDataEncryption;
        }

        /// <summary>
        /// Creates or updates an Azure Sql Database Transparent Data Encryption
        /// </summary>
        public Management.Sql.LegacySdk.Models.TransparentDataEncryption CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, string clientRequestId, TransparentDataEncryptionCreateOrUpdateParameters parameters)
        {
            return GetCurrentSqlClient(clientRequestId).TransparentDataEncryption.CreateOrUpdate(resourceGroupName, serverName, databaseName, parameters).TransparentDataEncryption;
        }

        /// <summary>
        /// Gets Azure Sql Database Transparent Data Encryption Activity
        /// </summary>
        public IList<Management.Sql.LegacySdk.Models.TransparentDataEncryptionActivity> ListActivity(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).TransparentDataEncryption.ListActivity(resourceGroupName, serverName, databaseName).TransparentDataEncryptionActivities;
        }

        /// <summary>
        /// Gets Azure Sql Database Transparent Data Encryption Protector
        /// </summary>
        public Management.Sql.LegacySdk.Models.EncryptionProtector GetEncryptionProtector(string resourceGroupName, string serverName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).TransparentDataEncryption.GetEncryptionProtector(resourceGroupName, serverName).EncryptionProtector;
        }

        /// <summary>
        /// Creates or updates an Azure Sql Database Transparent Data Encryption Protector
        /// </summary>
        public Management.Sql.LegacySdk.Models.EncryptionProtector CreateOrUpdateEncryptionProtector(string resourceGroupName, string serverName, string clientRequestId, EncryptionProtectorCreateOrUpdateParameters parameters)
        {
            return GetCurrentSqlClient(clientRequestId).TransparentDataEncryption.CreateOrUpdateEncryptionProtector(resourceGroupName, serverName, parameters).EncryptionProtector;
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient(String clientRequestId)
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            SqlClient.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            SqlClient.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);
            return SqlClient;
        }
    }
}
