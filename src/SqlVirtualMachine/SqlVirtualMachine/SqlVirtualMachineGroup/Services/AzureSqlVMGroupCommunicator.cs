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

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.SqlVirtualMachine;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlVMGroupCommunicator
    {
        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        private IAzureContext Context;

        /// <summary>
        /// Creates a communicator for Azure Sql Virtual Machine
        /// </summary>
        /// <param name="context"></param>
        public AzureSqlVMGroupCommunicator(IAzureContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Gets a Sql Virtual Machine group
        /// </summary>
        internal SqlVirtualMachineGroup Get(string resourceGroupName, string groupName)
        {
            return GetCurrentSqlClient().SqlVirtualMachineGroups.Get(resourceGroupName, groupName);
        }

        /// <summary>
        /// Creates or updates a Sql Virtual Machine group
        /// </summary>
        public SqlVirtualMachineGroup CreateOrUpdate(string resourceGroupName, string groupName, SqlVirtualMachineGroup parameters)
        {
            return GetCurrentSqlClient().SqlVirtualMachineGroups.CreateOrUpdate(resourceGroupName, groupName, parameters);
        }

        /// <summary>
        /// Deletes a Sql Virtual Machine group
        /// </summary>
        public void Delete(string resourceGroupName, string groupName)
        {
            GetCurrentSqlClient().SqlVirtualMachineGroups.Delete(resourceGroupName, groupName);
        }

        /// <summary>
        /// Lists Sql Virtual Machine groups in the given resource group
        /// </summary>
        public IList<SqlVirtualMachineGroup> ListByResourceGroup(string resourceGroupName)
        {
            return GetCurrentSqlClient().SqlVirtualMachineGroups.ListByResourceGroup(resourceGroupName).ToList();
        }

        /// <summary>
        /// Lists all the Sql Virtual Machine groups in the subscription
        /// </summary>
        public IList<SqlVirtualMachineGroup> List()
        {
            return GetCurrentSqlClient().SqlVirtualMachineGroups.List().ToList();
        }

        /// <summary>
        /// Retrieve the SQL Virtual Machine Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Virtual Machine Management client for the currently selected subscription.</returns>
        private SqlVirtualMachineManagementClient GetCurrentSqlClient()
        {
            // Get the SQL VM management client for the current subscription
            var sqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlVirtualMachineManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            return sqlClient;
        }
    }
}
