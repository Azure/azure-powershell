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
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.LegacySdk;

namespace Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the database ledger digest upload REST endpoints.
    /// </summary>
    public class AzureSqlDatabaseLedgerDigestUploadCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static Management.Sql.LegacySdk.SqlManagementClient LegacyClient { get; set; }

        /// <summary>
        /// The resources management client used by this communicator
        /// </summary>
        private static ResourceManagementClient ResourcesClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Database ledger digest upload REST endpoints.
        /// </summary>
        /// <param name="context">Azure context</param>
        public AzureSqlDatabaseLedgerDigestUploadCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                LegacyClient = null;
            }
        }

        /// <summary>
        /// Gets a databases ledger digest upload configuration
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <returns></returns>
        public Management.Sql.Models.LedgerDigestUploads GetLedgerDigestUpload(
            string resourceGroupName,
            string serverName, 
            string databaseName)
        {
            return GetCurrentSqlClient().LedgerDigestUploads.Get(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// Sets a databases ledger digest upload configuration
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <param name="parameters">Ledger digest upload parameters</param>
        /// <returns></returns>
        public void SetLedgerDigestUpload(
            string resourceGroupName,
            string serverName,
            string databaseName,
            Management.Sql.Models.LedgerDigestUploads parameters)
        {
            GetCurrentSqlClient().LedgerDigestUploads.CreateOrUpdate(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Disables ledger digest upload for a database
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <returns></returns>
        public void DisableLedgerDigestUpload(
            string resourceGroupName,
            string serverName, 
            string databaseName)
        {
            GetCurrentSqlClient().LedgerDigestUploads.Disable(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private Management.Sql.LegacySdk.SqlManagementClient GetLegacySqlClient()
        {
            // Get the SQL management client for the current subscription
            if (LegacyClient == null)
            {
                LegacyClient = AzureSession.Instance.ClientFactory.CreateClient<Management.Sql.LegacySdk.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return LegacyClient;
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private Management.Sql.SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            // Note: client is not cached in static field because that causes ObjectDisposedException in functional tests.
            return AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        /// Lazy creation of a single instance of a resoures client
        /// </summary>
        private ResourceManagementClient GetCurrentResourcesClient()
        {
            if (ResourcesClient == null)
            {
                ResourcesClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return ResourcesClient;
        }
    }
}
