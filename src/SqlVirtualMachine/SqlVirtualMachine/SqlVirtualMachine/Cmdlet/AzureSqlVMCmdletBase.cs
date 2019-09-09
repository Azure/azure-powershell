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

using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Adapter;
using System.Collections.Generic;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    /// <summary>
    /// Generic cmdlet for operations that run over a sql virtual machine. 
    /// </summary>
    public abstract class AzureSqlVMCmdletBase : AzureSqlVirtualMachineCmdletBase<IEnumerable<AzureSqlVMModel>, AzureSqlVMAdapter>
    {
        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <returns>The Sql virtual machine adapter</returns>
        protected override AzureSqlVMAdapter InitModelAdapter()
        {
            return new AzureSqlVMAdapter(DefaultContext);
        }

        /// <summary>
        /// Validate the resource id of a sql virtual machine
        /// </summary>
        /// <param name="sqlVirtualMachineResourceId">Resource id to be validated</param>
        /// <returns>True if the resource id is valid, false otherwise</returns>
        public bool ValidateSqlVirtualMachineId(string sqlVirtualMachineResourceId)
        {
            var regex = new Regex(@"/subscriptions/([^/]+)/resourceGroups/([^/]+)/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/([^/]+)");
            return regex.IsMatch(sqlVirtualMachineResourceId);
        }

        /// <summary>
        /// Retrieve an existent virtual machine
        /// </summary>
        /// <param name="resourceGroup">Name of the resource group in which the virtual machine should be</param>
        /// <param name="virtualMachineName">Name of the virtual machine</param>
        /// <returns></returns>
        public VirtualMachine RetrieveVirtualMachine(string resourceGroup, string virtualMachineName)
        {
            var client = AzureSession.Instance.ClientFactory.CreateArmClient<ComputeManagementClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
            try
            {
                return client.VirtualMachines.Get(resourceGroup, virtualMachineName);
            }
            catch(CloudException)
            {
                throw new PSArgumentException(
               string.Format("The parameters provided do not correspond to a virtual machine."),
               "SqlVirtualMachine");
            }
            throw new PSArgumentException(
               string.Format("Unexpected error while trying to retrieve the virtual machine"),
               "SqlVirtualMachine");
        }

        /// <summary>
        /// Get the resource group name of a sql virtual machine from its resource id
        /// </summary>
        /// <param name="sqlVirtualMachineId">Resource  id of the sql virtual machine</param>
        /// <returns>Resource group name contained in the resource id</returns>
        public string GetResourceGroupNameFromId(string sqlVirtualMachineId)
        {
            return sqlVirtualMachineId.Split('/')[4];
        }

        /// <summary>
        /// Get the name of a sql virtual machine from its resource id
        /// </summary>
        /// <param name="sqlVirtualMachineId">Resource  id of the sql virtual machine</param>
        /// <returns>Resource name contained in the resource id</returns>
        public string GetResourceNameFromId(string sqlVirtualMachineId)
        {
            return sqlVirtualMachineId.Split('/')[8];
        }
    }
}
