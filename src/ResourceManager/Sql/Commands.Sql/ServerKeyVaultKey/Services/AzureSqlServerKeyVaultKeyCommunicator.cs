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
using Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Model;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using Microsoft.WindowsAzure.Management.Storage;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the Server Key REST endpoints
    /// </summary>
    public class AzureSqlServerKeyVaultKeyCommunicator
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
        /// Gets or sets the Azure context
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Server Key
        /// </summary>
        /// <param name="context">The context</param>
        public AzureSqlServerKeyVaultKeyCommunicator(IAzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Server Key
        /// </summary>
        /// <param name="resourceGroupName">Resource Group</param>
        /// <param name="serverName">Sql Server name</param>
        /// <param name="keyName">Server Key Vault Key name</param>
        /// <returns>ServerKey with name keyName</returns>
        public Microsoft.Azure.Management.Sql.LegacySdk.Models.ServerKey Get(string resourceGroupName, string serverName, string keyName)
        {
            return GetCurrentSqlClient().ServerKey.Get(resourceGroupName, serverName, keyName).ServerKey;
        }

        /// <summary>
        /// Lists the Azure Sql Server Keys on a server
        /// </summary>
        /// <param name="resourceGroupName">Resource Group</param>
        /// <param name="serverName">Sql Server name</param>
        /// <returns>List of ServerKeys on the server</returns>
        public IList<Microsoft.Azure.Management.Sql.LegacySdk.Models.ServerKey> List(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().ServerKey.List(resourceGroupName, serverName).ServerKeys;
        }

        /// <summary>
        /// Creates or updates an Azure Sql Server Key
        /// </summary>
        /// <param name="resourceGroupName">Resource Group</param>
        /// <param name="serverName">Sql Server name</param>
        /// <param name="keyName">Server Key Vault Key name</param>
        /// <param name="parameters">CreateOrUpdateParameters for ServerKey</param>
        /// <returns>Created ServerKey</returns>
        public Microsoft.Azure.Management.Sql.LegacySdk.Models.ServerKey CreateOrUpdate(string resourceGroupName, string serverName, string keyName, ServerKeyCreateOrUpdateParameters parameters)
        {
            return GetCurrentSqlClient().ServerKey.CreateOrUpdate(resourceGroupName, serverName, keyName, parameters).ServerKey;
        }

        /// <summary>
        /// Deletes an Azure Sql Server Key
        /// </summary>
        /// <param name="resourceGroupName">Resource Group</param>
        /// <param name="serverName">Sql Server name</param>
        /// <param name="keyName">Server Key Vault Key name</param>
        public void Delete(string resourceGroupName, string serverName, string keyName)
        {
            GetCurrentSqlClient().ServerKey.Delete(resourceGroupName, serverName, keyName);
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
