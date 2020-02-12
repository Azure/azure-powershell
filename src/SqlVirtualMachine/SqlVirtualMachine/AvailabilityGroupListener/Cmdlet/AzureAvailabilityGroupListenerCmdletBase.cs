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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    /// <summary>
    /// Generic cmdlet for operations that run over Availability Group Listener.
    /// </summary>
    public abstract class AzureAvailabilityGroupListenerCmdletBase : AzureSqlVirtualMachineCmdletBase<IEnumerable<AzureAvailabilityGroupListenerModel>, AzureAvailabilityGroupListenerAdapter>
    {
        /// <summary>
        /// Resource group name of the AG listener
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.Name,
            Position = 0,
            HelpMessage = HelpMessages.ResourceGroupAvailabilityGroupListener)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of the sql virtual machine group
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.Name,
            Position = 1,
            HelpMessage = HelpMessages.NameSqlVMGroup)]
        [Alias("GroupName")]
        [ResourceNameCompleter("Microsoft.SqlVirtualMachine/SqlVirtualMachineGroups", nameof(ResourceGroupName))]
        public string SqlVMGroupName { get; set; }

        /// <summary>
        /// SqlVmGroup Object of the AG Listener
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParameterSet.SqlVMGroupObject,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = HelpMessages.SqlVMGroupObjectHelpMessage)]
        public AzureSqlVMGroupModel SqlVMGroupObject { get; set; }

        /// <summary>
        /// Name of the Availability Group Listener
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.Name,
            Position = 2,
            HelpMessage = HelpMessages.NameAvailabilityGroupListener)]
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.SqlVMGroupObject,
            Position = 1,
            HelpMessage = HelpMessages.NameAvailabilityGroupListener)]
        [ResourceNameCompleter("Microsoft.SqlVirtualMachine/SqlVirtualMachineGroups/AvailabilityGroupListeners", nameof(ResourceGroupName), nameof(SqlVMGroupName))]
        public string Name { get; set; }

        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <returns>The Availability Group Listener adapter</returns>
        protected override AzureAvailabilityGroupListenerAdapter InitModelAdapter()
        {
            return new AzureAvailabilityGroupListenerAdapter(DefaultContext);
        }

        /// <summary>
        /// Validate the resource id of a Availability Group Listener
        /// </summary>
        /// <param name="availabilityGroupListenerResourceId">Resource id to be validated</param>
        /// <returns>True if the resource id is valid, false otherwise</returns>
        public bool ValidateAvailabilityGroupListenerId(string availabilityGroupListenerResourceId)
        {
            var regex = new Regex(@"/subscriptions/([^/]+)/resourcegroups/([^/]+)/providers/microsoft.sqlvirtualmachine/sqlvirtualmachinegroups/([^/]+)/availabilityGroupListeners/([^/]+)", RegexOptions.IgnoreCase);
            return regex.IsMatch(availabilityGroupListenerResourceId);
        }

        /// <summary>
        /// Get the resource group name of an Availability Group Listener from its resource id
        /// </summary>
        /// <param name="availabilityGroupListenerId">Resource  id of the Availability Group Listener</param>
        /// <returns>Resource group name contained in the resource id</returns>
        public string GetResourceGroupNameFromId(string availabilityGroupListenerId)
        {
            return availabilityGroupListenerId.Split('/')[4];
        }

        /// <summary>
        /// Get the name of an AvailabilityGroupListener from its resource id
        /// </summary>
        /// <param name="availabilityGroupListenerId">Resource  id of the availabilityGroupListener</param>
        /// <returns>Resource name contained in the resource id</returns>
        public string GetSqlVmGroupNameFromId(string availabilityGroupListenerId)
        {
            return availabilityGroupListenerId.Split('/')[8];
        }

        /// <summary>
        /// Get the name of an AvailabilityGroupListener from its resource id
        /// </summary>
        /// <param name="availabilityGroupListenerId">Resource  id of the availabilityGroupListener</param>
        /// <returns>Resource name contained in the resource id</returns>
        public string GetResourceNameFromId(string availabilityGroupListenerId)
        {
            return availabilityGroupListenerId.Split('/')[10];
        }
    }
}
