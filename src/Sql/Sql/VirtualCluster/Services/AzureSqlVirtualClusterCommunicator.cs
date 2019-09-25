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
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.VirtualCluster.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlVirtualClusterCommunicator
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
        /// Creates a communicator for Virtual Cluster
        /// </summary>
        /// <param name="context"></param>
        public AzureSqlVirtualClusterCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the VirtualCluster
        /// </summary>
        public Management.Sql.Models.VirtualCluster Get(string resourceGroupName, string virtualClusterName)
        {
            return GetCurrentSqlClient().VirtualClusters.Get(resourceGroupName, virtualClusterName);
        }

        /// <summary>
        /// Lists Virtual clusters in a resource group
        /// </summary>
        public IList<Management.Sql.Models.VirtualCluster> ListByResourceGroup(string resourceGroupName)
        {
            return GetCurrentSqlClient().VirtualClusters.ListByResourceGroup(resourceGroupName).ToList();
        }

        /// <summary>
        /// Lists Managed instances
        /// </summary>
        public IList<Management.Sql.Models.VirtualCluster> List()
        {
            return GetCurrentSqlClient().VirtualClusters.List().ToList();
        }

        /// <summary>
        /// Deletes a Virtual Cluster
        /// </summary>
        public void Remove(string resourceGroupName, string virtualClusterName)
        {
            GetCurrentSqlClient().VirtualClusters.Delete(resourceGroupName, virtualClusterName);
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
