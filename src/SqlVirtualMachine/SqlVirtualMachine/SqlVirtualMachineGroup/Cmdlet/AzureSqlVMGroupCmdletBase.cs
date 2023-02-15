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
    /// Generic cmdlet for operations that run over a sql virtual machine group. 
    /// </summary>
    public abstract class AzureSqlVMGroupCmdletBase : AzureSqlVirtualMachineCmdletBase<IEnumerable<AzureSqlVMGroupModel>, AzureSqlVMGroupAdapter>
    {
        /// <summary>
        /// Resource group name of the sql virtual machine group
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.Name,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of the sql virtual machine group
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.Name,
            Position = 1,
            HelpMessage = HelpMessages.NameSqlVMGroup)]
        [Alias("SqlVMGroupName")]
        public string Name { get; set; }

        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <returns>The Sql virtual machine group adapter</returns>
        protected override AzureSqlVMGroupAdapter InitModelAdapter()
        {
            return new AzureSqlVMGroupAdapter(DefaultContext);
        }

        /// <summary>
        /// Validate the resource id of a sql virtual machine group
        /// </summary>
        /// <param name="sqlVirtualMachineGroupId">Resource id to be validated</param>
        /// <returns>True if the resource id is valid, false otherwise</returns>
        public bool ValidateSqlVirtualMachineGroupId(string sqlVirtualMachineGroupId)
        {
            var regex = new Regex(@"/subscriptions/([^/]+)/resourcegroups/([^/]+)/providers/microsoft.sqlvirtualmachine/sqlvirtualmachinegroups/([^/]+)", RegexOptions.IgnoreCase);
            return regex.IsMatch(sqlVirtualMachineGroupId);
        }

        /// <summary>
        /// Get the resource group name of a sql virtual machine group from its resource id
        /// </summary>
        /// <param name="sqlVirtualMachineGroupId">Resource  id of the sql virtual machine</param>
        /// <returns>Resource group name contained in the resource id</returns>
        public string GetResourceGroupNameFromId(string sqlVirtualMachineGroupId)
        {
            return sqlVirtualMachineGroupId.Split('/')[4];
        }

        /// <summary>
        /// Get the name of a sql virtual machine from its resource id
        /// </summary>
        /// <param name="sqlVirtualMachineGroupId">Resource  id of the sql virtual machine</param>
        /// <returns>Resource name contained in the resource id</returns>
        public string GetResourceNameFromId(string sqlVirtualMachineGroupId)
        {
            return sqlVirtualMachineGroupId.Split('/')[8];
        }
    }
}
