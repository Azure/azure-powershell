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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    /// <summary>
    /// This class implements the Get-AzSqlVM cmdlet. It will retrieve the information relative to one or more Sql Virtual Machine on Azure.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlVM", DefaultParameterSetName = ParameterSet.ResourceGroupOnly)]
    [OutputType(typeof(AzureSqlVMModel))]
    public class GetAzureSqlVM : AzureSqlVMCmdletBase
    {
        /// <summary>
        /// Resource group name of the sql virtual machine, overrided from the base class in order to not be mandatory
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.Name,
            Position = 0,
            HelpMessage = HelpMessages.ResourceGroupSqlVM)]
        [Parameter(Mandatory = false,
            ParameterSetName = ParameterSet.ResourceGroupOnly,
            Position = 0,
            HelpMessage = HelpMessages.ResourceGroupSqlVM)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of the sql virtual machine, overrided from the base class in order to not be mandatory
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.Name,
            Position = 1,
            HelpMessage = HelpMessages.NameSqlVM)]
        [Alias("SqlVMName")]
        [ResourceNameCompleter("Microsoft.SqlVirtualMachine/SqlVirtualMachines", "ResourceGroupName")]
        public string Name { get; set; }

        /// <summary>
        /// Resource id of the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.ResourceId,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = HelpMessages.SqlVMResourceId)]
        [Alias("SqlVMId")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Parse the parameters provided as input in order to obtain the name of the resource group and the sql virtual machine
        /// </summary>
        protected override void ParseInput()
        {
            if (ParameterSetName == ParameterSet.ResourceId)
            {
                if (!ValidateSqlVirtualMachineId(ResourceId))
                {
                    throw new PSArgumentException(
                        string.Format("The sql virtual machine resource id is not well formatted"),
                        "SqlVirtualMachine");
                }
                ResourceGroupName = GetResourceGroupNameFromId(ResourceId);
                Name = GetResourceNameFromId(ResourceId);
            }
        }

        /// <summary>
        /// Gets one or more sql virtual machines.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<AzureSqlVMModel> GetEntity()
        {
            ICollection<AzureSqlVMModel> results = null;
            if (ShouldGetByName(ResourceGroupName, Name))
            {
                results = new List<AzureSqlVMModel>();
                results.Add(ModelAdapter.GetSqlVirtualMachine(ResourceGroupName, Name));
            }
            else if (ShouldListByResourceGroup(ResourceGroupName, Name))
            {
                results = ModelAdapter.ListSqlVirtualMachineByResourceGroup(ResourceGroupName);
            }
            else
            {
                results = ModelAdapter.ListSqlVirtualMachine();
            }
            return results;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlVMModel> ApplyUserInputToModel(IEnumerable<AzureSqlVMModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlVMModel> PersistChanges(IEnumerable<AzureSqlVMModel> entity)
        {
            return entity;
        }
    }
}
