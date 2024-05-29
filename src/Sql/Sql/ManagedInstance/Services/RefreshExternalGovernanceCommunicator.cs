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
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.Models;
using System.Threading.Tasks;
using SqlManagementClient = Microsoft.Azure.Management.Sql.SqlManagementClient;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Services
{
    class RefreshExternalGovernanceCommunicator
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
        /// Creates a communicator for external governance.
        /// </summary>
        /// <param name="context">Azure context</param>
        public RefreshExternalGovernanceCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
            }
        }

        /// <summary>
        /// Refresh external governance status on MI
        /// </summary>
        /// <param name="resourceGroupName">Resource group</param>
        /// <param name="managedInstanceName">Managed Instance name</param>
        /// <returns></returns>
        public RefreshExternalGovernanceStatusOperationResultMI Refresh(string resourceGroupName, string managedInstanceName)
        {
            return GetCurrentSqlClient().ManagedInstances.RefreshStatus(resourceGroupName, managedInstanceName);
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
