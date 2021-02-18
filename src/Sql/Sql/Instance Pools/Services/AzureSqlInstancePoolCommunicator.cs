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

namespace Microsoft.Azure.Commands.Sql.Instance_Pools.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlInstancePoolCommunicator
    {
        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        internal static IAzureSubscription Subscription { get; private set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public static IAzureContext Context { get; set; }

        /// <summary>
        /// Creates an Azure SQL Instance Pool Communicator
        /// </summary>
        /// <param name="context">The azure context</param>
        public AzureSqlInstancePoolCommunicator(IAzureContext context)
        {
            Context = context;
            if (Context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
            }
        }

        /// <summary>
        /// Creates or updates an instance pool
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="instancePoolName">The instance pool name</param>
        /// <param name="parameters">The instance pool parameters</param>
        /// <returns>The created or updated instance pool</returns>
        public InstancePool UpsertInstancePool(string resourceGroupName, string instancePoolName, InstancePool parameters)
        {
            return GetCurrentSqlClient().InstancePools.CreateOrUpdate(resourceGroupName, instancePoolName, parameters);
        }

        /// <summary>
        /// Returns the fetched instance pool
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="instancePoolName">The instance pool name</param>
        /// <returns>Returns the instance pool</returns>
        public InstancePool GetInstancePool(string resourceGroupName, string instancePoolName)
        {
            return GetCurrentSqlClient().InstancePools.Get(resourceGroupName, instancePoolName);
        }

        /// <summary>
        /// Returns a list of instance pools by resource group
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <returns>A list of instance pools by resource group</returns>
        public IEnumerable<InstancePool> ListByResourceGroup(string resourceGroupName)
        {
            return GetCurrentSqlClient().InstancePools.ListByResourceGroup(resourceGroupName);
        }

        /// <summary>
        /// Returns a list of instance pools by subscription
        /// </summary>
        /// <returns>A list of instance pools across the customer's subscription</returns>
        public IEnumerable<InstancePool> List()
        {
            return GetCurrentSqlClient().InstancePools.List();
        }

        /// <summary>
        /// Deletes the instance pool
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="instancePoolName">The instance pool name</param>
        public void RemoveInstancePool(string resourceGroupName, string instancePoolName)
        {
            GetCurrentSqlClient().InstancePools.Delete(resourceGroupName, instancePoolName);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        public static SqlManagementClient GetCurrentSqlClient()
        {
            var sqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            return sqlClient;
        }
    }
}
