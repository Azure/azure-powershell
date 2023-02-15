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
using Microsoft.Azure.Management.Sql;
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
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Database Transparent Data Encryption
        /// </summary>
        public Management.Sql.Models.LogicalDatabaseTransparentDataEncryption Get(string resourceGroupName, string serverName, string databaseName)
        {
            return GetCurrentSqlClient().TransparentDataEncryptions.Get(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// Creates or updates an Azure Sql Database Transparent Data Encryption
        /// </summary>
        public Management.Sql.Models.LogicalDatabaseTransparentDataEncryption CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, Management.Sql.Models.LogicalDatabaseTransparentDataEncryption parameters)
        {
            return GetCurrentSqlClient().TransparentDataEncryptions.CreateOrUpdate(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Gets Azure Sql Database Transparent Data Encryption Protector
        /// </summary>
        public Management.Sql.Models.EncryptionProtector GetEncryptionProtector(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().EncryptionProtectors.Get(resourceGroupName, serverName);
        }

        /// <summary>
        /// Creates or updates an Azure Sql Database Transparent Data Encryption Protector
        /// </summary>
        public Management.Sql.Models.EncryptionProtector CreateOrUpdateEncryptionProtector(string resourceGroupName, string serverName, Management.Sql.Models.EncryptionProtector parameters)
        {
            return GetCurrentSqlClient().EncryptionProtectors.CreateOrUpdate(resourceGroupName, serverName, parameters);        
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
                SqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return SqlClient;
        }
    }
}
