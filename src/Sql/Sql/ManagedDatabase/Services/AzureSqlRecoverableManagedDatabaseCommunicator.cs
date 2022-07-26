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
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlRecoverableManagedDatabaseCommunicator
    {
        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Recoverable Azure Sql Managed Databases
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlRecoverableManagedDatabaseCommunicator(IAzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Managed Database geo-backup
        /// </summary>
        public Management.Sql.Models.RecoverableManagedDatabase Get(string resourceGroupName, string managedInstanceName, string databaseName)
        {
            return GetCurrentSqlClient().RecoverableManagedDatabases.Get(resourceGroupName, managedInstanceName, databaseName);
        }

        /// <summary>
        /// Lists Azure Sql Managed Databases geo-backups
        /// </summary>
        public IList<Management.Sql.Models.RecoverableManagedDatabase> List(string resourceGroupName, string managedInstanceName)
        {
            return new List<Management.Sql.Models.RecoverableManagedDatabase>(GetCurrentSqlClient().RecoverableManagedDatabases.ListByInstance(resourceGroupName,managedInstanceName));
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
            var sqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            return sqlClient;
        }
    }
}
