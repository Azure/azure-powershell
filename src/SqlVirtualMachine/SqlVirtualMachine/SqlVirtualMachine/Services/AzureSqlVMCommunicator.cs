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
    public class AzureSqlVMCommunicator
    {
        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        private IAzureContext Context;

        /// <summary>
        /// Creates a communicator for Azure Sql Virtual Machine
        /// </summary>
        /// <param name="context"></param>
        public AzureSqlVMCommunicator(IAzureContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Gets a Sql Virtual Machine
        /// </summary>
        internal SqlVirtualMachineModel Get(string resourceGroupName, string sqlVirtualMachineName)
        {
            return GetCurrentSqlClient().SqlVirtualMachines.Get(resourceGroupName, sqlVirtualMachineName);
        }

        /// <summary>
        /// Creates or updates a Sql Virtual Machine
        /// </summary>
        public SqlVirtualMachineModel CreateOrUpdate(string resourceGroupName, string sqlVirtualMachineName, SqlVirtualMachineModel parameters)
        {
            return GetCurrentSqlClient().SqlVirtualMachines.CreateOrUpdate(resourceGroupName, sqlVirtualMachineName, parameters);
        }

        /// <summary>
        /// Deletes a Sql Virtual Machine
        /// </summary>
        public void Delete(string resourceGroupName, string sqlVirtualMachineName)
        {
            GetCurrentSqlClient().SqlVirtualMachines.Delete(resourceGroupName, sqlVirtualMachineName);
        }

        /// <summary>
        /// Lists Sql Virtual Machines in the given resource group
        /// </summary>
        public IList<SqlVirtualMachineModel> ListByResourceGroup(string resourceGroupName)
        {
            return GetCurrentSqlClient().SqlVirtualMachines.ListByResourceGroup(resourceGroupName).ToList();
        }

        /// <summary>
        /// Lists all the Sql Virtual Machines in the subscription
        /// </summary>
        public IList<SqlVirtualMachineModel> List()
        {
            return GetCurrentSqlClient().SqlVirtualMachines.List().ToList();
        }

        /// <summary>
        /// Retrieve the SQL Virtual Machine Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Virtual Machine Management client for the currently selected subscription.</returns>
        private SqlVirtualMachineManagementClient GetCurrentSqlClient()
        {
            var sqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlVirtualMachineManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            return sqlClient;
        }


    }
}
