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
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    /// <summary>
    /// This class implements the Get-AzSqlVMGroup cmdlet. It will retrieve the information relative to one or more Availability Group Listener on Azure.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AvailabilityGroupListener", DefaultParameterSetName = ParameterSet.ResourceGroupOnly)]
    [OutputType(typeof(AzureSqlVMGroupModel))]
    public class GetAzureAvailabilityGroupListener : AzureAvailabilityGroupListenerCmdletBase
    {
        /// <summary>
        /// Resource group name of the sql virtual machine group, overrided from the base class in order to not be mandatory
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.Name,
            Position = 0,
            HelpMessage = HelpMessages.ResourceGroupSqlVMGroup)]
        [Parameter(Mandatory = false,
            ParameterSetName = ParameterSet.ResourceGroupOnly,
            Position = 0,
            HelpMessage = HelpMessages.ResourceGroupSqlVM)]
        [ResourceGroupCompleter]
        public new virtual string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of the sql virtual machine group
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.Name,
            Position = 1,
            HelpMessage = HelpMessages.NameSqlVMGroup)]
        [Alias("GroupName")]
        public new string GroupName { get; set; }

        /// <summary>
        /// Name of the Availability Group Listener
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.Name,
            Position = 1,
            HelpMessage = HelpMessages.NameAvailabilityGroupListener)]
        [Alias("AvailabilityGroupListener")]
        public new string Name { get; set; }

        /// <summary>
        /// Resource id of the Availability Group Listener
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.ResourceId,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = HelpMessages.AvailabilityGroupListenerResourceId)]
        [Alias("AvailabilityGroupListenerId")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Parse the parameters provided as input in order to obtain the name of the resource group and the Availability Group Listener
        /// </summary>
        protected override void ParseInput()
        {
            if (ParameterSetName == ParameterSet.ResourceId)
            {
                if (!ValidateAvailabilityGroupListenerId(ResourceId))
                    throw new PSArgumentException(
                string.Format("The Availability Group Listener resource id is not well formatted"),
                "AvailabilityGroupListener");
                ResourceGroupName = GetResourceGroupNameFromId(ResourceId);
                GroupName = GetResourceGroupNameFromId(ResourceId);
                Name = GetResourceNameFromId(ResourceId);
            }
        }

        /// <summary>
        /// Gets one or more Availability Group Listener.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<AzureAvailabilityGroupListenerModel> GetEntity()
        {
            ICollection<AzureAvailabilityGroupListenerModel> results = null;
            if(ShouldGetByName(ResourceGroupName, GroupName, Name))
            {
                results = new List<AzureAvailabilityGroupListenerModel>();
                results.Add(ModelAdapter.GetAvailabilityGroupListener(ResourceGroupName, GroupName, Name));
            }
            else
            {
                results = ModelAdapter.ListAvailabilityGroupListenerByGroup(ResourceGroupName, GroupName);
            }
            return results;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureAvailabilityGroupListenerModel> ApplyUserInputToModel(IEnumerable<AzureAvailabilityGroupListenerModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureAvailabilityGroupListenerModel> PersistChanges(IEnumerable<AzureAvailabilityGroupListenerModel> entity)
        {
            return entity;
        }
    }
}
