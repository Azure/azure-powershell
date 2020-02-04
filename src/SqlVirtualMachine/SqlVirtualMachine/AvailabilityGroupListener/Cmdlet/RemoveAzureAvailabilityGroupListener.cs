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
using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;


namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    /// <summary>
    /// This class implements the Remove-AzAvailabilityGroupListener cmdlet.  It will delete the Azure Sql virtual machine group instance corresponding to 
    /// the parameter given as input and it will return an AzureAvailabilityGroupListenerModel object containing the information of the deleted group.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AvailabilityGroupListener", DefaultParameterSetName = ParameterSet.Name, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureAvailabilityGroupListenerModel))]
    public class RemoveAzureAvailabilityGroupListener : AzureAvailabilityGroupListenerCmdletBase
    {
        /// <summary>
        /// AvailabilityGroupListener resource to be removed
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.InputObject,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = HelpMessages.InputObjectAvailabilityGroupListener)]
        [ValidateNotNullOrEmpty]
        public AzureAvailabilityGroupListenerModel InputObject { get; set; }

        /// <summary>
        /// Resource id of the Availability Group Listener that will be removed
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.ResourceId,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = HelpMessages.AvailabilityGroupListenerResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Parse the input of the cmdlet depending on the parameter set provided. Retrieve the resource group name and the resource name.
        /// </summary>
        protected override void ParseInput()
        {
            if (ParameterSetName == ParameterSet.InputObject)
            {
                Name = InputObject.Name;
                SqlVMGroupName = InputObject.GroupName;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName == ParameterSet.ResourceId)
            {
                Name = GetResourceNameFromId(ResourceId);
                SqlVMGroupName = GetSqlVmGroupNameFromId(ResourceId);
                ResourceGroupName = GetResourceGroupNameFromId(ResourceId);
            }
            else if (ParameterSetName == ParameterSet.SqlVMGroupObject)
            {
                SqlVMGroupName = SqlVMGroupObject.Name;
                ResourceGroupName = SqlVMGroupObject.ResourceGroupName;
            }
        }

        /// <summary>
        /// Get the entity to delete
        /// </summary>
        /// <returns>The Availability Group Listener that will be deleted</returns>
        protected override IEnumerable<AzureAvailabilityGroupListenerModel> GetEntity()
        {
            return new List<AzureAvailabilityGroupListenerModel>() {
                ModelAdapter.GetAvailabilityGroupListener(ResourceGroupName, SqlVMGroupName, Name)
            };
        }

        /// <summary>
        /// Apply user input. Nothing to apply
        /// </summary>
        /// <param name="model">The input model</param>
        /// <returns></returns>
        protected override IEnumerable<AzureAvailabilityGroupListenerModel> ApplyUserInputToModel(IEnumerable<AzureAvailabilityGroupListenerModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the Availability Group Listener
        /// </summary>
        /// <param name="entity">The Availability Group Listener being deleted</param>
        /// <returns>The Availability Group Listener that was deleted</returns>
        protected override IEnumerable<AzureAvailabilityGroupListenerModel> PersistChanges(IEnumerable<AzureAvailabilityGroupListenerModel> entity)
        {
            ModelAdapter.RemoveAvailabilityGroupListener(ResourceGroupName, SqlVMGroupName, Name);
            return entity;
        }
    }
}
