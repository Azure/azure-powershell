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
    /// This class implements the Get-AzAvailabilityGroupListener cmdlet. It will retrieve the information relative to one or more Availability Group Listener on Azure.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AvailabilityGroupListener", DefaultParameterSetName = ParameterSet.Name, ConfirmImpact = ConfirmImpact.None)]
    [OutputType(typeof(AzureAvailabilityGroupListenerModel))]
    public class GetAzureAvailabilityGroupListener : AzureAvailabilityGroupListenerCmdletBase
    {
        /// <summary>
        /// Name of the Availability Group Listener
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ParameterSet.Name,
            Position = 2,
            HelpMessage = HelpMessages.NameAvailabilityGroupListener)]
        [Parameter(Mandatory = false,
            ParameterSetName = ParameterSet.SqlVMGroupObject,
            Position = 1,
            HelpMessage = HelpMessages.NameAvailabilityGroupListener)]
        [ResourceNameCompleter("Microsoft.SqlVirtualMachine/SqlVirtualMachineGroups/AvailabilityGroupListeners", nameof(ResourceGroupName), nameof(SqlVMGroupName))]
        public new string Name { get; set; }

        /// <summary>
        /// Resource id of the Availability Group Listener
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.ResourceId,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = HelpMessages.AvailabilityGroupListenerResourceId)]
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
                SqlVMGroupName = GetSqlVmGroupNameFromId(ResourceId);
                Name = GetResourceNameFromId(ResourceId);
            }
            else if (ParameterSetName == ParameterSet.SqlVMGroupObject)
            {
                ResourceGroupName = SqlVMGroupObject.ResourceGroupName;
                SqlVMGroupName = SqlVMGroupObject.Name;
            }
        }

        /// <summary>
        /// Gets one or more Availability Group Listener.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<AzureAvailabilityGroupListenerModel> GetEntity()
        {
            ICollection<AzureAvailabilityGroupListenerModel> results = null;
            if (!string.IsNullOrEmpty(Name))
            {
                results = new List<AzureAvailabilityGroupListenerModel>();
                results.Add(ModelAdapter.GetAvailabilityGroupListener(ResourceGroupName, SqlVMGroupName, Name));
            }
            else
            {
                results = ModelAdapter.ListAvailabilityGroupListenerByGroup(ResourceGroupName, SqlVMGroupName);
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
