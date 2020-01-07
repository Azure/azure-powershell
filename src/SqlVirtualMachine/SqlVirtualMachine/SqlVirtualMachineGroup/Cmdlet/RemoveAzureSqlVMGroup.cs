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
    /// This class implements the Remove-AzSqlVMGroup cmdlet.  It will delete the Azure Sql virtual machine group instance corresponding to 
    /// the parameter given as input and it will return an AzureSqlVMGroupModel object containing the information of the deleted group.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlVMGroup", DefaultParameterSetName = ParameterSet.ParameterList, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlVMGroupModel))]
    public class RemoveAzureSqlVMGroup : AzureSqlVMGroupCmdletBase
    {
        /// <summary>
        /// Sql virtual machine group resource to be removed
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.InputObject,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = HelpMessages.InputObjectSqlVMGroup)]
        [Alias("SqlVMGroup")]
        [ValidateNotNullOrEmpty]
        public AzureSqlVMGroupModel InputObject { get; set; }

        /// <summary>
        /// Resource id of the sql virtual machine group that will be removed
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ParameterSet.ResourceId,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = HelpMessages.SqlVMGroupResourceId)]
        [Alias("SqlVMGroupId")]
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
            if(ParameterSetName == ParameterSet.InputObject)
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName == ParameterSet.ResourceId)
            {
                Name = GetResourceNameFromId(ResourceId);
                ResourceGroupName = GetResourceGroupNameFromId(ResourceId);
            }
        }

        /// <summary>
        /// Get the entity to delete
        /// </summary>
        /// <returns>The sql virtual machine group that will be deleted</returns>
        protected override IEnumerable<AzureSqlVMGroupModel> GetEntity()
        {
            return new List<AzureSqlVMGroupModel>() {
                ModelAdapter.GetSqlVirtualMachineGroup(ResourceGroupName, Name)
            };
        }

        /// <summary>
        /// Apply user input. Nothing to apply
        /// </summary>
        /// <param name="model">The input model</param>
        /// <returns></returns>
        protected override IEnumerable<AzureSqlVMGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlVMGroupModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the sql virtual machine group
        /// </summary>
        /// <param name="entity">The sql virtual machine group being deleted</param>
        /// <returns>The sql virtual machine group that was deleted</returns>
        protected override IEnumerable<AzureSqlVMGroupModel> PersistChanges(IEnumerable<AzureSqlVMGroupModel> entity)
        {
            ModelAdapter.RemoveSqlVirtualMachine(ResourceGroupName, Name);
            return entity;
        }
    }
}
