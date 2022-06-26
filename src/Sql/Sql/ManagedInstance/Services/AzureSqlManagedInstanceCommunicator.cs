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
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlManagedInstanceCommunicator
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
        /// Creates a communicator for Managed instance
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlManagedInstanceCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Managed instance
        /// </summary>
        public Management.Sql.Models.ManagedInstance Get(string resourceGroupName, string managedInstanceName, string expand = null)
        {
            return GetCurrentSqlClient().ManagedInstances.Get(resourceGroupName, managedInstanceName, expand);
        }

        /// <summary>
        /// Lists Managed instances in a resource group
        /// </summary>
        public IList<Management.Sql.Models.ManagedInstance> ListByResourceGroup(string resourceGroupName, string expand = null)
        {
            return GetCurrentSqlClient().ManagedInstances.ListByResourceGroup(resourceGroupName, expand).ToList();
        }

        /// <summary>
        /// Lists managed instances in an instance pool
        /// </summary>
        public IList<Management.Sql.Models.ManagedInstance> ListByInstancePool(string resourceGroupName, string instancePoolName, string expand = null)
        {
            return GetCurrentSqlClient().ManagedInstances.ListByInstancePool(resourceGroupName, instancePoolName, expand).ToList();
        }

        /// <summary>
        /// Lists Managed instances
        /// </summary>
        public IList<Management.Sql.Models.ManagedInstance> List(string expand = null)
        {
            return GetCurrentSqlClient().ManagedInstances.List(expand).ToList();
        }

        /// <summary>
        /// Creates or updates a Managed instance
        /// </summary>
        public Management.Sql.Models.ManagedInstance CreateOrUpdate(string resourceGroupName, string managedInstanceName, Management.Sql.Models.ManagedInstance parameters)
        {
            return GetCurrentSqlClient().ManagedInstances.CreateOrUpdate(resourceGroupName, managedInstanceName, parameters);
        }

        /// <summary>
        /// Creates or updates a Managed instance
        /// </summary>
        public Management.Sql.Models.ManagedInstance Update(string resourceGroupName, string managedInstanceName, Management.Sql.Models.ManagedInstanceUpdate parameters)
        {
            return GetCurrentSqlClient().ManagedInstances.Update(resourceGroupName, managedInstanceName, parameters);
        }

        /// <summary>
        /// Deletes a Managed instance
        /// </summary>
        public void Remove(string resourceGroupName, string managedInstanceName)
        {
            GetCurrentSqlClient().ManagedInstances.Delete(resourceGroupName, managedInstanceName);
        }

        /// <summary>
        /// Failovers a Managed instance
        /// </summary>
        public void Failover(string resourceGroupName, string name, string replicaType)
        {
            GetCurrentSqlClient().ManagedInstances.Failover(resourceGroupName, name, replicaType);
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
