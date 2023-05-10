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
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.InstanceActiveDirectoryOnlyAuthentication.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlInstanceActiveDirectoryOnlyAuthenticationCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// The Sql client default name for the active directory only authentication
        /// </summary>
        private static string ActiveDirectoryOnlyAuthenticationDefaultName { get { return "Default"; } }

        /// <summary>
        /// The Sql client default type for the active directory only authentication
        /// </summary>
        private static string ActiveDirectoryOnlyAuthenticationDefaultType { get { return "default"; } }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure SQL Managed Instance Active Directory administrator
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlInstanceActiveDirectoryOnlyAuthenticationCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure SQL Managed Instance Active Directory only authentication
        /// </summary>
        public Management.Sql.Models.ManagedInstanceAzureADOnlyAuthentication Get(string resourceGroupName, string InstanceName)
        {
            return GetCurrentSqlClient().ManagedInstanceAzureADOnlyAuthentications.GetAsync(resourceGroupName, InstanceName).Result;
        }

        /// <summary>
        /// Disables Azure Active Directory only authentication on a Azure SQL Managed Instance
        /// </summary>
        public Management.Sql.Models.ManagedInstanceAzureADOnlyAuthentication CreateOrUpdate(string resourceGroupName, string InstanceName, ManagedInstanceAzureADOnlyAuthentication parameters)
        {
            return GetCurrentSqlClient().ManagedInstanceAzureADOnlyAuthentications.CreateOrUpdate(resourceGroupName, InstanceName, parameters);
        }

        /// <summary>
        /// Lists Azure SQL Managed Instance Active Directory only authenctications
        /// </summary>
        public IEnumerable<Management.Sql.Models.ManagedInstanceAzureADOnlyAuthentication> List(string resourceGroupName, string InstanceName)
        {
            return GetCurrentSqlClient().ManagedInstanceAzureADOnlyAuthentications.ListByInstance(resourceGroupName, InstanceName);
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
                SqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return SqlClient;
        }
    }
}
