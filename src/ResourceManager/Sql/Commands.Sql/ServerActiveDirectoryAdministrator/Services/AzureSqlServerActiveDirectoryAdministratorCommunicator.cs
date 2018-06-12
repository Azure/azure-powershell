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

namespace Microsoft.Azure.Commands.Sql.ServerActiveDirectoryAdministrator.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlServerActiveDirectoryAdministratorCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// The Sql client default name for the active directory admin
        /// </summary>
        private static string ActiveDirectoryDefaultName { get { return "ActiveDirectory"; } }

        /// <summary>
        /// The Sql client default type for the active directory admin
        /// </summary>
        private static string ActiveDirectoryDefaultType { get { return "activeDirectory"; } }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure SQL Server Active Directory administrator
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="subscription"></param>
        public AzureSqlServerActiveDirectoryAdministratorCommunicator(IAzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure SQL Server Active Directory administrator
        /// </summary>
        public Management.Sql.LegacySdk.Models.ServerAdministrator Get(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().ServerAdministrators.Get(resourceGroupName, serverName, ActiveDirectoryDefaultName).Administrator;
        }

        /// <summary>
        /// Lists Azure SQL Server Active Directory administrators
        /// </summary>
        public IList<Management.Sql.LegacySdk.Models.ServerAdministrator> List(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().ServerAdministrators.List(resourceGroupName, serverName).Administrators;
        }

        /// <summary>
        /// Creates or updates a Azure SQL Server Active Directory Administrator
        /// </summary>
        public Management.Sql.LegacySdk.Models.ServerAdministrator CreateOrUpdate(string resourceGroupName, string serverName, ServerAdministratorCreateOrUpdateParameters parameters)
        {
            // Always set the type to active directory
            parameters.Properties.AdministratorType = ActiveDirectoryDefaultType;
            return GetCurrentSqlClient().ServerAdministrators.CreateOrUpdate(resourceGroupName, serverName, ActiveDirectoryDefaultName, parameters).ServerAdministrator;
        }

        /// <summary>
        /// Deletes a Azure SQL Server Active Directory Administrator
        /// </summary>
        public void Remove(string resourceGroupName, string serverName)
        {
            GetCurrentSqlClient().ServerAdministrators.Delete(resourceGroupName, serverName, ActiveDirectoryDefaultName);
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
